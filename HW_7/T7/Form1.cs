using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = int.Parse(textBox1.Text);
            int leng = int.Parse(textBox2.Text);
            
            if (graphics == null) graphics = this.CreateGraphics();
            drawCayleyTree(n, 200, 310, leng, -Math.PI / 2);
        }
        private Graphics graphics;

        void drawCayleyTree(int n,double x0,double y0,double leng,double th)
        {
            if (n == 0) return;
            else if (n > 12||n<0)
            {
                textBox1.Text = "12";
                n = 12;//递归深度不能超过12
            }

            if (leng > 130||leng<0)
            {
                textBox2.Text = "130";
                leng = 130;
            }


            double per1 = double.Parse(textBox3.Text);
            double per2 = double.Parse(textBox4.Text);
            double th1 = double.Parse(textBox5.Text) * Math.PI;
            double th2 = double.Parse(textBox6.Text) * Math.PI;


            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            drawLine(x0, y0, x1, y1);

            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);

        }

        void drawLine(double x0,double y0,double x1,double y1)
        {
            Color color = Color.FromName(comboBox1.Text);
            Pen pen1 = new Pen(color);
            string pen = comboBox1.Text;
            graphics.DrawLine(
                pen1,
                (int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           
        }

        private void comboBox1_Layout(object sender, LayoutEventArgs e)
        {
            Array colors = System.Enum.GetValues(typeof(KnownColor));
            foreach (object colorName in colors)
            {

                comboBox1.Items.Add(colorName);

            }
        }
    }
}
