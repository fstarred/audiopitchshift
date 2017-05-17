using System;
using System.Resources;
using System.Drawing;
using PitchAndShiftAudio.Properties;
using System.Windows.Forms;
using System.IO;
using Un4seen.Bass;
using Un4seen.Bass.AddOn.Enc;
using Un4seen.Bass.AddOn.Fx;
using System.Reflection;
using AudioController;
using System.Text.RegularExpressions;

namespace PitchAndShiftAudio
{
    class PSAudioUtils
    {
        public static bool IsWindowsOS()
        {
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.Win32NT:
                case PlatformID.Win32S:
                case PlatformID.Win32Windows:
                    return true;
                default:
                    return false;
            }
        }

        public const int NO_IMAGE = 999;

        public static Bitmap GetBlankImage()
        {
            Bitmap myImage = GetImageFromResources("no_image");
            myImage.Tag = NO_IMAGE;
            return myImage;
        }

        public static Bitmap GetImageFromResources(string image)
        {
            ResourceManager rm = Resources.ResourceManager;
            Bitmap myImage = (Bitmap)rm.GetObject(image);            
            return myImage;
        }

        public static void ChangeImageButton(Button button, string image)
        {
            Bitmap myImage = GetImageFromResources(image);
            button.Image = myImage;
        }

        public static void ChangeImageButton(ToolStripButton button, string image)
        {
            Bitmap myImage = GetImageFromResources(image);
            button.Image = myImage;
        }

        public static bool IsModuleFile(string filename)
        {
            int isMod = Bass.BASS_MusicLoad(filename, 0L, 0, BASSFlag.BASS_MUSIC_DECODE, 44100);
            Bass.BASS_StreamFree(isMod);
            return (isMod != 0);            
        }

        public static bool IsPlaylist(string filename)
        {
            string ext = Path.GetExtension(filename);
            return (ext.Equals(".pls", StringComparison.InvariantCultureIgnoreCase) || ext.Equals(".m3u", StringComparison.InvariantCultureIgnoreCase));            
        }

        public static void InitBass(IntPtr handle)
        {
            string bassEmail = Settings.Default.BassEmail;
            string bassCode = Settings.Default.BassCode;

            string targetPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (Utils.Is64Bit)
                targetPath = Path.Combine(targetPath, "lib/x64");
            else
                targetPath = Path.Combine(targetPath, "lib/x86");

            if (!string.IsNullOrEmpty(bassEmail) && !string.IsNullOrEmpty(bassCode))
            {
                BassNet.Registration(bassEmail, bassCode);
            }

            if (PSAudioUtils.IsWindowsOS())
            {
                bool isBassLoad = Bass.LoadMe(targetPath);
                bool isBassFxLoad = BassFx.LoadMe(targetPath);
                bool isBassEncLoad = BassEnc.LoadMe(targetPath);

                //Globals.Instance.PluginsLoaded = Bass.BASS_PluginLoadDirectory(targetPath);

                //Globals.Instance.FileSupportedExtFilter = Utils.BASSAddOnGetPluginFileFilter(Globals.Instance.PluginsLoaded, "All supported Audio Files");

            }

            Globals.Instance.PluginsLoaded = Bass.BASS_PluginLoadDirectory(targetPath);

            const string allSupportedAudioFilesWord = "All supported Audio Files";
            const string playlistExtFilter = "*.pls;*.m3u";

            Globals.Instance.FileSupportedExtFilter = Utils.BASSAddOnGetPluginFileFilter(Globals.Instance.PluginsLoaded, allSupportedAudioFilesWord);

            Regex allSupportedFilesPattern = new Regex(allSupportedAudioFilesWord + @"\|(.*?)\|");
            Match match = allSupportedFilesPattern.Match(Globals.Instance.FileSupportedExtFilter);

            string allSupportedFiles = match.Value;

            allSupportedFiles = String.Format("{0};{1}|", allSupportedFiles.Substring(0, allSupportedFiles.Length - 1), playlistExtFilter);

            Globals.Instance.FileSupportedExtFilter = Globals.Instance.FileSupportedExtFilter.Replace(match.Value, allSupportedFiles);

            Globals.Instance.FileSupportedExtFilter += String.Format("|Playlist|{0}", playlistExtFilter);

            bool isBassInit = false;

            BASS_DEVICEINFO[] devices = Bass.BASS_GetDeviceInfos();

            Globals.Instance.Devices = devices;

            int devnum = 0;

            foreach (BASS_DEVICEINFO device in devices)
            {                
                isBassInit = Bass.BASS_Init(devnum++, 44100, BASSInit.BASS_DEVICE_DEFAULT, handle);
            }

            AudioPlayer.Instance.SetDevice(Settings.Default.DefaultDevice);

            //if (!isBassInit)
            //    throw new ApplicationException("Some errors occurred while initializing audio dll");

        }
    }
}
