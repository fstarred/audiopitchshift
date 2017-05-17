using System;

namespace PitchAndShiftAudio
{
    public partial class UserControlTrackBarH : UserControlTrackBar
    {
        public UserControlTrackBarH()
        {
            InitializeComponent();

            trackBar.RightToLeftChanged += new EventHandler(trackBar_RightToLeftChanged);
        }

        void trackBar_RightToLeftChanged(object sender, EventArgs e)
        {
            UpdateControl(sender, e);
        }

        private void UpdateControl(object sender, EventArgs e)
        {
            if (trackBar.RightToLeft == System.Windows.Forms.RightToLeft.No)
            {
                labelTitle.Left = trackBar.Left;
                labelValue.Left = trackBar.Left + trackBar.Width - labelValue.Width;
            }
            else
            {
                labelTitle.Left = trackBar.Left + trackBar.Width - labelTitle.Width;
                labelValue.Left = trackBar.Left;
            }            
        }


        private void UserControlTrackBarH_Load(object sender, EventArgs e)
        {
            UpdateControl(sender, e);
        }
    }
}
