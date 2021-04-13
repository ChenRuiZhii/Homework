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
