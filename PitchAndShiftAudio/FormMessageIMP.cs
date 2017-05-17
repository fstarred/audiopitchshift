using PitchAndShiftAudio.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PitchAndShiftAudio
{
    public partial class FormMessageIMP : Form
    {
        public FormMessageIMP()
        {
            InitializeComponent();
        }

        private void linkLabelIMP_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenIMPUrl();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Settings.Default.ShowMessageIMP = (chkBoxNoMoreAlert.Checked == false);
            this.Close();
        }

        private void pictureBoxIMPLogo_Click(object sender, EventArgs e)
        {
            OpenIMPUrl();
        }

        private void OpenIMPUrl()
        {
            Process.Start("http://impulsemediaplayer.codeplex.com");
        }

        private void pictureBoxIMPLogo_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pictureBoxIMPLogo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    }
}
