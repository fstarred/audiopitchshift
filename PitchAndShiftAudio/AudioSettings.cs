using AudioController;
using System.Configuration;

namespace PitchAndShiftAudio
{
    /*
     * IMPORTANT: All serializing objects must have public accessors on its properties
     * */
    [SettingsSerializeAs(System.Configuration.SettingsSerializeAs.Xml)]
    public class AudioSettings
    {
        public AudioSettings()
        {
            // default settings
            this.Volume = 50;
            this.EQ = new int[5];
            this.TrackList = new TrackList();
        }

        public int Volume { get; set; }
        public int[] EQ { get; set; }
        public int Pan { get; set; }
        public int Pitch { get; set; }
        public int Speed { get; set; }
        public int LastTrack { get; set; }
        public TrackList TrackList { get; set; }
    }
}
