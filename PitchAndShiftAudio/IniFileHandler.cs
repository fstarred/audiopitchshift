using System.Text;
using System.Runtime.InteropServices;

namespace AudioController
{
    class IniFileHandler
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
            string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
                 string key, string def, StringBuilder retVal,
            int size, string filePath);

        /// <summary>

        /// INIFile Constructor.

        /// </summary>

        /// <PARAM name="INIPath"></PARAM>

        //public IniFile(string INIPath)
        //{
        //    path = INIPath;
        //}
        /// <summary>

        /// Write Data to the INI File

        /// </summary>

        /// <PARAM name="Section"></PARAM>

        /// Section name

        /// <PARAM name="Key"></PARAM>

        /// Key Name

        /// <PARAM name="Value"></PARAM>

        /// Value Name

        public static void IniWriteValue(string Section, string Key, string Value, string path)
        {
            WritePrivateProfileString(Section, Key, Value, path);
        }

        /// <summary>

        /// Read Data Value From the Ini File

        /// </summary>

        /// <PARAM name="Section"></PARAM>

        /// <PARAM name="Key"></PARAM>

        /// <PARAM name="Path"></PARAM>

        /// <returns></returns>

        public static string IniReadValue(string Section, string Key, string path)
        {
            StringBuilder temp = new StringBuilder(0xFF);
            int i = GetPrivateProfileString(Section, Key, "", temp,
                                            0xFF, path);
            return temp.ToString();

        }
    }

}
