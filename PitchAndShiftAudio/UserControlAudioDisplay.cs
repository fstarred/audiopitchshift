using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Un4seen.Bass.AddOn.Tags;
using System.IO;
using Un4seen.Bass.Misc;
using Un4seen.Bass;
using AudioController;

namespace PitchAndShiftAudio
{
    public partial class UserControlAudioDisplay : UserControl
    {
        public UserControlAudioDisplay()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            toolStripMenuItemDM.Click += new EventHandler(toolStripMenuItemDM_Click);
        }

        void toolStripMenuItemDM_Click(object sender, EventArgs e)
        {
            SwitchDisplayMode();
        }

        private Visuals vis = new Visuals();

        public void RefreshSpectrumLine(bool show)
        {
            this.pictureBoxSpec.Image = show ? vis.CreateSpectrumLine(AudioPlayer.Instance.CurrentAudioHandle.CurrentHandle, this.pictureBoxSpec.Width, this.pictureBoxSpec.Height, Color.Green, Color.Red, Color.Black, 2, 3, false, false, false)
                : null;
        }

        public void RefreshElapsedTime()
        {
            this.labelTime.Text = AudioPlayer.Instance.GetElapsedTime();
        }

        public void RefreshRemainingTime()
        {
            this.labelTime.Text = AudioPlayer.Instance.GetRemainingTime();
        }

        public void RefreshTime()
        {
            if (CurrentDisplayMode == DisplayMode.CURRENT_TIME)
                RefreshElapsedTime();
            else
                RefreshRemainingTime();
        }

        public void RefreshTrackPosition()
        {
            this.labelTrackPosition.Text = string.Format("Pos: {0}", (AudioPlayer.Instance.CurrentTrackIndex + 1).ToString());
        }

        public void RefreshLoop(Dictionary<string, long> marker)
        {
            string starttime = string.Empty;
            string endtime = string.Empty;

            if (marker != null)
            {
                if (marker.ContainsKey("START"))
                    starttime = String.Format("[{0}]", Utils.FixTimespan(Bass.BASS_ChannelBytes2Seconds(AudioPlayer.Instance.CurrentAudioHandle.CurrentHandle, marker["START"]), "MMSS"));

                if (marker.ContainsKey("END"))
                    endtime = String.Format("[{0}]", Utils.FixTimespan(Bass.BASS_ChannelBytes2Seconds(AudioPlayer.Instance.CurrentAudioHandle.CurrentHandle, marker["END"]), "MMSS"));
            }

            this.labelSLoop.Text = starttime;
            this.labelELoop.Text = endtime;
        }

        public void RefreshGeneralInfo()
        {
            string songTitle = String.Empty;

            Image imageCover = null;

            if (AudioPlayer.Instance.CurrentTrack != null)
            {
                string filename = AudioPlayer.Instance.CurrentTrack.Location;

                songTitle = string.Empty;

                // get artist tag            
                if (AudioPlayer.Instance.CurrentAudioHandle.IsTagAvailable)
                {
                    TAG_INFO tagInfo = AudioPlayer.Instance.CurrentAudioHandle.TagInfo;

                    if (AudioPlayer.Instance.CurrentAudioHandle.IsModule())
                    {
                        if (string.IsNullOrEmpty(tagInfo.title) == false)
                        {
                            songTitle = String.Format("{0}", tagInfo.title);
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(string.Concat(new string[] { tagInfo.artist, tagInfo.title })) == false)
                        {
                            songTitle = String.Format("{0} - {1}", tagInfo.artist, tagInfo.title);
                        }

                        int picturesCount = AudioPlayer.Instance.CurrentAudioHandle.TagInfo.PictureCount;

                        if (picturesCount > 0)
                        {
                            imageCover = AudioPlayer.Instance.CurrentAudioHandle.TagInfo.PictureGetImage(0);                            
                        }


                        //    PictureBox[] picBox = new PictureBox[] { pictureBoxCoverArtOne, pictureBoxCoverArtTwo };

                        //    for (int i = 0; i < picBox.Length; i++)
                        //    {
                        //        if (picturesCount > i)
                        //        {                        
                        //            Image image = AudioPlayer.Instance.CurrentAudioHandle.TagInfo.PictureGetImage(i);
                        //            picBox[i].Image = image;
                        //        }
                        //        else
                        //            picBox[i].Image = null;
                        //    }
                    }
                }

                if (string.IsNullOrEmpty(songTitle))
                {
                    songTitle = Path.GetFileName(filename);
                }

                this.Invoke((MethodInvoker)delegate
                {

                    if (AudioPlayer.Instance.CurrentAudioHandle.ChannelInfo != null)
                    {
                        labelTitle.Text = songTitle;

                        this.labelInfo.Text = AudioPlayer.Instance.CurrentAudioHandle.ChannelInfo.ToString();

                        this.labelTrackPosition.Text = string.Format("Pos: {0}", (AudioPlayer.Instance.CurrentTrackIndex + 1).ToString());

                        string totalTime = String.Empty;

                        if (AudioPlayer.Instance.CurrentAudioHandle.IsRemoteURL == false)
                            totalTime = AudioPlayer.Instance.GetTotalTime();

                        this.labelTime.Text = String.Empty;

                        this.labelTotalTime.Text = totalTime;

                        this.labelSLoop.Text = string.Empty;

                        this.labelELoop.Text = string.Empty;

                        this.pictureBoxCover.Image = imageCover;
                    }

                });
            }
            else
            {
                // NO AUDIO LOADED
                this.Invoke((MethodInvoker)delegate
                {
                    this.labelTitle.Text = string.Empty;

                    this.labelInfo.Text = string.Empty;

                    this.labelTrackPosition.Text = string.Empty;

                    this.labelTime.Text = string.Empty;

                    this.labelTotalTime.Text = string.Empty;

                    this.labelSLoop.Text = string.Empty;

                    this.labelELoop.Text = string.Empty;

                    this.pictureBoxSpec.Image = null;

                    this.pictureBoxCover.Image = imageCover;
                });
            }
        }

        private void labelTime_Click(object sender, EventArgs e)
        {
            SwitchDisplayMode();
        }

        public enum DisplayMode { CURRENT_TIME, REMAINING_TIME }

        public DisplayMode CurrentDisplayMode { get; set; }

        private void SwitchDisplayMode()
        {
            switch (CurrentDisplayMode)
            {
                case DisplayMode.CURRENT_TIME:
                    CurrentDisplayMode = DisplayMode.REMAINING_TIME;
                    break;
                case DisplayMode.REMAINING_TIME:
                    CurrentDisplayMode = DisplayMode.CURRENT_TIME;
                    break;
            }

        }
    }
}
