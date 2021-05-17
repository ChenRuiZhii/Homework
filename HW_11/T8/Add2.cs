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
    public partial class Add2 : Form
    {
        public Order newOrder;
        public OrderService orderService;
        public int Num { get; set; }
        public double Price { get; set; }
        public Add2()
        {
            InitializeComponent();



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.DataSource = newOrder.orderDetails;

        }

        private void addDetiles()
        {
           // textBox3.DataBindings.Add("Text", this, "Num");
           // textBox2.DataBindings.Add("Text", this, "Price");

            int num = int.Parse( textBox3.Text);
            double pri = double.Parse( textBox2.Text);
            newOrder.orderDetails = new List<OrderDetails>();
            OrderDetails newDetails = new OrderDetails(textBox1.Text, pri, num);
            bool isAdd = false;

            foreach (OrderDetails i in newOrder.orderDetails)
            {
                if (newDetails.comName==i.comName&&newDetails.comPrice==i.comPrice)
                {
                    newDetails.number = newDetails.number + i.number;
                    newOrder.orderDetails.Remove(i);

                    break;
                }

            }
                newOrder.orderDetails.Add(newDetails);
        }


        private void button1_Click(object sender, EventArgs e)
        {

            addDetiles();

            dataGridView1.DataSource = null;

            dataGridView1.DataSource = newOrder.orderDetails;

            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            newOrder.AddToSum();

            
            //orderService.AddOrder(newOrder);
            using (var db = new OrderModel())
            {
               
                db.orders.Add(newOrder);
                // db.orders.Add(orderD);

                db.SaveChanges();
            }
            this.Close();
        }
    }
}
