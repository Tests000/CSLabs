namespace Laba_3
{
    public interface IEmployee
    {
        string name { get; set; }
        float income { get; set; }
        float workTime { get; set; }
        float restTime { get; set; }

        void Work();

        void Rest();
    }
}
