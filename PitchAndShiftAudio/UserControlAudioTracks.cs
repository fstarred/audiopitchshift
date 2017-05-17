using System;
using System.Drawing;
using System.Windows.Forms;
using Un4seen.Bass;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Collections;
using System.Collections.Generic;
using AudioController;

namespace PitchAndShiftAudio
{
    public partial class UserControlAudioTracks : UserControl
    {

        //private ContextMenuStrip contextMenuListItem = new ContextMenuStrip();

        public UserControlAudioTracks()
        {
            InitializeComponent();
        }


        //void Tracks_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        //{
        //    userControlTrackListView.RefreshListView();

        //    userControlTrackListView.RefreshListViewPosition();

        //    ObservableCollectionExt<Track> tracks = AudioPlayer.Instance.TrackList.Tracks;

        //    // if current track was not deleted, refresh the items on the playlist
        //    if (AudioPlayer.Instance.CurrentTrackIndex >= 0)
        //        OnTrackChanged();
        //    else
        //    {
        //        // select the first track if playlist contains almost one song
        //        //if (AudioPlayer.Instance.TrackList.Tracks.Count > 0)
        //        //    AudioPlayer.Instance.CurrentTrack = AudioPlayer.Instance.TrackList.Tracks[0];
        //        //else
        //        //    AudioPlayer.Instance.CurrentTrack = null;
        //    }
        //}

        //void OnTrackChanged()
        //{
        //    this.Invoke((MethodInvoker)delegate
        //    {
        //        int currentTrackIndex = AudioPlayer.Instance.CurrentTrackIndex;

        //        if (AudioPlayer.Instance.CurrentAudioHandle.IsRemoteURL && userControlTrackListView.listViewTrackList.Items.Count > currentTrackIndex)
        //            RefreshItemInfo(this.userControlTrackListView.listViewTrackList.Items[AudioPlayer.Instance.CurrentTrackIndex]);

        //        foreach (ListViewItem lwi in userControlTrackListView.listViewTrackList.Items)
        //        {
        //            lwi.BackColor = Color.Black;
        //        }

        //        if (currentTrackIndex >= 0 && userControlTrackListView.listViewTrackList.Items.Count > currentTrackIndex)
        //            userControlTrackListView.listViewTrackList.Items[currentTrackIndex].BackColor = Color.Gray;    
                
        //    });
        //}

        //private void RefreshListViewPosition()
        //{
        //    for (int i = 0; i < this.userControlTrackListView.listViewTrackList.Items.Count; i++)
        //    {
        //        this.userControlTrackListView.listViewTrackList.Items[i].SubItems[0].Text = (i + 1).ToString();
        //    }
        //}

        //private void userControloListViewTrackList_ItemDrag(object sender, ItemDragEventArgs e)
        //{
        //    userControlTrackListView.listViewTrackList.DoDragDrop(userControlTrackListView.listViewTrackList.SelectedItems, DragDropEffects.Move);
        //}

        //private void userControloListViewTrackList_DragEnter(object sender, DragEventArgs e)
        //{
        //    int len = e.Data.GetFormats().Length - 1;
        //    //int i;
        //    //for (i = 0; i <= len; i++)
        //    //{
        //    //    if (e.Data.GetFormats()[i].Equals("System.Windows.Forms.ListView+SelectedListViewItemCollection"))
        //    //    {
        //    //        //The data from the drag source is moved to the target.	
        //    //        e.Effect = DragDropEffects.Move;
        //    //    }
        //    //}
        //    if (e.Data.GetDataPresent("System.Windows.Forms.ListView+SelectedListViewItemCollection"))
        //    {
        //        e.Effect = DragDropEffects.Move;
        //    }
        //    else if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
        //    {
        //        // allow them to continue
        //        // (without this, the cursor stays a "NO" symbol
        //        string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

        //        foreach (string file in files)
        //        {
        //            if (Utils.BASSAddOnIsFileSupported(Globals.Instance.PluginsLoaded, file)
        //                || PSAudioUtils.IsPlaylist(file))
        //            {
        //                e.Effect = DragDropEffects.All;
        //                return;
        //            }
        //        }
        //    }
        //}

        //private void userControloListViewTrackList_DragDrop(object sender, DragEventArgs e)
        //{

        //    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

        //    if (e.Data.GetDataPresent("System.Windows.Forms.ListView+SelectedListViewItemCollection"))
        //    {
        //        DragDropListViewItem(sender, e);
        //    }
        //    else if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
        //    {
        //        DragDropFiles(sender, e);
        //    }
        //}

        //private void DragDropFiles(object sender, DragEventArgs e)
        //{
        //    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

        //    foreach (string file in files)
        //    {
        //        if (Utils.BASSAddOnIsFileSupported(Globals.Instance.PluginsLoaded, file))
        //        {
        //            //if (PSAudioUtils.IsModuleFile(file) == false)
        //            AudioPlayer.Instance.TrackList.Tracks.Add(Track.GetTrack(file, false));
        //        }
        //        else if (PSAudioUtils.IsPlaylist(file))
        //        {
        //            AudioPlayer.Instance.OpenPlaylistFile(file);
        //        }
        //    }
        //}


        //private void DragDropListViewItem(object sender, DragEventArgs e)
        //{
        //    //Return if the items are not selected in the ListView control.
        //    if (userControlTrackListView.listViewTrackList.SelectedItems.Count == 0)
        //    {
        //        return;
        //    }
        //    //Returns the location of the mouse pointer in the ListView control.
        //    Point cp = userControlTrackListView.listViewTrackList.PointToClient(new Point(e.X, e.Y));
        //    //Obtain the item that is located at the specified location of the mouse pointer.
        //    ListViewItem dragToItem = userControlTrackListView.listViewTrackList.GetItemAt(cp.X, cp.Y);
        //    if (dragToItem == null)
        //    {
        //        return;
        //    }
        //    //Obtain the index of the item at the mouse pointer.
        //    int dragIndex = dragToItem.Index;
        //    ListViewItem[] sel = new ListViewItem[userControlTrackListView.listViewTrackList.SelectedItems.Count];

        //    Track[] tracks = new Track[userControlTrackListView.listViewTrackList.SelectedItems.Count];

        //    for (int i = 0; i <= userControlTrackListView.listViewTrackList.SelectedItems.Count - 1; i++)
        //    {
        //        sel[i] = userControlTrackListView.listViewTrackList.SelectedItems[i];
        //        tracks[i] = AudioPlayer.Instance.TrackList.Tracks[userControlTrackListView.listViewTrackList.Items.IndexOf(sel[i])];
        //    }
        //    for (int i = 0; i < sel.GetLength(0); i++)
        //    {
        //        //Obtain the ListViewItem to be dragged to the target location.
        //        ListViewItem dragItem = sel[i];
        //        int itemIndex = dragIndex;
        //        if (itemIndex == dragItem.Index)
        //        {
        //            return;
        //        }
        //        if (dragItem.Index < itemIndex)
        //            itemIndex++;
        //        else
        //            itemIndex = dragIndex + i;

        //        Track dragTrack = tracks[i];

        //        Track insertItem = dragTrack.Clone();
        //        AudioPlayer.Instance.TrackList.Tracks.Insert(itemIndex, insertItem);
        //        AudioPlayer.Instance.TrackList.Tracks.Remove(dragTrack);
        //    }
        //}


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = Globals.Instance.FileSupportedExtFilter;
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                int filesAudioCount = 0;

                foreach (string file in openFileDialog.FileNames)
                {
                    if (PSAudioUtils.IsPlaylist(file) == false)
                    {
                        filesAudioCount++;
                    }
                }

                Track[] tracks = new Track[filesAudioCount];

                int index = 0;

                foreach (string path in openFileDialog.FileNames)
                {
                    if (Utils.BASSAddOnIsFileSupported(Globals.Instance.PluginsLoaded, path))
                    {
                        Track track = Track.GetTrack(path, false);

                        tracks[index++] = track;
                    }
                    else if (PSAudioUtils.IsPlaylist(path))
                    {
                        AudioPlayer.Instance.OpenPlaylistFile(path);
                    }
                }

                AudioPlayer.Instance.TrackList.Tracks.AddRange(tracks);

            }
        }

        private void UpdateTrackInfo(Track track)
        {
            if (this.IsDisposed == false)
                this.Invoke((MethodInvoker)delegate
                {
                    int index = AudioPlayer.Instance.TrackList.Tracks.IndexOf(track);

                    if (index >= 0 && index < this.userControlTrackListView.listViewTrackList.Items.Count )
                    {
                        this.userControlTrackListView.listViewTrackList.Items[index].SubItems[1].Text = string.IsNullOrEmpty(track.Title) ? Path.GetFileName(track.Location) : track.Title;
                        this.userControlTrackListView.listViewTrackList.Items[index].SubItems[2].Text = track.Artist;
                        this.userControlTrackListView.listViewTrackList.Items[index].SubItems[3].Text = Utils.FixTimespan(track.Length, "MMSS");
                    }

                });
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            Track[] tracks = new Track[userControlTrackListView.listViewTrackList.SelectedItems.Count];

            int index = 0;

            foreach (ListViewItem item in userControlTrackListView.listViewTrackList.SelectedItems)
            {
                tracks[index++] = (Track)item.Tag;

                if (item.Index == AudioPlayer.Instance.CurrentTrackIndex)
                {
                    AudioPlayer.Instance.Stop();
                }
                //AudioPlayer.Instance.TrackList.Tracks.Remove((Track)item.Tag);
            }

            AudioPlayer.Instance.TrackList.Tracks.RemoveRange(tracks);
        }

        //private void RefreshItemInfo(ListViewItem lvi)
        //{
        //    Track track = (Track)lvi.Tag;

        //    LoadAndUpdateTrackInfo(track);
        //}

        //private void RefreshListView()
        //{
        //    this.Invoke((MethodInvoker)delegate
        //    {
            
        //        userControlTrackListView.listViewTrackList.Items.Clear();

        //        //Func<Track, Track> loadTrackInfo = delegate(Track obj) { obj.LoadTrackInfo(); return obj; };

        //        foreach (Track item in AudioPlayer.Instance.TrackList.Tracks)
        //        {
        //            ListViewItem lvi = new ListViewItem(new string[]{ 
        //                (userControlTrackListView.listViewTrackList.Items.Count+1).ToString(), 
        //                string.IsNullOrEmpty( item.Title ) ? Path.GetFileName(item.Location) : item.Title,
        //                item.Artist, 
        //                Utils.FixTimespan(item.Length, "MMSS"),
        //                item.Location
        //            });

        //            lvi.Tag = item;

        //            this.userControlTrackListView.listViewTrackList.Items.Add(lvi);

        //            //Task.Factory.StartNew(() => loadTrackInfo(item)).ContinueWith(o => UpdateTrackInfo(((Task<Track>)o).Result));

        //            LoadAndUpdateTrackInfo(item);
        //        }

        //    });
        //}

        // This asynchronous task prevents the freezing of the filling list 
        //private void LoadAndUpdateTrackInfo(Track item)
        //{
        //    Task.Factory.StartNew(() => Track.LoadTrackInfo(item)).ContinueWith(o => UpdateTrackInfo(item));
        //}

        private void PSAudioTrackListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Settings.Default.Save();
        }

        //private void userControloListViewTrackList_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    ListView listView = (ListView)sender;

        //    if (listView.SelectedItems.Count > 0)
        //    {
        //        //AudioPlayer.Instance.CurrentTrack = (Track)listView.SelectedItems[0].Tag;

        //        AudioPlayer.Instance.CurrentTrackIndex = listView.SelectedIndices[0];

        //        AudioPlayer.Instance.Play(true);
        //    }
        //}

        public delegate void DelegateTrackSelected(int selectedTrack);

        public event DelegateTrackSelected TrackSelected;

        // Invoke the TrackBarScroll event; 
        public void OnTrackSelected(object sender, EventArgs e)
        {
            if (TrackSelected != null)
                TrackSelected(userControlTrackListView.listViewTrackList.SelectedIndices[0]);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void OpenFileLocation(object obj, EventArgs e)
        {
            string location = AudioPlayer.Instance.TrackList.Tracks[userControlTrackListView.listViewTrackList.SelectedItems[0].Index].Location;

            if (File.Exists(location))
            {
                Process.Start(new ProcessStartInfo("explorer.exe", "/select, " + location));
            }
        }

        public void RemoveTracksFromList(object obj, EventArgs e)
        {
            buttonRemove_Click(obj, e);
        }

        public void AddTracksFromList(object obj, EventArgs e)
        {
            buttonAdd_Click(obj, e);
        }

        public delegate void DelegateAlignClicked(object sender, EventArgs e);

        public event DelegateAlignClicked OnAlignClick;

        private void buttonAlign_Click(object sender, EventArgs e)
        {
            if (OnAlignClick != null)
                OnAlignClick(sender, e);
        }

        private void buttonTrash_Click(object sender, EventArgs e)
        {
            AudioPlayer.Instance.TrackList.Tracks.Clear();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            string filter = string.Format("{0} file (*{0})|*{0}|{1} file (*{1})|*{1}", ".pls", ".m3u"); // "wma file (*.wma)|*.wma";

            saveFileDialog.Filter = filter;
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                AudioPlayer.SavePlaylist(saveFileDialog.FileName);
            }
        }

        //private void LoadPlayList(string filename)
        //{
        //    const string section = "playlist";

        //    try
        //    {
        //        int totaltracks = int.Parse(IniFileHandler.IniReadValue(section, "NumberOfEntries", filename));

        //        for (int i = 1; i <= totaltracks; i++)
        //        {
        //            string location = IniFileHandler.IniReadValue(section, string.Format("File{0}", i), filename);

        //            Track track = Track.GetTrack(location, false);

        //            AudioPlayer.Instance.TrackList.Tracks.Add(track);
        //        }

        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("Error loading playlist", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Playlist (*.pls;*.m3u)|*.pls;*.m3u";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                AudioPlayer.Instance.TrackList.Tracks.Clear();

                AudioPlayer.Instance.OpenPlaylistFile(openFileDialog.FileName);
                //LoadPlayList(openFileDialog.FileName);
            }
        }

        public void Init()
        {
            //AudioPlayer.Instance.TrackList.Tracks.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Tracks_CollectionChanged);

            //AudioPlayer.Instance.TrackChanged += new AudioPlayer.delTrackChanged(OnTrackChanged);

            //AudioPlayer.Instance.MetaUpdated += new AudioPlayer.delMetaUpdated(userControlTrackListView.RefreshListView);

            AudioPlayer.Instance.StatusChanged += new AudioPlayer.DelegateStatusChanged(AudioPlayerStatusChanged);

            //userControlTrackListView.RefreshListView();

            userControlTrackListView.Init();

            //OnTrackChanged();

            InitContextMenu();

            AudioPlayerStatusChanged();
        }

        private void InitContextMenu()
        {
            //ResourceManager rm = Resources.ResourceManager;

            //ToolStripItem t = contextMenuListItem.Items.Add("Open file location", (Bitmap)rm.GetObject("open"), new EventHandler(OpenFileLocation));            
            //contextMenuListItem.Items.Add("Add to list", (Bitmap)rm.GetObject("add"), new EventHandler(buttonAdd_Click));
            //contextMenuListItem.Items.Add("Remove from list", (Bitmap)rm.GetObject("minus_circle"), new EventHandler(buttonRemove_Click));

            //contextMenuListItem.Items.Add(new ToolStripSeparator());

            //contextMenuListItem.Items.Add("Open playlist", (Bitmap)rm.GetObject("open"), new EventHandler(buttonLoad_Click));
            //contextMenuListItem.Items.Add("Save playlist", (Bitmap)rm.GetObject("save"), new EventHandler(buttonSave_Click));
            //contextMenuListItem.Items.Add("Clean playlist", (Bitmap)rm.GetObject("trash"), new EventHandler(buttonSave_Click));

            //contextMenuListItem.Items.Add(new ToolStripSeparator());            

            toolStripMenuItemOpenFileLocation.Click += new EventHandler(OpenFileLocation);
            toolStripMenuItemAdd.Click += new EventHandler(buttonAdd_Click);
            toolStripMenuItemRemove.Click += new EventHandler(buttonRemove_Click);
            toolStripMenuItemMetaInfo.Click += new EventHandler(updateMetaInfo);
        }

        private void updateMetaInfo(object sender, EventArgs e)
        {
            foreach (ListViewItem item in userControlTrackListView.listViewTrackList.SelectedItems)
            {
                Track track = (Track)item.Tag;

                userControlTrackListView.RefreshItemInfo(item);
            }
        }

        private void AudioPlayerStatusChanged()
        {
            const string IconPlay = "play_playlist";
            const string IconPausePlay = "play_pause_playlist";
            const string IconPause = "pause_playlist";            

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
                        break;
                }

                PSAudioUtils.ChangeImageButton(this.buttonPlay, iconToShow);
            });
        }

        private void UserControlAudioTracks_Load(object sender, EventArgs e)
        {
            //AudioPlayer.Instance.TrackList.Tracks.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Tracks_CollectionChanged);

            //AudioPlayer.Instance.AudioHandleLoaded += new AudioPlayer.delTrackChanged(OnTrackChanged);

            //RefreshListView();

            //OnTrackChanged();                        
        }

        #region todelete
        private void userControloListViewTrackList_MouseUp(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    bool isRemoveEnabled = false;
            //    bool isOpenLocationEnabled = false;

            //    //Return if the items are not selected in the ListView control.
            //    if (userControloListViewTrackList.SelectedItems.Count > 0)
            //    {
            //        isRemoveEnabled = true;                    

            //        //Obtain the item that is located at the specified location of the mouse pointer.                
            //        ListViewItem selectedItem = userControloListViewTrackList.GetItemAt(e.X, e.Y);
            //        if (selectedItem != null)
            //        {
            //            //Obtain the index of the item at the mouse pointer.
            //            int selIndex = selectedItem.Index;
            //            ListViewItem[] sel = new ListViewItem[userControloListViewTrackList.SelectedItems.Count];

            //            Track[] tracks = new Track[userControloListViewTrackList.SelectedItems.Count];

            //            isOpenLocationEnabled = true;

            //            for (int i = 0; i <= userControloListViewTrackList.SelectedItems.Count - 1; i++)
            //            {
            //                sel[i] = userControloListViewTrackList.SelectedItems[i];
            //                tracks[i] = AudioPlayer.Instance.TrackList.Tracks[userControloListViewTrackList.Items.IndexOf(sel[i])];
            //                if (i > 0 && Path.GetDirectoryName(tracks[i].Location).Equals(Path.GetDirectoryName(tracks[i - 1].Location)) == false)
            //                {
            //                    isOpenLocationEnabled = false;
            //                    break;
            //                }
            //            }                        
            //        }
            //    }

            //    contextMenuListItem.Items[0].Enabled = isOpenLocationEnabled;
            //    contextMenuListItem.Items[2].Enabled = isRemoveEnabled;

            //    contextMenuListItem.Show(this.userControloListViewTrackList, new Point(e.X, e.Y));  
            //}                          
        }
        #endregion

        private void contextMenuStripListView_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool isRemoveEnabled = false;
            bool isOpenLocationEnabled = false;

            //Return if the items are not selected in the ListView control.
            if (userControlTrackListView.listViewTrackList.SelectedItems.Count > 0)
            {
                isRemoveEnabled = true;

                Point screenPoint = Cursor.Position;

                // Convert screen coordinates to a point relative to the control
                // that was right clicked, in your case this would be the relavant 
                // picture box.
                Point pictureBoxPoint = contextMenuStripListView.SourceControl.PointToClient(screenPoint);

                //Obtain the item that is located at the specified location of the mouse pointer.                
                ListViewItem selectedItem = userControlTrackListView.listViewTrackList.GetItemAt(pictureBoxPoint.X, pictureBoxPoint.Y);
                if (selectedItem != null)
                {
                    //Obtain the index of the item at the mouse pointer.
                    int selIndex = selectedItem.Index;
                    ListViewItem[] sel = new ListViewItem[userControlTrackListView.listViewTrackList.SelectedItems.Count];

                    Track[] tracks = new Track[userControlTrackListView.listViewTrackList.SelectedItems.Count];

                    isOpenLocationEnabled = true;

                    for (int i = 0; i <= userControlTrackListView.listViewTrackList.SelectedItems.Count - 1; i++)
                    {
                        sel[i] = userControlTrackListView.listViewTrackList.SelectedItems[i];
                        tracks[i] = AudioPlayer.Instance.TrackList.Tracks[userControlTrackListView.listViewTrackList.Items.IndexOf(sel[i])];
                        if (i > 0 && Path.GetDirectoryName(tracks[i].Location).Equals(Path.GetDirectoryName(tracks[i - 1].Location)) == false)
                        {
                            isOpenLocationEnabled = false;
                            break;
                        }
                    }
                }
            }

            toolStripMenuItemOpenFileLocation.Enabled = isOpenLocationEnabled;
            toolStripMenuItemRemove.Enabled = isRemoveEnabled;

        }

        private void buttonPlay_Click(object sender, EventArgs e)
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
                        if (AudioPlayer.Instance.CurrentTrackIndex < 0)
                            AudioPlayer.Instance.CurrentTrackIndex = 0;

                        isPlaying = AudioPlayer.Instance.Play(true);
                    }

                    if (isPlaying == false)
                    {
                        buttonAdd_Click(null, null);
                    }

                    break;
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            AudioPlayer.Instance.Stop();
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            // create temp list, so does not fire Tracks_CollectionChanged for every single change in collection
            List<Track> allTracks = new List<Track>(AudioPlayer.Instance.TrackList.Tracks);

            Track[] selectedTracks = new Track[userControlTrackListView.listViewTrackList.SelectedItems.Count];

            int[] indexes2Select = new int[selectedTracks.Length];

            int idx = 0;

            foreach (ListViewItem item in userControlTrackListView.listViewTrackList.SelectedItems)
            {
                Track track = (Track)item.Tag;

                //int index = AudioPlayer.Instance.TrackList.Tracks.IndexOf(track);

                int index = allTracks.IndexOf(track);

                if (index > 0)
                {
                    allTracks.Remove(track);
                    allTracks.Insert(--index, track);
                    //AudioPlayer.Instance.TrackList.Tracks.Remove(track);
                    //AudioPlayer.Instance.TrackList.Tracks.Insert(--index, track);                    
                }

                indexes2Select[idx++] = index;
            }

            AudioPlayer.Instance.TrackList.Tracks.Clear(false);
            AudioPlayer.Instance.TrackList.Tracks.AddRange(allTracks);

            foreach (int idx2 in indexes2Select)
                userControlTrackListView.listViewTrackList.Items[idx2].Selected = true;

            userControlTrackListView.listViewTrackList.Select();

        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            // create temp list, so does not fire Tracks_CollectionChanged for every single change in collection
            List<Track> allTracks = new List<Track>(AudioPlayer.Instance.TrackList.Tracks);

            Track[] selectedTracks = new Track[userControlTrackListView.listViewTrackList.SelectedItems.Count];

            int index = 0;

            int[] indexes2Select = new int[selectedTracks.Length];

            foreach (ListViewItem item in userControlTrackListView.listViewTrackList.SelectedItems)
            {
                selectedTracks[index++] = (Track)item.Tag;
            }

            int count = userControlTrackListView.listViewTrackList.SelectedItems.Count;

            for (int idx = count; --idx >= 0; )
            {
                Track track = selectedTracks[idx];

                //index = AudioPlayer.Instance.TrackList.Tracks.IndexOf(track);

                index = allTracks.IndexOf(track);

                if (index < AudioPlayer.Instance.TrackList.Tracks.Count - 1)
                {
                    allTracks.Remove(track);
                    allTracks.Insert(++index, track);
                    //AudioPlayer.Instance.TrackList.Tracks.Remove(track);
                    //AudioPlayer.Instance.TrackList.Tracks.Insert(++index, track);
                }

                indexes2Select[idx] = index;
            }

            AudioPlayer.Instance.TrackList.Tracks.Clear(false);
            AudioPlayer.Instance.TrackList.Tracks.AddRange(allTracks);

            foreach (int idx in indexes2Select)
                userControlTrackListView.listViewTrackList.Items[idx].Selected = true;

            userControlTrackListView.listViewTrackList.Select();
        }

    }
}
