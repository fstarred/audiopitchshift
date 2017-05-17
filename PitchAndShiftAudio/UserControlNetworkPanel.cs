using System;
using System.Windows.Forms;
using PitchAndShiftAudio.Properties;
using System.Net;

namespace PitchAndShiftAudio
{
    public partial class UserControlNetworkPanel : UserControl, IUserControlPrefPanel
    {
        public UserControlNetworkPanel()
        {
            InitializeComponent();
        }

        public void Save()
        {
            Settings.Default.ProxyEnabled = this.checkBoxProxy.Checked;
            Settings.Default.CredentialsEnabled = this.checkBoxCredentials.Checked;
            Settings.Default.ProxyHost = this.textBoxHost.Text;
            Settings.Default.ProxyPort = Convert.ToInt16(this.textBoxPort.Text);
            Settings.Default.ProxyUser = this.textBoxUser.Text;
            Settings.Default.ProxyPassword = this.textBoxPassword.Text;
            Settings.Default.ProxyDomain = this.textBoxDomain.Text;

            Settings.Default.Save();
        }

        private void buttonUpdates_Click(object sender, EventArgs e)
        {
            WebProxy webProxy = null;

            if (this.IsValid())
            {
                if (this.checkBoxProxy.Checked)
                {
                    webProxy = new WebProxy(this.textBoxHost.Text, Convert.ToInt16(this.textBoxPort.Text));

                    if (this.checkBoxCredentials.Checked)
                        webProxy.Credentials = new NetworkCredential(this.textBoxUser.Text, this.textBoxPassword.Text, this.textBoxDomain.Text);
                }

                SharedServices.CheckForUpdates(true, webProxy);
            }
            else
                MessageBox.Show("No valid settings specified", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }

        public void LoadSettings()
        {
            this.checkBoxProxy.Checked = Settings.Default.ProxyEnabled;
            this.checkBoxCredentials.Checked = Settings.Default.CredentialsEnabled;
            this.textBoxHost.Text = Settings.Default.ProxyHost;
            this.textBoxPort.Text = Convert.ToString(Settings.Default.ProxyPort);
            this.textBoxUser.Text = Settings.Default.ProxyUser;
            this.textBoxPassword.Text = Settings.Default.ProxyPassword;
            this.textBoxDomain.Text = Settings.Default.ProxyDomain;

            this.groupBoxProxy.Enabled = this.checkBoxProxy.Checked;
            this.groupBoxCredentials.Enabled = this.checkBoxCredentials.Checked; 
        }

        private void UserControlNetworkPanel_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                
            }
        }

        private void checkBoxProxy_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBoxProxy.Enabled = ((CheckBox)sender).Checked;           
        }

        public bool IsValid()
        {
            if (this.checkBoxProxy.Checked)
            {
                int num = 0;

                if (string.IsNullOrEmpty(this.textBoxHost.Text))
                    return false;
                if (string.IsNullOrEmpty(this.textBoxPort.Text))
                    return false;
                else if (int.TryParse(this.textBoxPort.Text, out num) == false)
                    return false;

                if (this.checkBoxCredentials.Checked)
                {
                    if (string.IsNullOrEmpty(this.textBoxUser.Text))
                        return false;
                }
            }

            return true;
        }

        private void checkBoxCredentials_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBoxCredentials.Enabled = ((CheckBox)sender).Checked;       
        }
    }
}
