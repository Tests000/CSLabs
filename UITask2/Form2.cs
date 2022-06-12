using System;
using System.Collections.Generic;
using Laba_2;
using System.Windows.Forms;

namespace UITask2
{
    public partial class Form2 : Form
    {
        List<Product> data;
        private float price;
        private int count;

        public Form2(List<Product> products)
        {
            InitializeComponent();
            data = products;
            Application.Idle += (object sender, EventArgs e) =>
            {
                button1.Enabled = nameField.Text != "" &&
                PriceField.Text != "" && float.TryParse(PriceField.Text, out price) &&
                CountField.Text != "" && int.TryParse(CountField.Text, out count);
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DateField.Text == "")
            {
                data.Add(new Product(nameField.Text, price, count));
                this.Close();
            }
            else if (DateTime.TryParse(DateField.Text, out DateTime date))
            {
                data.Add(new Wine(nameField.Text, price, count, date));
                this.Close();
            }
            else
                MessageBox.Show("Дата должна быть в формате [DD/MM/YYYY]");
        }
    }
}
