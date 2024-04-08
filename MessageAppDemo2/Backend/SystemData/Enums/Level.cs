using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppDemo2.Backend.SystemData.Enums
{
    [Flags]
    public enum Level
    {
        VeryLow = 1, Low, Medium, High, VeryHigh
    }
}
