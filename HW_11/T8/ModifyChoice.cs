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
    public partial class ModifyChoice : Form
    {
        public OrderService orderService;
        public ModifyChoice()
        {
            InitializeComponent();
        }

        private void ModifyChoice_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(var db = new OrderModel())
            {
                var order = db.orders.FirstOrDefault(p => p.id == int.Parse(textBox1.Text));
                db.Entry(order).State = System.Data.Entity.EntityState.Modified;
                order.customer.customername = textBox2.Text;
                db.SaveChanges();
                
                
                }


            //orderService.ModifyOrder(textBox1.Text, "1", textBox2.Text);
//this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // orderService.ModifyOrder(textBox1.Text, "2", textBox2.Text);
           // this.Close();
            using (var db = new OrderModel())
            {
                var order = db.orders.FirstOrDefault(p => p.id == int.Parse(textBox1.Text));
                db.Entry(order).State = System.Data.Entity.EntityState.Modified;
                order.oderTime = textBox2.Text;
                db.SaveChanges();


            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //orderService.ModifyOrder(textBox1.Text, "3", textBox2.Text);
            //this.Close();
            using (var db = new OrderModel())
            {
                var order = db.orders.FirstOrDefault(p => p.id == int.Parse(textBox1.Text));
                db.Entry(order).State = System.Data.Entity.EntityState.Modified;
                order.address = textBox2.Text;
                db.SaveChanges();


            }
        }
    }
}
