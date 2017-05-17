
namespace PitchAndShiftAudio
{
    interface IUserControlPrefPanel
    {
        bool IsValid();
        void Save();
        void LoadSettings();
    }
}
