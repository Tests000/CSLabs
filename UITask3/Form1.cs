using System;
using System.Threading;
using System.Windows.Forms;
using Laba_3;

namespace UITask3
{
    public partial class Form1 : Form
    {
        private Leader leader;
        private Thread update;

        public Form1()
        {
            InitializeComponent();
            update = new Thread(UpdateControl);
            update.Start();
            Application.ApplicationExit += (object sender, EventArgs args) =>
            {
                update?.Abort();
            };
            object[] param = new object[3];
        }

        private void UpdateControl()
        {
            leader = new Leader();
            var met = typeof(Leader).GetMethods();
            met[0].Invoke(leader, null);
            while (true)
            {
                leader.Update();
                ShowData(leader);
                Thread.Sleep(20);
            }
        }

        private void ShowData(Leader leader)
        {
            if (InvokeRequired)
            {
                try
                {
                    Invoke((Action<Leader>)ShowData, leader);
                }
                catch { }
            }
            else
            {
                if (leader.employees.Count > 0)
                    dataGridView1.RowCount = leader.employees.Count;

                int i = 0;
                BudgetField.Text = $"бюджет: {leader.budget.ToString()}";
                foreach (var emp in leader.employees)
                {
                    dataGridView1.Rows[i].Cells[0].Value = emp.name;
                    dataGridView1.Rows[i].Cells[1].Value = emp.income;
                    dataGridView1.Rows[i].Cells[2].Value = (emp is Cleaner) ? "Уборщик" : "Разработчик";
                    i++;
                }
            }
        }
    }
}
