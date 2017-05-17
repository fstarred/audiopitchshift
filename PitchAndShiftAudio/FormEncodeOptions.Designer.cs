namespace PitchAndShiftAudio
{
    partial class FormEncodeOptions
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
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panelLocalStream = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonAT = new System.Windows.Forms.RadioButton();
            this.radioButtonCT = new System.Windows.Forms.RadioButton();
            this.panelRemoteStream = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonMS = new System.Windows.Forms.RadioButton();
            this.radioButtonMU = new System.Windows.Forms.RadioButton();
            this.panelLocalStream.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelRemoteStream.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(150, 92);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(60, 30);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(12, 92);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(60, 30);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // panelLocalStream
            // 
            this.panelLocalStream.Controls.Add(this.groupBox1);
            this.panelLocalStream.Location = new System.Drawing.Point(12, 1);
            this.panelLocalStream.Name = "panelLocalStream";
            this.panelLocalStream.Size = new System.Drawing.Size(198, 85);
            this.panelLocalStream.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonAT);
            this.groupBox1.Controls.Add(this.radioButtonCT);
            this.groupBox1.Location = new System.Drawing.Point(16, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(167, 74);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // radioButtonAT
            // 
            this.radioButtonAT.AutoSize = true;
            this.radioButtonAT.Location = new System.Drawing.Point(6, 51);
            this.radioButtonAT.Name = "radioButtonAT";
            this.radioButtonAT.Size = new System.Drawing.Size(113, 17);
            this.radioButtonAT.TabIndex = 1;
            this.radioButtonAT.Text = "All tracks in playlist";
            this.radioButtonAT.UseVisualStyleBackColor = true;
            // 
            // radioButtonCT
            // 
            this.radioButtonCT.AutoSize = true;
            this.radioButtonCT.Checked = true;
            this.radioButtonCT.Location = new System.Drawing.Point(6, 19);
            this.radioButtonCT.Name = "radioButtonCT";
            this.radioButtonCT.Size = new System.Drawing.Size(90, 17);
            this.radioButtonCT.TabIndex = 0;
            this.radioButtonCT.TabStop = true;
            this.radioButtonCT.Text = "Current Track";
            this.radioButtonCT.UseVisualStyleBackColor = true;
            // 
            // panelRemoteStream
            // 
            this.panelRemoteStream.Controls.Add(this.groupBox2);
            this.panelRemoteStream.Location = new System.Drawing.Point(10, 1);
            this.panelRemoteStream.Name = "panelRemoteStream";
            this.panelRemoteStream.Size = new System.Drawing.Size(200, 85);
            this.panelRemoteStream.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonMU);
            this.groupBox2.Controls.Add(this.radioButtonMS);
            this.groupBox2.Location = new System.Drawing.Point(5, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(192, 77);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Encode Options";
            // 
            // radioButtonMS
            // 
            this.radioButtonMS.AutoSize = true;
            this.radioButtonMS.Checked = true;
            this.radioButtonMS.Location = new System.Drawing.Point(6, 19);
            this.radioButtonMS.Name = "radioButtonMS";
            this.radioButtonMS.Size = new System.Drawing.Size(178, 17);
            this.radioButtonMS.TabIndex = 0;
            this.radioButtonMS.TabStop = true;
            this.radioButtonMS.Text = "Stop encoding at user command";
            this.radioButtonMS.UseVisualStyleBackColor = true;
            // 
            // radioButtonMU
            // 
            this.radioButtonMU.AutoSize = true;
            this.radioButtonMU.Location = new System.Drawing.Point(6, 49);
            this.radioButtonMU.Name = "radioButtonMU";
            this.radioButtonMU.Size = new System.Drawing.Size(176, 17);
            this.radioButtonMU.TabIndex = 1;
            this.radioButtonMU.Text = "Stop encoding on meta updates";
            this.radioButtonMU.UseVisualStyleBackColor = true;
            // 
            // FormEncodeOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(222, 129);
            this.Controls.Add(this.panelRemoteStream);
            this.Controls.Add(this.panelLocalStream);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEncodeOptions";
            this.Text = "Encoding Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEncodeOptions_FormClosing);
            this.panelLocalStream.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelRemoteStream.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Panel panelLocalStream;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonAT;
        private System.Windows.Forms.RadioButton radioButtonCT;
        private System.Windows.Forms.Panel panelRemoteStream;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButtonMU;
        private System.Windows.Forms.RadioButton radioButtonMS;
    }
}