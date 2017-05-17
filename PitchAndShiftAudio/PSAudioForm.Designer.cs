namespace PitchAndShiftAudio
{
    partial class PSAudioForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PSAudioForm));
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonTrackList = new System.Windows.Forms.Button();
            this.buttonRemoveLoop = new System.Windows.Forms.Button();
            this.buttonRepeatLoop = new System.Windows.Forms.Button();
            this.buttonEndLoop = new System.Windows.Forms.Button();
            this.buttonStartLoop = new System.Windows.Forms.Button();
            this.buttonBackward = new System.Windows.Forms.Button();
            this.buttonForward = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.progressBarPeakLeft = new System.Windows.Forms.ProgressBar();
            this.progressBarPeakRight = new System.Windows.Forms.ProgressBar();
            this.trackBarPosition = new System.Windows.Forms.TrackBar();
            this.trackBarVol = new System.Windows.Forms.TrackBar();
            this.trackBarPan = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBoxMixer = new System.Windows.Forms.GroupBox();
            this.userControlMixer5 = new PitchAndShiftAudio.UserControlEq();
            this.userControlMixer4 = new PitchAndShiftAudio.UserControlEq();
            this.userControlMixer3 = new PitchAndShiftAudio.UserControlEq();
            this.userControlMixer2 = new PitchAndShiftAudio.UserControlEq();
            this.userControlMixer1 = new PitchAndShiftAudio.UserControlEq();
            this.btnMixerFlat = new System.Windows.Forms.Button();
            this.timerBPM = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.optionsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabelFormat = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxFormat = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabelBitRate = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxRates = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabelMessage = new System.Windows.Forms.ToolStripLabel();
            this.toolStripProgressBarFile = new System.Windows.Forms.ToolStripProgressBar();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabelStatusEncode = new System.Windows.Forms.ToolStripLabel();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonLastfm = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabelBPM = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabelTempo = new System.Windows.Forms.ToolStripLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.trackBarPitch = new System.Windows.Forms.TrackBar();
            this.trackBarSpeed = new System.Windows.Forms.TrackBar();
            this.labelSpeedValue = new System.Windows.Forms.Label();
            this.labelPitchValue = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.contextMenuStripWave = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemSL = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEL = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripForm = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemStop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemOpenURL = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemStartLoop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEndLoop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRepeatLoop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRemoveLoop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemBPM = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemOpenPlaylist = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBoxWF = new System.Windows.Forms.PictureBox();
            this.audioSettingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageDisplay = new System.Windows.Forms.TabPage();
            this.userControlAudioDisplay = new PitchAndShiftAudio.UserControlAudioDisplay();
            this.tabPageTracklist = new System.Windows.Forms.TabPage();
            this.userControlTrackListView = new PitchAndShiftAudio.UserControlTrackListView();
            this.contextMenuStripTrackList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemUpdateMetainfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEncode = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageInstruments = new System.Windows.Forms.TabPage();
            this.userControlModInstrumentPanel = new PitchAndShiftAudio.UserControlModInstrumentPanel();
            this.userControlEffectsPanel = new PitchAndShiftAudio.UserControlEffectsPanel();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPan)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBoxMixer.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.contextMenuStripWave.SuspendLayout();
            this.contextMenuStripForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.audioSettingsBindingSource)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPageDisplay.SuspendLayout();
            this.tabPageTracklist.SuspendLayout();
            this.contextMenuStripTrackList.SuspendLayout();
            this.tabPageInstruments.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerUpdate
            // 
            this.timerUpdate.Enabled = true;
            this.timerUpdate.Interval = 50;
            this.timerUpdate.Tick += new System.EventHandler(this.timerUpdate_Tick);
            // 
            // buttonTrackList
            // 
            this.buttonTrackList.Image = global::PitchAndShiftAudio.Properties.Resources.list;
            this.buttonTrackList.Location = new System.Drawing.Point(387, 203);
            this.buttonTrackList.Name = "buttonTrackList";
            this.buttonTrackList.Size = new System.Drawing.Size(35, 23);
            this.buttonTrackList.TabIndex = 68;
            this.toolTip.SetToolTip(this.buttonTrackList, "Tracklist");
            this.buttonTrackList.UseVisualStyleBackColor = true;
            this.buttonTrackList.Click += new System.EventHandler(this.buttonTrackList_Click);
            // 
            // buttonRemoveLoop
            // 
            this.buttonRemoveLoop.Image = global::PitchAndShiftAudio.Properties.Resources.del_loop;
            this.buttonRemoveLoop.Location = new System.Drawing.Point(122, 10);
            this.buttonRemoveLoop.Name = "buttonRemoveLoop";
            this.buttonRemoveLoop.Size = new System.Drawing.Size(32, 23);
            this.buttonRemoveLoop.TabIndex = 3;
            this.toolTip.SetToolTip(this.buttonRemoveLoop, "Remove loop");
            this.buttonRemoveLoop.UseVisualStyleBackColor = true;
            this.buttonRemoveLoop.Click += new System.EventHandler(this.buttonRemoveLoop_Click);
            // 
            // buttonRepeatLoop
            // 
            this.buttonRepeatLoop.Image = global::PitchAndShiftAudio.Properties.Resources.repeat_loop;
            this.buttonRepeatLoop.Location = new System.Drawing.Point(84, 10);
            this.buttonRepeatLoop.Name = "buttonRepeatLoop";
            this.buttonRepeatLoop.Size = new System.Drawing.Size(32, 23);
            this.buttonRepeatLoop.TabIndex = 2;
            this.toolTip.SetToolTip(this.buttonRepeatLoop, "Repeat loop");
            this.buttonRepeatLoop.UseVisualStyleBackColor = true;
            this.buttonRepeatLoop.Click += new System.EventHandler(this.buttonRepeatLoop_Click);
            // 
            // buttonEndLoop
            // 
            this.buttonEndLoop.Image = global::PitchAndShiftAudio.Properties.Resources.eloop;
            this.buttonEndLoop.Location = new System.Drawing.Point(46, 10);
            this.buttonEndLoop.Name = "buttonEndLoop";
            this.buttonEndLoop.Size = new System.Drawing.Size(32, 23);
            this.buttonEndLoop.TabIndex = 1;
            this.toolTip.SetToolTip(this.buttonEndLoop, "Set end loop");
            this.buttonEndLoop.UseVisualStyleBackColor = true;
            this.buttonEndLoop.Click += new System.EventHandler(this.buttonEndLoop_Click);
            // 
            // buttonStartLoop
            // 
            this.buttonStartLoop.Image = global::PitchAndShiftAudio.Properties.Resources.sloop;
            this.buttonStartLoop.Location = new System.Drawing.Point(8, 10);
            this.buttonStartLoop.Name = "buttonStartLoop";
            this.buttonStartLoop.Size = new System.Drawing.Size(32, 23);
            this.buttonStartLoop.TabIndex = 0;
            this.toolTip.SetToolTip(this.buttonStartLoop, "Set start loop");
            this.buttonStartLoop.UseVisualStyleBackColor = true;
            this.buttonStartLoop.Click += new System.EventHandler(this.buttonStartLoop_Click);
            // 
            // buttonBackward
            // 
            this.buttonBackward.Image = global::PitchAndShiftAudio.Properties.Resources.backward;
            this.buttonBackward.Location = new System.Drawing.Point(6, 10);
            this.buttonBackward.Name = "buttonBackward";
            this.buttonBackward.Size = new System.Drawing.Size(28, 23);
            this.buttonBackward.TabIndex = 37;
            this.toolTip.SetToolTip(this.buttonBackward, "Backward (Ctrl + L Arrow)");
            this.buttonBackward.UseVisualStyleBackColor = true;
            this.buttonBackward.Click += new System.EventHandler(this.buttonBackward_Click);
            // 
            // buttonForward
            // 
            this.buttonForward.Image = global::PitchAndShiftAudio.Properties.Resources.forward;
            this.buttonForward.Location = new System.Drawing.Point(108, 10);
            this.buttonForward.Name = "buttonForward";
            this.buttonForward.Size = new System.Drawing.Size(28, 23);
            this.buttonForward.TabIndex = 36;
            this.toolTip.SetToolTip(this.buttonForward, "Forward (CTRL + R Arrow)");
            this.buttonForward.UseVisualStyleBackColor = true;
            this.buttonForward.Click += new System.EventHandler(this.buttonForward_Click);
            // 
            // btnStop
            // 
            this.btnStop.Image = global::PitchAndShiftAudio.Properties.Resources.stop;
            this.btnStop.Location = new System.Drawing.Point(40, 10);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(28, 23);
            this.btnStop.TabIndex = 33;
            this.toolTip.SetToolTip(this.btnStop, "Stop");
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Image = global::PitchAndShiftAudio.Properties.Resources.play;
            this.btnPlay.Location = new System.Drawing.Point(74, 10);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(28, 23);
            this.btnPlay.TabIndex = 1;
            this.toolTip.SetToolTip(this.btnPlay, "Play / Pause");
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Image = global::PitchAndShiftAudio.Properties.Resources.eject;
            this.btnOpen.Location = new System.Drawing.Point(142, 10);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(28, 23);
            this.btnOpen.TabIndex = 35;
            this.toolTip.SetToolTip(this.btnOpen, "Open (Right mouse to open entire folder content)");
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            this.btnOpen.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnOpen_MouseUp);
            // 
            // progressBarPeakLeft
            // 
            this.progressBarPeakLeft.Location = new System.Drawing.Point(73, 281);
            this.progressBarPeakLeft.Maximum = 32768;
            this.progressBarPeakLeft.Name = "progressBarPeakLeft";
            this.progressBarPeakLeft.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.progressBarPeakLeft.RightToLeftLayout = true;
            this.progressBarPeakLeft.Size = new System.Drawing.Size(141, 12);
            this.progressBarPeakLeft.Step = 1;
            this.progressBarPeakLeft.TabIndex = 7;
            // 
            // progressBarPeakRight
            // 
            this.progressBarPeakRight.Location = new System.Drawing.Point(229, 281);
            this.progressBarPeakRight.Maximum = 32768;
            this.progressBarPeakRight.Name = "progressBarPeakRight";
            this.progressBarPeakRight.Size = new System.Drawing.Size(141, 12);
            this.progressBarPeakRight.Step = 1;
            this.progressBarPeakRight.TabIndex = 9;
            // 
            // trackBarPosition
            // 
            this.trackBarPosition.AutoSize = false;
            this.trackBarPosition.LargeChange = 50;
            this.trackBarPosition.Location = new System.Drawing.Point(32, 170);
            this.trackBarPosition.Maximum = 100;
            this.trackBarPosition.Name = "trackBarPosition";
            this.trackBarPosition.Size = new System.Drawing.Size(390, 23);
            this.trackBarPosition.SmallChange = 10;
            this.trackBarPosition.TabIndex = 25;
            this.trackBarPosition.TickFrequency = 0;
            this.trackBarPosition.Scroll += new System.EventHandler(this.trackBarPosition_Scroll);
            this.trackBarPosition.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarPosition_MouseDown);
            this.trackBarPosition.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarPosition_MouseUp);
            // 
            // trackBarVol
            // 
            this.trackBarVol.AutoSize = false;
            this.trackBarVol.Location = new System.Drawing.Point(49, 330);
            this.trackBarVol.Maximum = 100;
            this.trackBarVol.Name = "trackBarVol";
            this.trackBarVol.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarVol.Size = new System.Drawing.Size(29, 157);
            this.trackBarVol.TabIndex = 31;
            this.trackBarVol.TickFrequency = 25;
            this.trackBarVol.Value = 50;
            this.trackBarVol.Scroll += new System.EventHandler(this.trackBarVol_Scroll);
            // 
            // trackBarPan
            // 
            this.trackBarPan.AutoSize = false;
            this.trackBarPan.LargeChange = 10;
            this.trackBarPan.Location = new System.Drawing.Point(95, 251);
            this.trackBarPan.Maximum = 100;
            this.trackBarPan.Minimum = -100;
            this.trackBarPan.Name = "trackBarPan";
            this.trackBarPan.Size = new System.Drawing.Size(254, 24);
            this.trackBarPan.TabIndex = 32;
            this.trackBarPan.TickFrequency = 25;
            this.trackBarPan.Scroll += new System.EventHandler(this.trackBarPan_Scroll);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonBackward);
            this.groupBox1.Controls.Add(this.buttonForward);
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.btnPlay);
            this.groupBox1.Controls.Add(this.btnOpen);
            this.groupBox1.Location = new System.Drawing.Point(32, 193);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(177, 40);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            // 
            // groupBoxMixer
            // 
            this.groupBoxMixer.Controls.Add(this.userControlMixer5);
            this.groupBoxMixer.Controls.Add(this.userControlMixer4);
            this.groupBoxMixer.Controls.Add(this.userControlMixer3);
            this.groupBoxMixer.Controls.Add(this.userControlMixer2);
            this.groupBoxMixer.Controls.Add(this.userControlMixer1);
            this.groupBoxMixer.Controls.Add(this.btnMixerFlat);
            this.groupBoxMixer.Location = new System.Drawing.Point(95, 312);
            this.groupBoxMixer.Name = "groupBoxMixer";
            this.groupBoxMixer.Size = new System.Drawing.Size(180, 191);
            this.groupBoxMixer.TabIndex = 47;
            this.groupBoxMixer.TabStop = false;
            this.groupBoxMixer.Text = "Mixer";
            // 
            // userControlMixer5
            // 
            this.userControlMixer5.Center = 14000F;
            this.userControlMixer5.Index = 4;
            this.userControlMixer5.Location = new System.Drawing.Point(144, 45);
            this.userControlMixer5.Name = "userControlMixer5";
            this.userControlMixer5.Size = new System.Drawing.Size(28, 134);
            this.userControlMixer5.TabIndex = 72;
            this.userControlMixer5.Value = 0;
            // 
            // userControlMixer4
            // 
            this.userControlMixer4.Center = 6000F;
            this.userControlMixer4.Index = 3;
            this.userControlMixer4.Location = new System.Drawing.Point(110, 45);
            this.userControlMixer4.Name = "userControlMixer4";
            this.userControlMixer4.Size = new System.Drawing.Size(28, 134);
            this.userControlMixer4.TabIndex = 71;
            this.userControlMixer4.Value = 0;
            // 
            // userControlMixer3
            // 
            this.userControlMixer3.Center = 1000F;
            this.userControlMixer3.Index = 2;
            this.userControlMixer3.Location = new System.Drawing.Point(76, 45);
            this.userControlMixer3.Name = "userControlMixer3";
            this.userControlMixer3.Size = new System.Drawing.Size(28, 134);
            this.userControlMixer3.TabIndex = 70;
            this.userControlMixer3.Value = 0;
            // 
            // userControlMixer2
            // 
            this.userControlMixer2.Center = 310F;
            this.userControlMixer2.Index = 1;
            this.userControlMixer2.Location = new System.Drawing.Point(40, 45);
            this.userControlMixer2.Name = "userControlMixer2";
            this.userControlMixer2.Size = new System.Drawing.Size(30, 134);
            this.userControlMixer2.TabIndex = 69;
            this.userControlMixer2.Value = 0;
            // 
            // userControlMixer1
            // 
            this.userControlMixer1.Center = 100F;
            this.userControlMixer1.Index = 0;
            this.userControlMixer1.Location = new System.Drawing.Point(6, 45);
            this.userControlMixer1.Name = "userControlMixer1";
            this.userControlMixer1.Size = new System.Drawing.Size(28, 134);
            this.userControlMixer1.TabIndex = 68;
            this.userControlMixer1.Value = 0;
            // 
            // btnMixerFlat
            // 
            this.btnMixerFlat.Location = new System.Drawing.Point(67, 18);
            this.btnMixerFlat.Name = "btnMixerFlat";
            this.btnMixerFlat.Size = new System.Drawing.Size(52, 23);
            this.btnMixerFlat.TabIndex = 48;
            this.btnMixerFlat.Text = "flat";
            this.btnMixerFlat.UseVisualStyleBackColor = true;
            this.btnMixerFlat.Click += new System.EventHandler(this.btnMixerFlat_Click);
            // 
            // timerBPM
            // 
            this.timerBPM.Interval = 20;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripButton,
            this.toolStripLabelFormat,
            this.toolStripComboBoxFormat,
            this.toolStripLabelBitRate,
            this.toolStripComboBoxRates,
            this.toolStripLabelMessage,
            this.toolStripProgressBarFile,
            this.helpToolStripButton,
            this.toolStripLabelStatusEncode,
            this.saveToolStripButton,
            this.toolStripSeparator5,
            this.toolStripButtonLastfm});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(709, 39);
            this.toolStrip1.TabIndex = 50;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // optionsToolStripButton
            // 
            this.optionsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.optionsToolStripButton.Image = global::PitchAndShiftAudio.Properties.Resources.options;
            this.optionsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.optionsToolStripButton.Name = "optionsToolStripButton";
            this.optionsToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.optionsToolStripButton.Click += new System.EventHandler(this.optionsToolStripButton_Click);
            // 
            // toolStripLabelFormat
            // 
            this.toolStripLabelFormat.Name = "toolStripLabelFormat";
            this.toolStripLabelFormat.Size = new System.Drawing.Size(30, 36);
            this.toolStripLabelFormat.Text = "type";
            // 
            // toolStripComboBoxFormat
            // 
            this.toolStripComboBoxFormat.AutoSize = false;
            this.toolStripComboBoxFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxFormat.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.toolStripComboBoxFormat.Items.AddRange(new object[] {
            "MP3",
            "WMA"});
            this.toolStripComboBoxFormat.Name = "toolStripComboBoxFormat";
            this.toolStripComboBoxFormat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStripComboBoxFormat.Size = new System.Drawing.Size(69, 23);
            this.toolStripComboBoxFormat.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxFormat_SelectedIndexChanged);
            // 
            // toolStripLabelBitRate
            // 
            this.toolStripLabelBitRate.Name = "toolStripLabelBitRate";
            this.toolStripLabelBitRate.Size = new System.Drawing.Size(27, 36);
            this.toolStripLabelBitRate.Text = "rate";
            // 
            // toolStripComboBoxRates
            // 
            this.toolStripComboBoxRates.AutoSize = false;
            this.toolStripComboBoxRates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxRates.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.toolStripComboBoxRates.Name = "toolStripComboBoxRates";
            this.toolStripComboBoxRates.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStripComboBoxRates.Size = new System.Drawing.Size(81, 23);
            // 
            // toolStripLabelMessage
            // 
            this.toolStripLabelMessage.AutoSize = false;
            this.toolStripLabelMessage.Name = "toolStripLabelMessage";
            this.toolStripLabelMessage.Size = new System.Drawing.Size(55, 22);
            this.toolStripLabelMessage.Text = "ready";
            // 
            // toolStripProgressBarFile
            // 
            this.toolStripProgressBarFile.Name = "toolStripProgressBarFile";
            this.toolStripProgressBarFile.Size = new System.Drawing.Size(100, 36);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.helpToolStripButton.Text = "He&lp";
            this.helpToolStripButton.Click += new System.EventHandler(this.helpToolStripButton_Click);
            // 
            // toolStripLabelStatusEncode
            // 
            this.toolStripLabelStatusEncode.Name = "toolStripLabelStatusEncode";
            this.toolStripLabelStatusEncode.Size = new System.Drawing.Size(39, 36);
            this.toolStripLabelStatusEncode.Text = "Status";
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButtonLastfm
            // 
            this.toolStripButtonLastfm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonLastfm.Image = global::PitchAndShiftAudio.Properties.Resources.world_big;
            this.toolStripButtonLastfm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLastfm.Name = "toolStripButtonLastfm";
            this.toolStripButtonLastfm.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonLastfm.Text = "Web Services";
            this.toolStripButtonLastfm.Click += new System.EventHandler(this.toolStripButtonLastfm_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelBPM,
            this.toolStripLabelTempo});
            this.toolStrip2.Location = new System.Drawing.Point(0, 582);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(709, 25);
            this.toolStrip2.TabIndex = 51;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabelBPM
            // 
            this.toolStripLabelBPM.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabelBPM.AutoSize = false;
            this.toolStripLabelBPM.Name = "toolStripLabelBPM";
            this.toolStripLabelBPM.Size = new System.Drawing.Size(40, 22);
            // 
            // toolStripLabelTempo
            // 
            this.toolStripLabelTempo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabelTempo.Name = "toolStripLabelTempo";
            this.toolStripLabelTempo.Size = new System.Drawing.Size(35, 22);
            this.toolStripLabelTempo.Text = "BPM:";
            this.toolStripLabelTempo.Click += new System.EventHandler(this.toolStripLabelTempo_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.trackBarPitch);
            this.groupBox3.Controls.Add(this.trackBarSpeed);
            this.groupBox3.Controls.Add(this.labelSpeedValue);
            this.groupBox3.Controls.Add(this.labelPitchValue);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(286, 312);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(120, 191);
            this.groupBox3.TabIndex = 53;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Effects";
            // 
            // trackBarPitch
            // 
            this.trackBarPitch.LargeChange = 1;
            this.trackBarPitch.Location = new System.Drawing.Point(18, 45);
            this.trackBarPitch.Maximum = 12;
            this.trackBarPitch.Minimum = -12;
            this.trackBarPitch.Name = "trackBarPitch";
            this.trackBarPitch.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarPitch.Size = new System.Drawing.Size(45, 116);
            this.trackBarPitch.TabIndex = 48;
            this.trackBarPitch.TickFrequency = 2;
            this.trackBarPitch.Scroll += new System.EventHandler(this.trackBarPitch_Scroll);
            this.trackBarPitch.ValueChanged += new System.EventHandler(this.trackBarPitch_ValueChanged);
            // 
            // trackBarSpeed
            // 
            this.trackBarSpeed.LargeChange = 10;
            this.trackBarSpeed.Location = new System.Drawing.Point(69, 45);
            this.trackBarSpeed.Maximum = 100;
            this.trackBarSpeed.Minimum = -80;
            this.trackBarSpeed.Name = "trackBarSpeed";
            this.trackBarSpeed.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarSpeed.Size = new System.Drawing.Size(45, 116);
            this.trackBarSpeed.TabIndex = 45;
            this.trackBarSpeed.TickFrequency = 20;
            this.trackBarSpeed.Scroll += new System.EventHandler(this.trackBarSpeed_Scroll);
            this.trackBarSpeed.ValueChanged += new System.EventHandler(this.trackBarSpeed_ValueChanged);
            // 
            // labelSpeedValue
            // 
            this.labelSpeedValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelSpeedValue.Location = new System.Drawing.Point(60, 157);
            this.labelSpeedValue.Name = "labelSpeedValue";
            this.labelSpeedValue.Size = new System.Drawing.Size(45, 23);
            this.labelSpeedValue.TabIndex = 49;
            this.labelSpeedValue.Text = "100%";
            this.labelSpeedValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPitchValue
            // 
            this.labelPitchValue.Location = new System.Drawing.Point(9, 157);
            this.labelPitchValue.Name = "labelPitchValue";
            this.labelPitchValue.Size = new System.Drawing.Size(45, 23);
            this.labelPitchValue.TabIndex = 50;
            this.labelPitchValue.Text = "0";
            this.labelPitchValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 47;
            this.label4.Text = "Pitch";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "Speed";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 312);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 54;
            this.label2.Text = "Volume";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(76, 251);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 55;
            this.label3.Text = "L";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(352, 251);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 13);
            this.label5.TabIndex = 56;
            this.label5.Text = "R";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonRemoveLoop);
            this.groupBox4.Controls.Add(this.buttonRepeatLoop);
            this.groupBox4.Controls.Add(this.buttonEndLoop);
            this.groupBox4.Controls.Add(this.buttonStartLoop);
            this.groupBox4.Location = new System.Drawing.Point(220, 193);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(161, 40);
            this.groupBox4.TabIndex = 47;
            this.groupBox4.TabStop = false;
            // 
            // contextMenuStripWave
            // 
            this.contextMenuStripWave.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemSL,
            this.toolStripMenuItemEL});
            this.contextMenuStripWave.Name = "contextMenuStripWave";
            this.contextMenuStripWave.Size = new System.Drawing.Size(222, 48);
            this.contextMenuStripWave.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripWave_Opening);
            // 
            // toolStripMenuItemSL
            // 
            this.toolStripMenuItemSL.Image = global::PitchAndShiftAudio.Properties.Resources.sloop;
            this.toolStripMenuItemSL.Name = "toolStripMenuItemSL";
            this.toolStripMenuItemSL.ShortcutKeyDisplayString = "Ctrl + Left Click";
            this.toolStripMenuItemSL.Size = new System.Drawing.Size(221, 22);
            this.toolStripMenuItemSL.Text = "Start Loop";
            // 
            // toolStripMenuItemEL
            // 
            this.toolStripMenuItemEL.Image = global::PitchAndShiftAudio.Properties.Resources.eloop;
            this.toolStripMenuItemEL.Name = "toolStripMenuItemEL";
            this.toolStripMenuItemEL.ShortcutKeyDisplayString = "Ctrl + Right Click";
            this.toolStripMenuItemEL.Size = new System.Drawing.Size(221, 22);
            this.toolStripMenuItemEL.Text = "End Loop";
            // 
            // contextMenuStripForm
            // 
            this.contextMenuStripForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpen,
            this.toolStripMenuItemOpenFolder,
            this.toolStripMenuItemPlay,
            this.toolStripMenuItemStop,
            this.toolStripSeparator1,
            this.toolStripMenuItemOpenURL,
            this.toolStripSeparator3,
            this.toolStripMenuItemStartLoop,
            this.toolStripMenuItemEndLoop,
            this.toolStripMenuItemRepeatLoop,
            this.toolStripMenuItemRemoveLoop,
            this.toolStripSeparator2,
            this.toolStripMenuItemBPM,
            this.toolStripSeparator4,
            this.toolStripMenuItemOpenPlaylist});
            this.contextMenuStripForm.Name = "contextMenuStripForm";
            this.contextMenuStripForm.Size = new System.Drawing.Size(192, 270);
            // 
            // toolStripMenuItemOpen
            // 
            this.toolStripMenuItemOpen.Image = global::PitchAndShiftAudio.Properties.Resources.eject;
            this.toolStripMenuItemOpen.Name = "toolStripMenuItemOpen";
            this.toolStripMenuItemOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.toolStripMenuItemOpen.Size = new System.Drawing.Size(191, 22);
            this.toolStripMenuItemOpen.Text = "Open";
            // 
            // toolStripMenuItemOpenFolder
            // 
            this.toolStripMenuItemOpenFolder.Image = global::PitchAndShiftAudio.Properties.Resources.open;
            this.toolStripMenuItemOpenFolder.Name = "toolStripMenuItemOpenFolder";
            this.toolStripMenuItemOpenFolder.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.toolStripMenuItemOpenFolder.Size = new System.Drawing.Size(191, 22);
            this.toolStripMenuItemOpenFolder.Text = "Open Folder";
            // 
            // toolStripMenuItemPlay
            // 
            this.toolStripMenuItemPlay.Image = global::PitchAndShiftAudio.Properties.Resources.pause_play;
            this.toolStripMenuItemPlay.Name = "toolStripMenuItemPlay";
            this.toolStripMenuItemPlay.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.toolStripMenuItemPlay.Size = new System.Drawing.Size(191, 22);
            this.toolStripMenuItemPlay.Text = "Play/Pause";
            // 
            // toolStripMenuItemStop
            // 
            this.toolStripMenuItemStop.Image = global::PitchAndShiftAudio.Properties.Resources.stop;
            this.toolStripMenuItemStop.Name = "toolStripMenuItemStop";
            this.toolStripMenuItemStop.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.toolStripMenuItemStop.Size = new System.Drawing.Size(191, 22);
            this.toolStripMenuItemStop.Text = "Stop";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(188, 6);
            // 
            // toolStripMenuItemOpenURL
            // 
            this.toolStripMenuItemOpenURL.Image = global::PitchAndShiftAudio.Properties.Resources.world;
            this.toolStripMenuItemOpenURL.Name = "toolStripMenuItemOpenURL";
            this.toolStripMenuItemOpenURL.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.toolStripMenuItemOpenURL.Size = new System.Drawing.Size(191, 22);
            this.toolStripMenuItemOpenURL.Text = "Open URL";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(188, 6);
            // 
            // toolStripMenuItemStartLoop
            // 
            this.toolStripMenuItemStartLoop.Image = global::PitchAndShiftAudio.Properties.Resources.sloop;
            this.toolStripMenuItemStartLoop.Name = "toolStripMenuItemStartLoop";
            this.toolStripMenuItemStartLoop.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.toolStripMenuItemStartLoop.Size = new System.Drawing.Size(191, 22);
            this.toolStripMenuItemStartLoop.Text = "Set Start Loop";
            // 
            // toolStripMenuItemEndLoop
            // 
            this.toolStripMenuItemEndLoop.Image = global::PitchAndShiftAudio.Properties.Resources.eloop;
            this.toolStripMenuItemEndLoop.Name = "toolStripMenuItemEndLoop";
            this.toolStripMenuItemEndLoop.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.toolStripMenuItemEndLoop.Size = new System.Drawing.Size(191, 22);
            this.toolStripMenuItemEndLoop.Text = "Set End Loop";
            // 
            // toolStripMenuItemRepeatLoop
            // 
            this.toolStripMenuItemRepeatLoop.Image = global::PitchAndShiftAudio.Properties.Resources.repeat_loop;
            this.toolStripMenuItemRepeatLoop.Name = "toolStripMenuItemRepeatLoop";
            this.toolStripMenuItemRepeatLoop.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.toolStripMenuItemRepeatLoop.Size = new System.Drawing.Size(191, 22);
            this.toolStripMenuItemRepeatLoop.Text = "Repeat Loop";
            // 
            // toolStripMenuItemRemoveLoop
            // 
            this.toolStripMenuItemRemoveLoop.Image = global::PitchAndShiftAudio.Properties.Resources.del_loop;
            this.toolStripMenuItemRemoveLoop.Name = "toolStripMenuItemRemoveLoop";
            this.toolStripMenuItemRemoveLoop.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.toolStripMenuItemRemoveLoop.Size = new System.Drawing.Size(191, 22);
            this.toolStripMenuItemRemoveLoop.Text = "Remove Loop";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(188, 6);
            // 
            // toolStripMenuItemBPM
            // 
            this.toolStripMenuItemBPM.Name = "toolStripMenuItemBPM";
            this.toolStripMenuItemBPM.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.toolStripMenuItemBPM.Size = new System.Drawing.Size(191, 22);
            this.toolStripMenuItemBPM.Text = "Check BPM";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(188, 6);
            // 
            // toolStripMenuItemOpenPlaylist
            // 
            this.toolStripMenuItemOpenPlaylist.Image = global::PitchAndShiftAudio.Properties.Resources.list;
            this.toolStripMenuItemOpenPlaylist.Name = "toolStripMenuItemOpenPlaylist";
            this.toolStripMenuItemOpenPlaylist.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.toolStripMenuItemOpenPlaylist.Size = new System.Drawing.Size(191, 22);
            this.toolStripMenuItemOpenPlaylist.Text = "Open Tracklist";
            // 
            // pictureBoxWF
            // 
            this.pictureBoxWF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxWF.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBoxWF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxWF.ContextMenuStrip = this.contextMenuStripWave;
            this.pictureBoxWF.Location = new System.Drawing.Point(12, 521);
            this.pictureBoxWF.Name = "pictureBoxWF";
            this.pictureBoxWF.Size = new System.Drawing.Size(681, 58);
            this.pictureBoxWF.TabIndex = 64;
            this.pictureBoxWF.TabStop = false;
            this.pictureBoxWF.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxWF_MouseDown);
            this.pictureBoxWF.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxWF_MouseMove);
            this.pictureBoxWF.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxWF_MouseUp);
            this.pictureBoxWF.Resize += new System.EventHandler(this.pictureBoxWF_Resize);
            // 
            // tabControl
            // 
            this.tabControl.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl.Controls.Add(this.tabPageDisplay);
            this.tabControl.Controls.Add(this.tabPageTracklist);
            this.tabControl.Controls.Add(this.tabPageInstruments);
            this.tabControl.Location = new System.Drawing.Point(32, 47);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(401, 118);
            this.tabControl.TabIndex = 70;
            // 
            // tabPageDisplay
            // 
            this.tabPageDisplay.BackColor = System.Drawing.Color.Black;
            this.tabPageDisplay.Controls.Add(this.userControlAudioDisplay);
            this.tabPageDisplay.Location = new System.Drawing.Point(4, 25);
            this.tabPageDisplay.Name = "tabPageDisplay";
            this.tabPageDisplay.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDisplay.Size = new System.Drawing.Size(393, 89);
            this.tabPageDisplay.TabIndex = 0;
            this.tabPageDisplay.Text = "Display";
            // 
            // userControlAudioDisplay
            // 
            this.userControlAudioDisplay.BackColor = System.Drawing.Color.Black;
            this.userControlAudioDisplay.CurrentDisplayMode = PitchAndShiftAudio.UserControlAudioDisplay.DisplayMode.CURRENT_TIME;
            this.userControlAudioDisplay.Location = new System.Drawing.Point(0, 5);
            this.userControlAudioDisplay.Name = "userControlAudioDisplay";
            this.userControlAudioDisplay.Size = new System.Drawing.Size(395, 86);
            this.userControlAudioDisplay.TabIndex = 69;
            // 
            // tabPageTracklist
            // 
            this.tabPageTracklist.BackColor = System.Drawing.Color.Black;
            this.tabPageTracklist.Controls.Add(this.userControlTrackListView);
            this.tabPageTracklist.Location = new System.Drawing.Point(4, 25);
            this.tabPageTracklist.Name = "tabPageTracklist";
            this.tabPageTracklist.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTracklist.Size = new System.Drawing.Size(393, 89);
            this.tabPageTracklist.TabIndex = 1;
            this.tabPageTracklist.Text = "Tracklist";
            // 
            // userControlTrackListView
            // 
            this.userControlTrackListView.ContextMenuStrip = this.contextMenuStripTrackList;
            this.userControlTrackListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlTrackListView.Location = new System.Drawing.Point(3, 3);
            this.userControlTrackListView.Name = "userControlTrackListView";
            this.userControlTrackListView.Size = new System.Drawing.Size(387, 83);
            this.userControlTrackListView.TabIndex = 0;
            // 
            // contextMenuStripTrackList
            // 
            this.contextMenuStripTrackList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemUpdateMetainfo,
            this.toolStripMenuItemEncode});
            this.contextMenuStripTrackList.Name = "contextMenuStripTrackList";
            this.contextMenuStripTrackList.Size = new System.Drawing.Size(167, 48);
            // 
            // toolStripMenuItemUpdateMetainfo
            // 
            this.toolStripMenuItemUpdateMetainfo.Name = "toolStripMenuItemUpdateMetainfo";
            this.toolStripMenuItemUpdateMetainfo.Size = new System.Drawing.Size(166, 22);
            this.toolStripMenuItemUpdateMetainfo.Text = "Update Meta Info";
            // 
            // toolStripMenuItemEncode
            // 
            this.toolStripMenuItemEncode.Name = "toolStripMenuItemEncode";
            this.toolStripMenuItemEncode.Size = new System.Drawing.Size(166, 22);
            this.toolStripMenuItemEncode.Text = "Encode";
            // 
            // tabPageInstruments
            // 
            this.tabPageInstruments.BackColor = System.Drawing.Color.Black;
            this.tabPageInstruments.Controls.Add(this.userControlModInstrumentPanel);
            this.tabPageInstruments.Location = new System.Drawing.Point(4, 25);
            this.tabPageInstruments.Name = "tabPageInstruments";
            this.tabPageInstruments.Size = new System.Drawing.Size(393, 89);
            this.tabPageInstruments.TabIndex = 2;
            this.tabPageInstruments.Text = "Instruments";
            // 
            // userControlModInstrumentPanel
            // 
            this.userControlModInstrumentPanel.BackColor = System.Drawing.Color.Black;
            this.userControlModInstrumentPanel.Location = new System.Drawing.Point(2, 0);
            this.userControlModInstrumentPanel.Name = "userControlModInstrumentPanel";
            this.userControlModInstrumentPanel.Size = new System.Drawing.Size(394, 88);
            this.userControlModInstrumentPanel.TabIndex = 0;
            // 
            // userControlEffectsPanel
            // 
            this.userControlEffectsPanel.Location = new System.Drawing.Point(478, 86);
            this.userControlEffectsPanel.Name = "userControlEffectsPanel";
            this.userControlEffectsPanel.Size = new System.Drawing.Size(215, 416);
            this.userControlEffectsPanel.TabIndex = 67;
            // 
            // PSAudioForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 607);
            this.ContextMenuStrip = this.contextMenuStripForm;
            this.Controls.Add(this.userControlEffectsPanel);
            this.Controls.Add(this.pictureBoxWF);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.buttonTrackList);
            this.Controls.Add(this.groupBoxMixer);
            this.Controls.Add(this.trackBarPan);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.trackBarVol);
            this.Controls.Add(this.trackBarPosition);
            this.Controls.Add(this.progressBarPeakRight);
            this.Controls.Add(this.progressBarPeakLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "PSAudioForm";
            this.Text = "Audio Pitch & Shift";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PSAudioForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PSAudioForm_FormClosed);
            this.Load += new System.EventHandler(this.PSAudioForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.PSAudioForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.PSAudioForm_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PSAudioForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPan)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBoxMixer.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.contextMenuStripWave.ResumeLayout(false);
            this.contextMenuStripForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.audioSettingsBindingSource)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPageDisplay.ResumeLayout(false);
            this.tabPageTracklist.ResumeLayout(false);
            this.contextMenuStripTrackList.ResumeLayout(false);
            this.tabPageInstruments.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Timer timerUpdate;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ProgressBar progressBarPeakLeft;
        private System.Windows.Forms.ProgressBar progressBarPeakRight;
        private System.Windows.Forms.TrackBar trackBarPosition;
        private System.Windows.Forms.TrackBar trackBarVol;
        private System.Windows.Forms.TrackBar trackBarPan;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBoxMixer;
        private System.Windows.Forms.Button btnMixerFlat;
        private System.Windows.Forms.Timer timerBPM;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBarFile;
        private System.Windows.Forms.ToolStripLabel toolStripLabelMessage;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxRates;
        private System.Windows.Forms.ToolStripLabel toolStripLabelBitRate;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabelBPM;
        private System.Windows.Forms.ToolStripLabel toolStripLabelTempo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TrackBar trackBarPitch;
        private System.Windows.Forms.TrackBar trackBarSpeed;
        private System.Windows.Forms.Label labelSpeedValue;
        private System.Windows.Forms.Label labelPitchValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripLabel toolStripLabelFormat;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxFormat;
        private System.Windows.Forms.ToolStripButton optionsToolStripButton;
        private System.Windows.Forms.PictureBox pictureBoxWF;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonEndLoop;
        private System.Windows.Forms.Button buttonStartLoop;
        private System.Windows.Forms.Button buttonRepeatLoop;
        private System.Windows.Forms.Button buttonRemoveLoop;
        private UserControlEffectsPanel userControlEffectsPanel;
        private UserControlEq userControlMixer5;
        private UserControlEq userControlMixer4;
        private UserControlEq userControlMixer3;
        private UserControlEq userControlMixer2;
        private UserControlEq userControlMixer1;
        private System.Windows.Forms.Button buttonTrackList;
        private System.Windows.Forms.BindingSource audioSettingsBindingSource;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripWave;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSL;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEL;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripForm;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpen;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPlay;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemStartLoop;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRepeatLoop;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRemoveLoop;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEndLoop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemBPM;
        private System.Windows.Forms.ToolStripLabel toolStripLabelStatusEncode;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenURL;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Button buttonBackward;
        private System.Windows.Forms.Button buttonForward;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenPlaylist;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageDisplay;
        private UserControlAudioDisplay userControlAudioDisplay;
        private System.Windows.Forms.TabPage tabPageTracklist;
        private UserControlTrackListView userControlTrackListView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTrackList;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemUpdateMetainfo;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEncode;
        private System.Windows.Forms.TabPage tabPageInstruments;
        private UserControlModInstrumentPanel userControlModInstrumentPanel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenFolder;
        private System.Windows.Forms.ToolStripButton toolStripButtonLastfm;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    }
}