using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace PitchAndShiftAudio
{
    public partial class UserControlEq : UserControl
    {
        public UserControlEq()
        {
            InitializeComponent();
        }

        private ToolTip toolTip;

        public int Value
        {
            get
            {
                return trackBar.Value / 10;
            }
            set
            {
                trackBar.Value = value * 10;
            }
        }

        [Browsable(true)]
        public int Index { get; set; }


        private float center;

        [Browsable(true)]
        public float Center
        {
            get
            {
                return center;
            }
            set
            {
                center = value;

                string labelfreq;
                int valuefreq;

                if (value > 999)
                {
                    labelfreq = "Khz";
                    valuefreq = (int)(float)value / 1000;
                }
                else
                {
                    labelfreq = "Hz";
                    valuefreq = (int)(float)value;
                }

                label.Text = valuefreq + " " + labelfreq;
            }
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            toolTip.SetToolTip((Control)sender, ((int)trackBar.Value / 10).ToString());
            OnTrackBarScroll(sender, e);
        }

        private void UserControlMixer_Load(object sender, EventArgs e)
        {
            toolTip = new ToolTip();            
        }

        // EventHandler is the general event for controls
        public event EventHandler TrackBarScroll;

        // Invoke the TrackBarScroll event; 
        protected void OnTrackBarScroll(object sender, EventArgs e)
        {
            if (TrackBarScroll != null)
                TrackBarScroll(this, e);
        }
    }
}
