namespace Laba_1
{
    public class Wheel
    {
        public bool active { get; set; }

        public Wheel()
        {
            active = true;
        }

        public override string ToString()
        {
            return active?"Открыты":"Закрыты";
        }
    }
}
