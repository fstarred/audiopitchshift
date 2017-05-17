using System;
using System.Net;
using PitchAndShiftAudio.Properties;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace PitchAndShiftAudio
{
    class SharedServices
    {

        public static WebProxy GetWebProxyFromResources()
        {
            WebProxy webProxy = null;

            bool isProxyEnabled = Settings.Default.ProxyEnabled;
            bool isCredentialsEnabled = Settings.Default.CredentialsEnabled;

            if (isProxyEnabled)
            {
                try
                {
                    string host = Settings.Default.ProxyHost;
                    int port = Settings.Default.ProxyPort;
                    webProxy = new WebProxy(host, port);

                    if (isCredentialsEnabled)
                    {
                        string user = Settings.Default.ProxyUser;
                        string pwd = Settings.Default.ProxyPassword;
                        string domain = Settings.Default.ProxyDomain;

                        webProxy.Credentials = new NetworkCredential(user, pwd, domain);
                    }
                }
                catch (Exception)
                {                    
                    
                }
                
            }

            return webProxy;
        }


        public static Version GetProductVersion()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);

            return new Version(fileVersionInfo.ProductVersion);
        }

        public static void CheckForUpdates(bool showMessageAnyway)
        {
            WebProxy webProxy = SharedServices.GetWebProxyFromResources();

            CheckForUpdates(showMessageAnyway, webProxy);
        }

        public static void CheckForUpdates(bool showMessageAnyway, WebProxy webProxy)
        {

            Task.Factory.StartNew(() => ServiceUpdater.CheckForUpdates(Globals.URI_UPDATER, webProxy)).ContinueWith(task =>
            {
                if (task.Result != null)
                {
                    ServiceUpdater.VersionInfo lastVersionInfo = task.Result;

                    Version productVersion = SharedServices.GetProductVersion();

                    if (lastVersionInfo.LatestVersion > productVersion)
                    {
                        DialogResult result = MessageBox.Show(String.Format("A new version ({0}) is available, do you want to go to the homepage?", lastVersionInfo.LatestVersion), "NEW VERSION", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                        if (result == DialogResult.Yes)
                        {
                            Process.Start(lastVersionInfo.LatestVersionUrl);
                        }
                    }
                    else if (showMessageAnyway)
                    {
                        MessageBox.Show(String.Format("This version is up to date", lastVersionInfo.LatestVersion), "No updates available", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (showMessageAnyway)
                        MessageBox.Show("Network error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });       
        }

    }
}
