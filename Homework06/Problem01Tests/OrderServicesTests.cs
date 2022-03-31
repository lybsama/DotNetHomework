using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problem01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem01.Tests
{
    [TestClass()]
    public class OrderServicesTests
    {
        [TestMethod()]
        public void addOrderTest()
        {
            OrderServices service = new OrderServices();
            var expected = "1,Li Lei";
            var actual=service.addOrder(1,"Li Lei");
            Assert.AreEqual(expected,actual);
        }
        public static List<Order> allOrders = new List<Order>();
        public void removeOrderTest()
        {
            var expected = "操作正确！";
            OrderServices service=new OrderServices();
            int id = Convert.ToInt32(Console.ReadLine());
            var actual = service.removeOrder(allOrders, id);
            service.Export(actual);
        }
        public string searchOrderByMoneyTest()
        {
            OrderServices service = new OrderServices();
            string actual = service.searchOrderByMoney(1,100,allOrders);
            return actual;
        }
        public string searchOrderByNameTest()
        {
            OrderServices service = new OrderServices();
            string actual = service.searchOrderByName("Li Lei", allOrders);
            return actual;
        }
    }
}