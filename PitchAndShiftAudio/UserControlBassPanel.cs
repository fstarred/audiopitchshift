using System;
using System.Windows.Forms;
using PitchAndShiftAudio.Properties;
using System.Diagnostics;

namespace PitchAndShiftAudio
{
    public partial class UserControlBassPanel : UserControl, IUserControlPrefPanel 
    {
        public UserControlBassPanel()
        {
            InitializeComponent();
        }

        public void Save() {
            Settings.Default.BassEmail = txtBassEMail.Text;
            Settings.Default.BassCode = txtBassCode.Text;

            Settings.Default.Save();
        }

        public bool IsValid()
        {
            return true;
        }

        public void LoadSettings()
        {
            txtBassEMail.Text = Settings.Default.BassEmail;
            txtBassCode.Text = Settings.Default.BassCode;      
        }

        private void pictureBoxBassAudio_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pictureBoxBassAudio_Click(object sender, EventArgs e)
        {
            Process.Start("http://bass.radio42.com/bass_register.html");
        }

    }
}
