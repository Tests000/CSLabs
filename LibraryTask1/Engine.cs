namespace Laba_1
{
    public class Engine
    {
        public float acceleration { get; private set; }
        public bool active { get; private set; }

        public void Gas()
        {
            if (active)
                acceleration = 0.01f;
        }

        public void Break()
        {
            if (active)
                acceleration = -0.04f;
        }

        public void Start()
        {
            active = true;
        }

        public void Stop()
        {
            acceleration = 0;
            active = false;
        }
    }
}
