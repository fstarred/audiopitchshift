namespace PitchAndShiftAudio
{
    partial class UserControlTrackListView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listViewTrackList = new System.Windows.Forms.ListView();
            this.colHeaderPosition = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderArtist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderLength = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listViewTrackList
            // 
            this.listViewTrackList.AllowDrop = true;
            this.listViewTrackList.BackColor = System.Drawing.Color.Black;
            this.listViewTrackList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHeaderPosition,
            this.colHeaderTitle,
            this.colHeaderArtist,
            this.colHeaderLength,
            this.colHeaderPath});
            this.listViewTrackList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewTrackList.ForeColor = System.Drawing.Color.Lime;
            this.listViewTrackList.FullRowSelect = true;
            this.listViewTrackList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewTrackList.Location = new System.Drawing.Point(0, 0);
            this.listViewTrackList.Name = "listViewTrackList";
            this.listViewTrackList.ShowItemToolTips = true;
            this.listViewTrackList.Size = new System.Drawing.Size(618, 278);
            this.listViewTrackList.TabIndex = 15;
            this.listViewTrackList.UseCompatibleStateImageBehavior = false;
            this.listViewTrackList.View = System.Windows.Forms.View.Details;
            this.listViewTrackList.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listViewTrackList_ItemDrag);
            this.listViewTrackList.DragDrop += new System.Windows.Forms.DragEventHandler(this.listViewTrackList_DragDrop);
            this.listViewTrackList.DragEnter += new System.Windows.Forms.DragEventHandler(this.listViewTrackList_DragEnter);
            this.listViewTrackList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewTrackList_MouseDoubleClick);
            // 
            // colHeaderPosition
            // 
            this.colHeaderPosition.Text = "#";
            this.colHeaderPosition.Width = 30;
            // 
            // colHeaderTitle
            // 
            this.colHeaderTitle.Text = "Title";
            this.colHeaderTitle.Width = 240;
            // 
            // colHeaderArtist
            // 
            this.colHeaderArtist.Text = "Artist";
            this.colHeaderArtist.Width = 162;
            // 
            // colHeaderLength
            // 
            this.colHeaderLength.Text = "Length";
            // 
            // colHeaderPath
            // 
            this.colHeaderPath.Text = "Path";
            this.colHeaderPath.Width = 91;
            // 
            // UserControlTrackListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listViewTrackList);
            this.Name = "UserControlTrackListView";
            this.Size = new System.Drawing.Size(618, 278);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader colHeaderPosition;
        private System.Windows.Forms.ColumnHeader colHeaderTitle;
        private System.Windows.Forms.ColumnHeader colHeaderArtist;
        private System.Windows.Forms.ColumnHeader colHeaderLength;
        private System.Windows.Forms.ColumnHeader colHeaderPath;
        internal System.Windows.Forms.ListView listViewTrackList;
    }
}
