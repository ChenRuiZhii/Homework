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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public Form3(string id, OrderService orderservice)
        {
            InitializeComponent();


            foreach (Order i in orderservice.orders)
            {
                if (i.Id == int.Parse(id))
                {
                    label1.Text = "总价格：" + i.sumPrice;


                    dataGridView1.DataSource = i.orderDetails;
                    this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;


                    return;
                }

            }

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
