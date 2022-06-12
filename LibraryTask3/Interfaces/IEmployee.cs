using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_3
{
    interface IEmployee
    {
        string name { get; set; }
        float income { get; set; }
        float workTime { get; set; }
        float restTime { get; set; }

        void Work();

        void Rest();
    }
}
