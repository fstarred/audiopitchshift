using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace PitchAndShiftAudio
{
    public partial class UserControlTrackBar : UserControl
    {
        public UserControlTrackBar()
        {
            InitializeComponent();
        }

        private double multiplier = 1;

        [Browsable(true)]
        public double Multiplier
        {
            get
            {
                return multiplier;
            }
            set
            {
                multiplier = value;
            }
        }

        public int TickFrequency
        {
            get
            {
                return trackBar.TickFrequency;
            }
            set
            {
                trackBar.TickFrequency = value;
            }
        }

        public string Title
        {
            get
            {
                return labelTitle.Text;
            }
            set
            {
                this.labelTitle.Text = value;
            }
        }

        public int Maximum
        {
            get
            {
                return trackBar.Maximum;
            }
            set
            {
                trackBar.Maximum = value;
            }
        }

        public int Minimum
        {
            get
            {
                return trackBar.Minimum;
            }
            set
            {
                trackBar.Minimum = value;
            }
        }

        public double Value
        {
            get
            {
                return trackBar.Value * multiplier;
            }
            set
            {
                trackBar.Value = (int)(value / multiplier);
                labelValue.Text = value.ToString();
            }
        }

        protected void UpdateValue()
        {
            Value = trackBar.Value * multiplier;
            labelValue.Text = (trackBar.Value * multiplier).ToString();
        }


        protected void trackBar_Scroll(object sender, EventArgs e)
        {
            UpdateValue();
            OnTrackBarScroll(sender, e);
        }


        // EventHandler is the general event for controls
        public event EventHandler TrackBarScroll;

        // Invoke the TrackBarScroll event; 
        protected void OnTrackBarScroll(object sender, EventArgs e)
        {
            if (TrackBarScroll != null)
                TrackBarScroll(sender, e);
        }

        // EventHandler is the general event for controls
        public event EventHandler ValueChanged;

        // Invoke the TrackBarScroll event; 
        protected void OnValueChanged(object sender, EventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(sender, e);
        }

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            OnValueChanged(sender, e);
        }
    }
}
