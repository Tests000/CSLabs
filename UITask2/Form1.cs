using System;
using System.Collections.Generic;
using Laba_2;
using System.Windows.Forms;

namespace UITask2
{
    public partial class Form1 : Form
    {
        List<Product> products;
        public Form1()
        {
            InitializeComponent();
            products = new List<Product>();
            dataGridView1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product wine = new Wine("ХЗ", 1000, 100, new DateTime(2010, 6, 21));
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f2 = (new Form2(products));
            f2.Show();
            f2.FormClosing += UpdateTable;
        }

        public void UpdateTable(object sender, EventArgs e)
        {
            if (products.Count > 0)
                dataGridView1.RowCount = products.Count;
            int i = 0;
            foreach (var prod in products)
            {
                var values = new string[5];
                prod.ToGridRow(values);
                for(int j=0; j<values.Length;j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = values[j];
                }
                i++;
            }
        }
    }
}
