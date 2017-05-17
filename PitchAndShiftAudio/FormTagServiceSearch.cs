using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Diagnostics;
using System.Xml.Linq;
using System.IO;
using BrightIdeasSoftware;
using System.Threading.Tasks;
using Un4seen.Bass;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Text;
using System.Net;
using Un4seen.Bass.AddOn.Tags;
using System.Drawing.Imaging;
using AudioController;

namespace PitchAndShiftAudio
{
    public partial class FormTagServiceSearch : Form
    {
        private enum SERVICE_CALL { LASTFM, MUSIC_BRAINZ }

        private enum ARTIST_TYPE_SEARCH { INFO, EVENTS, ALBUMS, TRACKS, SEARCH };
        private enum TRACK_TYPE_SEARCH { INFO, SEARCH };
        private enum ALBUM_TYPE_SEARCH { INFO, SEARCH };

        private ARTIST_TYPE_SEARCH currentArtistSearchType = ARTIST_TYPE_SEARCH.SEARCH;
        private TRACK_TYPE_SEARCH currentTrackSearchType = TRACK_TYPE_SEARCH.SEARCH;
        private ALBUM_TYPE_SEARCH currentAlbumSearchType = ALBUM_TYPE_SEARCH.SEARCH;

        private enum OBJECT_TYPE { ARTIST, ALBUM, TRACK, EVENT }

        //Func<SearchParam, JObject> funcSearch;

        Func<string, SearchParam, string> funcSearch;

        private LastFMSearch lastFMSearch;

        private MusicBrainzSearch musicBrainzSearch;

        private SERVICE_CALL currentServiceUsed = SERVICE_CALL.LASTFM;

        // Get your own API_KEY and API_SECRET from http://www.last.fm/api/account
        const string API_KEY = "995e84db0fcca7b85279e94d2c01d9f7";

        private int NEW_IMAGE_TAG = 9999;

        public FormTagServiceSearch()
        {
            InitializeComponent();
        }



        #region useless
        void treeViewResult_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //if (e.Button == System.Windows.Forms.MouseButtons.Right)
            //{
            //    treeViewResult.SelectedNode = e.Node;
            //    if (e.Node.Tag != null)
            //    {

            //    }
            //}
        }

        void treeViewResult_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string contents = String.Empty;
            string title = String.Empty;
            string url = String.Empty;
            string image = String.Empty;

            //Object tag = e.Node.Tag;

            //if (tag == null && e.Node.Parent != null)
            //    tag = e.Node.Parent.Tag; 

            //if (tag != null)
            //{
            //    if (tag.GetType() == typeof(JObject))
            //    {

            //    }
            //}
            //else
            //{
            //    // node with no tag selected
            //    pictureBox.Image = PSAudioUtils.GetImageFromResources("no_image");                
            //}

            //TreeNode node = e.Node;

            //switch (currentServiceUsed)
            //{
            //    case SERVICE_CALL.LASTFM:
            //        string[] names = { "name", "title", "image", "wiki", "bio", "description", "url" };
            //        var query =
            //            from TreeNode childs in e.Node.Nodes
            //            where names.Contains(childs.Text)
            //            select childs;

            //        int imagePosition = 0;

            //        foreach (TreeNode element in query)
            //        {
            //            if (element.FirstNode != null)
            //            {
            //                switch (element.Text)
            //                {
            //                    case "name":
            //                    case "title":
            //                        title = element.FirstNode.Text;
            //                        break;
            //                    case "image":
            //                        if (imagePosition++ < 3)
            //                            image = element.FirstNode.Text;
            //                        break;
            //                    case "wiki":
            //                    case "bio":
            //                        var content =
            //                            from TreeNode child in element.Nodes
            //                            where child.Text.Equals("content")
            //                            select child;
            //                        contents = HttpUtility.HtmlDecode(content.First().FirstNode.Text);
            //                        break;
            //                    case "description":
            //                        contents = HttpUtility.HtmlDecode(element.FirstNode.Text);
            //                        break;
            //                    case "url":
            //                        url = element.FirstNode.Text;
            //                        break;
            //                }
            //            }
            //        }
            //        break;
            //}

            //if (String.IsNullOrEmpty(image))
            //    pictureBox.Image = PSAudioUtils.GetImageFromResources("no_image");
            //else
            //    pictureBox.Load(image);

            //if (String.IsNullOrEmpty(title))
            //{
            //    title = "No info available";
            //}
            //webBrowser.DocumentText = contents;
            //labelTitle.Text = title;
            //linkLabelURL.Text = url;
        }
        #endregion useless

        private void SearchOnWebService(string method, Func<string, SearchParam, string> func)
        {
            bool isSearchValid = true;
                        
            SearchParam sp = new SearchParam();

            if (checkBoxAlbum.Checked && String.IsNullOrEmpty(textBoxAlbum.Text) == false)
                sp.Album.Name = textBoxAlbum.Text;
            if (checkBoxArtist.Checked && String.IsNullOrEmpty(textBoxArtist.Text) == false)
                sp.Artist.Name = textBoxArtist.Text;
            if (checkBoxTrack.Checked && String.IsNullOrEmpty(textBoxTrack.Text) == false)
                sp.Track.Name = textBoxTrack.Text;

            switch (currentServiceUsed)
            {
                case SERVICE_CALL.LASTFM:
                    isSearchValid = !(checkBoxArtist.Checked && String.IsNullOrEmpty(sp.Artist.Name) == false && sp.Artist.Name.Trim().Length < 2);
                    isSearchValid = isSearchValid && !(checkBoxAlbum.Checked && String.IsNullOrEmpty(sp.Album.Name) == false && sp.Album.Name.Trim().Length < 2);
                    isSearchValid = isSearchValid && !(checkBoxTrack.Checked && String.IsNullOrEmpty(sp.Track.Name) == false && sp.Track.Name.Trim().Length < 2);

                    if (isSearchValid == false)
                    {
                        MessageBox.Show("Search field length must be almost of 2 characters", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case SERVICE_CALL.MUSIC_BRAINZ:                    
                    break;
            }

            try
            {
                if (isSearchValid)
                {
                    ExecMethodAndBuildView(method, sp, currentServiceUsed, func);
                }
            }
            catch (Exception e)
            {                
                MessageBox.Show(e.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void ExecMethodAndBuildView(string method, SearchParam sp, SERVICE_CALL service, Func<string, SearchParam, string> func)
        {
            TreeNode tnode = null;

            string xml = func(method, sp);

            tnode = XmlUtils.LoadXmlIntoTreeNode(xml);

            BuildXmlTree(xml, service);

            treeViewResult.Nodes.Clear();

            if (tnode != null)
            {
                treeViewResult.Nodes.Add(tnode);

                tnode.Expand();
            }
        }

        private void BuildXmlTree(string xml, SERVICE_CALL service)
        {
            XElement xmlroot = XElement.Parse(xml);

            Root root = new Root();

            //tw = new StreamWriter(@"C:\Java_libs\provalista.txt");

            string[] whcond = null;
            
            switch (service)
            {
                case SERVICE_CALL.LASTFM:
                    whcond = new string[] { "artist", "album", "track", "event", "venue" };
                    break;
                case SERVICE_CALL.MUSIC_BRAINZ:
                    whcond = new string[] { "artist", "release", "recording" };
                    break;
            }

            SearchElement(xmlroot, root, whcond, service);

            treeListViewResult.CanExpandGetter = delegate(object x) { return ((BaseObject)x).Childs.Count > 0; };
            treeListViewResult.ChildrenGetter = delegate(object x) { return ((BaseObject)x).Childs; };            
            treeListViewResult.Roots = root.Childs;

            treeListViewResult.RebuildAll(false);
        }


        //TextWriter tw;

        private const int ARTIST_INDEX = 0;
        private const int ALBUM_INDEX = 1;
        private const int TRACK_INDEX = 2;

        private void SearchElement(XElement elem, HasChilds parent, string[] whcond, SERVICE_CALL service)
        {
            foreach (XElement el in elem.Elements())
            {
                string name = el.Name.LocalName;

                //tw.WriteLine(name);

                BaseObject curelem = null;

                if (whcond.Contains(name))
                {
                    switch (service)
                    {
                        case SERVICE_CALL.MUSIC_BRAINZ:
                            curelem = GetModelObjectFromMusicBrainz(el);
                            break;
                        case SERVICE_CALL.LASTFM:
                            curelem = GetModelObjectFromLastFM(el);
                            break;
                    }
                    
                    parent.Childs.Add(curelem);
                }

                SearchElement(el, curelem ?? parent, whcond, service);

            }
        }


        private BaseObject GetModelObjectFromLastFM(XElement elem)
        {
            BaseObject obj = null;

            string name = elem.Name.LocalName;

            string[] prop = null;

            if (name.Equals("artist"))
            {
                obj = new Artist();
                prop = new string[] { "mbid", "url", "name" };
            }
            else if (name.Equals("album"))
            {
                obj = new Album();
                prop = new string[] { "mbid", "url", "name", "title", "releasedate" };
            }
            else if (name.Equals("track"))
            {
                obj = new Song();
                prop = new string[] { "mbid", "url", "name", "title", "duration" };

                IEnumerable<XAttribute> queryattr =
                from att in elem.Attributes()
                where att.Name.LocalName.Equals("rank")
                select att;

                if (queryattr.Count() > 0)
                    ((Song)obj).Position = queryattr.First().Value;
            }
            else if (name.Equals("event"))
            {
                obj = new BaseObject("Event");
                prop = new string[] { "name", "title", "url" };
            }
            else if (name.Equals("venue"))
            {
                obj = new BaseObject("Venue");
                prop = new string[] { "name", "title", "url" };
            }

            if (elem.HasElements)
            {
                IEnumerable<XElement> queryImage =
                from el in elem.Elements()
                where el.Name.LocalName.Equals("image")
                select el;

                if (queryImage.Count() > 0)
                    obj.ImageUrl = queryImage.Last().Value;

                IEnumerable<XElement> query =
                    from el in elem.Elements()
                    where prop.Contains(el.Name.LocalName)
                    select el;

                foreach (XElement element in query)
                {
                    name = element.Name.LocalName;

                    if (name.Equals("title") || name.Equals("name"))
                        obj.Name = element.Value;
                    else if (name.Equals("mbid"))
                        obj.MbId = element.Value;
                    else if (name.Equals("releasedate"))
                        ((Album)obj).Date = element.Value;
                    else if (name.Equals("url"))
                        obj.Url = element.Value;
                    else if (name.Equals("duration"))
                    {
                        // just a trick, should work on 99.9% of cases
                        double time = Double.Parse(element.Value);
                        if (time > 5000)
                            time /= 1000;
                        ((Song)obj).Length = TimeSpan.FromSeconds(time).ToString(@"mm\:ss");
                    }                    
                }
            }
            else
            {
                obj.Name = elem.Value;
            }

            return obj;
        }



        private BaseObject GetModelObjectFromMusicBrainz(XElement elem)
        {
            const string MB_URL = "http://musicbrainz.org/";

            BaseObject obj = null;

            string name = elem.Name.LocalName;

            string[] prop = null;

            if (name.Equals("artist"))
            {
                obj = new Artist();
                prop = new string[] { "name"};
            }
            else if (name.Equals("release"))
            {
                obj = new Album();
                prop = new string[] { "title", "date" };                
            }
            else if (name.Equals("recording"))
            {
                obj = new Song();
                prop = new string[] { "title", "length" };

                IEnumerable<XElement> position =
                    from el in elem.Parent.Descendants()
                    where el.Name.LocalName.Equals("position")
                    || el.Name.LocalName.Equals("number")
                    select el;

                if (position.Count() > 0)
                    ((Song)obj).Position = position.First().Value;
            }

            IEnumerable<XAttribute> queryattr =
                from att in elem.Attributes()
                where att.Name.LocalName.Equals("id")
                select att;

            if (queryattr.Count() > 0)
                obj.MbId = queryattr.First().Value;

            if (name.Equals("release"))
                obj.ImageUrl = musicBrainzSearch.GetImageUrl(name, obj.MbId, "front");

            obj.Url = String.Format("{0}{1}/{2}", MB_URL, name, obj.MbId);

            IEnumerable<XElement> query =
                from el in elem.Elements()
                where prop.Contains(el.Name.LocalName)
                select el;

            foreach (XElement element in query)
            {
                name = element.Name.LocalName;

                if (name.Equals("title") || name.Equals("name"))
                    obj.Name = element.Value;
                else if (name.Equals("date"))
                    ((Album)obj).Date = element.Value;
                else if (name.Equals("length"))
                    ((Song)obj).Length = TimeSpan.FromMilliseconds(Double.Parse(element.Value)).ToString(@"mm\:ss");
            }

            return obj;
        }

        private void FormTagServiceSearch_Load(object sender, EventArgs e)
        {
            lastFMSearch = new LastFMSearch();

            musicBrainzSearch = new MusicBrainzSearch();

            Track currentTrack = AudioPlayer.Instance.CurrentTrack;

            if (currentTrack != null && AudioPlayer.Instance.CurrentAudioHandle.IsModule() == false && AudioPlayer.Instance.CurrentAudioHandle.IsRemoteURL == false)
            {
                textBoxAlbum.Text = currentTrack.Album;
                textBoxArtist.Text = currentTrack.Artist;
                textBoxTrack.Text = currentTrack.Title;
            }

            InitCtxMenuLastFM();

            InitCtxMenuMusicBrainz();

            pictureBoxCover.Image = PSAudioUtils.GetBlankImage();

            browser.ListViewMode = View.Details;
            try
            {
                if (AudioPlayer.Instance.CurrentTrack != null)
                {
                    string folder = Path.GetDirectoryName( AudioPlayer.Instance.CurrentTrack.Location );
                    browser.StartUpDirectoryOther = folder;
                    browser.StartUpDirectory = FileBrowser.SpecialFolders.Other;
                    browser.Refresh();
                }
            }
            catch (Exception ex) { }


        }


        private void InitCtxMenuMusicBrainz()
        {
            // artist menu
            toolStripMenuItemArtistSearch.Tag = ARTIST_TYPE_SEARCH.SEARCH;
            toolStripMenuItemArtistRelease.Tag = ARTIST_TYPE_SEARCH.ALBUMS;
            toolStripMenuItemArtistRecording.Tag = ARTIST_TYPE_SEARCH.TRACKS;

            toolStripMenuItemArtistSearch.Checked = true;

            foreach (ToolStripMenuItem item in contextMenuStripArtistMusicBrainz.Items)
            {
                item.Click += new EventHandler(itemArtist_Click);
            }

            contextMenuStripArtistMusicBrainz.Click += new EventHandler(contextMenuStrip_Click);

            // release menu

            toolStripMenuItemReleaseSearch.Tag = ALBUM_TYPE_SEARCH.SEARCH;

            toolStripMenuItemReleaseSearch.Checked = true;

            toolStripMenuItemReleaseSearch.Click += new EventHandler(itemAlbum_Click);

            contextMenuStripReleaseMusicBrainz.Click += new EventHandler(contextMenuStrip_Click);

            // recording menu

            toolStripMenuItemTrackSearch.Tag = TRACK_TYPE_SEARCH.SEARCH;

            toolStripMenuItemTrackSearch.Checked = true;

            toolStripMenuItemTrackSearch.Click += new EventHandler(itemTrack_Click);

            contextMenuStripTrackMusicBrainz.Click += new EventHandler(contextMenuStrip_Click);
        }


        private void InitCtxMenuLastFM()
        {
            int index = 0;

            string[] searchAssigned = Enum.GetNames(typeof(ARTIST_TYPE_SEARCH));

            foreach (ToolStripMenuItem item in contextMenuStripArtistLastFM.Items)
            {
                ARTIST_TYPE_SEARCH searchType = (ARTIST_TYPE_SEARCH)Enum.Parse(typeof(ARTIST_TYPE_SEARCH), searchAssigned[index++]);
                item.Tag = searchType;
                if (searchType == currentArtistSearchType)
                    item.Checked = true;
                item.Click += new EventHandler(itemArtist_Click);
            }

            contextMenuStripArtistLastFM.Click += new EventHandler(contextMenuStrip_Click);

            searchAssigned = Enum.GetNames(typeof(TRACK_TYPE_SEARCH));

            index = 0;

            foreach (ToolStripMenuItem item in contextMenuStripTrackLastFM.Items)
            {
                TRACK_TYPE_SEARCH searchType = (TRACK_TYPE_SEARCH)Enum.Parse(typeof(TRACK_TYPE_SEARCH), searchAssigned[index++]);
                item.Tag = searchType;
                if (searchType == currentTrackSearchType)
                    item.Checked = true;
                item.Click += new EventHandler(itemTrack_Click);
            }

            contextMenuStripTrackLastFM.Click += new EventHandler(contextMenuStrip_Click);

            index = 0;

            searchAssigned = Enum.GetNames(typeof(ALBUM_TYPE_SEARCH));

            foreach (ToolStripMenuItem item in contextMenuStripAlbumLastFM.Items)
            {
                ALBUM_TYPE_SEARCH searchType = (ALBUM_TYPE_SEARCH)Enum.Parse(typeof(ALBUM_TYPE_SEARCH), searchAssigned[index++]);
                item.Tag = searchType;
                if (searchType == currentAlbumSearchType)
                    item.Checked = true;
                item.Click += new EventHandler(itemAlbum_Click);
            }

            contextMenuStripAlbumLastFM.Click += new EventHandler(contextMenuStrip_Click);
        }

        void itemAlbum_Click(object sender, EventArgs e)
        {
            currentServiceUsed = radioButtonLastFM.Checked ? SERVICE_CALL.LASTFM : SERVICE_CALL.MUSIC_BRAINZ;

            if (sender.GetType() == typeof(ToolStripMenuItem))
            {
                ToolStripMenuItem item = (ToolStripMenuItem)sender;

                item.Checked = true;

                currentAlbumSearchType = ((ALBUM_TYPE_SEARCH)item.Tag);
            }

            string method = null;

            switch (currentServiceUsed)
            {
                case SERVICE_CALL.LASTFM:
                    funcSearch = new Func<string, SearchParam, string>(lastFMSearch.CallMethod);

                    switch (currentAlbumSearchType)
                    {
                        case ALBUM_TYPE_SEARCH.INFO:
                            method = "album.getInfo";
                            //funcSearch = new Func<SearchParam, JObject>(AlbumInfo);
                            break;
                        case ALBUM_TYPE_SEARCH.SEARCH:
                            method = "album.search";
                            //funcSearch = new Func<SearchParam, JObject>(AlbumSearch);
                            break;
                    }
                    break;
                case SERVICE_CALL.MUSIC_BRAINZ:
                    funcSearch = new Func<string, SearchParam, string>(musicBrainzSearch.CallSearchMethod);

                    switch (currentAlbumSearchType)
                    {
                        case ALBUM_TYPE_SEARCH.INFO:
                            //method = "release";
                            break;
                        case ALBUM_TYPE_SEARCH.SEARCH:
                            method = "release";                            
                            break;
                    }
                    break;
            }


            try
            {
                if (funcSearch != null)
                    SearchOnWebService(method, funcSearch);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void itemTrack_Click(object sender, EventArgs e)
        {
            currentServiceUsed = radioButtonLastFM.Checked ? SERVICE_CALL.LASTFM : SERVICE_CALL.MUSIC_BRAINZ;

            if (sender.GetType() == typeof(ToolStripMenuItem))
            {
                ToolStripMenuItem item = (ToolStripMenuItem)sender;

                item.Checked = true;

                currentTrackSearchType = ((TRACK_TYPE_SEARCH)item.Tag);
            }

            funcSearch = null;

            string method = null;

            switch (currentServiceUsed)
            {
                case SERVICE_CALL.LASTFM:
                    funcSearch = new Func<string, SearchParam, string>(lastFMSearch.CallMethod);

                    switch (currentTrackSearchType)
                    {
                        case TRACK_TYPE_SEARCH.INFO:
                            method = "track.getInfo";
                            break;
                        case TRACK_TYPE_SEARCH.SEARCH:
                            method = "track.search";
                            //funcSearch = new Func<SearchParam, JObject>(TrackSearch);
                            break;
                    }

                    break;
                case SERVICE_CALL.MUSIC_BRAINZ:

                    funcSearch = new Func<string, SearchParam, string>(musicBrainzSearch.CallSearchMethod);

                    switch (currentTrackSearchType)
                    {
                        case TRACK_TYPE_SEARCH.INFO:
                            //method = "recording";
                            break;
                        case TRACK_TYPE_SEARCH.SEARCH:
                            method = "recording";
                            break;
                    }

                    break;
            }

            try
            {
                if (funcSearch != null)
                {
                    SearchOnWebService(method, funcSearch);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void contextMenuStrip_Click(object sender, EventArgs e)
        {
            ContextMenuStrip menu = (ContextMenuStrip)sender;

            foreach (ToolStripMenuItem item in menu.Items)
            {
                item.Checked = false;
            }
        }

        void itemArtist_Click(object sender, EventArgs e)
        {
            currentServiceUsed = radioButtonLastFM.Checked ? SERVICE_CALL.LASTFM : SERVICE_CALL.MUSIC_BRAINZ;

            if (sender.GetType() == typeof(ToolStripMenuItem))
            {
                ToolStripMenuItem item = (ToolStripMenuItem)sender;

                item.Checked = true;

                currentArtistSearchType = ((ARTIST_TYPE_SEARCH)item.Tag);
            }

            string method = null;

            switch (currentServiceUsed)
            {
                case SERVICE_CALL.LASTFM:
                    funcSearch = new Func<string, SearchParam, string>(lastFMSearch.CallMethod);

                    switch (currentArtistSearchType)
                    {
                        case ARTIST_TYPE_SEARCH.INFO:
                            method = "artist.getInfo";
                            //funcSearch = new Func<SearchParam, JObject>(ArtistInfo);
                            break;
                        case ARTIST_TYPE_SEARCH.EVENTS:
                            method = "artist.getEvents";
                            //funcSearch = new Func<SearchParam, JObject>(ArtistEvents);
                            break;
                        case ARTIST_TYPE_SEARCH.ALBUMS:
                            method = "artist.topAlbums";
                            //funcSearch = new Func<SearchParam, JObject>(ArtistTopAlbums);
                            break;
                        case ARTIST_TYPE_SEARCH.TRACKS:
                            method = "artist.topTracks";
                            //funcSearch = new Func<SearchParam, JObject>(ArtistTopTracks);
                            break;
                        case ARTIST_TYPE_SEARCH.SEARCH:
                            method = "artist.search";
                            //funcSearch = new Func<SearchParam, JObject>(ArtistSearch);
                            break;
                    }
                    break;
                case SERVICE_CALL.MUSIC_BRAINZ:
                    funcSearch = new Func<string, SearchParam, string>(musicBrainzSearch.CallSearchMethod);

                    switch (currentArtistSearchType)
                    {
                        case ARTIST_TYPE_SEARCH.INFO:
                            //method = "artist";
                            break;
                        case ARTIST_TYPE_SEARCH.EVENTS:
                            break;
                        case ARTIST_TYPE_SEARCH.ALBUMS:
                            method = "release";
                            break;
                        case ARTIST_TYPE_SEARCH.TRACKS:
                            method = "recording";
                            break;
                        case ARTIST_TYPE_SEARCH.SEARCH:
                            method = "artist";
                            break;
                    }
                    break;
            }

            try
            {
                if (funcSearch != null && method != null)
                    SearchOnWebService(method, funcSearch);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void buttonTrackSearch_Click(object sender, EventArgs e)
        {
            //lastSearchType = LAST_SEARCH_TYPE.TRACK;
            itemTrack_Click(sender, e);
        }

        private void buttonArtistSearch_Click(object sender, EventArgs e)
        {
            //lastSearchType = LAST_SEARCH_TYPE.ARTIST;
            itemArtist_Click(sender, e);
        }

        private void buttonAlbumSearch_Click(object sender, EventArgs e)
        {
            //lastSearchType = LAST_SEARCH_TYPE.ALBUM;
            itemAlbum_Click(sender, e);
        }

        private void linkLabelURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel link = (LinkLabel)sender;

            if (String.IsNullOrEmpty(link.Text) == false)
                Process.Start(link.Text);

        }

        private void contextMenuStripDetail_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
            
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private class SearchParam
        {
            public Artist Artist { get; set; }
            public Album Album { get; set; }
            public Song Track { get; set; }
            public Dictionary<string, string> Params { get; set; }

            public SearchParam()
            {
                Artist = new Artist();
                Album = new Album();
                Track = new Song();
                Params = new Dictionary<string, string>();
            }
        }

        private void treeViewResult_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            //if (e.Node.ToolTipText != null)
            //    this.toolTip.SetToolTip(treeViewResult, e.Node.ToolTipText);
        }

        private class XmlUtils
        {
            public static TreeNode LoadXmlIntoTreeNode(string xml)
            {
                XmlDocument result = new XmlDocument();

                result.LoadXml(xml);

                //treeViewResult.Nodes.Clear();

                //treeViewResult.Nodes.Add(new TreeNode(result.DocumentElement.Name));
                //TreeNode tNode = new TreeNode();
                //tNode = treeViewResult.Nodes[0];

                TreeNode tNode = new TreeNode(result.DocumentElement.Name);

                AddNode(result.DocumentElement, tNode);

                return tNode;

            }

            private static void AddNode(XmlNode inXmlNode, TreeNode inTreeNode)
            {
                XmlNode xNode;
                TreeNode tNode;
                XmlNodeList nodeList;
                int i;

                // Loop through the XML nodes until the leaf is reached.
                // Add the nodes to the TreeView during the looping process.
                if (inXmlNode.HasChildNodes)
                {
                    nodeList = inXmlNode.ChildNodes;
                    for (i = 0; i <= nodeList.Count - 1; i++)
                    {
                        xNode = inXmlNode.ChildNodes[i];
                        inTreeNode.Nodes.Add(new TreeNode(xNode.Name));
                        tNode = inTreeNode.Nodes[i];
                        AddNode(xNode, tNode);
                    }
                }
                else
                {
                    // Here you need to pull the data from the XmlNode based on the
                    // type of node, whether attribute values are required, and so forth.
                    inTreeNode.Text = (inXmlNode.OuterXml).Trim();
                }
            }
        }

        private class MusicBrainzSearch
        {
            private MusicBrainz musicBrainz = null;

            private string xml;

            public MusicBrainzSearch()
            {
                musicBrainz = new MusicBrainz();
                musicBrainz.Proxy = SharedServices.GetWebProxyFromResources();
            }

            public string GetXmlString()
            {
                return xml;
            }

            public string GetImageUrl(string method, string id, string objtype)
            {
                return musicBrainz.GetImageUrl(method, id, objtype);
            }

            public string CallSearchMethod(string method, SearchParam sp)
            {
                const string quote = "\"";

                Dictionary<string, string> param = new Dictionary<string, string>();
                if (String.IsNullOrEmpty(sp.Artist.Name) == false)
                    param.Add("artist", quote + sp.Artist.Name + quote);
                if (String.IsNullOrEmpty(sp.Album.Name) == false)
                    param.Add("release", quote + sp.Album.Name + quote);
                if (String.IsNullOrEmpty(sp.Track.Name) == false)
                    param.Add("recording", quote + sp.Track.Name + quote);
                if (String.IsNullOrEmpty(sp.Artist.MbId) == false)
                    param.Add("arid", sp.Artist.MbId);
                else if (String.IsNullOrEmpty(sp.Album.MbId) == false)
                    param.Add("reid", sp.Album.MbId);
                else if (String.IsNullOrEmpty(sp.Track.MbId) == false)
                    param.Add("rid", sp.Track.MbId);

                xml = musicBrainz.CallSearchMethod(method, param);

                return xml;
            }


            public string CallBrowseMethod(string method, SearchParam sp)
            {
                string id = null;

                Dictionary<string, string> param = new Dictionary<string, string>();
                if (String.IsNullOrEmpty(sp.Artist.Name) == false)
                    param.Add("artist", sp.Artist.Name);
                if (String.IsNullOrEmpty(sp.Album.Name) == false)
                    param.Add("release", sp.Album.Name);
                if (String.IsNullOrEmpty(sp.Track.Name) == false)
                    param.Add("recording", sp.Track.Name);
                if (String.IsNullOrEmpty(sp.Artist.MbId) == false)
                    id = sp.Artist.MbId;
                else if (String.IsNullOrEmpty(sp.Album.MbId) == false)
                    id = sp.Album.MbId;
                else if (String.IsNullOrEmpty(sp.Track.MbId) == false)
                    id = sp.Track.MbId;

                foreach (KeyValuePair<String, String> entry in sp.Params)
                    param.Add(entry.Key, entry.Value);

                xml = musicBrainz.CallBrowseMethod(method, id, param);

                return xml;
            }


            public string CallLookupMethod(string method, SearchParam sp)
            {
                string id = null;

                Dictionary<string, string> param = new Dictionary<string, string>();
                if (String.IsNullOrEmpty(sp.Artist.Name) == false)
                    param.Add("artist", sp.Artist.Name);
                if (String.IsNullOrEmpty(sp.Album.Name) == false)
                    param.Add("release", sp.Album.Name);
                if (String.IsNullOrEmpty(sp.Track.Name) == false)
                    param.Add("recording", sp.Track.Name);
                if (String.IsNullOrEmpty(sp.Artist.MbId) == false)
                    id = sp.Artist.MbId;
                else if (String.IsNullOrEmpty(sp.Album.MbId) == false)
                    id = sp.Album.MbId;
                else if (String.IsNullOrEmpty(sp.Track.MbId) == false)
                    id = sp.Track.MbId;

                foreach (KeyValuePair<String, String> entry in sp.Params)
                    param.Add(entry.Key, entry.Value);                

                xml = musicBrainz.CallLookupMethod(method, id, param);

                return xml;
            }
        }

        private class LastFMSearch
        {
            private LastFMFS lastFMFS = null;

            private string xml;

            public LastFMSearch()
            {
                lastFMFS = new LastFMFS(API_KEY, null);
                lastFMFS.Proxy = SharedServices.GetWebProxyFromResources();
            }

            public string GetXmlString()
            {
                return xml;
            }

            public string CallMethod(string method, SearchParam sp)
            {
                Dictionary<string, string> param = new Dictionary<string, string>();
                if (String.IsNullOrEmpty(sp.Artist.Name) == false)
                    param.Add("artist", sp.Artist.Name);
                if (String.IsNullOrEmpty(sp.Album.Name) == false)
                    param.Add("album", sp.Album.Name);
                if (String.IsNullOrEmpty(sp.Track.Name) == false)
                    param.Add("track", sp.Track.Name);
                if (String.IsNullOrEmpty(sp.Artist.MbId) == false)
                    param.Add("mbid", sp.Artist.MbId);
                else if (String.IsNullOrEmpty(sp.Album.MbId) == false)
                    param.Add("mbid", sp.Album.MbId);
                else if (String.IsNullOrEmpty(sp.Track.MbId) == false)
                    param.Add("mbid", sp.Track.MbId);

                xml = lastFMFS.CallSearchMethod(method, param);
                
                return xml;
            }

            #region old
            /*
            public TreeNode TrackInfo(SearchParam sp)
            {
                Dictionary<string, string> param = new Dictionary<string, string>();
                param.Add("artist", sp.Artist);
                param.Add("track", sp.Track);

                TreeNode tNode = null;

                string result = lastFMFS.CallMethod("track.getInfo", param);

                tNode = XmlUtils.LoadXmlIntoTreeNode(result);
                
                return tNode;
            }

            public TreeNode TrackSearch(SearchParam sp)
            {
                Dictionary<string, string> param = new Dictionary<string, string>();
                param.Add("track", sp.Track);
                
                TreeNode tNode = null;

                string result = lastFMFS.CallMethod("track.search", param);

                tNode = XmlUtils.LoadXmlIntoTreeNode(result);

                return tNode;
            }


            public TreeNode ArtistInfo(SearchParam sp)
            {
                Dictionary<string, string> param = new Dictionary<string, string>();
                if (String.IsNullOrEmpty(sp.Mbid))
                    param.Add("artist", sp.Artist);
                else
                    param.Add("mbid", sp.Mbid);

                TreeNode tNode = null;

                string result = lastFMFS.CallMethod("artist.getInfo", param);

                tNode = XmlUtils.LoadXmlIntoTreeNode(result);

                return tNode;
            }

            public TreeNode ArtistSearch(SearchParam sp)
            {
                Dictionary<string, string> param = new Dictionary<string, string>();
                param.Add("artist", sp.Artist);

                string result = lastFMFS.CallMethod("artist.search", param);

                TreeNode tNode = null;

                tNode = XmlUtils.LoadXmlIntoTreeNode(result);

                return tNode;
            }


            public TreeNode ArtistTopAlbums(SearchParam sp)
            {
                Dictionary<string, string> param = new Dictionary<string, string>();
                param.Add("artist", sp.Artist);

                string result = lastFMFS.CallMethod("artist.topalbums", param);

                TreeNode tNode = null;

                tNode = XmlUtils.LoadXmlIntoTreeNode(result);

                return tNode;
            }
             * */
            #endregion
        }

        private void radioButtonLastFM_CheckedChanged(object sender, EventArgs e)
        {
            //currentServiceUsed = SERVICE_CALL.LASTFM;
            //buttonArtistSearch.ContextMenuStrip = contextMenuStripArtistLastFM;
            //buttonTrackSearch.ContextMenuStrip = contextMenuStripTrackLastFM;
            //buttonAlbumSearch.ContextMenuStrip = contextMenuStripAlbumLastFM;

            buttonArtistTypeSearch.ContextMenuStrip = contextMenuStripArtistLastFM;
            buttonTrackTypeSearch.ContextMenuStrip = contextMenuStripTrackLastFM;
            buttonAlbumTypeSearch.ContextMenuStrip = contextMenuStripAlbumLastFM;

            currentAlbumSearchType = ALBUM_TYPE_SEARCH.INFO;
            currentArtistSearchType = ARTIST_TYPE_SEARCH.INFO;
            currentTrackSearchType = TRACK_TYPE_SEARCH.INFO;
        }

        private void radioButtonMusicBrainz_CheckedChanged(object sender, EventArgs e)
        {
            //currentServiceUsed = SERVICE_CALL.MUSIC_BRAINZ;
            //buttonArtistSearch.ContextMenuStrip = contextMenuStripArtistMusicBrainz;
            //buttonTrackSearch.ContextMenuStrip = contextMenuStripTrackMusicBrainz;
            //buttonAlbumSearch.ContextMenuStrip = contextMenuStripReleaseMusicBrainz;

            buttonArtistTypeSearch.ContextMenuStrip = contextMenuStripArtistMusicBrainz;
            buttonTrackTypeSearch.ContextMenuStrip = contextMenuStripTrackMusicBrainz;
            buttonAlbumTypeSearch.ContextMenuStrip = contextMenuStripReleaseMusicBrainz;

            currentArtistSearchType = ARTIST_TYPE_SEARCH.SEARCH;
            currentAlbumSearchType = ALBUM_TYPE_SEARCH.SEARCH;
            currentTrackSearchType = TRACK_TYPE_SEARCH.SEARCH;            
        }

        private void ClearDetailPanels()
        {
            const string noinfo = "<No Info>";

            pictureBoxArtist.Image = pictureBoxArtist.InitialImage;
            pictureBoxAlbum.Image = pictureBoxAlbum.InitialImage;            
            pictureBoxTrack.Image = pictureBoxTrack.InitialImage;
            labelArtistName.Text = noinfo;
            labelAlbumTitle.Text = noinfo;
            labelAlbumYear.Text = noinfo;
            labelTrackTitle.Text = noinfo;
            labelTrackLength.Text = noinfo;
        }

        private void LoadImageAsync(PictureBox pictureBox, string imageUrl)
        {
            if (String.IsNullOrEmpty(imageUrl) == false)
            {
                Task.Factory.StartNew(delegate
                {
                    try
                    {
                        pictureBox.Load(imageUrl);
                    }
                    catch (Exception) { }
                });
            }
        }

        private void FillDetailPanelWithObject(BaseObject obj)
        {
            Type objType = obj.GetType();

            if (objType == typeof(Artist))
            {
                Artist detail = (Artist)obj;
                labelArtistName.Text = detail.Name;
                LoadImageAsync(pictureBoxArtist, detail.ImageUrl);                
            }
            else if (objType == typeof(Album))
            {
                Album detail = (Album)obj;
                labelAlbumTitle.Text = detail.Name;
                labelAlbumYear.Text = detail.Date;
                LoadImageAsync(pictureBoxAlbum, detail.ImageUrl);                
            }
            else if (objType == typeof(Song))
            {
                Song detail = (Song)obj;
                labelTrackTitle.Text = detail.Name;
                labelTrackLength.Text = detail.Length;
                LoadImageAsync(pictureBoxTrack, detail.ImageUrl);
            }
            else
            {
                labelTrackTitle.Text = obj.Name;
                LoadImageAsync(pictureBoxTrack, obj.ImageUrl);
            }

            // Inspect all childs in object and put them in detail
            // if > 1 of types are found (e.g. 12 Song entities from a parent of type Album) 
            // then no detail is gathered
            var countObjTypeInChilds =
                from childs in obj.Childs
                group childs by childs.ObjType into grouping
                select new
                {
                    grouping.Key,
                    CountObjType = grouping.Count()
                };

            List<string> listAllowedTypes = new List<string>();

            foreach (var child in countObjTypeInChilds)
            {
                if (child.CountObjType == 1)
                    listAllowedTypes.Add(child.Key);
            }

            foreach (BaseObject child in obj.Childs)
            {
                if (listAllowedTypes.Contains(child.ObjType))
                    FillDetailPanelWithObject(child);
            }
        }

        private void treeListViewResult_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            ClearDetailPanels();

            ListViewItem item = e.Item;

            BaseObject obj = (BaseObject)((TreeListView)sender).GetModelObject(e.ItemIndex);

            FillDetailPanelWithObject(obj);
        }

        private void contextMenuStripDetail_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool isItemSelected = false;
            bool isMbidPresent = false;
            bool isUrlPresent = false;

            if (treeListViewResult.SelectedObjects.Count > 0)
            {
                isItemSelected = true;

                BaseObject obj = (BaseObject)treeListViewResult.SelectedObjects[0];

                isMbidPresent = String.IsNullOrEmpty(obj.MbId) == false;

                //toolStripMenuItemInfo.Enabled = isMbidPresent;

                isUrlPresent = String.IsNullOrEmpty(obj.Url) == false;

                //if (isMbidPresent)
                //{

                //}
            }
            else
            {
                //e.Cancel = true;
            }

            toolStripMenuItemInfo.Enabled = isMbidPresent;
            toolStripMenuItemCopy.Enabled = isItemSelected;
            toolStripMenuItemOpenURL.Enabled = isUrlPresent;
            toolStripMenuItemTagList.Enabled = isItemSelected;
        }

        private void toolStripMenuItemCopy_Click(object sender, EventArgs e)
        {
            if (treeListViewResult.SelectedObjects.Count > 0)
            {
                BaseObject obj = (BaseObject)treeListViewResult.SelectedObjects[0];

                TextBox tb = null;

                if (obj.GetType() == typeof(Artist))
                {
                    tb = textBoxArtist;
                }
                else if (obj.GetType() == typeof(Album))
                {
                    tb = textBoxAlbum;
                }
                else if (obj.GetType() == typeof(Song))
                {
                    tb = textBoxTrack;
                }

                if (tb != null)
                    tb.Text = obj.Name;
            }

        }

        private void toolStripMenuItemInfo_Click(object sender, EventArgs e)
        {
            //if (treeListViewResult.SelectedObjects.Count > 0)
            //{
            //    if (toolStripMenuItemInfoLastFM.Checked)
            //        toolStripMenuItemInfoLastFM_Click(sender, e);
            //    else if (toolStripMenuItemInfoMusicBrainz.Checked)
            //        toolStripMenuItemInfoMusicBrainz_Click(sender, e);
            //}
        }

        private void GetInfoFromLastFM()
        {
            toolStripMenuItemInfoMusicBrainz.Checked = false;

            if (treeListViewResult.SelectedObjects.Count > 0)
            {
                BaseObject obj = (BaseObject)treeListViewResult.SelectedObjects[0];

                string method = null;

                SearchParam sp = new SearchParam();

                if (obj.GetType() == typeof(Artist))
                {
                    method = "artist.getInfo";
                    sp.Artist.MbId = obj.MbId;
                }
                else if (obj.GetType() == typeof(Album))
                {
                    method = "album.getInfo";
                    sp.Album.MbId = obj.MbId;
                }
                else if (obj.GetType() == typeof(Song))
                {
                    method = "track.getInfo";
                    sp.Track.MbId = obj.MbId;
                }

                funcSearch = new Func<string, SearchParam, string>(lastFMSearch.CallMethod);

                try
                {
                    ExecMethodAndBuildView(method, sp, SERVICE_CALL.LASTFM, funcSearch);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toolStripMenuItemInfoLastFM_Click(object sender, EventArgs e)
        {

            GetInfoFromLastFM();
            
        }

        private void GetInfoFromMusicBrainz()
        {
            toolStripMenuItemInfoLastFM.Checked = false;

            if (treeListViewResult.SelectedObjects.Count > 0)
            {
                BaseObject obj = (BaseObject)treeListViewResult.SelectedObjects[0];

                string method = null;

                SearchParam sp = new SearchParam();

                if (obj.GetType() == typeof(Artist))
                {
                    method = "artist";
                    sp.Artist.MbId = obj.MbId;
                    sp.Params.Add("inc", "releases");
                }
                else if (obj.GetType() == typeof(Album))
                {
                    method = "release";
                    sp.Album.MbId = obj.MbId;
                    sp.Params.Add("inc", "recordings+artists");
                }
                else if (obj.GetType() == typeof(Song))
                {
                    method = "recording";
                    sp.Track.MbId = obj.MbId;
                    sp.Params.Add("inc", "releases+artists");
                }

                funcSearch = new Func<string, SearchParam, string>(musicBrainzSearch.CallLookupMethod);

                ExecMethodAndBuildView(method, sp, SERVICE_CALL.MUSIC_BRAINZ, funcSearch);
            }
        }

        private void toolStripMenuItemInfoMusicBrainz_Click(object sender, EventArgs e)
        {
            GetInfoFromMusicBrainz();
        }

        private void toolStripMenuItemOpenURL_Click(object sender, EventArgs e)
        {
            if (treeListViewResult.SelectedObjects.Count > 0)
            {
                BaseObject obj = (BaseObject)treeListViewResult.SelectedObjects[0];

                Process.Start(obj.Url);
            }
            
        }

        private void treeListViewResult_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (treeListViewResult.SelectedObjects.Count > 0)
            {
                BaseObject obj = (BaseObject)treeListViewResult.SelectedObjects[0];

                if (obj.Childs.Count > 0)
                    treeListViewResult.Expand(obj);

            }
        }

        private void explorerTreeViewTagger_SelectedIndexChanged(string physicalPath)
        {
            if (Directory.Exists(physicalPath))
            {
                DirectoryInfo d = Directory.CreateDirectory(physicalPath);
                FileInfo[] f = d.GetFiles();
                foreach (FileInfo file in f)
                {
                    if (Utils.BASSAddOnIsFileSupported(Globals.Instance.PluginsLoaded, file.Name))
                        listViewTagger.Items.Add(new ListViewItem(file.Name));
                }
            }
        }

        #region filebrowser
        private void browser_SelectedFolderChanged(object sender, FileBrowser.SelectedFolderChangedEventArgs e)
        {
            LoadFilesIntoListView(e.Path);
        }
        #endregion filebrowser

        private void LoadFilesIntoListView(string path)
        {
            listViewTagger.Items.Clear();

            if (Directory.Exists(path))
            {
                string[] files = Directory.GetFiles(path);
                foreach (string file in files)
                {
                    if (Utils.BASSAddOnIsFileSupported(Globals.Instance.PluginsLoaded, file))
                    {
                        if (PSAudioUtils.IsModuleFile(file) == false)
                            listViewTagger.Items.Add(new ListViewItem(new string[] { Path.GetFileName(file), path }));
                    }
                }
            }

            CheckAllSourceObjects();
        }

        private void listViewTagger_DragEnter(object sender, DragEventArgs e)
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

        private void listViewTagger_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                if (Utils.BASSAddOnIsFileSupported(Globals.Instance.PluginsLoaded, file))
                {
                    //Path.GetFileName(file);
                    try
                    {
                        File.Copy(file, Path.Combine( browser.SelectedItem.Path, Path.GetFileName(file)));                        
                    }
                    catch (Exception ex)
                    { }

                    //


                }
            }

            LoadFilesIntoListView(browser.SelectedItem.Path);
        }


        private List<BaseObject> GetListBaseObjectInSelfAndChilds(BaseObject obj, string objType)
        {
            List<BaseObject> list = new List<BaseObject>();

            GetSpecifiedBaseObjectInSelfAndChilds(obj, objType, list);

            return list;
        }

        private void GetSpecifiedBaseObjectInSelfAndChilds(BaseObject obj, string objType, List<BaseObject> list)
        {
            if (obj.ObjType.Equals(objType))
                list.Add(obj);

            foreach (BaseObject child in obj.Childs)
            {
                GetSpecifiedBaseObjectInSelfAndChilds(child, objType, list);
            }
        }

        private void CopyToTagList()
        {
            foreach (BaseObject obj in treeListViewResult.SelectedObjects)
            {
                BaseObject parent = obj;

                while (treeListViewResult.GetParent(parent) != null)
                    parent = (BaseObject)treeListViewResult.GetParent(parent);

                // this piece of code takes all albums / artists / tracks starting the parent node
                // takes only the 1st album found, the 1st artist and all the tracks
                // tipically, there are several situations:
                /*
                 * 1st case
                 * album
                 *  - artist
                 *  - tracks[]
                 *  
                 * 
                 * 2nd case
                 * track
                 *  - album
                 *  - artist
                 *  
                 * artist
                 *  - tracks[]
                 * */
                List<BaseObject> albums = GetListBaseObjectInSelfAndChilds(parent, "Album");
                List<BaseObject> artists = GetListBaseObjectInSelfAndChilds(parent, "Artist");
                List<BaseObject> tracks = GetListBaseObjectInSelfAndChilds(parent, "Track");

                List<SongDetail> listTracks = new List<SongDetail>();

                string cacheImageUrl = null;
                Image coverImage = null;
                
                foreach (Song song in tracks)
                {
                    SongDetail songDetail = new SongDetail();

                    if (albums.Count > 0)
                        songDetail.Album = (Album)albums[0];
                    if (artists.Count > 0)
                        songDetail.Artist = (Artist)artists[0];
                    songDetail.Song = song;

                    // take picture from web only if is not already taken from previous cycle                
                    string imageUrl = songDetail.Album.ImageUrl ?? songDetail.Song.ImageUrl;
                    if (String.IsNullOrEmpty(imageUrl) == false)
                    {
                        if (imageUrl.Equals(cacheImageUrl) == false)
                        {
                            cacheImageUrl = imageUrl;
                            coverImage = null;

                            try
                            {
                                // take picture from url                    
                                WebRequest req = WebRequest.Create(imageUrl);
                                WebResponse response = req.GetResponse();
                                Stream stream = response.GetResponseStream();

                                coverImage = Image.FromStream(stream);
                            }
                            catch (Exception)
                            { 
                                // error while getting image 
                            }
                        }
                    }

                    songDetail.CoverArt = coverImage;

                    listTracks.Add(songDetail);
                }

                int count = tracks.Count;

                string text = String.Format("tracks copied to tag list: {0} ", count);

                toolStripStatusLabelStatus.Text = text;

                objectListViewTagger.SetObjects(listTracks);

                if (tracks.Count == 0)
                    MessageBox.Show("No tracks found on this item", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItemTagList_Click(object sender, EventArgs e)
        {
            CopyToTagList();
        }

        private void objectListViewTagger_SelectionChanged(object sender, EventArgs e)
        {
            if (objectListViewTagger.SelectedObject != null)
            {
                SongDetail songDetail = (SongDetail)objectListViewTagger.SelectedObject;

                textBoxTagArtist.Text = songDetail.Artist.Name;
                textBoxTagAlbum.Text = songDetail.Album.Name;
                textBoxTagTitle.Text = songDetail.Song.Name;
                textBoxTagYear.Text = songDetail.Album.Date;
                labelTagLength.Text = songDetail.Song.Length;
                textBoxTagPos.Text = songDetail.Song.Position;

                Image image = songDetail.CoverArt != null ? songDetail.CoverArt : PSAudioUtils.GetBlankImage();

                pictureBoxCover.Image = image;
            }
        }

        private void toolStripButtonSendTag_Click(object sender, EventArgs e)
        {
            CopyToTagList();
        }

        private void TagFile(SongDetail songDetail)
        {
            int index = objectListViewTagger.IndexOf(songDetail);

            string path = String.Format("{0}\\{1}", listViewTagger.Items[index].SubItems[1].Text, listViewTagger.Items[index].SubItems[0].Text);
            TagLib.File tagFile = TagLib.File.Create(path);

            // album
            tagFile.Tag.Album = songDetail.Album.Name;
            // year
            if (String.IsNullOrEmpty(songDetail.Album.Date) == false)
            {
                uint year = 0;
                if (uint.TryParse(songDetail.Album.Date, out year))
                {
                    tagFile.Tag.Year = year;
                }
            }
            // performers
            tagFile.Tag.Performers = new string[] { songDetail.Artist.Name };
            // artist album
            tagFile.Tag.AlbumArtists = new string[] { songDetail.Artist.Name };
            // position
            if (String.IsNullOrEmpty(songDetail.Song.Position) == false)
                tagFile.Tag.Track = uint.Parse(songDetail.Song.Position);
            // title
            tagFile.Tag.Title = songDetail.Song.Name;
            // mbid
            tagFile.Tag.MusicBrainzArtistId = songDetail.Artist.MbId;
            tagFile.Tag.MusicBrainzReleaseId = songDetail.Album.MbId;
            tagFile.Tag.MusicBrainzTrackId = songDetail.Song.MbId;

            if (songDetail.CoverArt != null)
            {
                TagLib.ByteVector imageData;
                using (var memoryStream = new MemoryStream())
                {                    
                    songDetail.CoverArt.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    imageData = new TagLib.ByteVector(memoryStream.ToArray());
                }
                TagLib.Picture picture = new TagLib.Picture(imageData);
                tagFile.Tag.Pictures = new TagLib.IPicture[] { picture };
                tagFile.Tag.Pictures[0].Type = TagLib.PictureType.FrontCover;
            }

            tagFile.Save();
        }

        private void TagSelectedFiles()
        {
            int success = 0;
            int errors = 0;

            foreach (SongDetail songDetail in objectListViewTagger.CheckedObjects)
            {                
                try
                {
                    TagFile(songDetail);
                    success++;
                }
                catch (Exception)
                {
                    errors++;
                }
            }

            toolStripStatusLabelStatus.Text = String.Format("files tagged: {0}; errors {1}", success, errors);
        }

        private void toolStripButtonTag_Click(object sender, EventArgs e)
        {
            TagSelectedFiles();
        }

        private void MoveListViewItem(ObjectListView lv, bool moveUp)
        {
            List<Object> cache = new List<Object>();
            int selIdx;

            if (lv.Items.Count > 0)
            {
                selIdx = lv.SelectedItems[0].Index;
                if (moveUp)
                {
                    // ignore moveup of row(0)
                    if (selIdx == 0)
                        return;

                    // move the subitems for the previous row
                    // to cache to make room for the selected row
                    Object obj = lv.GetModelObject(selIdx) ;
                    cache.Add( lv.GetModelObject(selIdx) );
                    lv.RemoveObject(obj);
                    lv.InsertObjects(selIdx - 1, cache);
                    lv.Items[selIdx].Selected = false;
                    lv.Items[selIdx - 1].Selected = true;
                    lv.Refresh();
                    lv.Focus();                    
                }
                else
                {
                    // ignore movedown of last item
                    if (selIdx == lv.Items.Count - 1)
                        return;
                    // move the subitems for the next row
                    // to cache so we can move the selected row down
                    Object obj = lv.GetModelObject(selIdx + 1);
                    cache.Add(lv.GetModelObject(selIdx + 1));
                    lv.RemoveObject(obj);
                    lv.InsertObjects(selIdx, cache);
                    lv.Items[selIdx].Selected = false;
                    lv.Items[selIdx + 1].Selected = true;
                    lv.Refresh();
                    lv.Focus();
                }
            }
        }


        private void MoveListViewItem(ListView.ListViewItemCollection lvic, int selIdx, bool moveUp)
        {
            string cache;

            if (lvic.Count > 0)
            {
                if (moveUp)
                {
                    // ignore moveup of row(0)
                    if (selIdx == 0)
                        return;

                    // move the subitems for the previous row
                    // to cache to make room for the selected row
                    for (int i = 0; i < lvic[selIdx].SubItems.Count; i++)
                    {
                        cache = lvic[selIdx - 1].SubItems[i].Text;
                        lvic[selIdx - 1].SubItems[i].Text = lvic[selIdx].SubItems[i].Text;
                        lvic[selIdx].SubItems[i].Text = cache;
                    }
                    lvic[selIdx].Selected = false;
                    lvic[selIdx - 1].Selected = true;                    
                }
                else
                {
                    // ignore movedown of last item
                    if (selIdx == lvic.Count - 1)
                        return;
                    // move the subitems for the next row
                    // to cache so we can move the selected row down
                    for (int i = 0; i < lvic[selIdx].SubItems.Count; i++)
                    {
                        cache = lvic[selIdx + 1].SubItems[i].Text;
                        lvic[selIdx + 1].SubItems[i].Text = lvic[selIdx].SubItems[i].Text;
                        lvic[selIdx].SubItems[i].Text = cache;
                    }
                    lvic[selIdx].Selected = false;
                    lvic[selIdx + 1].Selected = true;                    
                }
            }
        }

        private void SaveTagFromDetail()
        {
            int success = 0;
            int errors = 0;

            foreach (ListViewItem lvi in listViewTagger.SelectedItems)
            {
                try
                {
                    string path = String.Format("{0}\\{1}", lvi.SubItems[1].Text, lvi.SubItems[0].Text);

                    TagLib.File tagFile = TagLib.File.Create(path);

                    // album
                    if (checkBoxAlbumTag.Checked)
                        tagFile.Tag.Album = textBoxTagAlbum.Text;
                    // year
                    if (checkBoxArtistTag.Checked)
                    {
                        uint year = 0;
                        bool isParsed = uint.TryParse(textBoxTagYear.Text, out year);
                        if (isParsed)
                            tagFile.Tag.Year = year;
                    }
                    // performers
                    if (checkBoxArtistTag.Checked)
                    {
                        tagFile.Tag.Performers = new string[] { textBoxTagArtist.Text };
                        tagFile.Tag.AlbumArtists = tagFile.Tag.Performers;
                    }
                    // position
                    if (checkBoxPosTag.Checked)
                    {
                        uint pos = 0;
                        bool isParsedPos = uint.TryParse(textBoxTagPos.Text, out pos);
                        if (isParsedPos)
                            tagFile.Tag.Track = pos;
                    }
                    // title
                    if (checkBoxTitleTag.Checked)
                        tagFile.Tag.Title = textBoxTagTitle.Text;
                    
                    // picture                
                    if (checkBoxPictureTag.Checked && pictureBoxCover.Image.Tag != null)
                    {
                        // write only if a new image is assigner or no image is assigned,
                        // with checkbox set to checked
                        try
                        {
                            TagLib.ByteVector imageData = new TagLib.ByteVector() ;
                            
                            // new image case
                            if (pictureBoxCover.Image.Tag.Equals(NEW_IMAGE_TAG))
                            {
                                using (var memoryStream = new MemoryStream())
                                {

                                    System.Drawing.Imaging.ImageFormat format = null;
                                    format = ImageFormat.Png.Equals(pictureBoxCover.Image.RawFormat) ? ImageFormat.Png : ImageFormat.Jpeg;                                    
                                        
                                    pictureBoxCover.Image.Save(memoryStream, format);
                                    imageData = new TagLib.ByteVector(memoryStream.ToArray());
                                }
                            }
                            if (imageData.Data.Length > 0)
                            {
                                TagLib.Picture picture = new TagLib.Picture(imageData);
                                tagFile.Tag.Pictures = new TagLib.IPicture[] { picture };
                                tagFile.Tag.Pictures[0].Type = TagLib.PictureType.FrontCover;
                            }
                            else
                            {
                                tagFile.Tag.Pictures = new TagLib.IPicture[0];
                            }
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("error saving image: " + e.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    // save
                    tagFile.Save();

                    success++;
                }
                catch (Exception)
                {
                    errors++;
                }

                toolStripStatusLabelStatus.Text = String.Format("Tag applied to {0} files, {1} errors reported", success, errors);
            }
        }

        private void toolStripButtonTagDetail_Click(object sender, EventArgs e)
        {
            SaveTagFromDetail();
        }

        private void listViewTagger_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = listViewTagger.SelectedIndices.Count;
            bool isBtnEnabled = count > 0;
            toolStripButtonLoadTag.Enabled = isBtnEnabled;
            toolStripButtonSaveTagDetail.Enabled = isBtnEnabled;
            toolStripButtonRename.Enabled = isBtnEnabled;
            toolStripButtonPlay.Enabled = isBtnEnabled;

            bool isMultipleFilesSelected = count > 1;

            checkBoxTitleTag.Checked = !isMultipleFilesSelected;
            checkBoxPosTag.Checked = !isMultipleFilesSelected;
            
        }

        private void LoadTagIntoPanel()
        {
            if (listViewTagger.SelectedIndices.Count == 1)
            {
                string path = String.Format("{0}\\{1}", listViewTagger.SelectedItems[0].SubItems[1].Text, listViewTagger.SelectedItems[0].SubItems[0].Text);

                try
                {
                    TagLib.File tagFile = TagLib.File.Create(path);

                    // album
                    textBoxTagAlbum.Text = tagFile.Tag.Album;
                    // year
                    textBoxTagYear.Text = tagFile.Tag.Year == 0 ? String.Empty : tagFile.Tag.Year.ToString();
                    // performers
                    textBoxTagArtist.Text = tagFile.Tag.Performers.Count() > 0 ? tagFile.Tag.Performers[0] : null;
                    // position
                    textBoxTagPos.Text = tagFile.Tag.Track == 0 ? String.Empty : tagFile.Tag.Track.ToString();
                    // title
                    textBoxTagTitle.Text = tagFile.Tag.Title;
                    // length
                    labelTagLength.Text = TimeSpan.FromSeconds(tagFile.Length).ToString(@"mm\:ss");

                    if (tagFile.Tag.Pictures.Count() > 0)
                    {
                        try
                        {
                            TagLib.ByteVector bv = tagFile.Tag.Pictures[0].Data;

                            //using (MemoryStream ms = new MemoryStream())
                            //{
                            //    ms.Write(bv.Data, 0, bv.Count);
                            //    System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
                            //    pictureBoxCover.Image = img;                            
                            //}

                            // NOTE: closing MemoryStream would generate a GDI+ error if later image is saved to a file
                            MemoryStream ms = new MemoryStream(bv.Count);
                            ms.Write(bv.Data, 0, bv.Count);
                            System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
                            pictureBoxCover.Image = img;

                        }
                        catch (Exception)
                        {
                            pictureBoxCover.Image = PSAudioUtils.GetBlankImage();
                        }
                    }
                    else
                        pictureBoxCover.Image = PSAudioUtils.GetBlankImage();

                    tabControlTag.SelectedTab = tabPageTagDetail;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toolStripButtonLoadTag_Click(object sender, EventArgs e)
        {
            LoadTagIntoPanel();
        }

        private void buttonSourceUp_Click(object sender, EventArgs e)
        {
            MoveListViewItem(objectListViewTagger, true);
        }

        private void buttonSourceDown_Click(object sender, EventArgs e)
        {
            MoveListViewItem(objectListViewTagger, false);
        }

        private void buttonDestUp_Click(object sender, EventArgs e)
        {
            //foreach (int idx in listViewTagger.SelectedIndices)                
                listViewTagger.MoveSelectedListViewItem(true);
                     
        }

        private void buttonDestDown_Click(object sender, EventArgs e)
        {
            //for (int idx = listViewTagger.SelectedIndices.Count; --idx >= 0;)
                listViewTagger.MoveSelectedListViewItem(false);            
        }

        private void toolStripMenuItemCheckall_Click(object sender, EventArgs e)
        {
            CheckAllSourceObjects();
        }

        private void CheckAllSourceObjects()
        {
            UnCheckAllSourceObjects();
            int count = listViewTagger.Items.Count > objectListViewTagger.GetItemCount() ?
                objectListViewTagger.GetItemCount() : listViewTagger.Items.Count;

            for (int i = 0; i < count; i++)
                objectListViewTagger.GetItem(i).Checked = true;
        }


        private void toolStripMenuItemUncheckAll_Click(object sender, EventArgs e)
        {
            UnCheckAllSourceObjects();
        }

        private void UnCheckAllSourceObjects()
        {
            foreach (OLVListItem lvi in objectListViewTagger.Items)
                lvi.Checked = false;
        }

        private void objectListViewTagger_ItemActivate(object sender, EventArgs e)
        {
            foreach (OLVListItem olvi in objectListViewTagger.SelectedItems) 
                olvi.Checked = !olvi.Checked;
        }

        private void objectListViewTagger_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int idx = e.Index;
            if (idx >= listViewTagger.Items.Count)
                e.NewValue = CheckState.Unchecked;
            
        }

        private void objectListViewTagger_ItemChecked(object sender, ItemCheckedEventArgs e)
        {            
            if (listViewTagger.Items.Count > e.Item.Index)
            {
                if (e.Item.Checked)
                {
                    listViewTagger.Items[e.Item.Index].BackColor = Color.LightGreen;
                }
                else
                    listViewTagger.Items[e.Item.Index].BackColor = Color.Transparent;
            }

            toolStripButtonSaveFromTagList.Enabled = objectListViewTagger.CheckedItems.Count > 0;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer4_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void treeListViewResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripButtonSendTag.Enabled = treeListViewResult.SelectedIndices.Count > 0;
                
            
        }

        private void objectListViewTagger_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listViewTagger_DoubleClick(object sender, EventArgs e)
        {
            LoadTagIntoPanel();
            tabControlTag.SelectedTab = tabPageTagDetail;
        }

        private void objectListViewTagger_Click(object sender, EventArgs e)
        {
            
        }

        private void objectListViewTagger_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                if (objectListViewTagger.CheckedIndices.Count > 0)
                    UnCheckAllSourceObjects();
                else
                    CheckAllSourceObjects();
            }
        }

        const string patternTitle = @"%\bt\b|%\btitle\b";
        const string patternArtist = @"%\ba\b|%\bartist\b";
        const string patternAlbum = @"%\br\b|%\balbum\b";
        const string patternYear = @"%\bd\b|%\by\b|%\byear\b";
        const string patternPos = @"%\bp\b|%\bpos\b";

        private string ReplaceFolderNameWithTag(string[] files, string path, string pattern)
        {
            string album = null;
            uint year = 0;
            string artist = null;

            bool isTagInitialized = false;
            bool isSameAlbum = true;

            string filenameReplaced = null;

            TagLib.File tagFile = null;

            foreach (string file in files)
            {
                tagFile = TagLib.File.Create(file);

                if (isTagInitialized)
                {
                    if (album.Equals(tagFile.Tag.Album) == false) isSameAlbum = false;
                    if (year.Equals(tagFile.Tag.Year) == false) isSameAlbum = false;
                    if (tagFile.Tag.Performers.Length > 0)
                        if (artist.Equals(tagFile.Tag.Performers[0]) == false) isSameAlbum = false;
                }
                else
                {
                    album = tagFile.Tag.Album;
                    year = tagFile.Tag.Year;
                    if (tagFile.Tag.Performers.Length > 0)
                        artist = tagFile.Tag.Performers[0];
                }

                isTagInitialized = true;
            }

            if (isSameAlbum)
            {
                StringBuilder sb = new StringBuilder(pattern);

                Regex rgx = new Regex(patternTitle, RegexOptions.IgnoreCase);

                MatchCollection matches = rgx.Matches(sb.ToString());

                // artist
                rgx = new Regex(patternArtist, RegexOptions.IgnoreCase);

                matches = rgx.Matches(sb.ToString());

                foreach (Match match in matches)
                    sb = sb.Replace(match.Value, String.Join(",", tagFile.Tag.Performers));

                // album
                rgx = new Regex(patternAlbum, RegexOptions.IgnoreCase);

                matches = rgx.Matches(sb.ToString());

                foreach (Match match in matches)
                    sb = sb.Replace(match.Value, tagFile.Tag.Album);

                // year
                rgx = new Regex(patternYear, RegexOptions.IgnoreCase);

                matches = rgx.Matches(sb.ToString());

                foreach (Match match in matches)
                    sb = sb.Replace(match.Value, tagFile.Tag.Year.ToString());

                filenameReplaced = sb.ToString();

            }
            else
                MessageBox.Show("To rename the parent folder, selected files must have same album, year and artist tag", null, MessageBoxButtons.OK, MessageBoxIcon.Error);

            return filenameReplaced;
        }

        private string ReplaceFileNameWithTag(string file, string pattern)
        {
            StringBuilder sb = new StringBuilder(pattern);

            TagLib.File tagFile = TagLib.File.Create(file);

            // title
            Regex rgx = new Regex(patternTitle, RegexOptions.IgnoreCase);

            MatchCollection matches = rgx.Matches(sb.ToString());

            foreach (Match match in matches)
                sb = sb.Replace(match.Value, tagFile.Tag.Title);

            // artist
            rgx = new Regex(patternArtist, RegexOptions.IgnoreCase);

            matches = rgx.Matches(sb.ToString());

            foreach (Match match in matches)
                sb = sb.Replace(match.Value, String.Join(",", tagFile.Tag.Performers));

            // album
            rgx = new Regex(patternAlbum, RegexOptions.IgnoreCase);

            matches = rgx.Matches(sb.ToString());

            foreach (Match match in matches)
                sb = sb.Replace(match.Value, tagFile.Tag.Album);

            // year
            rgx = new Regex(patternYear, RegexOptions.IgnoreCase);

            matches = rgx.Matches(sb.ToString());

            foreach (Match match in matches)
                sb = sb.Replace(match.Value, tagFile.Tag.Year.ToString());

            // position
            rgx = new Regex(patternPos, RegexOptions.IgnoreCase);

            matches = rgx.Matches(sb.ToString());

            foreach (Match match in matches)
                sb = sb.Replace(match.Value, tagFile.Tag.Track.ToString("D2"));

            string filenameReplaced = sb.ToString();

            return filenameReplaced;
        }

        private void RenameSelectedFiles()
        {
            string filenamePattern = textBoxFilename.Text;

            int cntsuccess = 0;
            int cnterrors = 0;

            string[] files = new string[listViewTagger.SelectedItems.Count];

            bool isFileRenameEnabled = checkBoxRenameFiles.Checked;
            bool isDirRenameEnabled = checkBoxIncludeDir.Checked;

            bool isValid = !(isFileRenameEnabled && String.IsNullOrEmpty(textBoxFilename.Text));
            isValid = isValid && !(isDirRenameEnabled && String.IsNullOrEmpty(textBoxRenameDir.Text));

            if (isValid)
            {
                if (files.Length > 0)
                {
                    int idx = 0;

                    foreach (ListViewItem item in listViewTagger.SelectedItems)
                    {
                        string path = String.Format("{0}\\{1}", item.SubItems[1].Text, item.SubItems[0].Text);

                        files[idx] = path;

                        if (checkBoxRenameFiles.Checked)
                        {
                            string filenameReplaced = ReplaceFileNameWithTag(path, filenamePattern);

                            if (String.IsNullOrEmpty(filenameReplaced) == false)
                            {
                                try
                                {
                                    string newPath = String.Format("{0}\\{1}{2}", item.SubItems[1].Text, filenameReplaced, Path.GetExtension(path));
                                    File.Move(path, newPath);
                                    if (path.Equals(newPath) == false)
                                    {
                                        files[idx] = newPath;
                                        cntsuccess++;
                                    }
                                }
                                catch (Exception e)
                                {
                                    cnterrors++;
                                }
                            }
                            else
                                cnterrors++;
                        }

                        idx++;
                    }

                    if (checkBoxIncludeDir.Checked)
                    {
                        string foldernameReplaced = ReplaceFolderNameWithTag(files, browser.SelectedItem.Path, textBoxRenameDir.Text);

                        if (String.IsNullOrEmpty(foldernameReplaced) == false)
                        {
                            try
                            {
                                string oldpath = browser.SelectedItem.Path;
                                string newpath = Directory.GetParent(browser.SelectedItem.Path) + "\\" + foldernameReplaced;
                                if (oldpath.Equals(newpath) == false)
                                {
                                    Directory.Move(oldpath, newpath);
                                    cntsuccess++;
                                }
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                cnterrors++;
                            }
                        }
                        else
                            cnterrors++;
                    }

                    LoadFilesIntoListView(browser.SelectedItem.Path);

                    toolStripStatusLabelStatus.Text = String.Format("Files successfully renamed: {0}; Files with errors: {1}", cntsuccess, cnterrors);
                }
                else
                    MessageBox.Show("Please select almost one file to tag", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Please specifiy a valid pattern", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            
        }

        private void toolStripButtonRename_Click(object sender, EventArgs e)
        {
            RenameSelectedFiles();
        }

        private void comboBoxMask_SelectedValueChanged(object sender, EventArgs e)
        {
            //textBoxFilename.Text = comboBoxMask.Text;            
        }

        private void tagFileToolStripMenuItemSaveTag_Click(object sender, EventArgs e)
        {
            if (objectListViewTagger.SelectedIndices.Count > 0)
            {
                int idx = objectListViewTagger.SelectedIndices[0];
                if (idx < listViewTagger.Items.Count)
                    TagFile((SongDetail)objectListViewTagger.SelectedObjects[0]);
            }
            
        }

        private void contextMenuStripSourceTagger_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool isTagEnabled = false;

            if (objectListViewTagger.SelectedIndices.Count > 0)
            {
                int idx = objectListViewTagger.SelectedIndices[0];
                if (idx < listViewTagger.Items.Count)                
                    isTagEnabled = true;             
            }

            tagFileToolStripMenuItemSaveTag.Enabled = isTagEnabled;
            
        }

        private void toolStripMenuItemLoadTag_Click(object sender, EventArgs e)
        {
            LoadTagIntoPanel();
        }

        private void toolStripMenuItemSaveTag_Click(object sender, EventArgs e)
        {
            SaveTagFromDetail();
        }

        private void toolStripMenuItemRenameTag_Click(object sender, EventArgs e)
        {
            RenameSelectedFiles();
        }

        private void contextMenuStripDestinationTag_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool isMenuItemsEnabled = (listViewTagger.SelectedItems.Count > 0);

            toolStripMenuItemLoadTag.Enabled = isMenuItemsEnabled;
            toolStripMenuItemSaveTag.Enabled = isMenuItemsEnabled;
            toolStripMenuItemRenameTag.Enabled = isMenuItemsEnabled;
            selecteAllToolStripMenuItemSelectAll.Enabled = isMenuItemsEnabled;
            toolStripMenuItemPlay.Enabled = isMenuItemsEnabled;
        }

        private void treeListViewResult_SelectionChanged(object sender, EventArgs e)
        {
            bool isMbidPresent = false;

            if (treeListViewResult.SelectedObjects.Count > 0)
            {
                BaseObject obj = (BaseObject)treeListViewResult.SelectedObjects[0];

                isMbidPresent = String.IsNullOrEmpty(obj.MbId) == false;
            }

            toolStripButtonLastFM.Enabled = isMbidPresent;
            toolStripButtonMusicBrainz.Enabled = isMbidPresent;
        }

        private void toolStripButtonLastFM_Click(object sender, EventArgs e)
        {
            GetInfoFromLastFM();
        }

        private void toolStripButtonMusicBrainz_Click(object sender, EventArgs e)
        {
            GetInfoFromMusicBrainz();
        }

        private void pictureBoxCover_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            string sep = string.Empty;
            string filter = String.Empty;
            string filterAllImages = String.Empty;

            foreach (var c in codecs)
            {
                string codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
                filter = String.Format("{0}{1}{2} ({3})|{3}", filter, sep, codecName, c.FilenameExtension);
                filterAllImages = String.Format("{0}{1};", filterAllImages, c.FilenameExtension);
                sep = "|";
            }

            //openFileDialog.Filter = String.Format("{0}{1}{2} ({3})|{3}{1}{4} ({5}|{5}) ", filter, sep, "All Files", "*.*", "All Images", filterAllImages);            

            openFileDialog.Filter = String.Format("{4} |{5}{1}{0}{1}{2} ({3})|{3}", filter, sep, "All Files", "*.*", "All Images", filterAllImages);            

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;

                pictureBoxCover.Image = Image.FromFile(path);

                pictureBoxCover.Image.Tag = NEW_IMAGE_TAG;
            }
        }

        private void checkBoxPictureTag_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked == false)
            {
                pictureBoxCover.Image = PSAudioUtils.GetBlankImage();
            }
        }

        private void checkBoxIncludeDir_CheckedChanged(object sender, EventArgs e)
        {
            textBoxRenameDir.Enabled = ((CheckBox)sender).Checked;
        }

        private void listViewTagger_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {

        }

        private void checkBoxRenameFiles_CheckedChanged(object sender, EventArgs e)
        {
            textBoxFilename.Enabled = ((CheckBox)sender).Checked;
        }

        private void selecteAllToolStripMenuItemSelectAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewTagger.Items)
                item.Selected = true;
        }

        private void pictureBoxCover_LoadCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {

        }

        private void toolStripButtonSaveImage_Click(object sender, EventArgs e)
        {
            if (pictureBoxCover.Image.Tag == null || pictureBoxCover.Image.Tag.Equals(PSAudioUtils.NO_IMAGE) == false)
            {
                // Displays a SaveFileDialog so the user can save the Image
                // assigned to Button2.
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
                saveFileDialog1.Title = "Save an Image File";
                saveFileDialog1.ShowDialog();

                // If the file name is not an empty string open it for saving.
                if (saveFileDialog1.FileName != "")
                {

                    // Saves the Image via a FileStream created by the OpenFile method.
                    System.IO.FileStream fs =
                       (System.IO.FileStream)saveFileDialog1.OpenFile();
                    // Saves the Image in the appropriate ImageFormat based upon the
                    // File type selected in the dialog box.
                    // NOTE that the FilterIndex property is one-based.
                    switch (saveFileDialog1.FilterIndex)
                    {
                        case 1:

                            pictureBoxCover.Image.Save(fs,
                                System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;

                        case 2:
                            pictureBoxCover.Image.Save(fs,
                               System.Drawing.Imaging.ImageFormat.Bmp);
                            break;

                        case 3:
                            pictureBoxCover.Image.Save(fs,
                               System.Drawing.Imaging.ImageFormat.Gif);
                            break;
                    }

                    fs.Close();
                }
            }
            else
                MessageBox.Show("No image is currently loaded in the cover box", null, MessageBoxButtons.OK, MessageBoxIcon.Error);

            

            
        }

        private void toolStripButtonSaveTags_Click(object sender, EventArgs e)
        {
            
        }

        private void OpenSearchType(object sender, MouseEventArgs e = null)
        {
            Button btn = ((Button)sender);

            if (e == null || e.Button == System.Windows.Forms.MouseButtons.Left)
                btn.ContextMenuStrip.Show(Cursor.Position);
            else
                btn.ContextMenuStrip.Hide();

        }

        private void toolStripButtonSaveFromTagList_Click(object sender, EventArgs e)
        {
            TagSelectedFiles();            
        }

        private void buttonTrackTypeSearch_Click(object sender, EventArgs e)
        {            
            OpenSearchType(sender);
        }

        private void buttonArtistTypeSearch_Click(object sender, EventArgs e)
        {
            OpenSearchType(sender);
        }

        private void buttonAlbumTypeSearch_Click(object sender, EventArgs e)
        {
            OpenSearchType(sender);
        }

        private void buttonTrackTypeSearch_MouseUp(object sender, MouseEventArgs e)
        {
            OpenSearchType(sender, e);
        }

        private void buttonArtistTypeSearch_MouseUp(object sender, MouseEventArgs e)
        {
            OpenSearchType(sender, e);
        }

        private void buttonAlbumTypeSearch_MouseUp(object sender, MouseEventArgs e)
        {
            OpenSearchType(sender, e);
        }

        private void PlaySelectedFiles()
        {
            if (listViewTagger.SelectedItems.Count > 0)
            {
                AudioPlayer.Instance.ResetTrackList();

                foreach (ListViewItem lvi in listViewTagger.SelectedItems)
                {
                    string file = Path.Combine(lvi.SubItems[1].Text, lvi.SubItems[0].Text);

                    Track track = Track.GetTrack(file);

                    AudioPlayer.Instance.TrackList.Tracks.Add(track);
                }

                if (AudioPlayer.Instance.TrackList.Tracks.Count > 0)
                {
                    AudioPlayer.Instance.CurrentTrackIndex = 0;
                    AudioPlayer.Instance.Play(true);
                }
            }
        }

        private void toolStripMenuItemPlay_Click(object sender, EventArgs e)
        {

            PlaySelectedFiles();

        }

        private void toolStripButtonPlay_Click(object sender, EventArgs e)
        {
            PlaySelectedFiles();
        }

    }

    interface HasChilds
    {
        List<BaseObject> Childs { get; set; }
    }

    class BaseObject : HasChilds
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public List<BaseObject> Childs { get; set; }
        public string ObjType { get; protected set; }
        public string MbId { get; set; }

        protected BaseObject()
        {
            this.Childs = new List<BaseObject>();
        }

        public BaseObject(string objtype) : this()
        {            
            this.ObjType = objtype;
        }
    }

    class Root : HasChilds
    {
        public List<BaseObject> Childs { get; set; }

        public Root()
        {
            this.Childs = new List<BaseObject>();
        }
    }

    class Song : BaseObject
    {
        public string Length { get; set; }
        public string Position { get; set; }

        public Song()
        {
            this.ObjType = "Track";
        }
    }

    class Artist : BaseObject
    {
        public Artist()
        {
            this.ObjType = "Artist";
        }
    }

    class Album : BaseObject
    {
        public string Date { get; set; }

        public Album()
        {
            this.ObjType = "Album";
        }
    }

    class SongDetail
    {
        public SongDetail()
        {
            this.Album = new Album();
            this.Artist = new Artist();
            this.Song = new Song();
        }

        public Song Song { get; set; }
        public Album Album { get; set; }
        public Artist Artist { get; set; }

        public Image CoverArt { get; set; }
    }
}
