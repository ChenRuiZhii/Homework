using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("+");
            comboBox1.Items.Add("-");
            comboBox1.Items.Add("*");
            comboBox1.Items.Add("/");

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a, b;
            string c;
            a = double.Parse(textBox1.Text);
            b = double.Parse(textBox2.Text);
            c = comboBox1.Text;
            double t;
            switch (c)
            {
                case "+":
                    t = a + b;
                    textBox3.Text = t.ToString();
                    break;
                case "-":
                    t = a - b;
                    textBox3.Text = t.ToString();
                    break;
                case "*":
                    t = a * b;
                    textBox3.Text = t.ToString();
                    break;
                case "/":
                    t = a / b;
                    textBox3.Text = t.ToString();
                    break;

            }
        }
    }
}
