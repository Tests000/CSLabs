using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary;

namespace Laba_3
{
    public class Developer :Engineer, IUpdate
    {
        public List<Project> projects { get; private set; }
        public Developer()
        {
            projects = new List<Project>();
        }

        public override void Work()
        {
            var proj = projects.ElementAt((new Random()).Next(0, projects.Count - 1));
            proj.time -= 0.01f;
            if (proj.time <= 0)
                projects.Remove(proj);
            base.Work();
        }

        public void GetProgect(Project proj)
        {
            projects.Add(proj);
        }

        public void Update()
        {
            if (learnTime < 2)
                Learn();
            else
            {
                var rand = (new Random()).Next(1, 4);
                if (rand > 1)
                    Work();
                else
                    Rest();
            }
        }
    }
}
