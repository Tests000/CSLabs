using System;
using ClassLibrary;

namespace Laba_5
{
    public class Quadrocopter : IMovable, IControllable, IFixable, IUpdate
    {
        public Vector3 position { get; set; }
        public Vector3 velocity { get; set; }
        public bool repaired { get; set; }

        public event Action<IFixable, Vector3> Broken;

        public Quadrocopter()
        {
            position = new Vector3();
            repaired = true;
        }

        public Quadrocopter(Vector3 pos)
        {
            position = pos;
            repaired = true;
        }

        public void Back()
        {
            if (repaired)
            {
                var direction = velocity;
                direction.y = 1;
                velocity = direction;
            }
        }

        public void Down()
        {
            if (repaired)
            {
                var direction = velocity;
                direction.z = -1;
                velocity = direction;
            }
        }

        public void Forward()
        {
            if (repaired)
            {
                var direction = velocity;
                direction.y = -1;
                velocity = direction;
            }
        }

        public void Left()
        {
            if (repaired)
            {
                var direction = velocity;
                direction.x = -1;
                velocity = direction;
            }
        }

        public void Move()
        {
            position += velocity;
        }

        public void Right()
        {
            if (repaired)
            {
                var direction = velocity;
                direction.x = 1;
                velocity = direction;
            }
        }

        public void Stop()
        {
            if (repaired)
                velocity = new Vector3();
        }

        public void Up()
        {
            if (repaired)
            {
                var direction = velocity;
                direction.z = 1;
                velocity = direction;
            }
        }

        public void Update() 
        {
            if ((new Random()).NextDouble() < 0.001)
            {
                repaired = false;
                Broken.Invoke(this, position);
                velocity = new Vector3();
                Stop();
                Down();
            }
            if(position.z<0)
            {
                var pos = position;
                pos.z = 0;
                velocity = new Vector3();
                position = pos;
            }
            Move();
        }
    }
}
