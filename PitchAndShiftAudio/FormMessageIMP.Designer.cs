namespace PitchAndShiftAudio
{
    partial class FormMessageIMP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMessageIMP));
            this.chkBoxNoMoreAlert = new System.Windows.Forms.CheckBox();
            this.pictureBoxIMPLogo = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabelIMP = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIMPLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // chkBoxNoMoreAlert
            // 
            this.chkBoxNoMoreAlert.AutoSize = true;
            this.chkBoxNoMoreAlert.Location = new System.Drawing.Point(197, 268);
            this.chkBoxNoMoreAlert.Name = "chkBoxNoMoreAlert";
            this.chkBoxNoMoreAlert.Size = new System.Drawing.Size(215, 17);
            this.chkBoxNoMoreAlert.TabIndex = 0;
            this.chkBoxNoMoreAlert.Text = "Do now show me this message anymore";
            this.chkBoxNoMoreAlert.UseVisualStyleBackColor = true;
            // 
            // pictureBoxIMPLogo
            // 
            this.pictureBoxIMPLogo.Image = global::PitchAndShiftAudio.Properties.Resources.Impulse_logo;
            this.pictureBoxIMPLogo.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxIMPLogo.Name = "pictureBoxIMPLogo";
            this.pictureBoxIMPLogo.Size = new System.Drawing.Size(400, 118);
            this.pictureBoxIMPLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxIMPLogo.TabIndex = 1;
            this.pictureBoxIMPLogo.TabStop = false;
            this.pictureBoxIMPLogo.Click += new System.EventHandler(this.pictureBoxIMPLogo_Click);
            this.pictureBoxIMPLogo.MouseEnter += new System.EventHandler(this.pictureBoxIMPLogo_MouseEnter);
            this.pictureBoxIMPLogo.MouseLeave += new System.EventHandler(this.pictureBoxIMPLogo_MouseLeave);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(160, 291);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 39);
            this.button1.TabIndex = 2;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(12, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(400, 113);
            this.label1.TabIndex = 3;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linkLabelIMP
            // 
            this.linkLabelIMP.AutoSize = true;
            this.linkLabelIMP.Location = new System.Drawing.Point(168, 229);
            this.linkLabelIMP.Name = "linkLabelIMP";
            this.linkLabelIMP.Size = new System.Drawing.Size(107, 13);
            this.linkLabelIMP.TabIndex = 4;
            this.linkLabelIMP.TabStop = true;
            this.linkLabelIMP.Text = "Impulse Media Player";
            this.linkLabelIMP.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelIMP_LinkClicked);
            // 
            // FormMessageIMP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 342);
            this.Controls.Add(this.linkLabelIMP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBoxIMPLogo);
            this.Controls.Add(this.chkBoxNoMoreAlert);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormMessageIMP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notification message";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIMPLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkBoxNoMoreAlert;
        private System.Windows.Forms.PictureBox pictureBoxIMPLogo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabelIMP;
    }
}