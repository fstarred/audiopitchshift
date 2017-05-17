namespace PitchAndShiftAudio
{
    partial class UserControlEq
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
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar
            // 
            this.trackBar.AutoSize = false;
            this.trackBar.LargeChange = 10;
            this.trackBar.Location = new System.Drawing.Point(3, 3);
            this.trackBar.Maximum = 150;
            this.trackBar.Minimum = -150;
            this.trackBar.Name = "trackBar";
            this.trackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar.Size = new System.Drawing.Size(22, 116);
            this.trackBar.TabIndex = 3;
            this.trackBar.TickFrequency = 150;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(3, 117);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(19, 11);
            this.label.TabIndex = 49;
            this.label.Text = "title";
            // 
            // UserControlMixer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label);
            this.Controls.Add(this.trackBar);
            this.Name = "UserControlMixer";
            this.Size = new System.Drawing.Size(30, 134);
            this.Load += new System.EventHandler(this.UserControlMixer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Label label;
    }
}
