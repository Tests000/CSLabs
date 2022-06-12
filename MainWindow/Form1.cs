using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainWindow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            UITask1.Form1 frm = new UITask1.Form1();
            frm.ShowDialog();
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            UITask2.Form1 frm = new UITask2.Form1();
            frm.ShowDialog();
            Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            UITask3.Form1 frm = new UITask3.Form1();
            frm.ShowDialog();
            Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            UITask4.Form1 frm = new UITask4.Form1();
            frm.ShowDialog();
            Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Hide();
            UITask5.Form1 frm = new UITask5.Form1();
            frm.ShowDialog();
            Show();
        }
    }
}
