using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Laba_5;
using ClassLibrary;

namespace UITask5
{
    public partial class Form1 : Form
    {
        private Thread thread;
        private Graphics graph;
        private List<IUpdate> updates;
        public Form1()
        {
            InitializeComponent();
            thread = new Thread(ThreadUpdate);
            thread.Start();
            graph = pictureBox1.CreateGraphics();
            Application.ApplicationExit += (object sender, EventArgs args) =>
            {
                thread.Abort();
            };
        }

        private void ThreadUpdate()
        {
            updates = new List<IUpdate>();
            var mechanic = new Mechanic(new Vector3(200, 100, 0));
            var quadrocopter = new Quadrocopter(new Vector3(200, 300, 0));
            using (var qOperator = new Operator<Quadrocopter>(quadrocopter))
            {
                updates.Add(mechanic);
                updates.Add(qOperator);
                updates.Add(quadrocopter);
                var redBrush = new SolidBrush(Color.Red);
                var blueBrush = new SolidBrush(Color.Blue);
                quadrocopter.Broken += mechanic.Fix;
                while (true)
                {
                    graph?.Clear(Color.FromArgb(240, 240, 240));
                    foreach (var update in updates) update.Update();
                    graph?.FillEllipse(blueBrush, new Rectangle(ToPoint(mechanic.position), new Size(10, 10)));
                    graph?.FillRectangle(redBrush, new Rectangle(ToPoint(quadrocopter.position), new Size(10, 10)));
                    ShowData($"Местоположение {quadrocopter.position}\nИсправен{quadrocopter.repaired}");
                    Thread.Sleep(10);
                }
            }
        }

        private Point ToPoint(Vector3 point)
        {
            return new Point((int)point.x, (int)point.y);
        }

        private void ShowData(string text)
        {
            if (InvokeRequired)
            {
                try
                {
                    Invoke((Action<string>)ShowData, text);
                }
                catch { }
            }
            else
            {
                textBox1.Text = text;
            }
        }
    }
}
