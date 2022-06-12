using System;

namespace Laba_3
{
    public class Cleaner : IEmployee
    {
        public string name { get; set; }
        public float income { get; set; }
        public float workTime { get; set; }
        public float restTime { get; set; }

        public void Rest()
        {
            restTime += 0.01f;
        }

        public void Work()
        {
            workTime += 0.01f;
        }

        public void Update()
        {
                var rand = (new Random()).Next(1, 4);
                if (rand > 1)
                    Work();
                else
                    Rest();
        }
    }
}
