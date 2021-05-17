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
    public partial class Search : Form
    {

        public OrderService orderService;

        public Search()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (var db = new OrderModel())
            {
                int k = int.Parse(textBox1.Text);
                var order = db.orders.FirstOrDefault(p => p.id == k);
               // var order = db.orders.FirstOrDefault(p => p.id == int.Parse(textBox1.Text));

                SearchReturn searchReturn = new SearchReturn(order);
                searchReturn.ShowDialog();

            }



            /*foreach (Order i in orderService.orders)
            {
                if(i.id == int.Parse(textBox1.Text))
                {
                    SearchReturn searchReturn = new SearchReturn(i);
                    searchReturn.ShowDialog();
                    this.Close();
                    break;
                }
            }*/
        }
    }
}
