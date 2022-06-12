using System;
using System.Threading;
using ClassLibrary;

namespace Laba_5
{
    public class Operator<T> : IUpdate, IDisposable
        where T : IMovable, IControllable
    {
        private T controllable;

        private Thread control;

        public Operator(T controllable)
        {
            this.controllable = controllable;
            control = new Thread(Control);
            control.Start();
        }

        public void Dispose()
        {
            control.Abort();
        }

        public void Update()
        {
            if (controllable.position.z < 10)
                controllable.Up();
            else
                controllable.Down();
        }

        private void Control()
        {
            while (true)
            {
                if (controllable.position.x > 700)
                    controllable.Left();
                else if (controllable.position.x < 100)
                    controllable.Right();
                else if ((new Random()).NextDouble() < 0.5)
                    controllable.Left();
                else
                    controllable.Right();


                if (controllable.position.y > 300)
                    controllable.Forward();
                else if (controllable.position.y < 50)
                    controllable.Back();
                else if ((new Random()).NextDouble() < 0.5)
                    controllable.Back();
                else
                    controllable.Forward();
                Thread.Sleep(500);
            }
        }
    }
}
