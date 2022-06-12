using ClassLibrary;

namespace Laba_1
{
    public class Pilot: IUpdate
    {
        private Airplane airplane;
        public Vector3 destination { get; private set; }
        private float destinationHeight;
        public Pilot(Airplane airplane, Vector3 destination)
        {
            destination.z = 0;
            this.airplane = airplane;
            this.destination = destination;
            airplane.engine.Start();
            airplane.engine.Gas();
            destinationHeight = 10;
        }

        public void Update()
        {
            var pos2D = airplane.position;
            pos2D.z = 0;
            if ((destination - pos2D).magnitude < 50)
                destinationHeight = 0;
            if ((destination - pos2D).magnitude < 10)
                airplane.engine.Break();
            var dir2D = airplane.direction;
            dir2D.z = 0;
            var ang = Vector3.Cross(dir2D, (destination - pos2D).normalizate).z;
            if (ang>0)
                airplane.wing.Right();
            else if(ang<0)
                airplane.wing.Left();
            if (airplane.speed == 0 && airplane.engine.acceleration < 0)
                airplane.engine.Stop();
            ang = Vector3.Angle(airplane.direction, new Vector3(0, 0, 1));
            if (airplane.position.z < destinationHeight&&ang>80)
                airplane.wing.Up();
            else if (airplane.position.z > destinationHeight && ang < 100)
                airplane.wing.Down();
            if (airplane.position.z < 0.5f)
                airplane.wheel.active = true;
            else
                airplane.wheel.active = false;
        }
    }
}
