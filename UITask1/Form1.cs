using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Laba_1;
using ClassLibrary;
using System.Threading;
using System.Linq;

namespace UITask1
{
    public partial class Form1 : Form
    {
        private Airplane plane;
        private Graphics gr;
        private SolidBrush gBrush;
        private Pilot pilot;
        private List<IUpdate> updates;
        private bool showWay;
        public Form1()
        {
            InitializeComponent();
            plane = new Airplane();
            gr = pictureBox1.CreateGraphics();
            gBrush = new SolidBrush(Color.Gray);
            updates = new List<IUpdate>();
            updates.Add(plane);
            updates.Add(plane.wing);
            Thread updateCoroutine = new Thread(UpdateController);
            updateCoroutine.Start();
            this.pictureBox1.MouseDown += pictureBox1_Click;
            Application.ApplicationExit += (object sender, EventArgs e) =>
            {
                updateCoroutine.Abort();
            };
            Application.Idle += (object sender, EventArgs e) =>
            {
                if (pilot != null)
                {
                    button1.Enabled = true;
                }
                else
                    button1.Enabled = false;
            };
        }
        private void UpdateController()
        {
            textBox1.Enabled = false;
            while (true)
            {
                gr.Clear(Color.FromArgb(240, 240, 240));
                ShowData($"Местоположение: {plane.position}\nНаправление: {plane.direction}\n Шасси:{plane.wheel}");
                if (showWay) ShowWay(gr, new Pen(Color.Blue));
                gr.FillPolygon(gBrush, ToPoints(plane.Draw()).ToArray());
                foreach (var update in updates) update.Update();
                Thread.Sleep(20);
            }
        }

        private Point ToPoint(Vector3 point)
        {
            return new Point((int)point.x, (int)point.y);
        }

        private IEnumerable<Point> ToPoints(Vector3[] points)
        {
            for (int i = 0; i < points.Length; i++)
                yield return ToPoint(points[i]);
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

        private void pictureBox1_Click(object sender, MouseEventArgs e)
        {
            if (pilot != null)
                updates.Remove(pilot);
            Vector3 pos = new Vector3();
            pos.x = e.X;
            pos.y = e.Y;
            pos.z = 0;
            pilot = new Pilot(plane, pos);
            updates.Add(pilot);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showWay = !showWay;
        }


        public void ShowWay(Graphics graphics, Pen pen)
        {
            graphics.DrawLine(pen, ToPoint(plane.position), ToPoint(pilot.destination));
        }
    }
}
