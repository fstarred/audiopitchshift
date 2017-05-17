using System;
using System.Windows.Forms;
using Un4seen.Bass;
using System.Reflection;
using BrendanGrant.Helpers.FileAssociation;

namespace PitchAndShiftAudio
{
    public partial class UserControlFileAssociationPanel : UserControl, IUserControlPrefPanel
    {
        public UserControlFileAssociationPanel()
        {
            InitializeComponent();
        }

        public bool IsValid()
        {
            return true;
        }

        public void Save()
        {
            

        }

        public void LoadSettings()
        {
            string[] extensions = Utils.BASSAddOnGetSupportedFileExtensions(Globals.Instance.PluginsLoaded, true).Split(';');

            foreach (string extension in extensions)
            {
                string value = extension.Replace("*", string.Empty);

                ListViewItem lvi = listViewFileExtensions.Items.Add(value);

                //FileAssociationInfo fai = new FileAssociationInfo(value);

                //if (fai.Exists && fai.ProgID.Equals(Globals.AppProgId))
                //    lvi.Selected = true;                
            }
        }

        private void UserControlFileAssociationPanel_VisibleChanged(object sender, EventArgs e)
        {            
            
        }

        private void listViewFileExtensions_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indices = listViewFileExtensions.SelectedIndices;

            if (indices.Count == 1)            
                RefreshExtension(listViewFileExtensions.Items[indices[0]].Text);

            buttonAssociate.Enabled = true;
            buttonRemove.Enabled = true;
        }

        private void RefreshExtension(string extension)
        {
            //AF_FileAssociator fai = new AF_FileAssociator(extension);

            FileAssociationInfo fai = new FileAssociationInfo(extension);

            string progID = "<none>";

            if (fai.Exists)
                progID = fai.ProgID;

            labelAppID.Text = progID;
        }

        private void buttonAssociate_Click(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            try
            {
                foreach (ListViewItem item in listViewFileExtensions.SelectedItems)
                {
                    string value = item.Text;

                    FileAssociationInfo fai = new FileAssociationInfo(value);
                    //if (!fai.Exists)
                    //{
                        fai.Create(Globals.AppTitle);

                        fai.ProgID = Globals.AppProgID;

                        //Specify MIME type (optional)
                        //fai.ContentType = "application/myfile";

                        fai.PerceivedType = PerceivedTypes.Audio;

                        //Programs automatically displayed in open with list
                        //fai.OpenWithList = new string[] { "notepad.exe", "wordpad.exe", "someotherapp.exe" };
                    //}
                }

                // removes the old program ID, if exists                
                ProgramAssociationInfo paiOld = new ProgramAssociationInfo("AudioPS");

                if (paiOld.Exists)
                    paiOld.Delete();
                // end

                ProgramAssociationInfo pai = new ProgramAssociationInfo(Globals.AppProgID);
                if (!pai.Exists)
                {
                    pai.Create
                    (
                        //Description of program/file type
                        String.Format("{0} {1}", Globals.AppTitle, "file"),

                        new ProgramVerb
                             (
                            //Verb name
                             "Open",
                            //Path and arguments to use
                             //@"C:\SomePath\MyApp.exe %1"
                             String.Format("{0} %1", assembly.Location )
                             )
                           );

                    //optional
                    
                    //pai.DefaultIcon = new ProgramIcon(Path.Combine(Path.GetDirectoryName(assembly.Location), "logo.ico"), 0);

                    pai.DefaultIcon = new ProgramIcon(assembly.Location, 0);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            if (listViewFileExtensions.SelectedIndices.Count > 0)
                RefreshExtension(listViewFileExtensions.Items[listViewFileExtensions.SelectedIndices[0]].Text);

            buttonAssociate.Enabled = false;
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem item in listViewFileExtensions.SelectedItems)
                {
                    string value = item.Text;

                    FileAssociationInfo fai = new FileAssociationInfo(item.Text);

                    fai.Create(Globals.AppProgID);

                    if (fai.Exists)
                        fai.Delete();

                    RefreshExtension(value);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
