using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PitchAndShiftAudio.Properties;
using Un4seen.Bass;
using AudioController;

namespace PitchAndShiftAudio
{
    public partial class UserControlDevicePanel : UserControl, IUserControlPrefPanel
    {
        public UserControlDevicePanel()
        {
            InitializeComponent();
        }

        public bool IsValid()
        {
            return true;
        }

        public void Save()
        {
            int seldevice = comboBoxDevices.SelectedIndex;

            Settings.Default.DefaultDevice = seldevice;
            AudioPlayer.Instance.SetDevice(seldevice);
            //AudioPlayer.Instance.LoadAudio();

            BASS_DEVICEINFO info = Bass.BASS_GetDeviceInfo(comboBoxDevices.SelectedIndex);
            if (info.IsInitialized == false)
                MessageBox.Show("Selected device is not initialized", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void LoadSettings()
        {
            int deviceUsed = Settings.Default.DefaultDevice;

            int numDevice = 0;

            Dictionary<int, string> dicto = new Dictionary<int, string>();

            foreach (BASS_DEVICEINFO device in Globals.Instance.Devices)
            {                
                dicto.Add(numDevice, string.Format("{0}: {1}", numDevice.ToString(), device.name));
                numDevice++;
            }

            comboBoxDevices.DataSource = new BindingSource(dicto, null);
            comboBoxDevices.DisplayMember = "Value";
            comboBoxDevices.ValueMember = "Key";

            comboBoxDevices.SelectedIndex = deviceUsed;
        }

        private void comboBoxDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

    }

    
}
