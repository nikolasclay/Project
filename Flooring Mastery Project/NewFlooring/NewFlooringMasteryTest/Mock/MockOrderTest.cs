using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NewFlooringMastery.Models.Interfaces;
using NewFlooringMastery.Models;
using NewFlooringMastery.BLL;
using NewFlooringMastery.Models.Responses;
using NewFlooringMastery.UI;
using NewFlooringMastery.Data;

namespace NewFlooringMasteryTest.Mock
{
    [TestFixture]
    public class MockOrderTest
    {
        [Test]
        public void CanLoadAllOrders()
        {
            OrderManager manager = OrderManagerFactory.Create();

            LookupOrderResponse response = new LookupOrderResponse();
            DateTime date = new DateTime(1984, 1, 10);
            response = manager.LookupOrder(date);

            Assert.IsNotNull(response.Orders);
            Assert.IsTrue(response.Success);
            Assert.AreEqual(1, response.Orders.Count());
        }

    }
}
