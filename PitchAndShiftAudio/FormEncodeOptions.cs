using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PitchAndShiftAudio
{
    public partial class FormEncodeOptions : Form
    {
        public bool EncodeAllTracks { get; private set; }
        public bool ManualStop { get; private set; }
        public string SavePath { get; private set; }
        public enum MODE { LOCAL, REMOTE }
        
        public FormEncodeOptions(MODE mode)
        {
            InitializeComponent();
            if (mode == MODE.LOCAL)
                panelRemoteStream.Visible = false;
            else
                panelLocalStream.Visible = false;

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            EncodeAllTracks = radioButtonAT.Checked;
            ManualStop = radioButtonMS.Checked;

            if (EncodeAllTracks)
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                DialogResult result = fbd.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    SavePath = fbd.SelectedPath;
                }                
            }
            this.Close();
        }



        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormEncodeOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.radioButtonAT.Checked && string.IsNullOrEmpty(SavePath))
                e.Cancel = true;
        }
    }
}
