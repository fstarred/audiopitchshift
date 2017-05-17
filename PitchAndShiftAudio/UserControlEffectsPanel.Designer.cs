namespace PitchAndShiftAudio
{
    partial class UserControlEffectsPanel
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.labelReverbEnabled = new System.Windows.Forms.LinkLabel();
            this.labelEchoEnabled = new System.Windows.Forms.LinkLabel();
            this.labelFlangerEnabled = new System.Windows.Forms.LinkLabel();
            this.labelChorusEnabled = new System.Windows.Forms.LinkLabel();
            this.labelDistortionEnabled = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.tabControlEffects = new System.Windows.Forms.TabControl();
            this.tabPageDistortion = new System.Windows.Forms.TabPage();
            this.usrCntPreLowpassCutoff = new PitchAndShiftAudio.UserControlTrackBar();
            this.usrCntPostEQBandwidth = new PitchAndShiftAudio.UserControlTrackBar();
            this.usrCntPostEQCenterFrequency = new PitchAndShiftAudio.UserControlTrackBar();
            this.usrCntEdge = new PitchAndShiftAudio.UserControlTrackBar();
            this.usrCntGainDist = new PitchAndShiftAudio.UserControlTrackBar();
            this.checkBoxDistortion = new System.Windows.Forms.CheckBox();
            this.tabPageChorus = new System.Windows.Forms.TabPage();
            this.usrCntDelay = new PitchAndShiftAudio.UserControlTrackBar();
            this.usrCntFrequency = new PitchAndShiftAudio.UserControlTrackBar();
            this.usrCntFeedback = new PitchAndShiftAudio.UserControlTrackBar();
            this.usrCntDepth = new PitchAndShiftAudio.UserControlTrackBar();
            this.usrCntWetDryMix = new PitchAndShiftAudio.UserControlTrackBar();
            this.checkBoxChorus = new System.Windows.Forms.CheckBox();
            this.comboBoxPhase = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBoxWaveform = new System.Windows.Forms.ComboBox();
            this.tabPageFlanger = new System.Windows.Forms.TabPage();
            this.usrCntDelayFlanger = new PitchAndShiftAudio.UserControlTrackBar();
            this.usrCntFrequencyFlanger = new PitchAndShiftAudio.UserControlTrackBar();
            this.usrCntFeedbackFlanger = new PitchAndShiftAudio.UserControlTrackBar();
            this.usrCntDepthFlanger = new PitchAndShiftAudio.UserControlTrackBar();
            this.usrCntWetDryMixFlanger = new PitchAndShiftAudio.UserControlTrackBar();
            this.checkBoxFlanger = new System.Windows.Forms.CheckBox();
            this.comboBoxPhaseFlanger = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxWaveformFlanger = new System.Windows.Forms.ComboBox();
            this.tabPageEcho = new System.Windows.Forms.TabPage();
            this.usrCntRightDelay = new PitchAndShiftAudio.UserControlTrackBarH();
            this.usrCntLeftDelay = new PitchAndShiftAudio.UserControlTrackBarH();
            this.usrCntFeedbackEcho = new PitchAndShiftAudio.UserControlTrackBar();
            this.usrCntWetDryMixEcho = new PitchAndShiftAudio.UserControlTrackBar();
            this.label18 = new System.Windows.Forms.Label();
            this.comboBoxPanDelay = new System.Windows.Forms.ComboBox();
            this.checkBoxEcho = new System.Windows.Forms.CheckBox();
            this.tabPageReverb = new System.Windows.Forms.TabPage();
            this.usrCntHighFreqRatio = new PitchAndShiftAudio.UserControlTrackBar();
            this.usrCntRevTime = new PitchAndShiftAudio.UserControlTrackBar();
            this.usrCntReverbMix = new PitchAndShiftAudio.UserControlTrackBar();
            this.usrCntInGain = new PitchAndShiftAudio.UserControlTrackBar();
            this.checkBoxReverb = new System.Windows.Forms.CheckBox();
            this.tabPagePriority = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.listBoxEffects = new System.Windows.Forms.ListBox();
            this.tabPageModules = new System.Windows.Forms.TabPage();
            this.usrCntVolInst = new PitchAndShiftAudio.UserControlTrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.listBoxChannels = new System.Windows.Forms.ListBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox5.SuspendLayout();
            this.tabControlEffects.SuspendLayout();
            this.tabPageDistortion.SuspendLayout();
            this.tabPageChorus.SuspendLayout();
            this.tabPageFlanger.SuspendLayout();
            this.tabPageEcho.SuspendLayout();
            this.tabPageReverb.SuspendLayout();
            this.tabPagePriority.SuspendLayout();
            this.tabPageModules.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.labelReverbEnabled);
            this.groupBox5.Controls.Add(this.labelEchoEnabled);
            this.groupBox5.Controls.Add(this.labelFlangerEnabled);
            this.groupBox5.Controls.Add(this.labelChorusEnabled);
            this.groupBox5.Controls.Add(this.labelDistortionEnabled);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label25);
            this.groupBox5.Controls.Add(this.label24);
            this.groupBox5.Controls.Add(this.label23);
            this.groupBox5.Location = new System.Drawing.Point(3, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(205, 60);
            this.groupBox5.TabIndex = 69;
            this.groupBox5.TabStop = false;
            // 
            // labelReverbEnabled
            // 
            this.labelReverbEnabled.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelReverbEnabled.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.labelReverbEnabled.LinkColor = System.Drawing.Color.Red;
            this.labelReverbEnabled.Location = new System.Drawing.Point(163, 28);
            this.labelReverbEnabled.Name = "labelReverbEnabled";
            this.labelReverbEnabled.Size = new System.Drawing.Size(36, 22);
            this.labelReverbEnabled.TabIndex = 14;
            this.labelReverbEnabled.TabStop = true;
            this.labelReverbEnabled.Text = "OFF";
            this.labelReverbEnabled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelReverbEnabled.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labelReverbEnabled_LinkClicked);
            // 
            // labelEchoEnabled
            // 
            this.labelEchoEnabled.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelEchoEnabled.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.labelEchoEnabled.LinkColor = System.Drawing.Color.Red;
            this.labelEchoEnabled.Location = new System.Drawing.Point(126, 28);
            this.labelEchoEnabled.Name = "labelEchoEnabled";
            this.labelEchoEnabled.Size = new System.Drawing.Size(36, 22);
            this.labelEchoEnabled.TabIndex = 13;
            this.labelEchoEnabled.TabStop = true;
            this.labelEchoEnabled.Text = "OFF";
            this.labelEchoEnabled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelEchoEnabled.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labelEchoEnabled_LinkClicked);
            // 
            // labelFlangerEnabled
            // 
            this.labelFlangerEnabled.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelFlangerEnabled.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.labelFlangerEnabled.LinkColor = System.Drawing.Color.Red;
            this.labelFlangerEnabled.Location = new System.Drawing.Point(84, 28);
            this.labelFlangerEnabled.Name = "labelFlangerEnabled";
            this.labelFlangerEnabled.Size = new System.Drawing.Size(36, 22);
            this.labelFlangerEnabled.TabIndex = 12;
            this.labelFlangerEnabled.TabStop = true;
            this.labelFlangerEnabled.Text = "OFF";
            this.labelFlangerEnabled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelFlangerEnabled.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labelFlangerEnabled_LinkClicked);
            // 
            // labelChorusEnabled
            // 
            this.labelChorusEnabled.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelChorusEnabled.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.labelChorusEnabled.LinkColor = System.Drawing.Color.Red;
            this.labelChorusEnabled.Location = new System.Drawing.Point(46, 28);
            this.labelChorusEnabled.Name = "labelChorusEnabled";
            this.labelChorusEnabled.Size = new System.Drawing.Size(36, 22);
            this.labelChorusEnabled.TabIndex = 11;
            this.labelChorusEnabled.TabStop = true;
            this.labelChorusEnabled.Text = "OFF";
            this.labelChorusEnabled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelChorusEnabled.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labelChorusEnabled_LinkClicked);
            // 
            // labelDistortionEnabled
            // 
            this.labelDistortionEnabled.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelDistortionEnabled.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.labelDistortionEnabled.LinkColor = System.Drawing.Color.Red;
            this.labelDistortionEnabled.Location = new System.Drawing.Point(7, 28);
            this.labelDistortionEnabled.Name = "labelDistortionEnabled";
            this.labelDistortionEnabled.Size = new System.Drawing.Size(36, 22);
            this.labelDistortionEnabled.TabIndex = 10;
            this.labelDistortionEnabled.TabStop = true;
            this.labelDistortionEnabled.Text = "OFF";
            this.labelDistortionEnabled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelDistortionEnabled.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDistortion_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(85, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Flanger";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Dist.";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(162, 12);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(42, 13);
            this.label25.TabIndex = 2;
            this.label25.Text = "Reverb";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(130, 12);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(32, 13);
            this.label24.TabIndex = 1;
            this.label24.Text = "Echo";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(45, 12);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(40, 13);
            this.label23.TabIndex = 0;
            this.label23.Text = "Chorus";
            // 
            // tabControlEffects
            // 
            this.tabControlEffects.Controls.Add(this.tabPageDistortion);
            this.tabControlEffects.Controls.Add(this.tabPageChorus);
            this.tabControlEffects.Controls.Add(this.tabPageFlanger);
            this.tabControlEffects.Controls.Add(this.tabPageEcho);
            this.tabControlEffects.Controls.Add(this.tabPageReverb);
            this.tabControlEffects.Controls.Add(this.tabPagePriority);
            this.tabControlEffects.Controls.Add(this.tabPageModules);
            this.tabControlEffects.Location = new System.Drawing.Point(6, 70);
            this.tabControlEffects.Multiline = true;
            this.tabControlEffects.Name = "tabControlEffects";
            this.tabControlEffects.SelectedIndex = 0;
            this.tabControlEffects.Size = new System.Drawing.Size(209, 346);
            this.tabControlEffects.TabIndex = 68;
            // 
            // tabPageDistortion
            // 
            this.tabPageDistortion.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageDistortion.Controls.Add(this.usrCntPreLowpassCutoff);
            this.tabPageDistortion.Controls.Add(this.usrCntPostEQBandwidth);
            this.tabPageDistortion.Controls.Add(this.usrCntPostEQCenterFrequency);
            this.tabPageDistortion.Controls.Add(this.usrCntEdge);
            this.tabPageDistortion.Controls.Add(this.usrCntGainDist);
            this.tabPageDistortion.Controls.Add(this.checkBoxDistortion);
            this.tabPageDistortion.Location = new System.Drawing.Point(4, 40);
            this.tabPageDistortion.Name = "tabPageDistortion";
            this.tabPageDistortion.Size = new System.Drawing.Size(201, 302);
            this.tabPageDistortion.TabIndex = 4;
            this.tabPageDistortion.Text = "Distortion";
            // 
            // usrCntPreLowpassCutoff
            // 
            this.usrCntPreLowpassCutoff.Location = new System.Drawing.Point(116, 178);
            this.usrCntPreLowpassCutoff.Maximum = 8000;
            this.usrCntPreLowpassCutoff.Minimum = 100;
            this.usrCntPreLowpassCutoff.Multiplier = 1D;
            this.usrCntPreLowpassCutoff.Name = "usrCntPreLowpassCutoff";
            this.usrCntPreLowpassCutoff.Size = new System.Drawing.Size(59, 124);
            this.usrCntPreLowpassCutoff.TabIndex = 77;
            this.usrCntPreLowpassCutoff.TickFrequency = 800;
            this.usrCntPreLowpassCutoff.Title = "PreLowpassCutoff";
            this.usrCntPreLowpassCutoff.Value = 4000D;
            // 
            // usrCntPostEQBandwidth
            // 
            this.usrCntPostEQBandwidth.Location = new System.Drawing.Point(16, 178);
            this.usrCntPostEQBandwidth.Maximum = 8000;
            this.usrCntPostEQBandwidth.Minimum = 100;
            this.usrCntPostEQBandwidth.Multiplier = 1D;
            this.usrCntPostEQBandwidth.Name = "usrCntPostEQBandwidth";
            this.usrCntPostEQBandwidth.Size = new System.Drawing.Size(59, 124);
            this.usrCntPostEQBandwidth.TabIndex = 76;
            this.usrCntPostEQBandwidth.TickFrequency = 800;
            this.usrCntPostEQBandwidth.Title = "PostEQBandwidth";
            this.usrCntPostEQBandwidth.Value = 4000D;
            // 
            // usrCntPostEQCenterFrequency
            // 
            this.usrCntPostEQCenterFrequency.Location = new System.Drawing.Point(133, 37);
            this.usrCntPostEQCenterFrequency.Maximum = 8000;
            this.usrCntPostEQCenterFrequency.Minimum = 1000;
            this.usrCntPostEQCenterFrequency.Multiplier = 1D;
            this.usrCntPostEQCenterFrequency.Name = "usrCntPostEQCenterFrequency";
            this.usrCntPostEQCenterFrequency.Size = new System.Drawing.Size(59, 124);
            this.usrCntPostEQCenterFrequency.TabIndex = 75;
            this.usrCntPostEQCenterFrequency.TickFrequency = 800;
            this.usrCntPostEQCenterFrequency.Title = "PostEQCeFreq";
            this.usrCntPostEQCenterFrequency.Value = 4000D;
            // 
            // usrCntEdge
            // 
            this.usrCntEdge.Location = new System.Drawing.Point(68, 37);
            this.usrCntEdge.Maximum = 100;
            this.usrCntEdge.Minimum = 0;
            this.usrCntEdge.Multiplier = 1D;
            this.usrCntEdge.Name = "usrCntEdge";
            this.usrCntEdge.Size = new System.Drawing.Size(59, 124);
            this.usrCntEdge.TabIndex = 74;
            this.usrCntEdge.TickFrequency = 10;
            this.usrCntEdge.Title = "Edge";
            this.usrCntEdge.Value = 50D;
            // 
            // usrCntGainDist
            // 
            this.usrCntGainDist.Location = new System.Drawing.Point(3, 35);
            this.usrCntGainDist.Maximum = 0;
            this.usrCntGainDist.Minimum = -60;
            this.usrCntGainDist.Multiplier = 1D;
            this.usrCntGainDist.Name = "usrCntGainDist";
            this.usrCntGainDist.Size = new System.Drawing.Size(59, 124);
            this.usrCntGainDist.TabIndex = 70;
            this.usrCntGainDist.TickFrequency = 6;
            this.usrCntGainDist.Title = "Gain";
            this.usrCntGainDist.Value = 0D;
            // 
            // checkBoxDistortion
            // 
            this.checkBoxDistortion.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxDistortion.Image = global::PitchAndShiftAudio.Properties.Resources.btn_enable;
            this.checkBoxDistortion.Location = new System.Drawing.Point(77, 6);
            this.checkBoxDistortion.Name = "checkBoxDistortion";
            this.checkBoxDistortion.Size = new System.Drawing.Size(50, 25);
            this.checkBoxDistortion.TabIndex = 73;
            this.checkBoxDistortion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.checkBoxDistortion, "On / Off");
            this.checkBoxDistortion.UseVisualStyleBackColor = true;
            this.checkBoxDistortion.CheckedChanged += new System.EventHandler(this.checkBoxDistortion_CheckedChanged);
            // 
            // tabPageChorus
            // 
            this.tabPageChorus.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageChorus.Controls.Add(this.usrCntDelay);
            this.tabPageChorus.Controls.Add(this.usrCntFrequency);
            this.tabPageChorus.Controls.Add(this.usrCntFeedback);
            this.tabPageChorus.Controls.Add(this.usrCntDepth);
            this.tabPageChorus.Controls.Add(this.usrCntWetDryMix);
            this.tabPageChorus.Controls.Add(this.checkBoxChorus);
            this.tabPageChorus.Controls.Add(this.comboBoxPhase);
            this.tabPageChorus.Controls.Add(this.label15);
            this.tabPageChorus.Controls.Add(this.label13);
            this.tabPageChorus.Controls.Add(this.comboBoxWaveform);
            this.tabPageChorus.Location = new System.Drawing.Point(4, 40);
            this.tabPageChorus.Name = "tabPageChorus";
            this.tabPageChorus.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageChorus.Size = new System.Drawing.Size(201, 302);
            this.tabPageChorus.TabIndex = 0;
            this.tabPageChorus.Text = "Chorus";
            // 
            // usrCntDelay
            // 
            this.usrCntDelay.Location = new System.Drawing.Point(3, 179);
            this.usrCntDelay.Maximum = 20;
            this.usrCntDelay.Minimum = 0;
            this.usrCntDelay.Multiplier = 1D;
            this.usrCntDelay.Name = "usrCntDelay";
            this.usrCntDelay.Size = new System.Drawing.Size(48, 124);
            this.usrCntDelay.TabIndex = 77;
            this.usrCntDelay.TickFrequency = 2;
            this.usrCntDelay.Title = "Delay";
            this.usrCntDelay.Value = 0D;
            // 
            // usrCntFrequency
            // 
            this.usrCntFrequency.Location = new System.Drawing.Point(147, 49);
            this.usrCntFrequency.Maximum = 10;
            this.usrCntFrequency.Minimum = 0;
            this.usrCntFrequency.Multiplier = 1D;
            this.usrCntFrequency.Name = "usrCntFrequency";
            this.usrCntFrequency.Size = new System.Drawing.Size(48, 124);
            this.usrCntFrequency.TabIndex = 76;
            this.usrCntFrequency.TickFrequency = 1;
            this.usrCntFrequency.Title = "Frequency";
            this.usrCntFrequency.Value = 0D;
            // 
            // usrCntFeedback
            // 
            this.usrCntFeedback.Location = new System.Drawing.Point(95, 49);
            this.usrCntFeedback.Maximum = 99;
            this.usrCntFeedback.Minimum = -99;
            this.usrCntFeedback.Multiplier = 1D;
            this.usrCntFeedback.Name = "usrCntFeedback";
            this.usrCntFeedback.Size = new System.Drawing.Size(49, 124);
            this.usrCntFeedback.TabIndex = 75;
            this.usrCntFeedback.TickFrequency = 20;
            this.usrCntFeedback.Title = "Feedback";
            this.usrCntFeedback.Value = 0D;
            // 
            // usrCntDepth
            // 
            this.usrCntDepth.Location = new System.Drawing.Point(48, 49);
            this.usrCntDepth.Maximum = 100;
            this.usrCntDepth.Minimum = 0;
            this.usrCntDepth.Multiplier = 1D;
            this.usrCntDepth.Name = "usrCntDepth";
            this.usrCntDepth.Size = new System.Drawing.Size(47, 124);
            this.usrCntDepth.TabIndex = 74;
            this.usrCntDepth.TickFrequency = 10;
            this.usrCntDepth.Title = "Depth";
            this.usrCntDepth.Value = 25D;
            // 
            // usrCntWetDryMix
            // 
            this.usrCntWetDryMix.Location = new System.Drawing.Point(3, 49);
            this.usrCntWetDryMix.Maximum = 100;
            this.usrCntWetDryMix.Minimum = 0;
            this.usrCntWetDryMix.Multiplier = 1D;
            this.usrCntWetDryMix.Name = "usrCntWetDryMix";
            this.usrCntWetDryMix.Size = new System.Drawing.Size(48, 124);
            this.usrCntWetDryMix.TabIndex = 73;
            this.usrCntWetDryMix.TickFrequency = 10;
            this.usrCntWetDryMix.Title = "WetDryMix";
            this.usrCntWetDryMix.Value = 0D;
            // 
            // checkBoxChorus
            // 
            this.checkBoxChorus.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxChorus.Image = global::PitchAndShiftAudio.Properties.Resources.btn_enable;
            this.checkBoxChorus.Location = new System.Drawing.Point(77, 6);
            this.checkBoxChorus.Name = "checkBoxChorus";
            this.checkBoxChorus.Size = new System.Drawing.Size(50, 25);
            this.checkBoxChorus.TabIndex = 72;
            this.checkBoxChorus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.checkBoxChorus, "On / Off");
            this.checkBoxChorus.UseVisualStyleBackColor = true;
            this.checkBoxChorus.CheckedChanged += new System.EventHandler(this.checkBoxChorus_CheckedChanged);
            // 
            // comboBoxPhase
            // 
            this.comboBoxPhase.FormattingEnabled = true;
            this.comboBoxPhase.Location = new System.Drawing.Point(102, 251);
            this.comboBoxPhase.Name = "comboBoxPhase";
            this.comboBoxPhase.Size = new System.Drawing.Size(76, 21);
            this.comboBoxPhase.TabIndex = 71;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(63, 258);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(28, 9);
            this.label15.TabIndex = 70;
            this.label15.Text = "Phase ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(54, 204);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 9);
            this.label13.TabIndex = 66;
            this.label13.Text = "Waveform";
            // 
            // comboBoxWaveform
            // 
            this.comboBoxWaveform.FormattingEnabled = true;
            this.comboBoxWaveform.Location = new System.Drawing.Point(102, 197);
            this.comboBoxWaveform.Name = "comboBoxWaveform";
            this.comboBoxWaveform.Size = new System.Drawing.Size(76, 21);
            this.comboBoxWaveform.TabIndex = 65;
            // 
            // tabPageFlanger
            // 
            this.tabPageFlanger.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageFlanger.Controls.Add(this.usrCntDelayFlanger);
            this.tabPageFlanger.Controls.Add(this.usrCntFrequencyFlanger);
            this.tabPageFlanger.Controls.Add(this.usrCntFeedbackFlanger);
            this.tabPageFlanger.Controls.Add(this.usrCntDepthFlanger);
            this.tabPageFlanger.Controls.Add(this.usrCntWetDryMixFlanger);
            this.tabPageFlanger.Controls.Add(this.checkBoxFlanger);
            this.tabPageFlanger.Controls.Add(this.comboBoxPhaseFlanger);
            this.tabPageFlanger.Controls.Add(this.label2);
            this.tabPageFlanger.Controls.Add(this.label4);
            this.tabPageFlanger.Controls.Add(this.comboBoxWaveformFlanger);
            this.tabPageFlanger.Location = new System.Drawing.Point(4, 40);
            this.tabPageFlanger.Name = "tabPageFlanger";
            this.tabPageFlanger.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFlanger.Size = new System.Drawing.Size(201, 302);
            this.tabPageFlanger.TabIndex = 5;
            this.tabPageFlanger.Text = "Flanger";
            // 
            // usrCntDelayFlanger
            // 
            this.usrCntDelayFlanger.Location = new System.Drawing.Point(3, 179);
            this.usrCntDelayFlanger.Maximum = 20;
            this.usrCntDelayFlanger.Minimum = 0;
            this.usrCntDelayFlanger.Multiplier = 1D;
            this.usrCntDelayFlanger.Name = "usrCntDelayFlanger";
            this.usrCntDelayFlanger.Size = new System.Drawing.Size(48, 124);
            this.usrCntDelayFlanger.TabIndex = 87;
            this.usrCntDelayFlanger.TickFrequency = 2;
            this.usrCntDelayFlanger.Title = "Delay";
            this.usrCntDelayFlanger.Value = 0D;
            // 
            // usrCntFrequencyFlanger
            // 
            this.usrCntFrequencyFlanger.Location = new System.Drawing.Point(147, 49);
            this.usrCntFrequencyFlanger.Maximum = 10;
            this.usrCntFrequencyFlanger.Minimum = 0;
            this.usrCntFrequencyFlanger.Multiplier = 1D;
            this.usrCntFrequencyFlanger.Name = "usrCntFrequencyFlanger";
            this.usrCntFrequencyFlanger.Size = new System.Drawing.Size(48, 124);
            this.usrCntFrequencyFlanger.TabIndex = 86;
            this.usrCntFrequencyFlanger.TickFrequency = 1;
            this.usrCntFrequencyFlanger.Title = "Frequency";
            this.usrCntFrequencyFlanger.Value = 0D;
            // 
            // usrCntFeedbackFlanger
            // 
            this.usrCntFeedbackFlanger.Location = new System.Drawing.Point(95, 49);
            this.usrCntFeedbackFlanger.Maximum = 99;
            this.usrCntFeedbackFlanger.Minimum = -99;
            this.usrCntFeedbackFlanger.Multiplier = 1D;
            this.usrCntFeedbackFlanger.Name = "usrCntFeedbackFlanger";
            this.usrCntFeedbackFlanger.Size = new System.Drawing.Size(49, 124);
            this.usrCntFeedbackFlanger.TabIndex = 85;
            this.usrCntFeedbackFlanger.TickFrequency = 20;
            this.usrCntFeedbackFlanger.Title = "Feedback";
            this.usrCntFeedbackFlanger.Value = 0D;
            // 
            // usrCntDepthFlanger
            // 
            this.usrCntDepthFlanger.Location = new System.Drawing.Point(48, 49);
            this.usrCntDepthFlanger.Maximum = 100;
            this.usrCntDepthFlanger.Minimum = 0;
            this.usrCntDepthFlanger.Multiplier = 1D;
            this.usrCntDepthFlanger.Name = "usrCntDepthFlanger";
            this.usrCntDepthFlanger.Size = new System.Drawing.Size(47, 124);
            this.usrCntDepthFlanger.TabIndex = 84;
            this.usrCntDepthFlanger.TickFrequency = 10;
            this.usrCntDepthFlanger.Title = "Depth";
            this.usrCntDepthFlanger.Value = 25D;
            // 
            // usrCntWetDryMixFlanger
            // 
            this.usrCntWetDryMixFlanger.Location = new System.Drawing.Point(3, 49);
            this.usrCntWetDryMixFlanger.Maximum = 100;
            this.usrCntWetDryMixFlanger.Minimum = 0;
            this.usrCntWetDryMixFlanger.Multiplier = 1D;
            this.usrCntWetDryMixFlanger.Name = "usrCntWetDryMixFlanger";
            this.usrCntWetDryMixFlanger.Size = new System.Drawing.Size(48, 124);
            this.usrCntWetDryMixFlanger.TabIndex = 83;
            this.usrCntWetDryMixFlanger.TickFrequency = 10;
            this.usrCntWetDryMixFlanger.Title = "WetDryMix";
            this.usrCntWetDryMixFlanger.Value = 0D;
            // 
            // checkBoxFlanger
            // 
            this.checkBoxFlanger.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxFlanger.Image = global::PitchAndShiftAudio.Properties.Resources.btn_enable;
            this.checkBoxFlanger.Location = new System.Drawing.Point(77, 6);
            this.checkBoxFlanger.Name = "checkBoxFlanger";
            this.checkBoxFlanger.Size = new System.Drawing.Size(50, 25);
            this.checkBoxFlanger.TabIndex = 82;
            this.checkBoxFlanger.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.checkBoxFlanger, "On / Off");
            this.checkBoxFlanger.UseVisualStyleBackColor = true;
            this.checkBoxFlanger.CheckedChanged += new System.EventHandler(this.checkBoxFlanger_CheckedChanged);
            // 
            // comboBoxPhaseFlanger
            // 
            this.comboBoxPhaseFlanger.FormattingEnabled = true;
            this.comboBoxPhaseFlanger.Location = new System.Drawing.Point(102, 251);
            this.comboBoxPhaseFlanger.Name = "comboBoxPhaseFlanger";
            this.comboBoxPhaseFlanger.Size = new System.Drawing.Size(76, 21);
            this.comboBoxPhaseFlanger.TabIndex = 81;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(63, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 9);
            this.label2.TabIndex = 80;
            this.label2.Text = "Phase ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(54, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 9);
            this.label4.TabIndex = 79;
            this.label4.Text = "Waveform";
            // 
            // comboBoxWaveformFlanger
            // 
            this.comboBoxWaveformFlanger.FormattingEnabled = true;
            this.comboBoxWaveformFlanger.Location = new System.Drawing.Point(102, 197);
            this.comboBoxWaveformFlanger.Name = "comboBoxWaveformFlanger";
            this.comboBoxWaveformFlanger.Size = new System.Drawing.Size(76, 21);
            this.comboBoxWaveformFlanger.TabIndex = 78;
            // 
            // tabPageEcho
            // 
            this.tabPageEcho.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageEcho.Controls.Add(this.usrCntRightDelay);
            this.tabPageEcho.Controls.Add(this.usrCntLeftDelay);
            this.tabPageEcho.Controls.Add(this.usrCntFeedbackEcho);
            this.tabPageEcho.Controls.Add(this.usrCntWetDryMixEcho);
            this.tabPageEcho.Controls.Add(this.label18);
            this.tabPageEcho.Controls.Add(this.comboBoxPanDelay);
            this.tabPageEcho.Controls.Add(this.checkBoxEcho);
            this.tabPageEcho.Location = new System.Drawing.Point(4, 40);
            this.tabPageEcho.Name = "tabPageEcho";
            this.tabPageEcho.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEcho.Size = new System.Drawing.Size(201, 302);
            this.tabPageEcho.TabIndex = 1;
            this.tabPageEcho.Text = "Echo";
            // 
            // usrCntRightDelay
            // 
            this.usrCntRightDelay.Location = new System.Drawing.Point(104, 243);
            this.usrCntRightDelay.Maximum = 2000;
            this.usrCntRightDelay.Minimum = 1;
            this.usrCntRightDelay.Multiplier = 1D;
            this.usrCntRightDelay.Name = "usrCntRightDelay";
            this.usrCntRightDelay.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.usrCntRightDelay.Size = new System.Drawing.Size(86, 52);
            this.usrCntRightDelay.TabIndex = 77;
            this.usrCntRightDelay.TickFrequency = 200;
            this.usrCntRightDelay.Title = "Right Delay";
            this.usrCntRightDelay.Value = 333D;
            // 
            // usrCntLeftDelay
            // 
            this.usrCntLeftDelay.Location = new System.Drawing.Point(9, 243);
            this.usrCntLeftDelay.Maximum = 2000;
            this.usrCntLeftDelay.Minimum = 1;
            this.usrCntLeftDelay.Multiplier = 1D;
            this.usrCntLeftDelay.Name = "usrCntLeftDelay";
            this.usrCntLeftDelay.Size = new System.Drawing.Size(86, 52);
            this.usrCntLeftDelay.TabIndex = 76;
            this.usrCntLeftDelay.TickFrequency = 200;
            this.usrCntLeftDelay.Title = "Left Delay";
            this.usrCntLeftDelay.Value = 333D;
            // 
            // usrCntFeedbackEcho
            // 
            this.usrCntFeedbackEcho.Location = new System.Drawing.Point(125, 44);
            this.usrCntFeedbackEcho.Maximum = 100;
            this.usrCntFeedbackEcho.Minimum = 0;
            this.usrCntFeedbackEcho.Multiplier = 1D;
            this.usrCntFeedbackEcho.Name = "usrCntFeedbackEcho";
            this.usrCntFeedbackEcho.Size = new System.Drawing.Size(60, 124);
            this.usrCntFeedbackEcho.TabIndex = 75;
            this.usrCntFeedbackEcho.TickFrequency = 10;
            this.usrCntFeedbackEcho.Title = "Feedback";
            this.usrCntFeedbackEcho.Value = 0D;
            // 
            // usrCntWetDryMixEcho
            // 
            this.usrCntWetDryMixEcho.Location = new System.Drawing.Point(9, 44);
            this.usrCntWetDryMixEcho.Maximum = 100;
            this.usrCntWetDryMixEcho.Minimum = 0;
            this.usrCntWetDryMixEcho.Multiplier = 1D;
            this.usrCntWetDryMixEcho.Name = "usrCntWetDryMixEcho";
            this.usrCntWetDryMixEcho.Size = new System.Drawing.Size(60, 124);
            this.usrCntWetDryMixEcho.TabIndex = 74;
            this.usrCntWetDryMixEcho.TickFrequency = 10;
            this.usrCntWetDryMixEcho.Title = "WetDryMix";
            this.usrCntWetDryMixEcho.Value = 0D;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(56, 197);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(38, 9);
            this.label18.TabIndex = 72;
            this.label18.Text = "Pan delay";
            // 
            // comboBoxPanDelay
            // 
            this.comboBoxPanDelay.FormattingEnabled = true;
            this.comboBoxPanDelay.Location = new System.Drawing.Point(101, 190);
            this.comboBoxPanDelay.Name = "comboBoxPanDelay";
            this.comboBoxPanDelay.Size = new System.Drawing.Size(84, 21);
            this.comboBoxPanDelay.TabIndex = 71;
            // 
            // checkBoxEcho
            // 
            this.checkBoxEcho.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxEcho.Image = global::PitchAndShiftAudio.Properties.Resources.btn_enable;
            this.checkBoxEcho.Location = new System.Drawing.Point(77, 6);
            this.checkBoxEcho.Name = "checkBoxEcho";
            this.checkBoxEcho.Size = new System.Drawing.Size(50, 25);
            this.checkBoxEcho.TabIndex = 73;
            this.checkBoxEcho.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.checkBoxEcho, "On / Off");
            this.checkBoxEcho.UseVisualStyleBackColor = true;
            this.checkBoxEcho.CheckedChanged += new System.EventHandler(this.checkBoxEcho_CheckedChanged);
            // 
            // tabPageReverb
            // 
            this.tabPageReverb.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageReverb.Controls.Add(this.usrCntHighFreqRatio);
            this.tabPageReverb.Controls.Add(this.usrCntRevTime);
            this.tabPageReverb.Controls.Add(this.usrCntReverbMix);
            this.tabPageReverb.Controls.Add(this.usrCntInGain);
            this.tabPageReverb.Controls.Add(this.checkBoxReverb);
            this.tabPageReverb.Location = new System.Drawing.Point(4, 40);
            this.tabPageReverb.Name = "tabPageReverb";
            this.tabPageReverb.Size = new System.Drawing.Size(201, 302);
            this.tabPageReverb.TabIndex = 2;
            this.tabPageReverb.Text = "Reverb";
            // 
            // usrCntHighFreqRatio
            // 
            this.usrCntHighFreqRatio.Location = new System.Drawing.Point(115, 181);
            this.usrCntHighFreqRatio.Maximum = 999;
            this.usrCntHighFreqRatio.Minimum = 1;
            this.usrCntHighFreqRatio.Multiplier = 0.001D;
            this.usrCntHighFreqRatio.Name = "usrCntHighFreqRatio";
            this.usrCntHighFreqRatio.Size = new System.Drawing.Size(60, 124);
            this.usrCntHighFreqRatio.TabIndex = 76;
            this.usrCntHighFreqRatio.TickFrequency = 100;
            this.usrCntHighFreqRatio.Title = "HighFreqRTRatio";
            this.usrCntHighFreqRatio.Value = 0.001D;
            // 
            // usrCntRevTime
            // 
            this.usrCntRevTime.Location = new System.Drawing.Point(8, 181);
            this.usrCntRevTime.Maximum = 30000;
            this.usrCntRevTime.Minimum = 1;
            this.usrCntRevTime.Multiplier = 0.1D;
            this.usrCntRevTime.Name = "usrCntRevTime";
            this.usrCntRevTime.Size = new System.Drawing.Size(60, 124);
            this.usrCntRevTime.TabIndex = 75;
            this.usrCntRevTime.TickFrequency = 3000;
            this.usrCntRevTime.Title = "Rev. Time";
            this.usrCntRevTime.Value = 1000D;
            // 
            // usrCntReverbMix
            // 
            this.usrCntReverbMix.Location = new System.Drawing.Point(115, 44);
            this.usrCntReverbMix.Maximum = 0;
            this.usrCntReverbMix.Minimum = -96;
            this.usrCntReverbMix.Multiplier = 1D;
            this.usrCntReverbMix.Name = "usrCntReverbMix";
            this.usrCntReverbMix.Size = new System.Drawing.Size(60, 124);
            this.usrCntReverbMix.TabIndex = 74;
            this.usrCntReverbMix.TickFrequency = 8;
            this.usrCntReverbMix.Title = "Reverb Mix";
            this.usrCntReverbMix.Value = 0D;
            // 
            // usrCntInGain
            // 
            this.usrCntInGain.Location = new System.Drawing.Point(8, 44);
            this.usrCntInGain.Maximum = 0;
            this.usrCntInGain.Minimum = -96;
            this.usrCntInGain.Multiplier = 1D;
            this.usrCntInGain.Name = "usrCntInGain";
            this.usrCntInGain.Size = new System.Drawing.Size(60, 124);
            this.usrCntInGain.TabIndex = 73;
            this.usrCntInGain.TickFrequency = 8;
            this.usrCntInGain.Title = "In. Gain";
            this.usrCntInGain.Value = 0D;
            // 
            // checkBoxReverb
            // 
            this.checkBoxReverb.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxReverb.Image = global::PitchAndShiftAudio.Properties.Resources.btn_enable;
            this.checkBoxReverb.Location = new System.Drawing.Point(77, 6);
            this.checkBoxReverb.Name = "checkBoxReverb";
            this.checkBoxReverb.Size = new System.Drawing.Size(50, 25);
            this.checkBoxReverb.TabIndex = 72;
            this.checkBoxReverb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.checkBoxReverb, "On / Off");
            this.checkBoxReverb.UseVisualStyleBackColor = true;
            this.checkBoxReverb.CheckedChanged += new System.EventHandler(this.checkBoxReverb_CheckedChanged);
            // 
            // tabPagePriority
            // 
            this.tabPagePriority.BackColor = System.Drawing.SystemColors.Control;
            this.tabPagePriority.Controls.Add(this.label1);
            this.tabPagePriority.Controls.Add(this.buttonDown);
            this.tabPagePriority.Controls.Add(this.buttonUp);
            this.tabPagePriority.Controls.Add(this.listBoxEffects);
            this.tabPagePriority.Location = new System.Drawing.Point(4, 40);
            this.tabPagePriority.Name = "tabPagePriority";
            this.tabPagePriority.Size = new System.Drawing.Size(201, 302);
            this.tabPagePriority.TabIndex = 3;
            this.tabPagePriority.Text = "Priority";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(17, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "FX PRIORITY";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonDown
            // 
            this.buttonDown.Image = global::PitchAndShiftAudio.Properties.Resources.arrow_down;
            this.buttonDown.Location = new System.Drawing.Point(133, 218);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(45, 26);
            this.buttonDown.TabIndex = 2;
            this.toolTip.SetToolTip(this.buttonDown, "Move down");
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // buttonUp
            // 
            this.buttonUp.Image = global::PitchAndShiftAudio.Properties.Resources.arrow_up;
            this.buttonUp.Location = new System.Drawing.Point(20, 218);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(45, 26);
            this.buttonUp.TabIndex = 1;
            this.toolTip.SetToolTip(this.buttonUp, "Move up");
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // listBoxEffects
            // 
            this.listBoxEffects.FormattingEnabled = true;
            this.listBoxEffects.Location = new System.Drawing.Point(19, 55);
            this.listBoxEffects.Name = "listBoxEffects";
            this.listBoxEffects.Size = new System.Drawing.Size(160, 147);
            this.listBoxEffects.TabIndex = 0;
            // 
            // tabPageModules
            // 
            this.tabPageModules.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageModules.Controls.Add(this.usrCntVolInst);
            this.tabPageModules.Controls.Add(this.label6);
            this.tabPageModules.Controls.Add(this.listBoxChannels);
            this.tabPageModules.Location = new System.Drawing.Point(4, 40);
            this.tabPageModules.Name = "tabPageModules";
            this.tabPageModules.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageModules.Size = new System.Drawing.Size(201, 302);
            this.tabPageModules.TabIndex = 6;
            this.tabPageModules.Text = "Modules";
            // 
            // usrCntVolInst
            // 
            this.usrCntVolInst.Location = new System.Drawing.Point(126, 56);
            this.usrCntVolInst.Maximum = 100;
            this.usrCntVolInst.Minimum = 0;
            this.usrCntVolInst.Multiplier = 0.01D;
            this.usrCntVolInst.Name = "usrCntVolInst";
            this.usrCntVolInst.Size = new System.Drawing.Size(59, 134);
            this.usrCntVolInst.TabIndex = 2;
            this.usrCntVolInst.TickFrequency = 10;
            this.usrCntVolInst.Title = "Volume";
            this.usrCntVolInst.Value = 1D;
            this.usrCntVolInst.TrackBarScroll += new System.EventHandler(this.usrCntVolInst_TrackBarScroll);
            this.usrCntVolInst.ValueChanged += new System.EventHandler(this.usrCntVolInst_ValueChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(186, 23);
            this.label6.TabIndex = 1;
            this.label6.Text = "Channels";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBoxChannels
            // 
            this.listBoxChannels.FormattingEnabled = true;
            this.listBoxChannels.Location = new System.Drawing.Point(7, 56);
            this.listBoxChannels.Name = "listBoxChannels";
            this.listBoxChannels.Size = new System.Drawing.Size(108, 134);
            this.listBoxChannels.TabIndex = 0;
            this.listBoxChannels.SelectedIndexChanged += new System.EventHandler(this.listBoxChannels_SelectedIndexChanged);
            // 
            // UserControlEffectsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.tabControlEffects);
            this.Name = "UserControlEffectsPanel";
            this.Size = new System.Drawing.Size(215, 416);
            this.Load += new System.EventHandler(this.UserControlEffectsPanel_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabControlEffects.ResumeLayout(false);
            this.tabPageDistortion.ResumeLayout(false);
            this.tabPageChorus.ResumeLayout(false);
            this.tabPageChorus.PerformLayout();
            this.tabPageFlanger.ResumeLayout(false);
            this.tabPageFlanger.PerformLayout();
            this.tabPageEcho.ResumeLayout(false);
            this.tabPageEcho.PerformLayout();
            this.tabPageReverb.ResumeLayout(false);
            this.tabPagePriority.ResumeLayout(false);
            this.tabPageModules.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TabControl tabControlEffects;
        private System.Windows.Forms.TabPage tabPageChorus;
        private System.Windows.Forms.TabPage tabPageEcho;
        private System.Windows.Forms.TabPage tabPageReverb;
        public System.Windows.Forms.CheckBox checkBoxChorus;
        public System.Windows.Forms.Label label15;
        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.CheckBox checkBoxEcho;
        public System.Windows.Forms.Label label18;
        public System.Windows.Forms.ComboBox comboBoxPanDelay;
        public System.Windows.Forms.CheckBox checkBoxReverb;
        private UserControlTrackBar usrCntFeedback;
        private UserControlTrackBar usrCntDepth;
        private UserControlTrackBar usrCntWetDryMix;
        private UserControlTrackBar usrCntFrequency;
        private UserControlTrackBar usrCntDelay;
        private System.Windows.Forms.ComboBox comboBoxPhase;
        private System.Windows.Forms.ComboBox comboBoxWaveform;
        private UserControlTrackBar usrCntInGain;
        private UserControlTrackBar usrCntReverbMix;
        private UserControlTrackBar usrCntRevTime;
        private UserControlTrackBar usrCntHighFreqRatio;
        private UserControlTrackBar usrCntFeedbackEcho;
        private UserControlTrackBar usrCntWetDryMixEcho;
        private UserControlTrackBarH usrCntRightDelay;
        private UserControlTrackBarH usrCntLeftDelay;
        private System.Windows.Forms.TabPage tabPagePriority;
        private System.Windows.Forms.ListBox listBoxEffects;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPageDistortion;
        private UserControlTrackBar usrCntPreLowpassCutoff;
        private UserControlTrackBar usrCntPostEQBandwidth;
        private UserControlTrackBar usrCntPostEQCenterFrequency;
        private UserControlTrackBar usrCntEdge;
        private UserControlTrackBar usrCntGainDist;
        public System.Windows.Forms.CheckBox checkBoxDistortion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPageFlanger;
        private UserControlTrackBar usrCntDelayFlanger;
        private UserControlTrackBar usrCntFrequencyFlanger;
        private UserControlTrackBar usrCntFeedbackFlanger;
        private UserControlTrackBar usrCntDepthFlanger;
        private UserControlTrackBar usrCntWetDryMixFlanger;
        public System.Windows.Forms.CheckBox checkBoxFlanger;
        private System.Windows.Forms.ComboBox comboBoxPhaseFlanger;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxWaveformFlanger;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TabPage tabPageModules;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBoxChannels;
        private UserControlTrackBar usrCntVolInst;
        private System.Windows.Forms.LinkLabel labelDistortionEnabled;
        private System.Windows.Forms.LinkLabel labelChorusEnabled;
        private System.Windows.Forms.LinkLabel labelFlangerEnabled;
        private System.Windows.Forms.LinkLabel labelEchoEnabled;
        private System.Windows.Forms.LinkLabel labelReverbEnabled;

    }
}
