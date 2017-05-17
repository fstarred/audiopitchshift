using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Un4seen.Bass.Misc;
using Un4seen.Bass;
using Un4seen.Bass.AddOn.Fx;
using AudioController;

namespace PitchAndShiftAudio
{

    public class EncArgument
    {
        public string Filename { get; set; }
        public string FilenameOutput { get; set; }
        public ENCODING_FORMAT Format { get; set; }
        public BaseEncoder Encoder { get; set; }
        //public float Speed { get; set; }
        //public float Pitch { get; set; }
        public int BitRate { get; set; }        

    }

    public enum ENCODING_FORMAT { MP3, WMA, WAV /*OGG*/}

    public class Encoder
    {
        public string Message { get; set; }

        public int Percentage { get; set; }

        public void Encode(EncArgument argument, AudioHandle audioHandle)
        {
            string filenameOutput = argument.FilenameOutput;
            //float speed = argument.Speed;
            //float pitch = argument.Pitch;
            int bitrate = argument.BitRate;

            Percentage = 0;

            BaseEncoder encoder = argument.Encoder;

            //string filenameInput = AudioPlayer.Instance.TrackList.Tracks[AudioPlayer.Instance.CurrentTrackIndex].Location;

            string filenameInput = AudioPlayer.Instance.CurrentTrack.Location;

            encoder.ChannelHandle = audioHandle.CurrentHandle;

            encoder.TAGs = audioHandle.TagInfo;

            encoder.OutputFile = filenameOutput;

            const int bufferLen = 32768;

            byte[] buffer = new byte[bufferLen]; // 16KB decode buffer

            long totalLength;

            if (audioHandle.IsModule())
            {
                totalLength = (long)(Bass.BASS_ChannelGetLength(audioHandle.CurrentHandle, BASSMode.BASS_POS_BYTES));

                totalLength = Bass.BASS_ChannelSeconds2Bytes(audioHandle.CurrentHandle, Bass.BASS_ChannelBytes2Seconds(audioHandle.CurrentHandle, totalLength));
            }
            else
            {
                totalLength = (long)(Bass.BASS_ChannelGetLength(audioHandle.CurrentHandle, BASSMode.BASS_POS_BYTES) / BassFx.BASS_FX_TempoGetRateRatio(audioHandle.CurrentHandle));

                totalLength = Bass.BASS_ChannelSeconds2Bytes(audioHandle.CurrentHandle, Bass.BASS_ChannelBytes2Seconds(audioHandle.CurrentHandle, totalLength));
            }


            //bool isEncoded = BaseEncoder.EncodeFile(encoder, new BaseEncoder.ENCODEFILEPROC(FileEncodingNotification), true, false);

            //MyEncProc = new ENCODEPROC(MyEncodingWriter);

            bool isEncoded = encoder.Start(null, IntPtr.Zero, false);

            if (isEncoded == false)
            {
                Message = "Error while encoding, operation was cancelled";
            }

            long totalBytesWritten = 0;

            while (Bass.BASS_ChannelIsActive(audioHandle.CurrentHandle) == BASSActive.BASS_ACTIVE_PLAYING)
            {
                int len = Bass.BASS_ChannelGetData(audioHandle.CurrentHandle, buffer, bufferLen);

                totalBytesWritten += len;

                Percentage = (int)(((float)totalBytesWritten / totalLength) * 100);

                // some modules might have infinite loop                
                if (audioHandle.IsRemoteURL == false && totalBytesWritten > totalLength) break;

                if (Globals.Instance.tokenSource.Token.IsCancellationRequested)
                {
                    encoder.Stop();
                    Globals.Instance.tokenSource.Token.ThrowIfCancellationRequested();
                }
            }

            encoder.Stop();

        }

    }
}
