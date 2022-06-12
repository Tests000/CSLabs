using System;
using ClassLibrary;

namespace Laba_1
{
    public class Wing: IUpdate
    {
        private float incline;
        private float rotate;

        public Action<float, float> transform;

        public Wing(Action<float, float> transform)
        {
            this.transform += transform;
            incline = 0;
            rotate = 0;
        }

        public void Update()
        {
            transform?.Invoke(incline, rotate);
            incline = 0;
            rotate = 0;
        }
        public void Up()
        {
            incline = 0.1f; 
        }
        public void Down()
        {
            incline = -0.1f;
        }

        public void Left()
        {
            rotate = -0.03f;
        }

        public void Right()
        {
            rotate = 0.03f;
        }
    }
}
