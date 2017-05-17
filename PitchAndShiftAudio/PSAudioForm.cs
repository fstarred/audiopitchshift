using AudioController;
using PitchAndShiftAudio.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Un4seen.Bass;
using Un4seen.Bass.AddOn.Aac;
using Un4seen.Bass.AddOn.Cd;
using Un4seen.Bass.AddOn.Flac;
using Un4seen.Bass.AddOn.Fx;
using Un4seen.Bass.AddOn.Mpc;
using Un4seen.Bass.AddOn.Wma;
using Un4seen.Bass.Misc;

namespace PitchAndShiftAudio
{
    public partial class PSAudioForm : Form
    {
        public PSAudioForm()
        {
            InitializeComponent();
        }


        // LOCAL VARS
        // AudioPlayer.Instance.CurrentHandle points to the global AudioPlayer.Instance.CurrentHandle instance
        //private AudioHandle AudioPlayer.Instance.CurrentHandle = null;

        //CancellationTokenSource tokenSource;

        private int tickCounter = 0;

        private bool _trackBarPositionCanDisplay = true;

        private float panRatio;

        private int ms20length = 0;
        private float[] rmsData;     // our global data buffer used at RMS

        private BPMPROCESSPROC bpmProc;
        //private ENCODEPROC MyEncProc;
        //private SYNCPROC mySyncProcEnd;

        //PSAudioTrackListForm trackListForm;

        PSTrackListForm tracklistForm;
        FormTagServiceSearch formTagService;

        private Encoder myEncoder;

        private bool stopEncodingOnMetaUpdates = false;

        //private int mySyncHandleEnd;

        //private BPMCounter bpmCounter;

        //private enum DisplayMode { CURRENT_TIME, REMAINING_TIME }

        //private DisplayMode currentDisplayMode;

        //private string filenameInput;

        //private string songTitle;

        //private double totalTime;

        //private int currentTrack;

        //private bool prepareNextTrack = false;

        int streamWave = 0;

        //private int[] fxEQ = { 0, 0, 0, 0, 0 };

        //private int fxChorusHandle = 0;
        //private BASS_DX8_CHORUS chorus = new BASS_DX8_CHORUS(0f, 0f, -99f, 0f, 0, 0f, BASSFXPhase.BASS_FX_PHASE_NEG_180);
        //private int fxReverbHandle = 0;
        //private BASS_DX8_REVERB reverb = new BASS_DX8_REVERB(-96f, -96f, 0.001f, 0.001f);
        //private int fxEchoHandle = 0;
        //private BASS_DX8_ECHO echo = new BASS_DX8_ECHO(0f, 0f, 1f, 1f, false);

        //private Visuals vis = new Visuals(); // visuals class instance

        //private string fileSupportedExtFilter;

        //private Dictionary<int, string> pluginsLoaded;

        private Task encodeTask;

        //delegate void DelegEncoding(EncArgument argument);

        //private int percentage = 0;

        private int msUpdateBar = 1000;

        //private int standardWidth = 445;

        //private int expandedWidth = 700;

        //private int standardHeight = 532;

        //private int expandedHeight = 611;

        private bool isExpanded = false;

        private long ghostCursorPosition = -1;

        private WaveForm waveForm = null;

        //private const int pictureWaveFormWidth = 666;
        //private const int pictureWaveFormHeight = 105;

        private enum ENCODING_FORMAT { MP3, WMA, WAV /*OGG*/}

        private const string IconPlay = "play";
        private const string IconPausePlay = "pause_play";
        private const string IconPause = "pause";
        private const string IconStop = "stop";

        private const short TrackBarPositionMaxLength = 1024;

        private void MyWaveFormCallback(int framesDone, int framesTotal, TimeSpan elapsedTime, bool finished)
        {
            if (finished)
            {

            }
            // will be called during rendering...
            DrawWave();
        }

        private void DrawWave()
        {
            if (waveForm != null)
                this.pictureBoxWF.BackgroundImage = waveForm.CreateBitmap(this.pictureBoxWF.Width, this.pictureBoxWF.Height, -1, -1, true);
            else
                this.pictureBoxWF.BackgroundImage = null;
        }

        private void DrawWavePosition(long pos, long len)
        {
            if (len == 0 || pos < 0)
            {
                this.pictureBoxWF.Image = null;
                return;
            }

            Bitmap bitmap = null;
            Graphics g = null;
            Pen p = null;
            double bpp = 0;

            try
            {

                bpp = len / (double)this.pictureBoxWF.Width;  // bytes per pixel

                p = new Pen(Color.Red);
                bitmap = new Bitmap(this.pictureBoxWF.Width, this.pictureBoxWF.Height);
                g = Graphics.FromImage(bitmap);
                //g.Clear(Color.Black);
                int x = (int)Math.Round(pos / bpp);  // position (x) where to draw the line
                g.DrawLine(p, x, 0, x, this.pictureBoxWF.Height - 1);
                //bitmap.MakeTransparent(Color.Black);

                DrawGhostCursorPosition(g, ghostCursorPosition, len);

            }
            catch (Exception)
            {
                bitmap = null;
            }
            finally
            {
                // clean up graphics resources
                if (p != null)
                    p.Dispose();
                if (g != null)
                    g.Dispose();
            }

            this.pictureBoxWF.Image = bitmap;
        }


        //private Font drawFont = new Font(FontFamily.GenericMonospace, 16);
        //private SolidBrush drawBrush = new SolidBrush(Color.Black);
        //private PointF pointF = new PointF();

        private void DrawGhostCursorPosition(Graphics g, long pos, long len)
        {
            if (ghostCursorPosition < 0)
                return;

            Pen p = null;
            double bpp = 0;

            try
            {
                p = new Pen(Color.Gray);
                bpp = len / (double)this.pictureBoxWF.Width;  // bytes per pixel

                //g.Clear(Color.Black);
                int x = (int)Math.Round(pos / bpp);  // position (x) where to draw the line

                //pointF.X = x;
                //pointF.Y = this.pictureBoxWF.Height / 2;

                g.DrawLine(p, x, 0, x, this.pictureBoxWF.Height - 1);
                //g.DrawString(Convert.ToString(Bass.BASS_ChannelBytes2Seconds(streamFX, pos)), drawFont, drawBrush, pointF);

                //labelGhostCursorPosition.Text = Utils.FixTimespan(Bass.BASS_ChannelBytes2Seconds(streamFX, pos), "MMSS");

                toolTip.Show(Utils.FixTimespan(Bass.BASS_ChannelBytes2Seconds(AudioPlayer.Instance.CurrentAudioHandle.CurrentHandle, pos), "MMSS"), this, x, this.pictureBoxWF.Top + this.pictureBoxWF.Height);


            }
            catch (Exception)
            {

            }
            finally
            {
                // clean up graphics resources
                if (p != null)
                    p.Dispose();
                if (g != null)
                    g.Dispose();
            }

        }

        private void RenderWaveForm()
        {
            string filename = AudioPlayer.Instance.CurrentTrack.Location;

            // render a wave form
            //waveForm = new WaveForm(this.filename, new WAVEFORMPROC(MyWaveFormCallback), this);
            waveForm = new WaveForm();
            waveForm.FrameResolution = 0.01f; // 10ms are nice
            waveForm.CallbackFrequency = 2000; // every 30 seconds rendered (3000*10ms=30sec)
            waveForm.ColorBackground = Color.WhiteSmoke;
            waveForm.ColorLeft = Color.Gainsboro;
            waveForm.ColorLeftEnvelope = Color.Gray;
            waveForm.ColorRight = Color.LightGray;
            waveForm.ColorRightEnvelope = Color.DimGray;
            waveForm.ColorMarker = Color.DarkBlue;
            waveForm.DrawWaveForm = WaveForm.WAVEFORMDRAWTYPE.Stereo;
            waveForm.DrawMarker = WaveForm.MARKERDRAWTYPE.Line | WaveForm.MARKERDRAWTYPE.Name | WaveForm.MARKERDRAWTYPE.NamePositionAlternate;
            waveForm.MarkerLength = 0.75f;

            if (AudioPlayer.Instance.CurrentAudioHandle.IsModule())
                streamWave = Bass.BASS_MusicLoad(filename, 0, 0, BASSFlag.BASS_MUSIC_DECODE | BASSFlag.BASS_MUSIC_FLOAT | BASSFlag.BASS_MUSIC_PRESCAN, 0);
            else
                streamWave = Bass.BASS_StreamCreateFile(filename, 0L, 0L, BASSFlag.BASS_STREAM_DECODE | BASSFlag.BASS_SAMPLE_FLOAT | BASSFlag.BASS_STREAM_PRESCAN);

            waveForm.NotifyHandler = new WAVEFORMPROC(MyWaveFormCallback);
            waveForm.WinControl = this;
            bool isRendering = waveForm.RenderStart(streamWave, true);
        }

        private void trackBarPosition_Scroll(object sender, System.EventArgs e)
        {
            //AudioPlayer.Instance.Position = this.trackBarPosition.Value;
            AudioPlayer.Instance.Position = GetTrackPosition((short)this.trackBarPosition.Value, AudioPlayer.Instance.CurrentAudioHandle.LengthInBytes);
        }

        private void trackBarPosition_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _trackBarPositionCanDisplay = false;
            int newTrackPosition = (int)(this.trackBarPosition.Maximum * ((double)e.X / this.trackBarPosition.Width));
            //AudioPlayer.Instance.Position = newTrackPosition;
            AudioPlayer.Instance.Position = GetTrackPosition((short)this.trackBarPosition.Value, AudioPlayer.Instance.CurrentAudioHandle.LengthInBytes);
        }

        private void trackBarPosition_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _trackBarPositionCanDisplay = true;
        }

        private void trackBarVol_Scroll(object sender, EventArgs e)
        {
            UpdateVolumeByCurrentValue();
        }


        private void UpdateVolumeByCurrentValue()
        {
            int trackbarValue = trackBarVol.Value;

            float volume;

            int multiplier;

            bool isModule = AudioPlayer.Instance.CurrentAudioHandle.IsModule();

            //forced to false
            isModule = false;

            if (isModule)
            {
                const int maxVolumeValueIT = 128;
                const int maxVolumeValueMOD = 64;

                int maxVolume = AudioPlayer.Instance.CurrentAudioHandle.ChannelInfo.ctype == BASSChannelType.BASS_CTYPE_MUSIC_IT ? maxVolumeValueIT : maxVolumeValueMOD;

                multiplier = maxVolume;

            }
            else
                multiplier = 1;

            volume = ((float)trackbarValue * multiplier / 100);

            AudioPlayer.Instance.CurrentAudioHandle.SetVolume(volume);

            toolTip.SetToolTip(trackBarVol, String.Format("{0}%", trackBarVol.Value));
        }



        private void btnPlay_Click(object sender, EventArgs e)
        {
            BASSActive currentAction = AudioPlayer.Instance.GetStreamStatus();

            switch (currentAction)
            {
                case BASSActive.BASS_ACTIVE_PLAYING:
                    //PSAudioUtils.ChangeImageButton(btnPlay, "pause_play");
                    AudioPlayer.Instance.Pause();

                    break;

                case BASSActive.BASS_ACTIVE_PAUSED:
                    //PSAudioUtils.ChangeImageButton(btnPlay, "play");
                    AudioPlayer.Instance.Play(false);

                    break;

                default:

                    //string filename = null;

                    //if (AudioPlayer.Instance.TrackList.Tracks.Count > 0)
                    //{
                    //    //filename = AudioPlayer.Instance.TrackList.Tracks[AudioPlayer.Instance.CurrentTrackIndex].Location;                        
                    //}

                    bool isPlaying = false;

                    if (AudioPlayer.Instance.TrackList.Tracks.Count > 0)
                    {
                        if (AudioPlayer.Instance.CurrentTrack == null)
                            AudioPlayer.Instance.CurrentTrackIndex = 0;

                        isPlaying = AudioPlayer.Instance.Play(true);
                    }

                    if (isPlaying == false)
                    {
                        OpenFileDialogAndPlay();
                    }

                    break;
            }
        }

        private void PrepareTrack()
        {
            //bool isStreamOk = false;

            try
            {
                Bass.BASS_StreamFree(streamWave);

                BASS_CHANNELINFO info = null;

                int[] rates = null;

                bool isModule = AudioPlayer.Instance.CurrentAudioHandle.IsModule();

                if (AudioPlayer.Instance.CurrentAudioHandle.IsRemoteURL == false)
                {
                    //trackBarSpeed.Enabled = !isModule;                

                    ms20length = (int)Bass.BASS_ChannelSeconds2Bytes(AudioPlayer.Instance.CurrentAudioHandle.Handle, 0.02f); // 20ms window

                    long len = AudioPlayer.Instance.CurrentAudioHandle.LengthInBytes;

                    //totalTime = AudioPlayer.Instance.CurrentAudioHandle.LengthInSeconds;

                    this.Invoke((MethodInvoker)delegate
                    {
                        // prepare start time position to play according to track position value
                        int startPosition = (int)(this.trackBarPosition.Value * len / this.trackBarPosition.Maximum);

                        //this.trackBarPosition.Maximum = (int)len;

                        this.trackBarPosition.Enabled = true;

                        this.trackBarPosition.Maximum = TrackBarPositionMaxLength;

                        this.trackBarPosition.Value = GetTrackbarPosition(startPosition, len);

                        trackBarPitch.Enabled = !isModule;

                        trackBarSpeed.Enabled = true;

                        AudioPlayer.Instance.CurrentAudioHandle.Position = startPosition;

                        //ShowAudioInfoOnDisplay();

                        userControlAudioDisplay.RefreshGeneralInfo();

                        // channel info
                        info = AudioPlayer.Instance.CurrentAudioHandle.ChannelInfo;

                        int chans = info.chans;

                        int freq = info.freq;

                        InitEQ(groupBoxMixer);

                        userControlEffectsPanel.InjectFX(AudioPlayer.Instance.CurrentAudioHandle);

                        userControlEffectsPanel.UpdateModuleTab(isModule);

                        userControlModInstrumentPanel.ShowInfo(AudioPlayer.Instance.CurrentAudioHandle);

                        //PrepareTabCoverArts(isModule);

                        PrepareTabControlDisplay(isModule);

                        UpdateVolumeByCurrentValue();

                        UpdatePanByCurrentValue();

                        UpdatePitchByCurrentValue();

                        UpdateSpeedByCurrentValue();

                        RenderWaveForm();

                    });

                }
                else
                {
                    //ShowAudioInfoOnDisplay();

                    this.trackBarPosition.Value = 0;

                    this.trackBarPosition.Enabled = false;

                    userControlAudioDisplay.RefreshGeneralInfo();

                    // channel info
                    info = AudioPlayer.Instance.CurrentAudioHandle.ChannelInfo;

                    int chans = info.chans;

                    InitEQ(groupBoxMixer);

                    userControlEffectsPanel.InjectFX(AudioPlayer.Instance.CurrentAudioHandle);

                    userControlEffectsPanel.UpdateModuleTab(isModule);

                    userControlModInstrumentPanel.ShowInfo(AudioPlayer.Instance.CurrentAudioHandle);

                    UpdateVolumeByCurrentValue();

                    UpdatePanByCurrentValue();

                    this.Invoke((MethodInvoker)delegate
                    {
                        // CHECK IT OUT
                        //this.labelTime.Text = string.Empty;

                        //this.labelTotalTime.Text = string.Empty;

                        trackBarPitch.Enabled = false;

                        trackBarSpeed.Enabled = false;
                    });

                    this.pictureBoxWF.BackgroundImage = null;
                }
                
                // common for all stream types
                if (PSAudioUtils.IsWindowsOS())
                {
                    BASSWMAEncode wmaEncodeFlag = BASSWMAEncode.BASS_WMA_ENCODE_DEFAULT;

                    if (info.Is8bit)
                        wmaEncodeFlag |= BASSWMAEncode.BASS_SAMPLE_8BITS;
                    else if (info.Is32bit)
                        wmaEncodeFlag |= BASSWMAEncode.BASS_SAMPLE_FLOAT;

                    rates = BassWma.BASS_WMA_EncodeGetRates(info.freq, info.chans, wmaEncodeFlag);

                    this.Invoke((MethodInvoker)delegate
                    {
                        toolStripComboBoxRates.Items.Clear();
                    });
                }


                if (rates != null)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        foreach (int rate in rates)
                        {
                            toolStripComboBoxRates.Items.Add(rate);
                        }

                        if (toolStripComboBoxRates.Items.Count > 0)
                        {
                            toolStripComboBoxRates.Text = Convert.ToString(rates[0]);
                        }
                    });
                }

            }
            catch (Exception)
            {                
                //isStreamOk = false;
            }

            //return isStreamOk;

        }

        private void PrepareTabControlDisplay(bool isModule)
        {
            if (isModule)
            {
                if (tabControl.TabPages.Contains(tabPageInstruments) == false)
                    tabControl.TabPages.Add(tabPageInstruments);
            }
            else
                tabControl.TabPages.Remove(tabPageInstruments);
        }


        private void PrepareTabCoverArts(bool isModule)
        {
            //if (isModule == false)
            //{
            //    if (tabControl.TabPages.Contains(tabPageCoverArts) == false)                
            //        tabControl.TabPages.Add(tabPageCoverArts);

            //    int picturesCount = AudioPlayer.Instance.CurrentAudioHandle.TagInfo.PictureCount;

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

            //}
            //else
            //    tabControl.TabPages.Remove(tabPageCoverArts);
        }
        
        private void PSAudioForm_Load(object sender, EventArgs e)
        {
            PSAudioUtils.InitBass(this.Handle);

            SharedServices.CheckForUpdates(false);

            InitForm();

            _sync = new SYNCPROC(SetPosition);

            bpmProc = new BPMPROCESSPROC(MyBPMProc);

            LoadAudioSettings();

            InitTrackListForm();

            InitTrackList();

            InitContextMenu();

            ShowMessageIMP();
        }

        private void ShowMessageIMP()
        {
            if (Settings.Default.ShowMessageIMP)
            {
                Task.Factory.StartNew(() =>
                    {
                        Thread.Sleep(3000);

                        this.Invoke((MethodInvoker)delegate
                        {
                            FormMessageIMP messageIMP = new FormMessageIMP();
                            messageIMP.ShowDialog(this);
                        });                        
                    });                
            }
        }

        [DllImport("user32.dll")]
        static public extern bool ShowScrollBar(System.IntPtr hWnd, int wBar, bool bShow);
        private const uint SB_HORZ = 0;
        private const uint SB_VERT = 1;
        private const uint ESB_DISABLE_BOTH = 0x3;
        private const uint ESB_ENABLE_BOTH = 0x0;

        private void InitTrackList()
        {
            userControlTrackListView.Init();

            userControlTrackListView.listViewTrackList.HeaderStyle = ColumnHeaderStyle.None;

            userControlTrackListView.listViewTrackList.MultiSelect = false;

            userControlTrackListView.listViewTrackList.Columns[4].Width = 0;

            // hides horizontal scroll bar
            userControlTrackListView.listViewTrackList.Scrollable = false;
            
            ShowScrollBar(userControlTrackListView.listViewTrackList.Handle, (int)SB_VERT, true);
        }

        private void updateMetaInfo(object sender, EventArgs e)
        {
            foreach (ListViewItem item in userControlTrackListView.listViewTrackList.SelectedItems)
            {
                Track track = (Track)item.Tag;

                userControlTrackListView.RefreshItemInfo(item);
            }
        }

        private void LoadAudioSettings()
        {
            AudioSettings audioSettings = Settings.Default.AudioSettings ?? new AudioSettings();

            AudioPlayer.Instance.TrackList = audioSettings.TrackList;

            TrackList trackList = AudioPlayer.Instance.TrackList;

            AudioPlayer.Instance.CurrentTrackIndex = audioSettings.LastTrack;

            //if (audioSettings.LastTrack >= 0 && audioSettings.LastTrack < trackList.Tracks.Count)
            //    AudioPlayer.Instance.CurrentTrack = trackList.Tracks[audioSettings.LastTrack];

            this.trackBarVol.Value = audioSettings.Volume;

            this.trackBarSpeed.Value = audioSettings.Speed;

            this.trackBarPitch.Value = audioSettings.Pitch;

            this.trackBarPan.Value = audioSettings.Pan;

            this.userControlMixer1.Value = audioSettings.EQ[0];
            this.userControlMixer2.Value = audioSettings.EQ[1];
            this.userControlMixer3.Value = audioSettings.EQ[2];
            this.userControlMixer4.Value = audioSettings.EQ[3];
            this.userControlMixer5.Value = audioSettings.EQ[4];

            string[] files = Environment.GetCommandLineArgs();

            // program is automatically launched by the file association
            if (files.Length > 1)
            {
                string composedFile = String.Join(" ", files, 1, files.Length - 1 );

                AudioPlayer.Instance.ResetTrackList();

                AudioPlayer.Instance.TrackList.Tracks.Add(Track.GetTrack(files[1]));

                AudioPlayer.Instance.CurrentTrackIndex = 0;

                AudioPlayer.Instance.Play(true);

            }
            else
            {
                if (trackList.Tracks.Count > 0)
                {
                    try
                    {
                        // load last track open

                        string filename = trackList.Tracks[AudioPlayer.Instance.CurrentTrackIndex].Location;

                        if (File.Exists(filename))
                        {
                            LoadFile(filename, false);

                            string waveFormFile = GetWaveformFilePath();

                            bool isWaveFormLoad = false;

                            if (File.Exists(waveFormFile))
                            {
                                AudioPlayer.Instance.LoadAudio();

                                isWaveFormLoad = waveForm.WaveFormLoadFromFile(waveFormFile, true);
                            }

                            if (isWaveFormLoad)
                            {
                                if (waveForm.Wave.marker != null)
                                {
                                    //UpdateLoopLabels(waveForm.Wave.marker);

                                    userControlAudioDisplay.RefreshLoop(waveForm.Wave.marker);

                                    if (waveForm.Wave.marker.ContainsKey("END"))
                                    {
                                        long pos = waveForm.Wave.marker["END"];
                                        _syncer = Bass.BASS_ChannelSetSync(AudioPlayer.Instance.CurrentAudioHandle.CurrentHandle, BASSSync.BASS_SYNC_POS, pos, _sync, IntPtr.Zero);
                                    }
                                }
                            }

                        }


                    }
                    catch (Exception)
                    {

                    }
                }
            }

            Settings.Default.AudioSettings = audioSettings;
        }

        private void SetPosition(int handle, int channel, int data, IntPtr user)
        {
            if (waveForm.Wave.marker.ContainsKey("START"))
            {
                long startpos = waveForm.Wave.marker["START"];
                Bass.BASS_ChannelSetPosition(channel, (long)startpos);
            }
            else
                Bass.BASS_ChannelSetPosition(channel, 0);

        }


        private void InitForm()
        {
            //this.Width = this.standardWidth;
            //this.Height = this.standardHeight;

            //isExpanded = false;

            isExpanded = true;

            //this.labelSLoop.Text = string.Empty;
            //this.labelELoop.Text = string.Empty;

            PrepareTabControlDisplay(AudioPlayer.Instance.CurrentAudioHandle.IsModule());

            userControlAudioDisplay.CurrentDisplayMode = UserControlAudioDisplay.DisplayMode.CURRENT_TIME;

            userControlAudioDisplay.RefreshLoop(null);

            Dictionary<ENCODING_FORMAT, string> dictComboBoxFormat = new Dictionary<ENCODING_FORMAT, string>();

            // combo box format
            this.toolStripComboBoxFormat.Items.Clear();
            dictComboBoxFormat.Add(ENCODING_FORMAT.MP3, ENCODING_FORMAT.MP3.ToString());
            dictComboBoxFormat.Add(ENCODING_FORMAT.WMA, ENCODING_FORMAT.WMA.ToString());
            dictComboBoxFormat.Add(ENCODING_FORMAT.WAV, ENCODING_FORMAT.WAV.ToString());

            this.toolStripComboBoxFormat.ComboBox.DataSource = new BindingSource(dictComboBoxFormat, null);
            this.toolStripComboBoxFormat.ComboBox.DisplayMember = "Value";
            this.toolStripComboBoxFormat.ComboBox.ValueMember = "Key";

            if (new EncoderMP3(0).EncoderExists == false)
                toolStripComboBoxFormat.SelectedIndex = 1;

            this.toolStripLabelStatusEncode.Text = string.Empty;

            AudioPlayer.Instance.AudioHandleLoaded += new AudioPlayer.delAudioHandleLoaded(PrepareTrack);

            AudioPlayer.Instance.StatusChanged += new AudioPlayer.DelegateStatusChanged(AudioStatusChanged);

            AudioPlayer.Instance.TrackEnded += new AudioPlayer.DelegateTrackEnded(TrackEnded);

            AudioPlayer.Instance.MetaUpdated += new AudioPlayer.delMetaUpdated(MetaUpdated);

            AudioPlayer.Instance.TrackChanged += new AudioPlayer.delTrackChanged(TrackChanged);
        }

        private void MetaUpdated()
        {
            if (stopEncodingOnMetaUpdates)
                if (encodeTask != null && encodeTask.IsCompleted == false)
                    Globals.Instance.tokenSource.Cancel();                

            //ShowAudioInfoOnDisplay();

            userControlAudioDisplay.RefreshGeneralInfo();
        }

        private void TrackChanged()
        {
            this.Invoke((MethodInvoker)delegate
            {
                // Refresh current track playing position or clean display if no track selected
                if (AudioPlayer.Instance.GetStreamStatus() == BASSActive.BASS_ACTIVE_PLAYING)
                    userControlAudioDisplay.RefreshTrackPosition();
                    //this.labelTrackPosition.Text = string.Format("Pos: {0}", (AudioPlayer.Instance.CurrentTrackIndex + 1).ToString());
                else if (AudioPlayer.Instance.CurrentTrackIndex < 0)
                    userControlAudioDisplay.RefreshGeneralInfo();
                    //ShowAudioInfoOnDisplay();
            });
        }


        private void InitContextMenu()
        {
            contextMenuStripWave.Items[0].Click += new EventHandler(waveMenu_StartLoop);
            contextMenuStripWave.Items[1].Click += new EventHandler(waveMenu_EndLoop);

            toolStripMenuItemOpen.Click += new EventHandler(btnOpen_Click);
            toolStripMenuItemOpenFolder.Click += new EventHandler(toolStripMenuItemOpenFolder_Click);
            toolStripMenuItemPlay.Click += new EventHandler(btnPlay_Click);
            toolStripMenuItemStop.Click += new EventHandler(btnStop_Click);
            toolStripMenuItemOpenURL.Click += new EventHandler(open_URL);

            toolStripMenuItemStartLoop.Click += new EventHandler(buttonStartLoop_Click);
            toolStripMenuItemRepeatLoop.Click += new EventHandler(buttonRepeatLoop_Click);
            toolStripMenuItemRemoveLoop.Click += new EventHandler(buttonRemoveLoop_Click);

            toolStripMenuItemBPM.Click += new EventHandler(toolStripLabelTempo_Click);
            toolStripMenuItemOpenPlaylist.Click += new EventHandler(buttonTrackList_Click);

            toolStripMenuItemUpdateMetainfo.Click += new EventHandler(updateMetaInfo);
            toolStripMenuItemEncode.Click += new EventHandler(toolStripMenuItemEncode_Click);
        }

        void toolStripMenuItemOpenFolder_Click(object sender, EventArgs e)
        {
            OpenDirectoryDialog();
        }

        void toolStripMenuItemEncode_Click(object sender, EventArgs e)
        {
            if (userControlTrackListView.listViewTrackList.SelectedItems.Count > 0)
            {
                Track track = (Track)userControlTrackListView.listViewTrackList.SelectedItems[0].Tag;

                AudioHandle audioHandle = new AudioHandle();

                audioHandle.CreateHandle(track.Location, BASSFlag.BASS_STREAM_DECODE, BASSFlag.BASS_MUSIC_DECODE, BASSFlag.BASS_STREAM_DECODE);

                if (audioHandle.IsRemoteURL)
                {
                    stopEncodingOnMetaUpdates = false;
                }
                
                EncodeTrack(track);
            }
        }

        private void open_URL(object sender, EventArgs e)
        {
            PSAudioOpenURLForm urlForm = new PSAudioOpenURLForm();
            urlForm.ShowDialog();
            if (urlForm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                string url = urlForm.Url;

                AudioPlayer.Instance.ResetTrackList();

                AudioPlayer.Instance.TrackList.Tracks.Add(Track.GetTrack(url));

                AudioPlayer.Instance.Stop();
                AudioPlayer.Instance.Play(true);
            }
        }

        private void waveMenu_StartLoop(object sender, EventArgs e)
        {
            Point screenPoint = Cursor.Position;

            // Convert screen coordinates to a point relative to the control
            // that was right clicked, in your case this would be the relavant 
            // picture box.
            Point pictureBoxPoint = contextMenuStripWave.SourceControl.PointToClient(screenPoint);

            long pos = waveForm.GetBytePositionFromX(pictureBoxPoint.X, this.pictureBoxWF.Width, -1, -1);

            SetStartMarker(pos);
            DrawWave();
        }

        private void waveMenu_EndLoop(object sender, EventArgs e)
        {
            Point screenPoint = Cursor.Position;

            // Convert screen coordinates to a point relative to the control
            // that was right clicked, in your case this would be the relavant 
            // picture box.
            Point pictureBoxPoint = contextMenuStripWave.SourceControl.PointToClient(screenPoint);

            long pos = waveForm.GetBytePositionFromX(pictureBoxPoint.X, this.pictureBoxWF.Width, -1, -1);

            SetEndMarker(pos);
            DrawWave();
        }

        private void TrackEnded()
        {
            int currentTrackIndex = AudioPlayer.Instance.CurrentTrackIndex;

            if (currentTrackIndex < (AudioPlayer.Instance.TrackList.Tracks.Count - 1))
            {
                AudioPlayer.Instance.CurrentTrackIndex++;                
                AudioPlayer.Instance.Play(true);
            }
        }

        private void AudioStatusChanged()
        {
            this.Invoke((MethodInvoker)delegate
            {
                string iconToShow;

                switch (AudioPlayer.Instance.GetStreamStatus())
                {
                    case BASSActive.BASS_ACTIVE_PAUSED:
                        iconToShow = IconPausePlay;
                        break;
                    case BASSActive.BASS_ACTIVE_PLAYING:
                        iconToShow = IconPause;
                        break;
                    default:
                        iconToShow = IconPlay;

                        userControlAudioDisplay.RefreshSpectrumLine(false);

                        //vis.ClearPeaks();

                        //this.pictureBoxSpec.Image = null;

                        break;
                }

                PSAudioUtils.ChangeImageButton(btnPlay, iconToShow);
            });
        }

        private void InitEQ(GroupBox obj)
        {
            List<KeyValuePair<int, float>> listEQ = new List<KeyValuePair<int, float>>();

            Dictionary<int, int> eqValues = new Dictionary<int, int>();

            //int idx = 0;

            //List<float> listEQ = new List<float>();

            float[] arrEQ;

            // assign event for each mixer control
            foreach (Control control in obj.Controls)
            {
                Type objType = control.GetType();

                if (objType == typeof(UserControlEq))
                {
                    UserControlEq mixer = (UserControlEq)control;

                    mixer.TrackBarScroll += new EventHandler(SetEQ);

                    listEQ.Add(new KeyValuePair<int, float>(mixer.Index, mixer.Center));

                    eqValues.Add(mixer.Index, mixer.Value);
                }
            }

            arrEQ = new float[listEQ.Count];

            foreach (KeyValuePair<int, float> keyval in listEQ)
                arrEQ[keyval.Key] = keyval.Value;

            // init handle with EQ bandwith
            AudioPlayer.Instance.CurrentAudioHandle.InitEQ(arrEQ);

            // assign eq band values to current handle
            foreach (KeyValuePair<int, int> entry in eqValues)
            {
                AudioPlayer.Instance.CurrentAudioHandle.SetEQ(entry.Key, eqValues[entry.Key]);
            }
        }

        private void SetEQ(object sender, EventArgs e)
        {
            UserControlEq mixer = (UserControlEq)sender;

            AudioPlayer.Instance.CurrentAudioHandle.SetEQ(mixer.Index, mixer.Value);
        }


        private void MyBPMProc(int chan, float percent)
        {
            BeginInvoke((MethodInvoker)delegate()
            {
                // this code runs on the UI thread!
                //this.labelBPM.Text = String.Format("{0}%", percent);
                float bpm = percent;
            });
        }

        #region useless routine
        private double RMS(int channel, out int peakL, out int peakR)
        {
            double sum = 0f;
            float maxL = 0f;
            float maxR = 0f;
            int length = ms20length;
            int l4 = length / 4; // the number of 32-bit floats required (since length is in bytes!)

            // increase our data buffer as needed
            if (rmsData == null || rmsData.Length < l4)
                rmsData = new float[l4];

            try
            {
                length = Bass.BASS_ChannelGetData(channel, rmsData, length);
                l4 = length / 4; // the number of 32-bit floats received

                for (int a = 0; a < l4; a++)
                {
                    sum += rmsData[a] * rmsData[a]; // sum the squares
                    // decide on L/R channel
                    if (a % 2 == 0)
                    {
                        // L channel
                        if (rmsData[a] > maxL)
                            maxL = rmsData[a];
                    }
                    else
                    {
                        // R channel
                        if (rmsData[a] > maxR)
                            maxR = rmsData[a];
                    }
                }
            }
            catch { }

            peakL = (int)Math.Round(32768f * maxL);
            if (peakL > 32768)
                peakL = 32768;
            peakR = (int)Math.Round(32768f * maxR);
            if (peakR > 32768)
                peakR = 32768;

            if (panRatio > 0)
                peakL -= (int)(peakL * panRatio);
            else if (panRatio < 0)
                peakR -= (int)(peakR * Math.Abs(panRatio));

            return Math.Sqrt(sum / (l4 / 2));  // l4/2, since we use 2 channels!
        }
        #endregion

        // calculates the level of a stereo signal between 0 and 65535
        // where 0 = silent, 32767 = 0dB and 65535 = +6dB
        #region useless routine
        private void GetLevel(int channel, out int peakL, out int peakR)
        {
            float maxL = 0f;
            float maxR = 0f;

            // length of a 20ms window in bytes
            int length20ms = (int)Bass.BASS_ChannelSeconds2Bytes(channel, 0.02);
            // the number of 32-bit floats required (since length is in bytes!)
            int l4 = length20ms / 4; // 32-bit = 4 bytes

            // create a data buffer as needed
            float[] sampleData = new float[l4];

            int length = Bass.BASS_ChannelGetData(channel, sampleData, length20ms);

            // the number of 32-bit floats received
            // as less data might be returned by BASS_ChannelGetData as requested
            l4 = length / 4;

            for (int a = 0; a < l4; a++)
            {
                float absLevel = Math.Abs(sampleData[a]);

                // decide on L/R channel
                if (a % 2 == 0)
                {
                    // Left channel
                    if (absLevel > maxL)
                        maxL = absLevel;
                }
                else
                {
                    // Right channel
                    if (absLevel > maxR)
                        maxR = absLevel;
                }
            }

            // limit the maximum peak levels to +6bB = 65535 = 0xFFFF
            // the peak levels will be int values, where 32767 = 0dB
            // and a float value of 1.0 also represents 0db.
            peakL = (int)Math.Round(32767f * maxL) & 0xFFFF;
            peakR = (int)Math.Round(32767f * maxR) & 0xFFFF;
        }
        #endregion

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            BASSActive bassActive = AudioPlayer.Instance.GetStreamStatus();

            switch (bassActive)
            {
                case BASSActive.BASS_ACTIVE_PLAYING:
                    break;
                case BASSActive.BASS_ACTIVE_STOPPED:
                case BASSActive.BASS_ACTIVE_PAUSED:
                case BASSActive.BASS_ACTIVE_STALLED:
                    // the stream is NOT playing anymore...
                    //this.timerUpdate.Stop();
                    this.progressBarPeakLeft.Value = 0;
                    this.progressBarPeakRight.Value = 0;
                    //Stop();
                    return;
            }

            // calculate the sound level
            int peakL = 0;
            int peakR = 0;
            //double rms = RMS(AudioPlayer.Instance.CurrentAudioHandle.HandleFX, out peakL, out peakR);

            //GetLevel(AudioPlayer.Instance.CurrentAudioHandle.HandleFX, out peakL, out peakR);

            int peak = Bass.BASS_ChannelGetLevel(AudioPlayer.Instance.CurrentAudioHandle.CurrentHandle);

            peakL = Utils.LowWord32(peak);
            peakR = Utils.HighWord32(peak);

            this.progressBarPeakLeft.Value = peakL;
            this.progressBarPeakRight.Value = peakR;

            userControlAudioDisplay.RefreshSpectrumLine(true);

            //this.pictureBoxSpec.Image = vis.CreateSpectrumLine(AudioPlayer.Instance.CurrentAudioHandle.HandleFX, this.pictureBoxSpec.Width, this.pictureBoxSpec.Height, Color.Green, Color.Red, Color.Black, 2, 3, false, false, false);

            long len = AudioPlayer.Instance.CurrentAudioHandle.LengthInBytes; // length in bytes
            long pos = AudioPlayer.Instance.CurrentAudioHandle.Position; // position in bytes

            // from here on, the stream is for sure playing...
            tickCounter++;

            if (tickCounter % 2 == 0 && isExpanded && AudioPlayer.Instance.CurrentAudioHandle.IsRemoteURL == false)
            {
                // update the wave position
                DrawWavePosition(pos, len);
            }
            if (tickCounter == 4)
            {
                // display the position every 200ms (since timer is 50ms)
                tickCounter = 0;

                //UpdateFormTitle();

                const string format = "{1} (CPU: {0:0.00}%)";

                string title = WindowState == FormWindowState.Minimized ? AudioPlayer.Instance.CurrentTrack.Title : Globals.AppTitle;

                this.Text = String.Format(format, Bass.BASS_GetCPU().ToString(), title);

                bool isRemoteURL = AudioPlayer.Instance.CurrentAudioHandle.IsRemoteURL;

                if (isRemoteURL == false)
                {
                    userControlAudioDisplay.RefreshTime();

                    //if (currentDisplayMode == DisplayMode.CURRENT_TIME)
                    //{
                    //    //this.labelTime.Text = AudioPlayer.Instance.GetElapsedTime();
                    //    userControlAudioDisplay.RefreshElapsedTime();
                    //}
                    //else
                    //{
                    //    //this.labelTime.Text = AudioPlayer.Instance.GetRemainingTime();
                    //    userControlAudioDisplay.RefreshRemainingTime();
                    //}

                    // set the track bar
                    if (_trackBarPositionCanDisplay)
                    {
                        // for some strange reasons, sometimes position is > len

                        //if (!(pos > this.trackBarPosition.Maximum))
                            //this.trackBarPosition.Value = (int)pos;
                        if (pos < len)
                            this.trackBarPosition.Value = GetTrackbarPosition(pos, len);
                    }
                }
            }

        }

        public short GetTrackbarPosition(long pos, long len)
        {
            short val = (short)(pos * TrackBarPositionMaxLength / len);

            return val;
        }

        public long GetTrackPosition(short barpos, long len)
        {
            long pos = (long)(len * barpos / TrackBarPositionMaxLength);

            return pos;
        }

        // called with tick update
        //private void UpdateFormTitle()
        //{
        //    const string format = "{1} (CPU: {0:0.00}%)";

        //    string title = WindowState == FormWindowState.Minimized ? songTitle : AppTitle;

        //    this.Text = String.Format(format, Bass.BASS_GetCPU().ToString(), title);            

        //}

        private void UpdatePanByCurrentValue()
        {
            int trackbarValue = trackBarPan.Value;

            float pan;

            //int multiplier;

            panRatio = ((float)trackbarValue / 100);

            if (AudioPlayer.Instance.CurrentAudioHandle.IsModule())
            {
                pan = (trackbarValue >> 1) + 50;
            }
            else
            {
                pan = panRatio;
            }


            //this.AudioPlayer.Instance.CurrentHandle.SetVolume(pan);

            //// get the resulting pan...
            //panRatio = ((float)(trackBarPan.Value) / 100);

            AudioPlayer.Instance.CurrentAudioHandle.SetPan(pan);
        }

        private void trackBarPan_Scroll(object sender, EventArgs e)
        {
            UpdatePanByCurrentValue();

            string message;

            if (AudioPlayer.Instance.CurrentAudioHandle.IsModule())
            {
                message = String.Format("{0} {1}", "Pan Separation: ", (trackBarPan.Value >> 1) + 50);
            }
            else
            {
                if (panRatio == 0)
                    message = "Centre";
                else if (panRatio > 0)
                    message = String.Format("{0} {1}", Math.Abs(trackBarPan.Value), ">");
                else
                    message = String.Format("{0} {1}", "<", Math.Abs(trackBarPan.Value));
            }

            toolTip.SetToolTip(trackBarPan, message);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void Stop()
        {
            AudioPlayer.Instance.Stop();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            Bass.BASS_ChannelPause(AudioPlayer.Instance.CurrentAudioHandle.CurrentHandle);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {            
            OpenFileDialogAndPlay();
        }

        private void OpenFileDialogAndPlay()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = Globals.Instance.FileSupportedExtFilter;
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                AudioPlayer.Instance.ResetTrackList();

                List<Track> tracks = new List<Track>();

                foreach (string path in openFileDialog.FileNames)
                {
                    if (Utils.BASSAddOnIsFileSupported(Globals.Instance.PluginsLoaded, path))
                    {
                        Track track = Track.GetTrack(path, false);

                        tracks.Add(track);
                    }
                    else if (PSAudioUtils.IsPlaylist(path))
                    {
                        AudioPlayer.Instance.OpenPlaylistFile(path);
                    }
                }

                AudioPlayer.Instance.TrackList.Tracks.AddRange(tracks);

                //AudioPlayer.Instance.TrackList.Tracks.Add(Track.GetTrack(openFileDialog.FileName));

                if (AudioPlayer.Instance.TrackList.Tracks.Count > 0)
                {
                    AudioPlayer.Instance.CurrentTrackIndex = 0;                    
                    AudioPlayer.Instance.Play(true);
                }
            }
        }

        private void LoadFile(string filename, bool play)
        {
            if (AudioPlayer.Instance.GetStreamStatus() != BASSActive.BASS_ACTIVE_STOPPED)
            {
                // the stream is still playing...
                Stop();
            }

            RemoveLoop();

            //bool isLoadOk = false;

            if (File.Exists(filename))
            {
                if (play)
                    AudioPlayer.Instance.Play(true);
            }

            //return isLoadOk;

        }


        //private void SwitchDisplayMode()
        //{
        //    switch (currentDisplayMode)
        //    {
        //        case DisplayMode.CURRENT_TIME:
        //            currentDisplayMode = DisplayMode.REMAINING_TIME;
        //            break;
        //        case DisplayMode.REMAINING_TIME:
        //            currentDisplayMode = DisplayMode.CURRENT_TIME;
        //            break;
        //    }

        //}

        //private void labelTime_Click(object sender, EventArgs e)
        //{
        //    SwitchDisplayMode();
        //}

        private void UpdateSpeedByCurrentValue()
        {
            int trackbarValue = trackBarSpeed.Value;

            //float speed = AudioPlayer.Instance.CurrentAudioHandle.IsModule() ? ((float)AudioPlayer.Instance.CurrentAudioHandle.originalBPM * (trackbarValue + 100) / 100) : trackbarValue;

            float speed = trackbarValue;

            AudioPlayer.Instance.CurrentAudioHandle.SetTempo(speed);
        }

        private void trackBarSpeed_Scroll(object sender, EventArgs e)
        {
            UpdateSpeedByCurrentValue();
        }

        private void UpdatePitchByCurrentValue()
        {
            AudioPlayer.Instance.CurrentAudioHandle.SetPitch((float)trackBarPitch.Value);
        }

        private void trackBarPitch_Scroll(object sender, EventArgs e)
        {
            UpdatePitchByCurrentValue();
        }


        private void DetectBPM()
        {
            if (AudioPlayer.Instance.CurrentAudioHandle.Handle != 0 /*&& Bass.BASS_ChannelIsActive(streamFX) == BASSActive.BASS_ACTIVE_PLAYING */ )
            {
                string filenameInput = AudioPlayer.Instance.CurrentTrack.Location;

                AudioHandle audioHandleBPM = new AudioHandle();

                audioHandleBPM.CreateHandle(filenameInput, BASSFlag.BASS_STREAM_DECODE, BASSFlag.BASS_MUSIC_DECODE, BASSFlag.BASS_STREAM_DECODE);

                long pos = Bass.BASS_ChannelGetPosition(AudioPlayer.Instance.CurrentAudioHandle.Handle, BASSMode.BASS_POS_BYTES);

                double elapsedtime = Bass.BASS_ChannelBytes2Seconds(AudioPlayer.Instance.CurrentAudioHandle.Handle, pos);

                float bpm = BassFx.BASS_FX_BPM_DecodeGet(audioHandleBPM.Handle, elapsedtime, (elapsedtime + 5f), Utils.MakeLong(50, 180), BASSFXBpm.BASS_FX_BPM_BKGRND | BASSFXBpm.BASS_FX_FREESOURCE | BASSFXBpm.BASS_FX_BPM_MULT2, bpmProc);

                audioHandleBPM.FreeResources();

                string message = bpm > 0 ? String.Format("{0:#00.00}", bpm) : "n/a";

                this.toolStripLabelBPM.Text = message;
            }

        }


        private void btnBPM_Click(object sender, EventArgs e)
        {

            //bool mode = !(timerBPM.Enabled);
            //SwitchBPMMode(mode);

        }

        private void btnMixerFlat_Click(object sender, EventArgs e)
        {
            foreach (Control item in groupBoxMixer.Controls)
            {
                if (item.GetType() == typeof(UserControlEq))
                {
                    UserControlEq mixer = (UserControlEq)item;
                    mixer.Value = 0;
                    SetEQ(mixer, null);
                }
            }
        }


        private void btnAbout_Click(object sender, EventArgs e)
        {

        }

        private void OpenAboutBox()
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }

        private void toolStripButtonAbout_Click(object sender, EventArgs e)
        {
            OpenAboutBox();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (this.encodeTask != null && this.encodeTask.IsCompleted == false)
            {
                Globals.Instance.tokenSource.Cancel();
            }
            else
            {
                if (AudioPlayer.Instance.TrackList.Tracks.Count > 1 && AudioPlayer.Instance.CurrentAudioHandle.IsRemoteURL == false)
                {
                    if (tracklistForm.Visible)
                        tracklistForm.Hide();
                    FormEncodeOptions form = new FormEncodeOptions(FormEncodeOptions.MODE.LOCAL);
                    DialogResult result = form.ShowDialog(this);
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        if (form.EncodeAllTracks)
                            EncodeAllTracks(form.SavePath);
                        else
                            EncodeTrack(AudioPlayer.Instance.CurrentTrack);
                    }
                }
                else if (AudioPlayer.Instance.TrackList.Tracks.Count > 0)
                {
                    bool startEncode = true;

                    if (AudioPlayer.Instance.CurrentTrack == null)
                        AudioPlayer.Instance.CurrentTrackIndex = 0;

                    if (AudioPlayer.Instance.CurrentAudioHandle.IsRemoteURL == true)
                    {
                        FormEncodeOptions form = new FormEncodeOptions(FormEncodeOptions.MODE.REMOTE);
                        DialogResult result = form.ShowDialog(this);
                        if (result == System.Windows.Forms.DialogResult.OK)
                        {
                            stopEncodingOnMetaUpdates = form.ManualStop == false;
                        }
                        else
                            startEncode = false;
                        
                    }
                    
                    if (startEncode)
                        EncodeTrack(AudioPlayer.Instance.CurrentTrack);
                }
            }
            //Encode();
        }

        private void EncodeTrack(Track track)
        {
            KeyValuePair<ENCODING_FORMAT, string> selectedFormat = (KeyValuePair<ENCODING_FORMAT, string>)this.toolStripComboBoxFormat.SelectedItem;

            ENCODING_FORMAT format = selectedFormat.Key;

            string extension = null;

            BaseEncoder encoder = null;

            switch (format)
            {
                case ENCODING_FORMAT.WMA:
                    encoder = new EncoderWMA(0);
                    extension = ((EncoderWMA)encoder).DefaultOutputExtension;
                    break;
                case ENCODING_FORMAT.MP3:
                    encoder = new EncoderLAME(0);
                    extension = ((EncoderLAME)encoder).DefaultOutputExtension;
                    if (encoder.EncoderExists == false)
                    {
                        MessageBox.Show("MP3 Encoding requires lame.exe", "No encoder found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;
                case ENCODING_FORMAT.WAV:
                    encoder = new EncoderWAV(0);
                    extension = ((EncoderWAV)encoder).DefaultOutputExtension;
                    break;
                //case ENCODING_FORMAT.OGG:
                //encoder = new EncoderOGG(0);
                //extension = ((EncoderOGG)encoder).DefaultOutputExtension;
                //break;
            }

            Globals.Instance.tokenSource = new CancellationTokenSource();

            string filenameInput = null;

            Track trackToEncode = track;

            if (AudioPlayer.Instance.TrackList.Tracks.Count > 0 && AudioPlayer.Instance.CurrentTrack != null)
                filenameInput = trackToEncode.Location;

            if (string.IsNullOrEmpty(filenameInput) == false)
            {
                string filenameOutput = OpenSaveDlg(extension, filenameInput);

                if (string.IsNullOrEmpty(filenameOutput) == false)
                {
                    if (filenameOutput.Equals(filenameInput) == false)
                    {
                        toolStripLabelStatusEncode.Text = trackToEncode.Title.Length > 20 ? String.Format("{0} ...", trackToEncode.Title.Substring(0, 20)) : trackToEncode.Title;

                        AudioHandle audioHandle = new AudioHandle();

                        audioHandle.CreateHandle(filenameInput, BASSFlag.BASS_STREAM_DECODE | BASSFlag.BASS_STREAM_PRESCAN, BASSFlag.BASS_MUSIC_DECODE | BASSFlag.BASS_MUSIC_PRESCAN, BASSFlag.BASS_STREAM_DECODE);

                        if (audioHandle.IsRemoteURL)
                            Track.LoadTrackInfo(trackToEncode);

                        //BASS_CHANNELINFO info = tmpAudioPlayer.Instance.CurrentHandle.ChannelInfo;

                        BASSFlag flagEncoding = BASSFlag.BASS_STREAM_DECODE;

                        audioHandle.CreateTempoHandle(audioHandle.Handle, flagEncoding);

                        float tempo = 0;
                        float pitch = 0;
                        int bitRate = 0;

                        this.Invoke((MethodInvoker)delegate
                        {
                            tempo = trackBarSpeed.Value;
                            pitch = trackBarPitch.Value;
                            bitRate = (int)toolStripComboBoxRates.SelectedItem;
                        });

                        if (audioHandle.IsModule() == false && audioHandle.IsRemoteURL == false)
                        {
                            // is this really necessary ?
                            //this.Invoke((MethodInvoker)delegate
                            //{

                                audioHandle.SetPitch(pitch);

                            //});
                        }

                        audioHandle.SetTempo(tempo);

                        userControlEffectsPanel.InjectFX(audioHandle);

                        saveToolStripButton.ToolTipText = "Stop";

                        PSAudioUtils.ChangeImageButton(saveToolStripButton, "stop_task");

                        EncArgument encArgument = new EncArgument();
                        encArgument.Encoder = encoder;
                        encArgument.Filename = filenameInput;
                        encArgument.FilenameOutput = filenameOutput;
                        encArgument.BitRate = bitRate;

                        myEncoder = new Encoder();

                        this.encodeTask = Task.Factory.StartNew(() => myEncoder.Encode(encArgument, audioHandle), Globals.Instance.tokenSource.Token).ContinueWith(EncodingFinished);
                        //    .ContinueWith(delegate(Task item)
                        //{
                        //    PSAudioUtils.ChangeImageButton(saveToolStripButton, "save_tool");

                        //    toolStripProgressBarFile.Value = 100;

                        //    toolStripLabelStatusEncode.Text = "Done";
                        //}); ;

                        Task.Factory.StartNew(() => UpdateProgressBar(audioHandle), Globals.Instance.tokenSource.Token);

                        if (Globals.Instance.tokenSource.Token.IsCancellationRequested)
                        {
                            Globals.Instance.tokenSource.Token.ThrowIfCancellationRequested();
                        }

                    }
                    else
                        MessageBox.Show("Destination and source file cannot be the same", "OPERATION NOT PERMITTED", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string OpenSaveDlg(string extension, string filenameInput)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string filter = string.Format("{0} file (*.{0})|*{0}", extension); // "wma file (*.wma)|*.wma";

            saveFileDialog1.FileName = Path.GetFileNameWithoutExtension(Path.ChangeExtension(filenameInput, extension));
            saveFileDialog1.Filter = filter;
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                return saveFileDialog1.FileName;
            }
            else
            {
                return null;
            }
        }




        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            OpenAboutBox();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialogAndPlay();
        }


        private void EncodeAllTracks(string path)
        {
            AudioHandle audioHandle = new AudioHandle();

            KeyValuePair<ENCODING_FORMAT, string> selectedFormat = (KeyValuePair<ENCODING_FORMAT, string>)this.toolStripComboBoxFormat.SelectedItem;

            ENCODING_FORMAT format = selectedFormat.Key;

            string extension = null;

            BaseEncoder encoder = null;

            switch (format)
            {
                case ENCODING_FORMAT.WMA:
                    encoder = new EncoderWMA(0);
                    extension = ((EncoderWMA)encoder).DefaultOutputExtension;
                    break;
                case ENCODING_FORMAT.MP3:
                    encoder = new EncoderLAME(0);
                    extension = ((EncoderLAME)encoder).DefaultOutputExtension;
                    if (encoder.EncoderExists == false)
                    {
                        MessageBox.Show("MP3 Encoding requires lame.exe", "No encoder found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;
                case ENCODING_FORMAT.WAV:
                    encoder = new EncoderWAV(0);
                    extension = ((EncoderWAV)encoder).DefaultOutputExtension;
                    break;
            }

            Globals.Instance.tokenSource = new CancellationTokenSource();

            Action action = new Action(delegate()
            {
                // Were we already canceled?
                Globals.Instance.tokenSource.Token.ThrowIfCancellationRequested();

                foreach (Track item in AudioPlayer.Instance.TrackList.Tracks)
                {
                    saveToolStripButton.ToolTipText = "Stop";

                    PSAudioUtils.ChangeImageButton(saveToolStripButton, "stop_task");

                    string filenameInput = item.Location;

                    string filenameOutput = Path.Combine(path, Path.GetFileName(Path.ChangeExtension(filenameInput, extension)));


                    if (filenameOutput.Equals(filenameInput) == false)
                    {
                        toolStripLabelStatusEncode.Text = item.Title.Length > 20 ? String.Format("{0} ...", item.Title.Substring(0, 20)) : item.Title;

                        audioHandle.CreateHandle(filenameInput, BASSFlag.BASS_STREAM_DECODE | BASSFlag.BASS_STREAM_PRESCAN, BASSFlag.BASS_MUSIC_DECODE | BASSFlag.BASS_MUSIC_PRESCAN, BASSFlag.BASS_STREAM_DECODE);

                        // if is a streaming server, skip it
                        if (audioHandle.IsRemoteURL)
                            continue;

                        BASSFlag flagEncoding = BASSFlag.BASS_STREAM_DECODE;

                        audioHandle.CreateTempoHandle(audioHandle.Handle, flagEncoding);

                        float tempo = 0;
                        float pitch = 0;
                        int bitRate = 0;

                        BASSWMAEncode wmaEncodeFlag = BASSWMAEncode.BASS_WMA_ENCODE_DEFAULT;

                        // channel info
                        BASS_CHANNELINFO info = AudioPlayer.Instance.CurrentAudioHandle.ChannelInfo;

                        int chans = info.chans;

                        int[] rates = null;

                        int freq = info.freq;

                        if (info.Is8bit)
                            wmaEncodeFlag |= BASSWMAEncode.BASS_SAMPLE_8BITS;
                        else if (info.Is32bit)
                            wmaEncodeFlag |= BASSWMAEncode.BASS_SAMPLE_FLOAT;

                        rates = BassWma.BASS_WMA_EncodeGetRates(info.freq, info.chans, wmaEncodeFlag);

                        bitRate = rates[0];

                        this.Invoke((MethodInvoker)delegate
                        {
                            tempo = trackBarSpeed.Value;
                            pitch = trackBarPitch.Value;
                        });

                        if (AudioPlayer.Instance.CurrentAudioHandle.IsModule() == false)
                        {
                            this.Invoke((MethodInvoker)delegate
                            {

                                audioHandle.SetTempo(tempo);

                                audioHandle.SetPitch(pitch);

                            });
                        }

                        userControlEffectsPanel.InjectFX(audioHandle);

                        EncArgument encArgument = new EncArgument();
                        encArgument.Encoder = encoder;
                        encArgument.Filename = filenameInput;
                        encArgument.FilenameOutput = filenameOutput;
                        encArgument.BitRate = bitRate;

                        myEncoder = new Encoder();

                        this.encodeTask = Task.Factory.StartNew(() => myEncoder.Encode(encArgument, audioHandle), Globals.Instance.tokenSource.Token).ContinueWith(EncodingFinished);

                        Task.Factory.StartNew(() => UpdateProgressBar(audioHandle), Globals.Instance.tokenSource.Token);

                        this.encodeTask.Wait(Globals.Instance.tokenSource.Token);

                        if (Globals.Instance.tokenSource.Token.IsCancellationRequested)
                        {
                            Globals.Instance.tokenSource.Token.ThrowIfCancellationRequested();
                        }
                    }
                    else
                        MessageBox.Show("Destination and source file cannot be the same", "OPERATION NOT PERMITTED", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            });

            //Task.Factory.StartNew(action, Globals.Instance.tokenSource.Token).ContinueWith(delegate(Task task)
            //{
            //PSAudioUtils.ChangeImageButton(saveToolStripButton, "save_tool");

            //toolStripLabelStatusEncode.Text = string.Empty;

            //toolStripProgressBarFile.Value = 100;

            //toolStripLabelStatusEncode.Text = "Done";
            //});

            Task.Factory.StartNew(action, Globals.Instance.tokenSource.Token);
        }


        // not used
        public void FileEncodingNotification(long bytesTotal, long bytesDone)
        {
            //percentage = (int)((float)bytesDone / (float)bytesTotal * 100);
            //Console.Write("Encoding: {0:P}\r", Math.Round((double)bytesDone / (double)bytesTotal, 2));
        }

        private byte[] _encbuffer = new byte[1048510]; // 1MB buffer

        public void MyEncodingWriter(int handle, int channel, IntPtr buffer, int length, IntPtr user)
        {
            // copy from managed to unmanaged memory
            Marshal.Copy(buffer, _encbuffer, 0, length);
            // process the data in _encbuffer, e.g. write to disk or whatever    
        }


        private void UpdateProgressBar(AudioHandle audioHandle)
        {
            while (!encodeTask.IsCompleted)
            {
                if (Globals.Instance.tokenSource.Token.IsCancellationRequested)
                {
                    Globals.Instance.tokenSource.Token.ThrowIfCancellationRequested();
                }

                this.Invoke((MethodInvoker)delegate
                {
                    if (audioHandle.IsRemoteURL == false)
                    {
                        toolStripProgressBarFile.Value = myEncoder.Percentage;
                        toolStripLabelMessage.Text = string.Format("{0}%", myEncoder.Percentage);
                    }
                    else
                        toolStripLabelMessage.Text = "N/A";
                });
                Thread.Sleep(this.msUpdateBar);
            }
        }


        private void EncodingFinished(Task obj)
        {
            //Task<string> t = (Task<string>)obj;

            this.Invoke((MethodInvoker)delegate
            {
                saveToolStripButton.ToolTipText = "Save";

                PSAudioUtils.ChangeImageButton(saveToolStripButton, "save_tool");

                toolStripProgressBarFile.Value = toolStripProgressBarFile.Maximum;

                toolStripLabelMessage.Text = "Ready";

                toolStripLabelStatusEncode.Text = string.Empty;
            });
        }

        //private class EncArgument
        //{
        //    public string FilenameOutput { get; set; }
        //    public float Speed { get; set; }
        //    public float Pitch { get; set; }
        //    public int BitRate { get; set; }
        //    public string Filename { get; set; }

        //}

        private void PSAudioForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Bass.FreeMe();
            BassFx.FreeMe();
            BassWma.FreeMe();
            BassCd.FreeMe();
            BassFlac.FreeMe();
            BassAac.FreeMe();
            BassMpc.FreeMe();
        }

        private void StoreAudioSettings()
        {
            AudioSettings settings = Settings.Default.AudioSettings;

            settings.TrackList = AudioPlayer.Instance.TrackList;

            settings.LastTrack = AudioPlayer.Instance.CurrentTrackIndex;
            settings.Pan = this.trackBarPan.Value;
            settings.Volume = this.trackBarVol.Value;
            settings.Pitch = this.trackBarPitch.Value;
            settings.Speed = this.trackBarSpeed.Value;

            settings.EQ[0] = this.userControlMixer1.Value;
            settings.EQ[1] = this.userControlMixer2.Value;
            settings.EQ[2] = this.userControlMixer3.Value;
            settings.EQ[3] = this.userControlMixer4.Value;
            settings.EQ[4] = this.userControlMixer5.Value;

            string waveFormFile = GetWaveformFilePath();

            if (waveForm != null && waveForm.IsRendered)
                waveForm.WaveFormSaveToFile(waveFormFile, true);
            else
                if (File.Exists(waveFormFile))
                    File.Delete(waveFormFile);


            Settings.Default.Save();
        }

        private string GetWaveformFilePath()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string appPath = Path.GetDirectoryName(assembly.Location);
            string waveFormFile = Path.Combine(appPath, "last.wf");

            return waveFormFile;
        }

        private void PSAudioForm_DragDrop(object sender, DragEventArgs e)
        {
            // transfer the filenames to a string array
            // (yes, everything to the left of the "=" can be put in the 
            // foreach loop in place of "files", but this is easier to understand.)

            AudioPlayer.Instance.ResetTrackList();

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {

                if (Utils.BASSAddOnIsFileSupported(Globals.Instance.PluginsLoaded, file))
                {
                    Track track = Track.GetTrack(file);

                    AudioPlayer.Instance.TrackList.Tracks.Add(track);

                    // load file
                    //this.LoadFile(file, true);
                }
                else if (PSAudioUtils.IsPlaylist(file))
                {
                    AudioPlayer.Instance.OpenPlaylistFile(file);
                }
            }

            if (AudioPlayer.Instance.TrackList.Tracks.Count > 0)
            {
                AudioPlayer.Instance.CurrentTrackIndex = 0;
                AudioPlayer.Instance.Play(true);
            }

        }

        //private void ResetTrackList()
        //{
        //    AudioPlayer.Instance.CurrentTrackIndex = -1;

        //    AudioPlayer.Instance.TrackList.Tracks.Clear();
        //}

        private void PSAudioForm_DragEnter(object sender, DragEventArgs e)
        {
            // make sure they're actually dropping files (not text or anything else)
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                // allow them to continue
                // (without this, the cursor stays a "NO" symbol
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                foreach (string file in files)
                {
                    if (Utils.BASSAddOnIsFileSupported(Globals.Instance.PluginsLoaded, file) || PSAudioUtils.IsPlaylist(file))
                    {
                        e.Effect = DragDropEffects.All;
                        break;
                    }
                }
            }
        }

        private void btnAdvanced_Click(object sender, EventArgs e)
        {
            //    if (isExpanded)
            //    {
            //        this.Width = this.standardWidth;
            //        this.Height = this.standardHeight;
            //    }
            //    else
            //    {
            //        this.Width = this.expandedWidth;
            //        this.Height = this.expandedHeight;
            //    }

            //    isExpanded = !isExpanded;
            //    if (isExpanded)
            //        PSAudioUtils.ChangeImageButton(this.btnAdvanced, "star_full");
            //    else
            //        PSAudioUtils.ChangeImageButton(this.btnAdvanced, "star_empty");
        }


        private void optionsToolStripButton_Click(object sender, EventArgs e)
        {
            OpenSettings();
        }

        private void OpenSettings()
        {
            PreferencesForm settingsForm = new PreferencesForm();
            settingsForm.ShowDialog();
        }


        private void toolStripComboBoxFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<ENCODING_FORMAT, string> selectedFormat = (KeyValuePair<ENCODING_FORMAT, string>)((ToolStripComboBox)sender).SelectedItem;

            this.toolStripComboBoxRates.Enabled = selectedFormat.Key == ENCODING_FORMAT.WMA;
        }

        private void pictureBoxWF_Resize(object sender, EventArgs e)
        {
            DrawWave();
        }

        private int _syncer = 0;
        private SYNCPROC _sync = null;

        private void pictureBoxWF_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void pictureBoxWF_MouseUp(object sender, MouseEventArgs e)
        {
            toolTip.Hide(this);

            if (waveForm == null)
                return;

            ghostCursorPosition = -1;

            if (e.Button == MouseButtons.Left)
            {
                long pos = waveForm.GetBytePositionFromX(e.X, this.pictureBoxWF.Width, -1, -1);
                Bass.BASS_ChannelSetPosition(AudioPlayer.Instance.CurrentAudioHandle.CurrentHandle, pos);

                if (Control.ModifierKeys == Keys.Control)
                {
                    // set Start marker
                    SetStartMarker(pos);
                    DrawWave();
                }
            }
            else if (e.Button == MouseButtons.Right && Control.ModifierKeys == Keys.Control)
            {
                // hides context menu
                contextMenuStripWave.Hide();

                long pos = waveForm.GetBytePositionFromX(e.X, this.pictureBoxWF.Width, -1, -1);
                // set End marker
                SetEndMarker(pos);
                DrawWave();
            }
        }

        private void SetStartMarker(long pos)
        {
            long endpos = -1;

            waveForm.AddMarker("START", pos);
            if (waveForm.Wave.marker.ContainsKey("END"))
            {
                endpos = waveForm.Wave.marker["END"];
                if (endpos < pos)
                {
                    waveForm.RemoveMarker("END");
                }
            }

            //UpdateLoopLabels(waveForm.Wave.marker);

            userControlAudioDisplay.RefreshLoop(waveForm.Wave.marker);
        }

        private void SetEndMarker(long pos)
        {
            long startpos = -1;

            waveForm.AddMarker("END", pos);
            Bass.BASS_ChannelRemoveSync(AudioPlayer.Instance.CurrentAudioHandle.CurrentHandle, _syncer);
            _syncer = Bass.BASS_ChannelSetSync(AudioPlayer.Instance.CurrentAudioHandle.CurrentHandle, BASSSync.BASS_SYNC_POS, pos, _sync, IntPtr.Zero);
            if (waveForm.Wave.marker.ContainsKey("START"))
            {
                startpos = waveForm.Wave.marker["START"];
                if (startpos > pos)
                {
                    waveForm.RemoveMarker("START");
                }
            }

            //UpdateLoopLabels(waveForm.Wave.marker);

            userControlAudioDisplay.RefreshLoop(waveForm.Wave.marker);
        }

        //private void UpdateLoopLabels(Dictionary<string, long> marker)
        //{
        //    string starttime = string.Empty;
        //    string endtime = string.Empty;

        //    if (marker != null)
        //    {
        //        if (marker.ContainsKey("START"))
        //            starttime = String.Format("[{0}]", Utils.FixTimespan(Bass.BASS_ChannelBytes2Seconds(AudioPlayer.Instance.CurrentAudioHandle.HandleFX, marker["START"]), "MMSS"));

        //        if (marker.ContainsKey("END"))
        //            endtime = String.Format("[{0}]", Utils.FixTimespan(Bass.BASS_ChannelBytes2Seconds(AudioPlayer.Instance.CurrentAudioHandle.HandleFX, marker["END"]), "MMSS"));
        //    }

        //    this.labelSLoop.Text = starttime;
        //    this.labelELoop.Text = endtime;
        //}

        private void pictureBoxWF_MouseMove(object sender, MouseEventArgs e)
        {
            if (waveForm == null)
                return;

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                long pos = waveForm.GetBytePositionFromX(e.X, this.pictureBoxWF.Width, -1, -1);
                ghostCursorPosition = pos;
            }
        }

        private void buttonStartLoop_Click(object sender, EventArgs e)
        {
            if (waveForm == null)
                return;

            long pos = AudioPlayer.Instance.Position;

            SetStartMarker(pos);
            DrawWave();
        }

        private void buttonEndLoop_Click(object sender, EventArgs e)
        {
            if (waveForm == null)
                return;

            //long pos = Bass.BASS_ChannelGetPosition(AudioPlayer.Instance.CurrentHandle.HandleFX);

            long pos = AudioPlayer.Instance.Position;

            SetEndMarker(pos);
            DrawWave();

            RepeatLoop();
        }

        private void buttonRepeatLoop_Click(object sender, EventArgs e)
        {
            RepeatLoop();
        }

        private void RepeatLoop()
        {
            if (waveForm != null && waveForm.Wave.marker != null)
            {
                SetPosition(-1, AudioPlayer.Instance.CurrentAudioHandle.CurrentHandle, 0, IntPtr.Zero);

                BASSActive currentAction = Bass.BASS_ChannelIsActive(AudioPlayer.Instance.CurrentAudioHandle.CurrentHandle);

                if (currentAction != BASSActive.BASS_ACTIVE_PLAYING)
                {
                    AudioPlayer.Instance.Play(false);
                }
            }

        }

        private void PSAudioForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StoreAudioSettings();
        }

        private void buttonRemoveLoop_Click(object sender, EventArgs e)
        {
            RemoveLoop();
        }

        private void RemoveLoop()
        {
            if (waveForm != null && waveForm.Wave.marker != null)
            {
                waveForm.Wave.marker.Remove("START");
                waveForm.Wave.marker.Remove("END");
                Bass.BASS_ChannelRemoveSync(AudioPlayer.Instance.CurrentAudioHandle.CurrentHandle, _syncer);
                DrawWave();
                //UpdateLoopLabels(waveForm.Wave.marker);

                userControlAudioDisplay.RefreshLoop(waveForm.Wave.marker);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowTrackListForm();
        }

        private void InitTrackListForm()
        {
            if (tracklistForm == null || tracklistForm.IsDisposed)
            {
                tracklistForm = new PSTrackListForm();

                //trackListForm.TrackSelected += new PSAudioTrackListForm.DelegateTrackSelected(OnTrackSelected);
            }
        }

        private void ShowTrackListForm()
        {
            InitTrackListForm();

            //if (trackListForm.Visible == false)
            //    trackListForm.Show(this);
            //else
            //    trackListForm.Hide();
        }

        private void OnTrackSelected(int track)
        {
            //currentTrack = track;
            //prepareNextTrack = true;
            Stop();
        }

        private void toolStripLabelTempo_Click(object sender, EventArgs e)
        {
            DetectBPM();
        }

        private void trackBarSpeed_ValueChanged(object sender, EventArgs e)
        {
            int value = (100 + trackBarSpeed.Value);

            string message = String.Format("{0}%", value);

            labelSpeedValue.Text = message;

            toolTip.SetToolTip(trackBarSpeed, message);
        }

        private void trackBarPitch_ValueChanged(object sender, EventArgs e)
        {
            int value = trackBarPitch.Value;

            string message = String.Format("{0}", value);

            labelPitchValue.Text = message;

            toolTip.SetToolTip(trackBarPitch, message);
        }

        private void buttonTrackList_Click(object sender, EventArgs e)
        {
            //if (tracklistForm == null)
            //    tracklistForm = new PSTrackListForm();

            if (tracklistForm.Visible)
                tracklistForm.Hide();
            else
                tracklistForm.Show();
        }

        private void contextMenuStripWave_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (AudioPlayer.Instance.CurrentAudioHandle.Handle == 0)
                e.Cancel = true;
        }

        private void buttonBackward_Click(object sender, EventArgs e)
        {
            AudioPlayer.Instance.Backward(true);
            AudioPlayer.Instance.Play(true);
        }

        private void buttonForward_Click(object sender, EventArgs e)
        {
            AudioPlayer.Instance.Forward(true);
            AudioPlayer.Instance.Play(true);
        }

        private void PSAudioForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.Right:
                        buttonForward_Click(sender, null);
                        break;
                    case Keys.Left:
                        buttonBackward_Click(sender, null);
                        break;                    
                }
            }
        }

        private void btnOpen_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                contextMenuStripForm.Hide();
                OpenDirectoryDialog();
            }
            
        }

        private void OpenDirectoryDialog()
        {
            try
            {
                string startupPath = Application.StartupPath;
                using (FolderBrowserDialog dialog = new FolderBrowserDialog())
                {
                    //dialog.Description = "Open folder";
                    dialog.ShowNewFolderButton = false;                    
                    //dialog.RootFolder = Environment.SpecialFolder.MyComputer;
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        string supp = Utils.BASSAddOnGetSupportedFileExtensions(Globals.Instance.PluginsLoaded, true);
                        string folder = dialog.SelectedPath;

                        AudioPlayer.Instance.ResetTrackList();

                        string[] filesInPath = Directory.GetFiles(folder, "*", SearchOption.AllDirectories);

                        List<Track> tracks = new List<Track>();

                        foreach (string path in filesInPath)
                        {
                            if (Utils.BASSAddOnIsFileSupported(Globals.Instance.PluginsLoaded, path))
                            {
                                Track track = Track.GetTrack(path, false);

                                tracks.Add(track);
                            }
                            else if (PSAudioUtils.IsPlaylist(path))
                            {
                                AudioPlayer.Instance.OpenPlaylistFile(path);
                            }
                        }

                        AudioPlayer.Instance.TrackList.Tracks.AddRange(tracks);

                        if (AudioPlayer.Instance.TrackList.Tracks.Count > 0)
                        {
                            AudioPlayer.Instance.CurrentTrackIndex = 0;                            
                            AudioPlayer.Instance.Play(true);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Import failed because " + exc.Message + " , please try again later.");
            }


            
            
        }

        private void toolStripButtonLastfm_Click(object sender, EventArgs e)
        {
            if (formTagService == null || formTagService.IsDisposed)
                formTagService = new FormTagServiceSearch();            

            formTagService.Show();
        }

    }
}
