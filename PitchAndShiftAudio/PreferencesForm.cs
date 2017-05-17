using System;
using System.Windows.Forms;

namespace PitchAndShiftAudio
{
    public partial class PreferencesForm : Form
    {
        public PreferencesForm()
        {
            InitializeComponent();
        }

        private void PreferencesForm_Load(object sender, EventArgs e)
        {

            networkPanel.LoadSettings();
            bassPanel.LoadSettings();
            fileAssociationPanel.LoadSettings();
            devicePanel.LoadSettings();

            networkPanel.Visible = false;
            bassPanel.Visible = false;
            fileAssociationPanel.Visible = false;
            devicePanel.Visible = false;

            treeViewMenu.SelectedNode = treeViewMenu.Nodes[0];

            AddEnableSaveOnTextChanged(networkPanel);
            AddEnableSaveOnTextChanged(bassPanel);
            //AddEnableSaveOnTextChanged(fileAssociationPanel);
            AddEnableSaveOnTextChanged(devicePanel);
        }

        private void AddEnableSaveOnTextChanged(Control obj)
        {
            foreach (Control control in obj.Controls)
            {
                control.TextChanged += EnableSave;

                if (control.GetType() == typeof(CheckBox))                
                {
                    ((CheckBox)control).CheckedChanged += EnableSave;
                }
                else if (control.GetType() == typeof(ListView))
                {
                    ((ListView)control).SelectedIndexChanged += EnableSave;
                }
                else if (control.GetType() == typeof(ComboBox))
                {
                    ((ComboBox)control).SelectedIndexChanged += EnableSave;
                }

                if (control.Controls.Count > 0)
                    AddEnableSaveOnTextChanged(control);
            }
        }

        private void EnableSave(object sender, EventArgs e)
        {
            this.buttonSave.Enabled = true;
        }

        private UserControlNetworkPanel networkPanel = new UserControlNetworkPanel();
        private UserControlBassPanel bassPanel = new UserControlBassPanel();
        private UserControlFileAssociationPanel fileAssociationPanel = new UserControlFileAssociationPanel();
        private UserControlDevicePanel devicePanel = new UserControlDevicePanel();

        private UserControl mActivePanel;

        private void treeViewMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            UserControl newPanel = null;
            switch (e.Node.Index)
            {
                case 0: newPanel = networkPanel; break;
                case 1: newPanel = bassPanel; break;
                case 2: newPanel = fileAssociationPanel; break;
                case 3: newPanel = devicePanel; break;
                // etc...
            }
            if (newPanel != null)
            {
                if (mActivePanel != null)
                {
                    mActivePanel.Hide();
                    this.Controls.Remove(mActivePanel);
                }
                newPanel.Show();
                newPanel.Dock = DockStyle.Fill;                
                tableLayoutPanelRight.Controls.Add(newPanel);
                tableLayoutPanelRight.SetColumnSpan(newPanel, 2);

                mActivePanel = newPanel;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //((UserControlPrefPanel)mActivePanel).Save();
            bool isValid = true;

            isValid = isValid && networkPanel.IsValid();
            isValid = isValid && bassPanel.IsValid();
            isValid = isValid && fileAssociationPanel.IsValid();

            if (isValid)
            {
                networkPanel.Save();
                bassPanel.Save();
                fileAssociationPanel.Save();
                devicePanel.Save();
                buttonSave.Enabled = false;
            }
            else
                MessageBox.Show("No valid settings specified", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }



    }
}
