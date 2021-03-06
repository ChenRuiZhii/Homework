﻿using System;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            
        }

        public Form2(string id,OrderService orderservice)
        {
            InitializeComponent();
            using(var db = new OrderModel())
            {
                int k = int.Parse(id);

                var i = db.orders.Include("orderDetails").Include("Customer").FirstOrDefault(p => p.id == k);
                label1.Text = i.Customer.ToString();
                label2.Text = "订单号：" + i.id;
                label3.Text = "配送地址：" + i.address;
            }

           
        }
        private void Form2_load(object sender,EventArgs e)
        {
            string initializedText = "NIL";
            label1.DataBindings.Add("Text", this, "initializedText");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
