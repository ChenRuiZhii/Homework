using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using T6;

namespace T8
{
    public partial class Add1 : Form
    {
        public int ID { get; set; }

        public Form form1;

        public OrderService orderService;
        public Add1()
        {
            InitializeComponent();


        }
       
        private void Add1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string str1, id1, cus1, oderTime, price, add, comName;
            double pri;
            int num;
            //Console.WriteLine("开始增添新的订单！请依次输入：订单ID，客户，下单时间，配送地址");
            textBox1.DataBindings.Add("Text", this, "ID");
            //textBox2.DataBindings.Add("Text", this, "cus1");
            //textBox3.DataBindings.Add("Text", this, "orderTime");
            //textBox4.DataBindings.Add("Text", this, "add");
            id1 = textBox1.Text;
            cus1 = textBox2.Text;
            oderTime = textBox3.Text;
            add = textBox4.Text;
            Order newOrder = new Order(id1, cus1, oderTime, add);//尚未add

            Add2 add2 = new Add2();
            add2.newOrder = newOrder;
            add2.orderService = orderService;
            add2.ShowDialog();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
