namespace PitchAndShiftAudio
{
    partial class UserControlAudioDisplay
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemDM = new System.Windows.Forms.ToolStripMenuItem();
            this.labelTrackPosition = new System.Windows.Forms.Label();
            this.labelELoop = new System.Windows.Forms.Label();
            this.labelSLoop = new System.Windows.Forms.Label();
            this.labelTotalTime = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBoxSpec = new System.Windows.Forms.PictureBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.pictureBoxCover = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.ContextMenuStrip = this.contextMenuStrip;
            this.panel1.Controls.Add(this.pictureBoxCover);
            this.panel1.Controls.Add(this.labelTrackPosition);
            this.panel1.Controls.Add(this.labelELoop);
            this.panel1.Controls.Add(this.labelSLoop);
            this.panel1.Controls.Add(this.labelTotalTime);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.pictureBoxSpec);
            this.panel1.Controls.Add(this.labelTitle);
            this.panel1.Controls.Add(this.labelTime);
            this.panel1.Controls.Add(this.labelInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(383, 83);
            this.panel1.TabIndex = 70;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemDM});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(215, 26);
            // 
            // toolStripMenuItemDM
            // 
            this.toolStripMenuItemDM.Name = "toolStripMenuItemDM";
            this.toolStripMenuItemDM.Size = new System.Drawing.Size(214, 22);
            this.toolStripMenuItemDM.Text = "Switch Time Display Mode";
            // 
            // labelTrackPosition
            // 
            this.labelTrackPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTrackPosition.BackColor = System.Drawing.SystemColors.Desktop;
            this.labelTrackPosition.ForeColor = System.Drawing.Color.Lime;
            this.labelTrackPosition.Location = new System.Drawing.Point(3, 61);
            this.labelTrackPosition.Name = "labelTrackPosition";
            this.labelTrackPosition.Size = new System.Drawing.Size(110, 20);
            this.labelTrackPosition.TabIndex = 87;
            this.labelTrackPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelELoop
            // 
            this.labelELoop.AutoSize = true;
            this.labelELoop.BackColor = System.Drawing.Color.Black;
            this.labelELoop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelELoop.Location = new System.Drawing.Point(3, 42);
            this.labelELoop.Name = "labelELoop";
            this.labelELoop.Size = new System.Drawing.Size(40, 13);
            this.labelELoop.TabIndex = 86;
            this.labelELoop.Text = "] 00:00";
            // 
            // labelSLoop
            // 
            this.labelSLoop.AutoSize = true;
            this.labelSLoop.BackColor = System.Drawing.Color.Black;
            this.labelSLoop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelSLoop.Location = new System.Drawing.Point(3, 26);
            this.labelSLoop.Name = "labelSLoop";
            this.labelSLoop.Size = new System.Drawing.Size(40, 13);
            this.labelSLoop.TabIndex = 85;
            this.labelSLoop.Text = "[ 00:00";
            // 
            // labelTotalTime
            // 
            this.labelTotalTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTotalTime.BackColor = System.Drawing.SystemColors.Desktop;
            this.labelTotalTime.ForeColor = System.Drawing.Color.Lime;
            this.labelTotalTime.Location = new System.Drawing.Point(252, 61);
            this.labelTotalTime.Name = "labelTotalTime";
            this.labelTotalTime.Size = new System.Drawing.Size(128, 20);
            this.labelTotalTime.TabIndex = 84;
            this.labelTotalTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Desktop;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(296, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 83;
            // 
            // pictureBoxSpec
            // 
            this.pictureBoxSpec.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxSpec.BackColor = System.Drawing.Color.Black;
            this.pictureBoxSpec.Location = new System.Drawing.Point(244, 26);
            this.pictureBoxSpec.Name = "pictureBoxSpec";
            this.pictureBoxSpec.Size = new System.Drawing.Size(136, 29);
            this.pictureBoxSpec.TabIndex = 82;
            this.pictureBoxSpec.TabStop = false;
            // 
            // labelTitle
            // 
            this.labelTitle.BackColor = System.Drawing.Color.Black;
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitle.ForeColor = System.Drawing.Color.Lime;
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(383, 23);
            this.labelTitle.TabIndex = 80;
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTime
            // 
            this.labelTime.BackColor = System.Drawing.Color.Black;
            this.labelTime.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelTime.Location = new System.Drawing.Point(0, 23);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(383, 37);
            this.labelTime.TabIndex = 79;
            this.labelTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTime.Click += new System.EventHandler(this.labelTime_Click);
            // 
            // labelInfo
            // 
            this.labelInfo.BackColor = System.Drawing.Color.Black;
            this.labelInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelInfo.ForeColor = System.Drawing.Color.Lime;
            this.labelInfo.Location = new System.Drawing.Point(0, 60);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(383, 23);
            this.labelInfo.TabIndex = 81;
            this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxCover
            // 
            this.pictureBoxCover.BackColor = System.Drawing.Color.Black;
            this.pictureBoxCover.Location = new System.Drawing.Point(58, 23);
            this.pictureBoxCover.Name = "pictureBoxCover";
            this.pictureBoxCover.Size = new System.Drawing.Size(35, 35);
            this.pictureBoxCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCover.TabIndex = 88;
            this.pictureBoxCover.TabStop = false;
            // 
            // UserControlAudioDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "UserControlAudioDisplay";
            this.Size = new System.Drawing.Size(383, 83);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelTrackPosition;
        private System.Windows.Forms.Label labelELoop;
        private System.Windows.Forms.Label labelSLoop;
        private System.Windows.Forms.Label labelTotalTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBoxSpec;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDM;
        private System.Windows.Forms.PictureBox pictureBoxCover;
    }
}
