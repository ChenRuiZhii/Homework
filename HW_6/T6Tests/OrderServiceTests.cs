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

        [TestMethod()]
        public void OrderServiceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddOrderTest()
        {
            orderService.AddOrder();
            result.AddOrder();
            Assert.AreEqual(result, orderService);
        }

        [TestMethod()]
        public void DeleteOrderTest()
        {
            orderService.AddOrder();
            orderService.DeleteOrder("1");
            Assert.AreEqual(result, orderService);

        }

        [TestMethod()]
        public void ModifyOrderTest()
        {
            Assert.IsFalse(orderService.ModifyOrder("1", "10", "11"));
        }

        [TestMethod()]
        public void SortOrdersTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SearchOrderTest()
        {
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