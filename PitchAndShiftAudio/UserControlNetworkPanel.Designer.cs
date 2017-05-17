namespace PitchAndShiftAudio
{
    partial class UserControlNetworkPanel
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
            this.checkBoxProxy = new System.Windows.Forms.CheckBox();
            this.groupBoxProxy = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxHost = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDomain = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.buttonUpdates = new System.Windows.Forms.Button();
            this.groupBoxCredentials = new System.Windows.Forms.GroupBox();
            this.checkBoxCredentials = new System.Windows.Forms.CheckBox();
            this.groupBoxProxy.SuspendLayout();
            this.groupBoxCredentials.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxProxy
            // 
            this.checkBoxProxy.AutoSize = true;
            this.checkBoxProxy.Location = new System.Drawing.Point(8, 10);
            this.checkBoxProxy.Name = "checkBoxProxy";
            this.checkBoxProxy.Size = new System.Drawing.Size(88, 17);
            this.checkBoxProxy.TabIndex = 7;
            this.checkBoxProxy.Text = "Enable Proxy";
            this.checkBoxProxy.UseVisualStyleBackColor = true;
            this.checkBoxProxy.CheckedChanged += new System.EventHandler(this.checkBoxProxy_CheckedChanged);
            // 
            // groupBoxProxy
            // 
            this.groupBoxProxy.Controls.Add(this.checkBoxCredentials);
            this.groupBoxProxy.Controls.Add(this.groupBoxCredentials);
            this.groupBoxProxy.Controls.Add(this.label5);
            this.groupBoxProxy.Controls.Add(this.textBoxPort);
            this.groupBoxProxy.Controls.Add(this.label4);
            this.groupBoxProxy.Controls.Add(this.textBoxHost);
            this.groupBoxProxy.Location = new System.Drawing.Point(8, 35);
            this.groupBoxProxy.Name = "groupBoxProxy";
            this.groupBoxProxy.Size = new System.Drawing.Size(318, 235);
            this.groupBoxProxy.TabIndex = 6;
            this.groupBoxProxy.TabStop = false;
            this.groupBoxProxy.Text = "Proxy";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Port";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(93, 57);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(59, 20);
            this.textBoxPort.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Host";
            // 
            // textBoxHost
            // 
            this.textBoxHost.Location = new System.Drawing.Point(93, 31);
            this.textBoxHost.Name = "textBoxHost";
            this.textBoxHost.Size = new System.Drawing.Size(187, 20);
            this.textBoxHost.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Domain";
            // 
            // textBoxDomain
            // 
            this.textBoxDomain.Location = new System.Drawing.Point(87, 71);
            this.textBoxDomain.Name = "textBoxDomain";
            this.textBoxDomain.Size = new System.Drawing.Size(187, 20);
            this.textBoxDomain.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(87, 45);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(187, 20);
            this.textBoxPassword.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "User";
            // 
            // textBoxUser
            // 
            this.textBoxUser.Location = new System.Drawing.Point(87, 19);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(187, 20);
            this.textBoxUser.TabIndex = 1;
            // 
            // buttonUpdates
            // 
            this.buttonUpdates.Image = global::PitchAndShiftAudio.Properties.Resources.world;
            this.buttonUpdates.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonUpdates.Location = new System.Drawing.Point(197, 3);
            this.buttonUpdates.Name = "buttonUpdates";
            this.buttonUpdates.Size = new System.Drawing.Size(129, 29);
            this.buttonUpdates.TabIndex = 8;
            this.buttonUpdates.Text = "Check updates";
            this.buttonUpdates.UseVisualStyleBackColor = true;
            this.buttonUpdates.Click += new System.EventHandler(this.buttonUpdates_Click);
            // 
            // groupBoxCredentials
            // 
            this.groupBoxCredentials.Controls.Add(this.label1);
            this.groupBoxCredentials.Controls.Add(this.textBoxUser);
            this.groupBoxCredentials.Controls.Add(this.textBoxPassword);
            this.groupBoxCredentials.Controls.Add(this.label3);
            this.groupBoxCredentials.Controls.Add(this.label2);
            this.groupBoxCredentials.Controls.Add(this.textBoxDomain);
            this.groupBoxCredentials.Location = new System.Drawing.Point(6, 126);
            this.groupBoxCredentials.Name = "groupBoxCredentials";
            this.groupBoxCredentials.Size = new System.Drawing.Size(306, 101);
            this.groupBoxCredentials.TabIndex = 12;
            this.groupBoxCredentials.TabStop = false;
            this.groupBoxCredentials.Text = "Credentials";
            // 
            // checkBoxCredentials
            // 
            this.checkBoxCredentials.AutoSize = true;
            this.checkBoxCredentials.Location = new System.Drawing.Point(6, 93);
            this.checkBoxCredentials.Name = "checkBoxCredentials";
            this.checkBoxCredentials.Size = new System.Drawing.Size(100, 17);
            this.checkBoxCredentials.TabIndex = 13;
            this.checkBoxCredentials.Text = "Use Credentials";
            this.checkBoxCredentials.UseVisualStyleBackColor = true;
            this.checkBoxCredentials.CheckedChanged += new System.EventHandler(this.checkBoxCredentials_CheckedChanged);
            // 
            // UserControlNetworkPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonUpdates);
            this.Controls.Add(this.checkBoxProxy);
            this.Controls.Add(this.groupBoxProxy);
            this.Name = "UserControlNetworkPanel";
            this.Size = new System.Drawing.Size(339, 281);
            this.groupBoxProxy.ResumeLayout(false);
            this.groupBoxProxy.PerformLayout();
            this.groupBoxCredentials.ResumeLayout(false);
            this.groupBoxCredentials.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonUpdates;
        private System.Windows.Forms.CheckBox checkBoxProxy;
        private System.Windows.Forms.GroupBox groupBoxProxy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxHost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDomain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.CheckBox checkBoxCredentials;
        private System.Windows.Forms.GroupBox groupBoxCredentials;
    }
}
