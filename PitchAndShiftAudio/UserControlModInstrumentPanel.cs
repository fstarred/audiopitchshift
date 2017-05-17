using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Un4seen.Bass;
using System.Runtime.InteropServices;
using AudioController;

namespace PitchAndShiftAudio
{
    public partial class UserControlModInstrumentPanel : UserControl
    {
        public UserControlModInstrumentPanel()
        {
            InitializeComponent();
        }

        public void ShowInfo(AudioHandle audioHandle)
        {
            this.listBoxInstruments.Items.Clear();
            this.listBoxSamples.Items.Clear();

            bool isModule = audioHandle.IsModule();

            if (isModule)
            {
                int instrument = 0;
                int sample = 0;
                
                IntPtr p = IntPtr.Zero;

                do
                {
                    p = Bass.BASS_ChannelGetTags(audioHandle.Handle, BASSTag.BASS_TAG_MUSIC_INST + instrument++);                    
                    if (p != IntPtr.Zero)
                    {
                        string name = String.Format("{0}: {1}", instrument.ToString("00"), Marshal.PtrToStringAnsi(p));
                        listBoxInstruments.Items.Add(name);
                    }
                } while (p != IntPtr.Zero);

                do
                {
                    p = Bass.BASS_ChannelGetTags(audioHandle.Handle, BASSTag.BASS_TAG_MUSIC_SAMPLE + sample++);
                    if (p != IntPtr.Zero)
                    {
                        string name = String.Format("{0}: {1}", sample.ToString("00"), Marshal.PtrToStringAnsi(p));
                        listBoxSamples.Items.Add(name);
                    }
                } while (p != IntPtr.Zero);
            }
            else
            {
                
            }
        }
    }
}
