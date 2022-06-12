using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_3
{
    public class Project
    {
        public float time { get; set; }
        public float price { get; private set; }

        public Project(float time, float price)
        {
            this.time = time;
            this.price = price;
        }
    }
}
