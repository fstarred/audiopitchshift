namespace PitchAndShiftAudio
{
    partial class UserControlTrackBarH
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
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(3, 5);
            this.labelTitle.Size = new System.Drawing.Size(17, 9);
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelValue
            // 
            this.labelValue.Location = new System.Drawing.Point(55, 4);
            this.labelValue.Size = new System.Drawing.Size(28, 10);
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(-1, 17);
            this.trackBar.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.trackBar.Size = new System.Drawing.Size(85, 31);
            // 
            // UserControlTrackBarH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "UserControlTrackBarH";
            this.Size = new System.Drawing.Size(86, 52);
            this.Load += new System.EventHandler(this.UserControlTrackBarH_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
