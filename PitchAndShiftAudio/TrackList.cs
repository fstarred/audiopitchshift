using System;
using System.Collections.Generic;
using System.Configuration;
using Un4seen.Bass.AddOn.Tags;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Un4seen.Bass;

namespace AudioController
{

    [SettingsSerializeAs(System.Configuration.SettingsSerializeAs.Xml)]
    public class TrackList : SettingAttribute
    {
        public TrackList()
        {
            this.tracks = new ObservableCollectionExt<Track>();
        }

        protected ObservableCollectionExt<Track> tracks;

        public ObservableCollectionExt<Track> Tracks
        {
            get
            {
                return tracks;
            }
        }

    }


    public class ObservableCollectionExt<T> : ObservableCollection<T>
    {
        private bool fireCollectionChanged = true;

        public ObservableCollectionExt()
            : base()
        {
            
        }

        public void AddRange(IEnumerable<T> collection)
        {
            foreach (var i in collection) 
                Items.Add(i);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public void RemoveRange(IEnumerable<T> collection)
        {
            foreach (var i in collection) 
                Items.Remove(i);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        /*
         * if refreshCurrentIndex = false, clear collection without firing OnCollectionChanged,
         * in order to leave the current track playing
         * */
        public void Clear(bool refreshCurrentIndex)
        {
            this.fireCollectionChanged = refreshCurrentIndex;
            base.ClearItems();
            this.fireCollectionChanged = true;
        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (fireCollectionChanged)
                base.OnCollectionChanged(e);
        }

        protected override void ClearItems()
        {
            base.ClearItems();
        }
    }
        

    public class Track : ICloneable
    {

        // Provide an "Explicit Interface Method Implementation"
        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public Track Clone()
        {
            return (Track)this.MemberwiseClone();
        }


        public static Track GetTrack(string path, bool loadInfo = true)
        {

            Track track = new Track();

            track.Location = path;

            if (loadInfo)
                LoadTrackInfo(track);

            return track;
        }

        protected Track()
        {
        }



        public static void LoadTrackInfo(Track track)
        {
            bool isURL = false;

            int stream = Bass.BASS_StreamCreateFile(track.Location, 0L, 0L, BASSFlag.BASS_STREAM_DECODE | BASSFlag.BASS_SAMPLE_MONO);

            if (stream == 0)
            {
                stream = Bass.BASS_MusicLoad(track.Location, 0L, 0, BASSFlag.BASS_STREAM_DECODE | BASSFlag.BASS_SAMPLE_MONO | BASSFlag.BASS_MUSIC_PRESCAN, 0);
            }

            if (stream == 0)
            {
                stream = Bass.BASS_StreamCreateURL(track.Location, 0, BASSFlag.BASS_STREAM_DECODE, null, IntPtr.Zero);
                if (stream != 0) isURL = true;
            }

            TAG_INFO tagInfo = new TAG_INFO();

            bool isTagAvailable = false;
            
            isTagAvailable = isURL ? BassTags.BASS_TAG_GetFromURL(stream, tagInfo) : BassTags.BASS_TAG_GetFromFile(stream, tagInfo);
            
            double length = Bass.BASS_ChannelBytes2Seconds(stream, Bass.BASS_ChannelGetLength(stream));

            track.Artist = tagInfo.artist;

            track.Album = tagInfo.album;

            track.Title = tagInfo.title;

            track.Length = length;

            Bass.BASS_StreamFree(stream);
        }

        public string Location { get; set; }

        public string Title { get; set; }

        public string Artist { get; set; }

        public string Album { get; set; }

        public double Length { get; set; }
    }    


}
