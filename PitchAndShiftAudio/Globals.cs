using System.Net;
using System.Collections.Generic;
using System.Threading;
using Un4seen.Bass;

namespace PitchAndShiftAudio
{
    class Globals
    {
        //public WebProxy WebProxy { get; set; }

        private static Globals instance = new Globals();

        public const string URI_UPDATER = "http://dl.dropbox.com/u/55285635/audiops_updater.xml";

        public const string AppTitle = "Audio Pitch & Shift";

        public const string AppProgID = "AudioPitchShift";

        //public const string AppProgId = "AudioPS";

        public const string AppHomepage = "http://audiops.codeplex.com/";

        public CancellationTokenSource tokenSource;

        protected Globals()
        {
            
        }

        public static Globals Instance
        {            
            get { return instance; }
        }

        public Dictionary<int, string> PluginsLoaded;

        public string FileSupportedExtFilter;

        public BASS_DEVICEINFO[] Devices;

        //private static AudioPlayer audioPlayer;

        //public AudioPlayer AudioPlayer { get; private set; }
    }
}
