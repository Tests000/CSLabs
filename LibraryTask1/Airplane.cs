using ClassLibrary;

namespace Laba_1
{
    public class Airplane:IUpdate
    {

        public Vector3 position { get; private set; }
        public Vector3 direction { get; private set; }
        public float maxSpeed { get; set; }
        public float speed { get; private set; }
        public Wing wing;
        public Engine engine;
        public Wheel wheel { get; set; }


        public void Move()
        {
            position += direction*speed;
            speed = Mathf.Clamp(speed + engine.acceleration, 0, maxSpeed);
        }

        public Airplane()
        {
            position = new Vector3(3,10,0);
            direction = new Vector3(1, 0, 0);
            maxSpeed = 1;
            speed = 0;
            wing = new Wing(ChangeRotate);
            engine = new Engine();
            wheel = new Wheel();
        }

        private void ChangeRotate(float incline, float rotate)
        {
            if (speed > 0)
            {
                direction = Vector3.RotateAround(direction, new Vector3(0, 0, 1), rotate);
                direction = Vector3.RotateAround(direction, Vector3.Cross(new Vector3(0, 0, -1), direction), incline);
            }
        }

        public void Update()
        {
            Move();
        }

        public Vector3[] Draw()
        {
            Vector3[] triangle = new Vector3[4];
            triangle[0] = position + direction * 20;
            var perp = Vector3.Cross(direction, new Vector3(0, 0, 1));
            triangle[1] = position + perp * 6;
            triangle[2] = position - perp * 6;
            triangle[3] = position + direction * 20;
            return triangle;
        }
    }
}
