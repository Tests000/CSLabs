namespace Laba_3
{
    public abstract class Engineer: IEmployee
    {
        public float experience { get; set; }
        public float workTime { get; set; }
        public float restTime { get; set; }
        public float learnTime { get; private set; }
        public float income { get; set; }
        public string name { get; set; }

        public void Learn()
        {
            experience += 0.01f;
            learnTime += 0.01f;
        }

        public void Rest()
        {
            experience += 0.01f;
            restTime += 0.01f;
        }

        public virtual void Work()
        {
            experience += 0.01f;
            workTime += 0.01f;
        }
    }
}
