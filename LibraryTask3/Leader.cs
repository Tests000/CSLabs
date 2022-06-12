using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary;

namespace Laba_3
{
    public class Leader : Engineer, IUpdate
    {
        private string[] names = new string[]
        {
            "Алексей",
            "Михаил",
            "Александр",
            "Елизавета",
            "Мария",
            "Дарья",
            "Владислав",
            "Евгений",
            "Иван"
        };

        public List<IEmployee> employees { get; private set; }
        public List<Project> projects { get; private set; }
        public float budget { get; set; }

        public override void Work()
        {
            projects.RemoveAll(a =>
            {
                if (a.time <= 0)
                {
                    budget += a.price;
                    return true;
                }
                return false;
            });
            if (projects.Count < 20)
                projects.Add(new Project((new Random()).Next(2, 5), (new Random()).Next(1000, 40000)));
            foreach(var emp in employees)
                if(emp is Developer&&((Developer)emp).projects.Count<2)
                {
                    ((Developer)emp).GetProgect(projects.ElementAt((new Random()).Next(0, projects.Count - 1)));
                }
        }

        public void Hire()
        {
            if (budget > 1000)
            {
                IEmployee empl;
                if ((new Random()).Next(0, 2) == 0)
                    empl = new Developer() { income = (new Random()).Next(300, 600), name = names[(new Random()).Next(0, names.Length-1)] };
                else
                    empl = new Cleaner() { income = (new Random()).Next(100, 200), name = names[(new Random()).Next(0, names.Length - 1)] };
                budget -= empl.income;
                employees.Add(empl);
            }
        }

        public void Fire()
        {
            employees.RemoveAll(a => a.workTime < a.restTime);
        }

        public void Update()
        {
            foreach (var i in employees)
                if (i is IUpdate)
                    ((IUpdate)i).Update();
            Work();
            Hire();
            Fire();
        }

        public Leader()
        {
            budget = 10000;
            employees = new List<IEmployee>();
            projects = new List<Project>();
        }
    }
}
