using System;
using System.Windows.Forms;

namespace PitchAndShiftAudio
{
    public partial class PSTrackListForm : Form
    {
        public PSTrackListForm()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void PSTrackListForm_Load(object sender, EventArgs e)
        {
            userControlAudioTracks.Init();
        }

        // this allows to disable close button leaving the icon turned on
        private const int CP_NOCLOSE_BUTTON = 0x200;
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams myCp = base.CreateParams;
        //        myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
        //        return myCp;
        //    }
        //} 

        private void buttonAlign_Click(object sender, EventArgs e)
        {
            if (Owner != null)
            {
                this.Top = this.Owner.Top;

                if (this.Owner.Left > (Screen.FromControl(this.Owner).WorkingArea.Width >> 1))
                {
                    this.Left = this.Owner.Left - this.Width;
                }
                else
                {
                    this.Left = this.Owner.Right;
                }
            }            
        }

        private void PSTrackListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

    }
}
