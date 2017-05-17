namespace PitchAndShiftAudio
{
    partial class UserControlBassPanel
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBassCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBassEMail = new System.Windows.Forms.TextBox();
            this.pictureBoxBassAudio = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBassAudio)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBassCode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtBassEMail);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 79);
            this.groupBox1.TabIndex = 68;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bass Audio";
            // 
            // txtBassCode
            // 
            this.txtBassCode.Location = new System.Drawing.Point(50, 49);
            this.txtBassCode.Name = "txtBassCode";
            this.txtBassCode.Size = new System.Drawing.Size(190, 20);
            this.txtBassCode.TabIndex = 70;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 69;
            this.label3.Text = "Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 68;
            this.label2.Text = "EMail";
            // 
            // txtBassEMail
            // 
            this.txtBassEMail.Location = new System.Drawing.Point(51, 23);
            this.txtBassEMail.Name = "txtBassEMail";
            this.txtBassEMail.Size = new System.Drawing.Size(189, 20);
            this.txtBassEMail.TabIndex = 67;
            // 
            // pictureBoxBassAudio
            // 
            this.pictureBoxBassAudio.ErrorImage = null;
            this.pictureBoxBassAudio.Image = global::PitchAndShiftAudio.Properties.Resources.logo_bass;
            this.pictureBoxBassAudio.Location = new System.Drawing.Point(90, 120);
            this.pictureBoxBassAudio.Name = "pictureBoxBassAudio";
            this.pictureBoxBassAudio.Size = new System.Drawing.Size(106, 50);
            this.pictureBoxBassAudio.TabIndex = 69;
            this.pictureBoxBassAudio.TabStop = false;
            this.pictureBoxBassAudio.Click += new System.EventHandler(this.pictureBoxBassAudio_Click);
            this.pictureBoxBassAudio.MouseEnter += new System.EventHandler(this.pictureBoxBassAudio_MouseEnter);
            // 
            // UserControlBassPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBoxBassAudio);
            this.Controls.Add(this.groupBox1);
            this.Name = "UserControlBassPanel";
            this.Size = new System.Drawing.Size(284, 220);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBassAudio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBassCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBassEMail;
        private System.Windows.Forms.PictureBox pictureBoxBassAudio;
    }
}
