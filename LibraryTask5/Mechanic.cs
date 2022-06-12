using ClassLibrary;

namespace Laba_5
{
    public class Mechanic : IMechanic, IMovable, IUpdate
    {
        public Vector3 position { get; set; }
        public Vector3 velocity { get; set; }

        private Vector3 destination;
        private IFixable obj;
        private bool broken;
        public Mechanic(Vector3 pos)
        {
            position = pos;
        }

        public Mechanic()
        {
            position = new Vector3();
        }

        public void Fix(IFixable fixable, Vector3 pos)
        {
            var dir = (pos - position).normalizate;
            dir.z = 0;
            velocity =dir;
            pos.z = 0;
            destination = pos;
            obj = fixable;
            broken = true;
        }

        public void Move()
        {
            if ((destination - position).magnitude < 2&&broken)
            {
                velocity = new Vector3();
                obj.repaired = true;
                broken = false;
            }
            else
                position += velocity;
        }

        public void Update()
        {
            Move();
        }
    }
}
