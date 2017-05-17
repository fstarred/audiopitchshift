namespace PitchAndShiftAudio
{
    partial class UserControlAudioTracks
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlAudioTracks));
            this.contextMenuStripListView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemOpenFileLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemMetaInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.buttonTrash = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.userControlTrackListView = new PitchAndShiftAudio.UserControlTrackListView();
            this.contextMenuStripListView.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStripListView
            // 
            this.contextMenuStripListView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpenFileLocation,
            this.toolStripMenuItemMetaInfo,
            this.toolStripMenuItemAdd,
            this.toolStripMenuItemRemove});
            this.contextMenuStripListView.Name = "contextMenuStripListView";
            this.contextMenuStripListView.Size = new System.Drawing.Size(217, 92);
            this.contextMenuStripListView.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripListView_Opening);
            // 
            // toolStripMenuItemOpenFileLocation
            // 
            this.toolStripMenuItemOpenFileLocation.Name = "toolStripMenuItemOpenFileLocation";
            this.toolStripMenuItemOpenFileLocation.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.toolStripMenuItemOpenFileLocation.Size = new System.Drawing.Size(216, 22);
            this.toolStripMenuItemOpenFileLocation.Text = "Open File Location";
            // 
            // toolStripMenuItemMetaInfo
            // 
            this.toolStripMenuItemMetaInfo.Name = "toolStripMenuItemMetaInfo";
            this.toolStripMenuItemMetaInfo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.toolStripMenuItemMetaInfo.Size = new System.Drawing.Size(216, 22);
            this.toolStripMenuItemMetaInfo.Text = "Update Meta Info";
            // 
            // toolStripMenuItemAdd
            // 
            this.toolStripMenuItemAdd.Image = global::PitchAndShiftAudio.Properties.Resources.add;
            this.toolStripMenuItemAdd.Name = "toolStripMenuItemAdd";
            this.toolStripMenuItemAdd.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.toolStripMenuItemAdd.Size = new System.Drawing.Size(216, 22);
            this.toolStripMenuItemAdd.Text = "Add to list";
            // 
            // toolStripMenuItemRemove
            // 
            this.toolStripMenuItemRemove.Image = global::PitchAndShiftAudio.Properties.Resources.minus_circle;
            this.toolStripMenuItemRemove.Name = "toolStripMenuItemRemove";
            this.toolStripMenuItemRemove.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.toolStripMenuItemRemove.Size = new System.Drawing.Size(216, 22);
            this.toolStripMenuItemRemove.Text = "Remove from list";
            // 
            // buttonTrash
            // 
            this.buttonTrash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTrash.Image = global::PitchAndShiftAudio.Properties.Resources.trash;
            this.buttonTrash.Location = new System.Drawing.Point(582, 3);
            this.buttonTrash.Name = "buttonTrash";
            this.buttonTrash.Size = new System.Drawing.Size(33, 28);
            this.buttonTrash.TabIndex = 22;
            this.toolTip1.SetToolTip(this.buttonTrash, "Clean playlist");
            this.buttonTrash.UseVisualStyleBackColor = true;
            this.buttonTrash.Click += new System.EventHandler(this.buttonTrash_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonSave.Image = global::PitchAndShiftAudio.Properties.Resources.save;
            this.buttonSave.Location = new System.Drawing.Point(538, 3);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(33, 28);
            this.buttonSave.TabIndex = 23;
            this.toolTip1.SetToolTip(this.buttonSave, "Save playlist");
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Image = global::PitchAndShiftAudio.Properties.Resources.open;
            this.buttonLoad.Location = new System.Drawing.Point(494, 3);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(33, 28);
            this.buttonLoad.TabIndex = 24;
            this.toolTip1.SetToolTip(this.buttonLoad, "Open playlist");
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Image = global::PitchAndShiftAudio.Properties.Resources.add;
            this.buttonAdd.Location = new System.Drawing.Point(3, 3);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(33, 28);
            this.buttonAdd.TabIndex = 25;
            this.toolTip1.SetToolTip(this.buttonAdd, "Add to playlist");
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemove.Image = ((System.Drawing.Image)(resources.GetObject("buttonRemove.Image")));
            this.buttonRemove.Location = new System.Drawing.Point(52, 3);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(33, 28);
            this.buttonRemove.TabIndex = 26;
            this.toolTip1.SetToolTip(this.buttonRemove, "Remove from playlist");
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.userControlTrackListView, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(614, 416);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonDown);
            this.panel1.Controls.Add(this.buttonUp);
            this.panel1.Controls.Add(this.buttonTrash);
            this.panel1.Controls.Add(this.buttonPlay);
            this.panel1.Controls.Add(this.buttonSave);
            this.panel1.Controls.Add(this.buttonStop);
            this.panel1.Controls.Add(this.buttonLoad);
            this.panel1.Controls.Add(this.buttonAdd);
            this.panel1.Controls.Add(this.buttonRemove);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 335);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(618, 46);
            this.panel1.TabIndex = 17;
            // 
            // buttonDown
            // 
            this.buttonDown.Image = global::PitchAndShiftAudio.Properties.Resources.arrow_down_playlist;
            this.buttonDown.Location = new System.Drawing.Point(194, 3);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(33, 28);
            this.buttonDown.TabIndex = 30;
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // buttonUp
            // 
            this.buttonUp.Image = global::PitchAndShiftAudio.Properties.Resources.arrow_up_playlist;
            this.buttonUp.Location = new System.Drawing.Point(155, 3);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(33, 28);
            this.buttonUp.TabIndex = 29;
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Image = global::PitchAndShiftAudio.Properties.Resources.play_playlist;
            this.buttonPlay.Location = new System.Drawing.Point(354, 3);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(33, 28);
            this.buttonPlay.TabIndex = 28;
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Image = global::PitchAndShiftAudio.Properties.Resources.stop_playlist;
            this.buttonStop.Location = new System.Drawing.Point(315, 3);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(33, 28);
            this.buttonStop.TabIndex = 27;
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // userControlTrackListView
            // 
            this.userControlTrackListView.ContextMenuStrip = this.contextMenuStripListView;
            this.userControlTrackListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlTrackListView.Location = new System.Drawing.Point(3, 3);
            this.userControlTrackListView.Name = "userControlTrackListView";
            this.userControlTrackListView.Size = new System.Drawing.Size(618, 326);
            this.userControlTrackListView.TabIndex = 18;
            // 
            // UserControlAudioTracks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UserControlAudioTracks";
            this.Size = new System.Drawing.Size(614, 416);
            this.Load += new System.EventHandler(this.UserControlAudioTracks_Load);
            this.contextMenuStripListView.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStripListView;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenFileLocation;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAdd;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRemove;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMetaInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonTrash;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Button buttonUp;
        private UserControlTrackListView userControlTrackListView;


    }
}
