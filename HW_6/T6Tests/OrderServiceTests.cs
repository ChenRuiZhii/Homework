using Microsoft.VisualStudio.TestTools.UnitTesting;
using T6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T6.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        OrderService orderService = new OrderService();
        OrderService result = new OrderService();

        Order order1 = new Order("1", "a", "3.1", "珞珈山");
        Order order2 = new Order("2", "b", "3.2", "珞珈河");
        Order order3 = new Order("3", "c", "3.3", "珞珈湖");
        
        [TestMethod()]
        public void OrderServiceTest()
        {
        }

        [TestMethod()]
        public void AddOrderTest()
        {
            orderService.AddOrder(order1);
            result.AddOrder(order2);
        }

        [TestMethod()]
        public void DeleteOrderTest()
        {
            orderService.DeleteOrder("1");
            Assert.IsFalse(result.Equals( orderService));

        }

        [TestMethod()]
        public void ModifyOrderTest()
        {
            Assert.IsFalse(orderService.ModifyOrder("1", "10", "11"));
        }

        [TestMethod()]
        public void SortOrdersTest()
        {
        }

        [TestMethod()]
        public void SearchOrderTest()
        {
            orderService.orders.Add(order1);
            Assert.IsTrue(orderService.SearchOrder("2", "1"));
        }

        [TestMethod()]
        public void ExportTest()
        {
        }

        [TestMethod()]
        public void ImortTest()
        {
        }
    }
}