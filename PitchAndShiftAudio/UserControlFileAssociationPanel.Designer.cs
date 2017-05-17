namespace PitchAndShiftAudio
{
    partial class UserControlFileAssociationPanel
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
            this.listViewFileExtensions = new System.Windows.Forms.ListView();
            this.buttonAssociate = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelAppID = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listViewFileExtensions);
            this.groupBox1.Location = new System.Drawing.Point(3, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 159);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Associated Filetypes";
            // 
            // listViewFileExtensions
            // 
            this.listViewFileExtensions.HideSelection = false;
            this.listViewFileExtensions.Location = new System.Drawing.Point(6, 28);
            this.listViewFileExtensions.Name = "listViewFileExtensions";
            this.listViewFileExtensions.Size = new System.Drawing.Size(317, 125);
            this.listViewFileExtensions.TabIndex = 1;
            this.listViewFileExtensions.UseCompatibleStateImageBehavior = false;
            this.listViewFileExtensions.View = System.Windows.Forms.View.SmallIcon;
            this.listViewFileExtensions.SelectedIndexChanged += new System.EventHandler(this.listViewFileExtensions_SelectedIndexChanged);
            // 
            // buttonAssociate
            // 
            this.buttonAssociate.Enabled = false;
            this.buttonAssociate.Location = new System.Drawing.Point(9, 214);
            this.buttonAssociate.Name = "buttonAssociate";
            this.buttonAssociate.Size = new System.Drawing.Size(75, 23);
            this.buttonAssociate.TabIndex = 2;
            this.buttonAssociate.Text = "Associate";
            this.buttonAssociate.UseVisualStyleBackColor = true;
            this.buttonAssociate.Click += new System.EventHandler(this.buttonAssociate_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Enabled = false;
            this.buttonRemove.Location = new System.Drawing.Point(255, 214);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonRemove.TabIndex = 3;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Application ID";
            // 
            // labelAppID
            // 
            this.labelAppID.Location = new System.Drawing.Point(135, 188);
            this.labelAppID.Name = "labelAppID";
            this.labelAppID.Size = new System.Drawing.Size(158, 13);
            this.labelAppID.TabIndex = 5;
            // 
            // UserControlFileAssociationPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelAppID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonAssociate);
            this.Controls.Add(this.groupBox1);
            this.Name = "UserControlFileAssociationPanel";
            this.Size = new System.Drawing.Size(341, 249);
            this.VisibleChanged += new System.EventHandler(this.UserControlFileAssociationPanel_VisibleChanged);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listViewFileExtensions;
        private System.Windows.Forms.Button buttonAssociate;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelAppID;

    }
}
