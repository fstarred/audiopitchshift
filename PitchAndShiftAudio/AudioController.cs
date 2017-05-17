using System;
using System.Collections.Generic;
using Un4seen.Bass;
using Un4seen.Bass.AddOn.Fx;
using Un4seen.Bass.AddOn.Tags;
using System.IO;
using System.Runtime.InteropServices;

namespace AudioController
{

    public class AudioPlayer
    {
        public delegate void delAudioHandleLoaded();

        public event delAudioHandleLoaded AudioHandleLoaded;
        
        public void OnAudioHandleLoaded(object sender, EventArgs e)
        {
            if (AudioHandleLoaded != null)
                AudioHandleLoaded();
        }

        public delegate void delTrackChanged();

        public event delTrackChanged TrackChanged;

        public void OnTrackChanged(object sender, EventArgs e)
        {
            if (TrackChanged != null)
                TrackChanged();
        }

        private SYNCPROC mySyncProcEnd;

        private SYNCPROC syncMetaUpdated;

        private int mySyncHandleEnd;

        private static AudioPlayer instance;

        private int device;

        public bool EnableTempo { get; set; }

        public int GetDevice()
        {
            return Bass.BASS_GetDevice();
        }

        public bool SetDevice(int device)
        {
            this.device = device;
            return true;
        }

        public static AudioPlayer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AudioPlayer();

                    instance.EnableTempo = true;

                    instance.currentAudioHandle = new AudioHandle();

                }

                return instance;
            }
        }

        static void Tracks_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            instance.CurrentTrackIndex = instance.TrackList.Tracks.IndexOf(instance.CurrentTrack);
        }

        private AudioHandle currentAudioHandle;

        public AudioHandle CurrentAudioHandle
        {
            get
            {
                if (currentAudioHandle == null)
                    currentAudioHandle = new AudioHandle();

                return currentAudioHandle;
            }
        }

        private TrackList tracklist = new TrackList();

        public TrackList TrackList
        {
            get
            {
                return tracklist;
            }
            set
            {
                tracklist = value;
                instance.tracklist.Tracks.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Tracks_CollectionChanged);
            }
        }

        // the pointer to the current track selected
        // it is useful to retrieve its new position when playlist got updates
        public Track CurrentTrack { get; private set; }

        private int currentTrackIndex;

        public int CurrentTrackIndex
        {
            get
            {
                return currentTrackIndex;
            }
            set
            {
                currentTrackIndex = value;

                Track lastTrack = CurrentTrack;

                if (currentTrackIndex >= 0 && currentTrackIndex < instance.tracklist.Tracks.Count)
                    CurrentTrack = instance.tracklist.Tracks[currentTrackIndex];
                else
                    CurrentTrack = null;

                // if track index changes, the track currently playing stops
                if (CurrentTrack == null || lastTrack != null && lastTrack.Equals(CurrentTrack) == false)
                {
                    if (instance.GetStreamStatus() != BASSActive.BASS_ACTIVE_STOPPED)
                        instance.Stop();

                    currentAudioHandle.FreeResources();
                }

                // fire event
                OnTrackChanged(this, null);
            }
        }

        public void SyncProcEndCallback(int handle, int channel, int data, IntPtr user)
        {
            Bass.BASS_ChannelRemoveSync(AudioPlayer.Instance.CurrentAudioHandle.CurrentHandle, mySyncHandleEnd);

            OnTrackEnded();
        }

        public void ResetTrackList()
        {
            this.CurrentTrackIndex = -1;

            this.TrackList.Tracks.Clear();
        }

        public void Forward(bool loop)
        {
            if (TrackList.Tracks.Count > 0)
            {
                int currentTrackIndex = instance.CurrentTrackIndex;

                if (currentTrackIndex < (TrackList.Tracks.Count - 1))
                    instance.CurrentTrackIndex++;
                else if (loop)
                    instance.CurrentTrackIndex = 0;
            }
        }

        public void Backward(bool loop)
        {
            if (TrackList.Tracks.Count > 0)
            {
                int currentTrackIndex = instance.CurrentTrackIndex;

                if (currentTrackIndex > 0)
                    CurrentTrackIndex--;
                else if (loop)
                    CurrentTrackIndex = TrackList.Tracks.Count - 1;

                
            }
        }

        public bool OpenPlaylistFile(string filename)
        {
            string ext = Path.GetExtension(filename);

            bool ret = false;

            if (ext.Equals(".pls", StringComparison.InvariantCultureIgnoreCase))
                ret = OpenPLSFile(filename);
            else if (ext.Equals(".m3u", StringComparison.InvariantCultureIgnoreCase))
                ret = OpenM3UFile(filename);

            return ret;
        }

        public static void SavePlaylist(string filename)
        {
            if (File.Exists(filename))
                File.Delete(filename);

            string ext = Path.GetExtension(filename);

            if (ext.Equals(".pls", StringComparison.InvariantCultureIgnoreCase))
                SavePLSFile(filename);
            else if (ext.Equals(".m3u", StringComparison.InvariantCultureIgnoreCase))
                SaveM3UFile(filename);
        }



        private bool OpenM3UFile(string filename)
        {
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(filename))
                {
                    string line;
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Substring(0, 1).Equals("#") == false)
                        {
                            Track track = Track.GetTrack(line, false);

                            this.TrackList.Tracks.Add(track);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return true;
        }

        private static void SaveM3UFile(string filename)
        {
            const string header = "#EXTM3U";
            const string extraInfo = "#EXTINF";

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(filename, true))
            {
                file.WriteLine(header);

                foreach (Track track in AudioPlayer.Instance.TrackList.Tracks)
                {
                    int seconds = (int)Math.Round(track.Length);
                    string artist = track.Artist;
                    string title = track.Title;
                    string location = track.Location;

                    string format = "{0}:{1},{2} - {3}";

                    file.WriteLine(String.Format(format, extraInfo, seconds.ToString(), artist, title));

                    file.WriteLine(location);
                }
            }


        }

        private bool OpenPLSFile(string filename)
        {
            const string section = "playlist";

            try
            {
                int totaltracks = int.Parse(IniFileHandler.IniReadValue(section, "NumberOfEntries", filename));

                for (int i = 1; i <= totaltracks; i++)
                {
                    string location = IniFileHandler.IniReadValue(section, string.Format("File{0}", i), filename);

                    Track track = Track.GetTrack(location, false);

                    this.TrackList.Tracks.Add(track);
                }

            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private static void SavePLSFile(string filename)
        {
            const string section = "playlist";

            int index = 0;

            foreach (Track track in AudioPlayer.Instance.TrackList.Tracks)
            {
                index++;

                IniFileHandler.IniWriteValue(section, string.Format("File{0}", index), track.Location, filename);
                IniFileHandler.IniWriteValue(section, string.Format("Title{0}", index), track.Title, filename);
                IniFileHandler.IniWriteValue(section, string.Format("Length{0}", index), track.Length.ToString(), filename);
            }

            IniFileHandler.IniWriteValue(section, "NumberOfEntries", AudioPlayer.Instance.TrackList.Tracks.Count.ToString(), filename);
            IniFileHandler.IniWriteValue(section, "Version", "2", filename);
        }

        public delegate void delMetaUpdated();

        public event delMetaUpdated MetaUpdated;

        public void OnMetaUpdated(object sender, EventArgs e)
        {
            if (MetaUpdated != null)
                MetaUpdated();
        }

        private void MetaSync(int handle, int channel, int data, IntPtr user)
        {
            TAG_INFO tagInfo = AudioPlayer.instance.currentAudioHandle.TagInfo;

            // BASS_SYNC_META is triggered on meta changes of SHOUTcast streams
            bool isUpdated = tagInfo.UpdateFromMETA(Bass.BASS_ChannelGetTags(channel, BASSTag.BASS_TAG_META), true, tagInfo.tagType == BASSTag.BASS_TAG_META);

            OnMetaUpdated(this, null);
        }

        public bool LoadAudio()
        {
            //prepareNextTrack = false;

            bool isStreamOk = false;

            try
            {
                if (CurrentTrack == null)
                    return false;

                if (GetDevice() != device)
                    Bass.BASS_SetDevice(device);

                currentAudioHandle.FreeResources();

                BASSFlag flagForHStream = BASSFlag.BASS_SAMPLE_FLOAT;
                BASSFlag flagForHMusic = BASSFlag.BASS_MUSIC_FLOAT | BASSFlag.BASS_MUSIC_PRESCAN | BASSFlag.BASS_MUSIC_POSRESETEX;
                BASSFlag flagForHStreamURL = BASSFlag.BASS_DEFAULT;

                if (EnableTempo)
                {
                    flagForHStream |= BASSFlag.BASS_STREAM_DECODE;
                    flagForHMusic |= BASSFlag.BASS_STREAM_DECODE;
                }
                
                currentAudioHandle.CreateHandle(CurrentTrack.Location, flagForHStream, flagForHMusic, flagForHStreamURL);

                if (EnableTempo == true)
                {
                    currentAudioHandle.CreateTempoHandle(currentAudioHandle.Handle, BASSFlag.BASS_DEFAULT);
                }

                if (currentAudioHandle.Handle == 0)
                {
                    return false;
                }

                bool isModule = currentAudioHandle.IsModule();

                if (currentAudioHandle.CurrentHandle == 0)
                    return false;

                //Bass.BASS_ChannelSetAttribute(AudioPlayer.Instance.CurrentHandle.HandleFX, BASSAttribute.BASS_ATTRIB_TEMPO_OPTION_PREVENT_CLICK, 1);
                //Bass.BASS_ChannelSetAttribute(AudioPlayer.Instance.CurrentHandle.HandleFX, BASSAttribute.BASS_ATTRIB_TEMPO_OPTION_SEQUENCE_MS, 82);
                //Bass.BASS_ChannelSetAttribute(AudioPlayer.Instance.CurrentHandle.HandleFX, BASSAttribute.BASS_ATTRIB_TEMPO_OPTION_SEEKWINDOW_MS, 14);
                //Bass.BASS_ChannelSetAttribute(AudioPlayer.Instance.CurrentHandle.HandleFX, BASSAttribute.BASS_ATTRIB_TEMPO_OPTION_OVERLAP_MS, 12);                

                mySyncProcEnd = new SYNCPROC(SyncProcEndCallback);

                mySyncHandleEnd = Bass.BASS_ChannelSetSync(currentAudioHandle.CurrentHandle, BASSSync.BASS_SYNC_END, 0, mySyncProcEnd, IntPtr.Zero);

                if (currentAudioHandle.IsRemoteURL)
                {
                    syncMetaUpdated = new SYNCPROC(MetaSync);
                    Bass.BASS_ChannelSetSync(currentAudioHandle.Handle, BASSSync.BASS_SYNC_META, 0, syncMetaUpdated, IntPtr.Zero);
                }

                isStreamOk = true;

                OnAudioHandleLoaded(this, null);

            }
            catch (Exception e)
            {
                isStreamOk = false;
            }

            return isStreamOk;

        }

        public delegate void DelegateStatusChanged();

        public event DelegateStatusChanged StatusChanged;

        public void OnStatusChanged()
        {
            if (StatusChanged != null)
                StatusChanged();
        }

        public delegate void DelegateTrackEnded();

        public event DelegateTrackEnded TrackEnded;

        public void OnTrackEnded()
        {
            if (TrackEnded != null)
                TrackEnded();
        }

        public bool Play(bool restart)
        {
            if (currentAudioHandle.Handle == 0)
                LoadAudio();

            bool status;

            status = Bass.BASS_ChannelPlay( currentAudioHandle.CurrentHandle, restart);

            OnStatusChanged();

            return status;
        }

        public bool Pause()
        {
            bool status = Bass.BASS_ChannelPause(currentAudioHandle.CurrentHandle);

            OnStatusChanged();

            return status;
        }

        public bool Stop()
        {
            bool status = Bass.BASS_ChannelStop(currentAudioHandle.CurrentHandle);

            //instance.Position = 0;

            Position = 0;

            OnStatusChanged();

            return status;
        }

        public BASSActive GetStreamStatus()
        {
            return Bass.BASS_ChannelIsActive(currentAudioHandle.CurrentHandle);
        }


        public string GetElapsedTime()
        {
            return String.Format(" {0}", Utils.FixTimespan(currentAudioHandle.GetElapsedTime(), "MMSS"));
        }

        public string GetTotalTime()
        {
            return Utils.FixTimespan(currentAudioHandle.LengthInSeconds, "MMSS");
        }

        public string GetRemainingTime()
        {
            return String.Format("-{0}", Utils.FixTimespan((currentAudioHandle.LengthInSeconds - currentAudioHandle.GetElapsedTime()), "MMSS"));
        }

        public long Position
        {
            get
            {
                return currentAudioHandle.Position;
            }
            set
            {
                currentAudioHandle.Position = value;
            }
        }

    }




    public class AudioHandle
    {
        private const int ReverbChain = 1;
        private const int EchoChain = 2;
        private const int ChorusChain = 3;
        private const int FlangerChain = 4;
        private const int DistortionChain = 5;

        public float originalBPM { get; private set; }

        private int[] fxEQ = { };

        private int fxChorusHandle = 0;
        private BASS_DX8_CHORUS chorus = new BASS_DX8_CHORUS();

        private int fxFlangerHandle = 0;
        private BASS_DX8_FLANGER flanger = new BASS_DX8_FLANGER();

        private int fxReverbHandle = 0;
        private BASS_DX8_REVERB reverb = new BASS_DX8_REVERB();

        private int fxEchoHandle = 0;
        private BASS_DX8_ECHO echo = new BASS_DX8_ECHO();

        private int fxDistortionHandle = 0;
        private BASS_DX8_DISTORTION distortion = new BASS_DX8_DISTORTION();

        public TAG_INFO TagInfo { get; set; }

        public BASS_CHANNELINFO ChannelInfo { get; private set; }

        public bool IsTagAvailable { get; set; }

        public int Handle { get; private set; }

        public int HandleFX { get; private set; }

        //public Ptr<int> CurrentHandle { get; private set; }

        public int CurrentHandle { get; private set; }

        public bool IsRemoteURL { get; set; }

        public bool IsTempoEnabled { get; private set; }

        public void FreeResources()
        {
            Bass.BASS_StreamFree(HandleFX);
            Bass.BASS_StreamFree(Handle);
            Handle = 0;
            HandleFX = 0;            
            IsRemoteURL = false;            
        }

        public void CreateHandle(string filename, BASSFlag flagSample, BASSFlag flagMusic, BASSFlag flagStream)
        {
            IsRemoteURL = false;

            // sample stream
            this.Handle = Bass.BASS_StreamCreateFile(filename, 0L, 0L, flagSample);

            // music stream
            if (this.Handle == 0)
            {
                // BASS_MUSIC_PRESCAN calculate the playback length of the music, and enable seeking in bytes
                this.Handle = Bass.BASS_MusicLoad(filename, 0L, 0, flagMusic, 0);

                if (this.Handle != 0)
                {
                    float bpm = 0;

                    Bass.BASS_ChannelGetAttribute(this.Handle, BASSAttribute.BASS_ATTRIB_MUSIC_BPM, ref bpm);

                    originalBPM = bpm;
                }
            }

            // streaming server
            if (this.Handle == 0)
            {
                this.Handle = Bass.BASS_StreamCreateURL(filename, 0, flagStream, null, IntPtr.Zero);
                if (this.Handle != 0) IsRemoteURL = true;
            }

            if (this.Handle != 0)
            {
                ChannelInfo = Bass.BASS_ChannelGetInfo(Handle);

                TagInfo = new TAG_INFO(filename);
                IsTagAvailable = IsRemoteURL ? BassTags.BASS_TAG_GetFromURL(Handle, TagInfo) : BassTags.BASS_TAG_GetFromFile(Handle, TagInfo);
            }

            this.CurrentHandle = this.Handle;

            //this.CurrentHandle = new Ptr<int>(() => this.Handle, v => this.Handle = v);
        }

        public void CreateTempoHandle(int stream, BASSFlag flag)
        {
            if (IsRemoteURL)
            {
                //this.HandleFX = this.Handle;
                
                this.LengthInBytes = 0;
                this.LengthInSeconds = 0;
            }
            else
            {
                this.HandleFX = BassFx.BASS_FX_TempoCreate(stream, flag);

                if (this.HandleFX != 0)
                {
                    this.LengthInBytes = Bass.BASS_ChannelGetLength(HandleFX);
                    this.LengthInSeconds = Bass.BASS_ChannelBytes2Seconds(HandleFX, this.LengthInBytes);

                    IsTempoEnabled = true;

                    this.CurrentHandle = this.HandleFX;

                    //this.CurrentHandle = new Ptr<int>(() => this.HandleFX, v => this.HandleFX = v);
                }
            }
        }

        //public void InitEQ(KeyValuePair<int, float>[] eqItems)
        //{
        //    fxEQ = new int[eqItems.Length];

        //    foreach (KeyValuePair<int, float> item in eqItems)
        //    {

        //        fxEQ[item.Key] = Bass.BASS_ChannelSetFX(CurrentHandle, BASSFXType.BASS_FX_DX8_PARAMEQ, 0);

        //        BASS_DX8_PARAMEQ eq = new BASS_DX8_PARAMEQ();
        //        eq.fCenter = item.Value;

        //        Bass.BASS_FXSetParameters(fxEQ[item.Key], eq);
        //    }
        //}

        public void InitEQ(float[] eqItems)
        {
            fxEQ = new int[eqItems.Length];

            for (int i=0; i<eqItems.Length; i++)
            {
                fxEQ[i] = Bass.BASS_ChannelSetFX(CurrentHandle, BASSFXType.BASS_FX_DX8_PARAMEQ, 0);

                BASS_DX8_PARAMEQ eq = new BASS_DX8_PARAMEQ();
                eq.fCenter = eqItems[i];

                Bass.BASS_FXSetParameters(fxEQ[i], eq);
            }
        }

        public void SetEQ(int index, float gain)
        {
            BASS_DX8_PARAMEQ eq = new BASS_DX8_PARAMEQ();
            if (fxEQ.Length > 0)
                if (Bass.BASS_FXGetParameters(fxEQ[index], eq))
                {
                    eq.fGain = gain;
                    Bass.BASS_FXSetParameters(fxEQ[index], eq);
                }
        }


        public void SetPan(float value)
        {
            BASSAttribute attrib;
            int stream;

            if (IsModule())
            {
                attrib = BASSAttribute.BASS_ATTRIB_MUSIC_PANSEP;
                stream = Handle;
            }
            else
            {
                attrib = BASSAttribute.BASS_ATTRIB_PAN;
                stream = CurrentHandle;
            }

            Bass.BASS_ChannelSetAttribute(stream, attrib, value);
        }

        public void SetChorusFX(float wetDryMix,
            float depth,
            float feedback,
            float frequency,
            int waveform,
            float delay,
            BASSFXPhase phase)
        {
            chorus.fWetDryMix = wetDryMix;
            chorus.fDepth = depth;
            chorus.fFeedback = feedback;
            chorus.fFrequency = frequency;
            chorus.lWaveform = waveform;
            chorus.fDelay = delay;
            chorus.lPhase = phase;

            Bass.BASS_FXSetParameters(fxChorusHandle, chorus);
        }


        public void SetFlangerFX(float wetDryMix,
            float depth,
            float feedback,
            float frequency,
            int waveform,
            float delay,
            BASSFXPhase phase)
        {
            flanger.fWetDryMix = wetDryMix;
            flanger.fDepth = depth;
            flanger.fFeedback = feedback;
            flanger.fFrequency = frequency;
            flanger.lWaveform = waveform;
            flanger.fDelay = delay;
            flanger.lPhase = phase;

            Bass.BASS_FXSetParameters(fxFlangerHandle, flanger);
        }


        public void SetReverbFX(
            float inGain,
            float reverbMix,
            float reverbTime,
            float highFreqRTRatio)
        {
            reverb.fInGain = inGain;
            reverb.fReverbMix = reverbMix;
            reverb.fReverbTime = reverbTime;
            reverb.fHighFreqRTRatio = highFreqRTRatio;

            Bass.BASS_FXSetParameters(fxReverbHandle, reverb);
        }


        public void SetEchoFX(
            float wetDryMix,
            float feedback,
            float leftDelay,
            float rightDelay,
            bool panDelay
        )
        {
            echo.fWetDryMix = wetDryMix;
            echo.fFeedback = feedback;
            echo.fLeftDelay = leftDelay;
            echo.fRightDelay = rightDelay;
            echo.lPanDelay = panDelay;

            Bass.BASS_FXSetParameters(fxEchoHandle, echo);
        }

        public void SetDistortionFX(
            float gain,
            float edge,
            float postEQCenterFrequency,
            float postEQBandwidth,
            float preLowpassCutoff
        )
        {
            distortion.fGain = gain;
            distortion.fEdge = edge;
            distortion.fPostEQCenterFrequency = postEQCenterFrequency;
            distortion.fPostEQBandwidth = postEQBandwidth;
            distortion.fPreLowpassCutoff = preLowpassCutoff;

            Bass.BASS_FXSetParameters(fxDistortionHandle, distortion);
        }

        public void ToggleChorus(bool enable, int chain = ChorusChain)
        {
            if (enable)
            {
                this.fxChorusHandle = Bass.BASS_ChannelSetFX(CurrentHandle, BASSFXType.BASS_FX_DX8_CHORUS, chain);
                Bass.BASS_FXSetParameters(fxChorusHandle, chorus);
            }
            else
                Bass.BASS_ChannelRemoveFX(CurrentHandle, fxChorusHandle);
        }

        public void ToggleFlanger(bool enable, int chain = FlangerChain)
        {
            if (enable)
            {
                this.fxFlangerHandle = Bass.BASS_ChannelSetFX(CurrentHandle, BASSFXType.BASS_FX_DX8_FLANGER, chain);
                Bass.BASS_FXSetParameters(fxFlangerHandle, flanger);
            }
            else
                Bass.BASS_ChannelRemoveFX(CurrentHandle, fxFlangerHandle);
        }


        public void ToggleEcho(bool enable, int chain = EchoChain)
        {
            if (enable)
            {
                this.fxEchoHandle = Bass.BASS_ChannelSetFX(CurrentHandle, BASSFXType.BASS_FX_DX8_ECHO, chain);
                Bass.BASS_FXSetParameters(fxEchoHandle, echo);
            }
            else
                Bass.BASS_ChannelRemoveFX(CurrentHandle, fxEchoHandle);
        }

        public void ToggleDistortion(bool enable, int chain = DistortionChain)
        {
            if (enable)
            {
                this.fxDistortionHandle = Bass.BASS_ChannelSetFX(CurrentHandle, BASSFXType.BASS_FX_DX8_DISTORTION, chain);

                Bass.BASS_FXSetParameters(fxDistortionHandle, distortion);
            }
            else
                Bass.BASS_ChannelRemoveFX(CurrentHandle, fxDistortionHandle);
        }


        public void SetVolume(float volume)
        {
            bool isModule = IsModule();

            //forced to false
            isModule = false;

            BASSAttribute attrib;
            int stream;

            if (isModule)
            {
                attrib = BASSAttribute.BASS_ATTRIB_MUSIC_VOL_GLOBAL;
                stream = this.Handle;
            }
            else
            {
                attrib = BASSAttribute.BASS_ATTRIB_VOL;
                stream = this.CurrentHandle;
            }

            Bass.BASS_ChannelSetAttribute(stream, attrib, volume);
        }


        public void SetTempo(float tempo)
        {
            BASSAttribute attrib;
            int stream;

            attrib = BASSAttribute.BASS_ATTRIB_TEMPO;
            stream = CurrentHandle;
            
            Bass.BASS_ChannelSetAttribute(stream, attrib, tempo);
        }

        public void SetModuleBPM(float tempo)
        {
            if (IsModule())
            {
                BASSAttribute attrib = BASSAttribute.BASS_ATTRIB_MUSIC_BPM;
                int stream = Handle;

                Bass.BASS_ChannelSetAttribute(stream, attrib, tempo);
            }
        }

        public void SetPitch(float pitch)
        {
            // change the pitch (key) by one octave (12 semitones)
            if (!IsModule())
                Bass.BASS_ChannelSetAttribute(HandleFX, BASSAttribute.BASS_ATTRIB_TEMPO_PITCH, pitch);
        }


        public void ToggleReverb(bool enable, int chain = ReverbChain)
        {
            if (enable)
            {
                this.fxReverbHandle = Bass.BASS_ChannelSetFX(CurrentHandle, BASSFXType.BASS_FX_DX8_REVERB, chain);
                Bass.BASS_FXSetParameters(fxReverbHandle, reverb);
            }
            else
                Bass.BASS_ChannelRemoveFX(CurrentHandle, fxReverbHandle);
        }

        public long Position
        {
            get
            {
                return Bass.BASS_ChannelGetPosition(Handle);
            }
            set
            {
                Bass.BASS_ChannelSetPosition(Handle, (long)value);
            }
        }

        public long LengthInBytes { get; private set; }

        public double LengthInSeconds { get; private set; }

        public double GetElapsedTime()
        {
            return Bass.BASS_ChannelBytes2Seconds(Handle, Position);
        }

        public bool IsModule()
        {
            if (this.ChannelInfo == null) return false;

            return (ChannelInfo.ctype & BASSChannelType.BASS_CTYPE_MUSIC_MOD) == BASSChannelType.BASS_CTYPE_MUSIC_MOD;
        }


    }
}
