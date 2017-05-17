using System;
using System.Xml;
using System.Net;
using System.IO;

namespace PitchAndShiftAudio
{
    class ServiceUpdater
    {
        //public WebProxy WebProxy { get; set; }
        //public string Url { get; set; }

        public const int REQUEST_TIMEOUT_MS = 4000;

        public class VersionInfo
        {
            public Version LatestVersion { get; set; }
            public string LatestVersionUrl { get; set; }        
        }

        private ServiceUpdater()
        {

        }

        public static VersionInfo CheckForUpdates(string url, WebProxy proxy)
        {
            VersionInfo version = null;

            XmlDocument xmldoc = new XmlDocument();
            string contents = GetWebPage(url, proxy);
            if (string.IsNullOrEmpty(contents) == false)
            {
                xmldoc.LoadXml(contents);

                version = new VersionInfo();

                string latestversion = xmldoc.SelectSingleNode("//latestversion").InnerText;
                version.LatestVersionUrl = xmldoc.SelectSingleNode("//latestversionurl").InnerText;

                version.LatestVersion = new Version(latestversion);
            }

            return version;

            //lblUpdateVersion.Text = "Latest Version:  " + (VersionInfo.SelectSingleNode("//latestversion").InnerText);
        }

        private static string GetWebPage(string URL, WebProxy proxy)
        {
            System.Net.HttpWebRequest Request = (HttpWebRequest)(WebRequest.Create(new Uri(URL)));
            Request.Method = "GET";
            Request.MaximumAutomaticRedirections = 4;
            Request.MaximumResponseHeadersLength = 4;
            Request.Timeout = REQUEST_TIMEOUT_MS;
            Request.ContentLength = 0;

            StreamReader ReadStream = null;
            HttpWebResponse Response = null;
            string ResponseText = string.Empty;

            Request.Proxy = proxy;

            //Request.Proxy = new WebProxy("proxy.inps", 8080);
            //Request.Proxy.Credentials = new NetworkCredential("fstellato", "f.123456", "risorse");

            try
            {
                Response = (HttpWebResponse)(Request.GetResponse());
                Stream ReceiveStream = Response.GetResponseStream();
                ReadStream = new StreamReader(ReceiveStream, System.Text.Encoding.UTF8);
                ResponseText = ReadStream.ReadToEnd();
                Response.Close();
                ReadStream.Close();

            }
            catch (Exception)
            {
                ResponseText = string.Empty;
            }

            return ResponseText;
        }
    }
}
