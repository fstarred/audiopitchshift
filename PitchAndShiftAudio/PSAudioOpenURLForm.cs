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
    public partial class PSAudioOpenURLForm : Form
    {

        public string Url { get { return this.textBoxURL.Text; } }

        public PSAudioOpenURLForm()
        {
            InitializeComponent();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
