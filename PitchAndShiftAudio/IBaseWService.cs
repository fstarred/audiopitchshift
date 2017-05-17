using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PitchAndShiftAudio
{
    interface IBaseWService
    {
        string CallSearchMethod(string name, Dictionary<string, string> param);
    }
}
