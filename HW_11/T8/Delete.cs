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
    public partial class Delete : Form
    {

        public OrderService orderService;

        public Delete()
        {
            InitializeComponent();



        }

        private void button1_Click(object sender, EventArgs e)
        {
         
            string id = textBox1.Text;
            using (var db = new OrderModel())
            {
                int k = int.Parse(id);

                var order = db.orders.Include("OrderDetails").FirstOrDefault(p => p.id == k);
                if (order != null)
                {
                    //db.orders.Attach(order);
                    db.orders.Remove(order);
                    db.SaveChanges();
                }
               
            }

            if (orderService.DeleteOrder(id))
            {
                DeleteSucced deleteSucced = new DeleteSucced();
                deleteSucced.ShowDialog();
                this.Close();
            }
            else
            {
                DeleteError deleteError = new DeleteError();
                deleteError.ShowDialog();
                this.Close();
            }
           
        }
    }
}
