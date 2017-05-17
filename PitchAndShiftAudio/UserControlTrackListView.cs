using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Un4seen.Bass;
using System.Threading.Tasks;
using System.IO;
using AudioController;

namespace PitchAndShiftAudio
{
    public partial class UserControlTrackListView : UserControl
    {
        public UserControlTrackListView()
        {
            InitializeComponent();
        }

        void Tracks_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            RefreshListView();

            RefreshListViewPosition();

            ObservableCollectionExt<Track> tracks = AudioPlayer.Instance.TrackList.Tracks;

            // if current track was not deleted, refresh the items on the playlist
            if (AudioPlayer.Instance.CurrentTrackIndex >= 0)
                OnTrackChanged();
        }

        void OnTrackChanged()
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (AudioPlayer.Instance.CurrentAudioHandle.IsRemoteURL)
                    RefreshItemInfo(this.listViewTrackList.Items[AudioPlayer.Instance.CurrentTrackIndex]);

                foreach (ListViewItem lwi in listViewTrackList.Items)
                {
                    lwi.BackColor = Color.Black;
                }

                int currentTrackIndex = AudioPlayer.Instance.CurrentTrackIndex;

                if (currentTrackIndex >= 0 && listViewTrackList.Items.Count > currentTrackIndex)
                    listViewTrackList.Items[currentTrackIndex].BackColor = Color.Gray;

            });
        }

        public void RefreshListViewPosition()
        {
            for (int i = 0; i < this.listViewTrackList.Items.Count; i++)
            {
                this.listViewTrackList.Items[i].SubItems[0].Text = (i + 1).ToString();
            }
        }

        private void listViewTrackList_ItemDrag(object sender, ItemDragEventArgs e)
        {
            listViewTrackList.DoDragDrop(listViewTrackList.SelectedItems, DragDropEffects.Move);
        }

        private void listViewTrackList_DragEnter(object sender, DragEventArgs e)
        {
            int len = e.Data.GetFormats().Length - 1;
            
            if (e.Data.GetDataPresent("System.Windows.Forms.ListView+SelectedListViewItemCollection"))
            {
                e.Effect = DragDropEffects.Move;
            }
            else if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                // allow them to continue
                // (without this, the cursor stays a "NO" symbol
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                foreach (string file in files)
                {
                    if (Utils.BASSAddOnIsFileSupported(Globals.Instance.PluginsLoaded, file)
                        || PSAudioUtils.IsPlaylist(file))
                    {
                        e.Effect = DragDropEffects.All;
                        return;
                    }
                }
            }
        }

        private void listViewTrackList_DragDrop(object sender, DragEventArgs e)
        {

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (e.Data.GetDataPresent("System.Windows.Forms.ListView+SelectedListViewItemCollection"))
            {
                DragDropListViewItem(sender, e);
            }
            else if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                DragDropFiles(sender, e);
            }
        }

        private void DragDropFiles(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            List<Track> tracks = new List<Track>();

            foreach (string file in files)
            {
                if (Utils.BASSAddOnIsFileSupported(Globals.Instance.PluginsLoaded, file))
                {
                    tracks.Add(Track.GetTrack(file, false));
                }
                else if (PSAudioUtils.IsPlaylist(file))
                {
                    AudioPlayer.Instance.OpenPlaylistFile(file);
                }
            }

            AudioPlayer.Instance.TrackList.Tracks.AddRange(tracks);
        }


        private void DragDropListViewItem(object sender, DragEventArgs e)
        {
            List<Track> allTracks = new List<Track>(AudioPlayer.Instance.TrackList.Tracks);

            //Return if the items are not selected in the ListView control.
            if (listViewTrackList.SelectedItems.Count == 0)
            {
                return;
            }
            //Returns the location of the mouse pointer in the ListView control.
            Point cp = listViewTrackList.PointToClient(new Point(e.X, e.Y));
            //Obtain the item that is located at the specified location of the mouse pointer.
            ListViewItem dragToItem = listViewTrackList.GetItemAt(cp.X, cp.Y);
            if (dragToItem == null)
            {
                return;
            }
            //Obtain the index of the item at the mouse pointer.
            int dragIndex = dragToItem.Index;
            ListViewItem[] sel = new ListViewItem[listViewTrackList.SelectedItems.Count];

            Track[] tracks = new Track[listViewTrackList.SelectedItems.Count];

            for (int i = 0; i <= listViewTrackList.SelectedItems.Count - 1; i++)
            {
                sel[i] = listViewTrackList.SelectedItems[i];
                tracks[i] = AudioPlayer.Instance.TrackList.Tracks[listViewTrackList.Items.IndexOf(sel[i])];
            }
            for (int i = 0; i < sel.GetLength(0); i++)
            {
                //Obtain the ListViewItem to be dragged to the target location.
                ListViewItem dragItem = sel[i];
                int itemIndex = dragIndex;
                if (itemIndex == dragItem.Index)
                {
                    return;
                }
                if (dragItem.Index < itemIndex)
                    itemIndex++;
                else
                    itemIndex = dragIndex + i;

                Track dragTrack = tracks[i];

                Track insertItem = dragTrack.Clone();
                allTracks.Insert(itemIndex, insertItem);
                allTracks.Remove(dragTrack);
                //AudioPlayer.Instance.TrackList.Tracks.Insert(itemIndex, insertItem);
                //AudioPlayer.Instance.TrackList.Tracks.Remove(dragTrack);
            }

            AudioPlayer.Instance.TrackList.Tracks.Clear(false);
            AudioPlayer.Instance.TrackList.Tracks.AddRange(allTracks);
        }

        private void UpdateTrackInfo(Track track)
        {
            if (this.IsDisposed == false)
                this.Invoke((MethodInvoker)delegate
                {
                    int index = AudioPlayer.Instance.TrackList.Tracks.IndexOf(track);

                    if (index >= 0)
                    {
                        this.listViewTrackList.Items[index].SubItems[1].Text = string.IsNullOrEmpty(track.Title) ? Path.GetFileName(track.Location) : track.Title;
                        this.listViewTrackList.Items[index].SubItems[2].Text = track.Artist;
                        this.listViewTrackList.Items[index].SubItems[3].Text = Utils.FixTimespan(track.Length, "MMSS");
                    }

                });
        }

        public void RefreshItemInfo(ListViewItem lvi)
        {
            Track track = (Track)lvi.Tag;

            LoadAndUpdateTrackInfo(track);
        }

        public void RefreshListView()
        {
            this.Invoke((MethodInvoker)delegate
            {

                listViewTrackList.Items.Clear();

                //Func<Track, Track> loadTrackInfo = delegate(Track obj) { obj.LoadTrackInfo(); return obj; };

                foreach (Track item in AudioPlayer.Instance.TrackList.Tracks)
                {
                    ListViewItem lvi = new ListViewItem(new string[]{ 
                        (listViewTrackList.Items.Count+1).ToString(), 
                        string.IsNullOrEmpty( item.Title ) ? Path.GetFileName(item.Location) : item.Title,
                        item.Artist, 
                        Utils.FixTimespan(item.Length, "MMSS"),
                        item.Location
                    });

                    lvi.Tag = item;

                    this.listViewTrackList.Items.Add(lvi);

                    //Task.Factory.StartNew(() => loadTrackInfo(item)).ContinueWith(o => UpdateTrackInfo(((Task<Track>)o).Result));

                    LoadAndUpdateTrackInfo(item);
                }

            });
        }

        // This asynchronous task prevents the freezing of the filling list 
        private void LoadAndUpdateTrackInfo(Track item)
        {
            Task.Factory.StartNew(() => Track.LoadTrackInfo(item)).ContinueWith(o => UpdateTrackInfo(item));
        }

        private void listViewTrackList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListView listView = (ListView)sender;

            if (listView.SelectedItems.Count > 0)
            {
                //AudioPlayer.Instance.CurrentTrack = (Track)listView.SelectedItems[0].Tag;

                AudioPlayer.Instance.CurrentTrackIndex = listView.SelectedIndices[0];

                AudioPlayer.Instance.Play(true);
            }

        }

        public delegate void DelegateTrackSelected(int selectedTrack);

        public event DelegateTrackSelected TrackSelected;

        // Invoke the TrackBarScroll event; 
        public void OnTrackSelected(object sender, EventArgs e)
        {
            if (TrackSelected != null)
                TrackSelected(listViewTrackList.SelectedIndices[0]);
        }

        public void Init()
        {
            AudioPlayer.Instance.TrackList.Tracks.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Tracks_CollectionChanged);

            AudioPlayer.Instance.TrackChanged += new AudioPlayer.delTrackChanged(OnTrackChanged);

            AudioPlayer.Instance.MetaUpdated += new AudioPlayer.delMetaUpdated(RefreshListView);

            RefreshListView();

            OnTrackChanged();

            //InitContextMenu();
        }

        //private void InitContextMenu()
        //{

        //}

        

        //private void updateMetaInfo(object sender, EventArgs e)
        //{
        //    foreach (ListViewItem item in listViewTrackList.SelectedItems)
        //    {
        //        Track track = (Track)item.Tag;

        //        RefreshItemInfo(item);
        //    }
        //}        


        //private void contextMenuStripListView_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        //{

        //}


    }

    
}
