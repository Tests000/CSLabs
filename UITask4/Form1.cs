using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Laba_DLL;

namespace UITask4
{
    public partial class Form1 : Form
    {
        private List<Type> classes;
        private string path;
        private MethodInfo[] methods;
        private string[] paramsValue;
        private object movable;
        public Form1()
        {
            InitializeComponent();
            pathField.MouseDoubleClick += pathField_TextChanged;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            button2.Visible = false;
            comboBox2.SelectedIndexChanged += ChangeMethod;
            comboBox1.SelectedIndexChanged += (object sender, EventArgs e) =>
            {
                movable = Activator.CreateInstance(classes.ElementAt(comboBox1.SelectedIndex));
                comboBox2.SelectedIndex = 0;
                SetProperties();
            };
            comboBox3.Visible = false;
            paramValue.Visible = false;
            comboBox3.SelectedIndexChanged += (object sender, EventArgs e) =>
            {
                paramValue.Text = paramsValue[comboBox3.SelectedIndex];
            };
        }

        private void pathField_TextChanged(object sender, MouseEventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "dll files (*.dll)|*.dll|All files (*.*)|*.*";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Assembly asm = Assembly.LoadFile(fileDialog.FileName);
                        List<Type> tmp = new List<Type>();
                        foreach (Type c in asm.GetTypes())
                        {
                            var interf = c.GetInterfaces();
                            if (interf.Any(a => a.Name == nameof(IMovable)) && !c.IsAbstract)
                                tmp.Add(c);
                        }
                        if (tmp.Count == 0)
                            throw new Exception("В данной библиотеке нет ни одного класса, который реализует интерфейс");
                        comboBox1.Items.Clear();
                        foreach (Type c in tmp)
                            comboBox1.Items.Add(c.Name);
                        string s = Path.GetFileName(fileDialog.FileName);
                        pathField.Text = s.Remove(s.Length - 4, 4);
                        pathField.ForeColor = Color.Black;
                        classes = tmp;
                        comboBox1.Visible = true;
                        comboBox1.SelectedIndex = 0;
                        ShowMethods(tmp.First().GetMethods());
                        comboBox2.Visible = true;
                        comboBox2.SelectedIndex = 0;
                        path = fileDialog.FileName;
                        button2.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        comboBox1.Visible = false;
                        pathField.Text = "Нажмите, чтобы открыть...";
                        pathField.ForeColor = Color.Gray;
                        button2.Visible = false;
                        comboBox3.Visible = false;
                        paramValue.Visible = false;
                    }
                }
            }
        }

        private void ShowMethods(MethodInfo[] meths)
        {
            methods = meths;
            comboBox2.Items.Clear();
            foreach (MethodInfo c in meths)
                if (!c.IsPrivate)
                    comboBox2.Items.Add(c.Name);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pathField_TextChanged(sender, null);
        }

        private void ChangeMethod(object sender, EventArgs e)
        {
            var paramets = methods[comboBox2.SelectedIndex].GetParameters();
            comboBox3.Items.Clear();
            if (paramets.Length > 0)
            {
                paramsValue = new string[paramets.Length];
                comboBox3.Visible = true;
                paramValue.Visible = true;
                foreach (var param in paramets)
                    comboBox3.Items.Add($"[{param.GetType().Name}]{param.Name}");
                comboBox3.SelectedIndex = 0;
            }
            else
            {
                comboBox3.Visible = false;
                paramValue.Visible = false;
            }
        }

        private void SetProperties()
        {
            propField.Text = "";
            try
            {
                foreach (var prop in classes.ElementAt(comboBox1.SelectedIndex).GetProperties())
                    propField.Text += $"{prop.Name}: {prop.GetValue(movable)}\t\n\n";
            }
            catch { }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            ShowMethods(classes.ElementAt(comboBox1.SelectedIndex).GetMethods());
        }

        private void paramValue_TextChanged(object sender, EventArgs e)
        {
            paramsValue[comboBox3.SelectedIndex] = paramValue.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var paramets = methods[comboBox2.SelectedIndex].GetParameters();
            object[] pars = new object[paramets.Length];
            for (int i = 0; i < paramets.Length; i++)
            {
                if (int.TryParse(paramsValue[i], out int num))
                {
                    pars[i] = num;
                }
                else
                    pars[i] = 0;
            }
            var meth = methods[comboBox2.SelectedIndex];
            object res;
            if (meth.GetParameters().Length > 0)
                res = meth.Invoke(movable, pars);
            else
                res = meth.Invoke(movable, null);
            if (res != null)
                returnField.Text = res.ToString();
            SetProperties();
        }
    }
}
