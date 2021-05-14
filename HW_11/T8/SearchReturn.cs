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
    public partial class SearchReturn : Form
    {
        public SearchReturn(Order order)
        {
            InitializeComponent();
            label1.Text = order.customer.ToString();
            label2.Text = "订单号：" + order.id;
            label3.Text = "配送地址：" + order.address;

            label4.Text = "总价格：" + order.sumPrice;


            dataGridView1.DataSource = order.orderDetails;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;


            return;

            return;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
