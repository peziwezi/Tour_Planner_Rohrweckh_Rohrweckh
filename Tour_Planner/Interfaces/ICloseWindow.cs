using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tour_Planner.Interfaces
{
    interface ICloseWindow
    {
        Action? Close { get; set; }
    }
}
