namespace PitchAndShiftAudio
{
    partial class UserControlModInstrumentPanel
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
            this.listBoxSamples = new System.Windows.Forms.ListBox();
            this.listBoxInstruments = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxSamples
            // 
            this.listBoxSamples.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxSamples.BackColor = System.Drawing.Color.Black;
            this.listBoxSamples.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxSamples.ForeColor = System.Drawing.Color.Lime;
            this.listBoxSamples.FormattingEnabled = true;
            this.listBoxSamples.Location = new System.Drawing.Point(192, 16);
            this.listBoxSamples.Name = "listBoxSamples";
            this.listBoxSamples.Size = new System.Drawing.Size(184, 65);
            this.listBoxSamples.TabIndex = 3;
            // 
            // listBoxInstruments
            // 
            this.listBoxInstruments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxInstruments.BackColor = System.Drawing.Color.Black;
            this.listBoxInstruments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxInstruments.ForeColor = System.Drawing.Color.Lime;
            this.listBoxInstruments.FormattingEnabled = true;
            this.listBoxInstruments.Location = new System.Drawing.Point(3, 16);
            this.listBoxInstruments.Name = "listBoxInstruments";
            this.listBoxInstruments.Size = new System.Drawing.Size(183, 65);
            this.listBoxInstruments.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(53, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Instruments";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(258, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Samples";
            // 
            // UserControlModInstrumentPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxSamples);
            this.Controls.Add(this.listBoxInstruments);
            this.Name = "UserControlModInstrumentPanel";
            this.Size = new System.Drawing.Size(394, 88);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxSamples;
        private System.Windows.Forms.ListBox listBoxInstruments;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
