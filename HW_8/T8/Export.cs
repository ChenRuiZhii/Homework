using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using T6;
namespace T8
{
    public partial class Export : Form
    {
        public OrderService orderService;
        public Export()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(textBox1.Text+".xml", FileMode.Create))
            {

                xmlSerializer.Serialize(fs, orderService.orders);
                Succeed succeed = new Succeed();
                succeed.ShowDialog();
                this.Close();
            }

        }
    }
}
