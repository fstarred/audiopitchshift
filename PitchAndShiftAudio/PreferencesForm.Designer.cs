namespace PitchAndShiftAudio
{
    partial class PreferencesForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Network");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Bass");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Associations");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Devices");
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.treeViewMenu = new System.Windows.Forms.TreeView();
            this.tableLayoutPanelRight = new System.Windows.Forms.TableLayoutPanel();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tableLayoutPanelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Location = new System.Drawing.Point(12, 12);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.treeViewMenu);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.tableLayoutPanelRight);
            this.splitContainer.Size = new System.Drawing.Size(532, 374);
            this.splitContainer.SplitterDistance = 177;
            this.splitContainer.TabIndex = 0;
            // 
            // treeViewMenu
            // 
            this.treeViewMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewMenu.Location = new System.Drawing.Point(0, 0);
            this.treeViewMenu.Name = "treeViewMenu";
            treeNode1.Name = "NodeNetwork";
            treeNode1.Text = "Network";
            treeNode2.Name = "NodeBass";
            treeNode2.Text = "Bass";
            treeNode3.Name = "NodeAssociations";
            treeNode3.Text = "Associations";
            treeNode4.Name = "NodeDevice";
            treeNode4.Text = "Devices";
            this.treeViewMenu.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            this.treeViewMenu.ShowLines = false;
            this.treeViewMenu.Size = new System.Drawing.Size(177, 374);
            this.treeViewMenu.TabIndex = 1;
            this.treeViewMenu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewMenu_AfterSelect);
            // 
            // tableLayoutPanelRight
            // 
            this.tableLayoutPanelRight.ColumnCount = 2;
            this.tableLayoutPanelRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelRight.Controls.Add(this.buttonSave, 0, 1);
            this.tableLayoutPanelRight.Controls.Add(this.buttonCancel, 1, 1);
            this.tableLayoutPanelRight.Location = new System.Drawing.Point(2, 0);
            this.tableLayoutPanelRight.Name = "tableLayoutPanelRight";
            this.tableLayoutPanelRight.RowCount = 2;
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.40971F));
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.5903F));
            this.tableLayoutPanelRight.Size = new System.Drawing.Size(346, 371);
            this.tableLayoutPanelRight.TabIndex = 0;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSave.Enabled = false;
            this.buttonSave.Location = new System.Drawing.Point(49, 331);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 35);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(222, 331);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 35);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Close";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // PreferencesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(560, 399);
            this.Controls.Add(this.splitContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PreferencesForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "PreferencesForm";
            this.Load += new System.EventHandler(this.PreferencesForm_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.tableLayoutPanelRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TreeView treeViewMenu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelRight;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}