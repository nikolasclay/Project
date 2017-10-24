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

        [TestCase("1", "01/10/1984", "Wise", "MI", "Michigan", 6.75, "Carpet", 2.50, 5.00)]
        [TestCase("1", "01/10/1984", "Clay", "OH", "Ohio", 7.00, "Wood", 2.50, 5.00)]
        [TestCase("1", "01/10/1984", "Wise", "MI", "Michigan", 1.00, "Tile", 5.00, 6.00)]
        public void CanAddOrder(string orderNumber, string orderDate, string CustomerName,
            string stateAbbreviation, string stateName, decimal taxRate,
            string productType, decimal costPerSquareFoot, decimal laborCostPerSquareFoot)
        {
            DateTime date = DateTime.Parse(orderDate);

            OrderManager manager = new OrderManager(new MockOrderRepo(), new MockTaxRepo(), new MockProductRepo());

            var preInsertResponse = manager.LookupOrder(date);

            StateTaxInfo stateTaxInfo = new StateTaxInfo
            {
                StateAbbreviation = stateAbbreviation,
                StateName = stateName,
                TaxRate = taxRate
            };
            ProductDetail productDetail = new ProductDetail
            {
                ProductType = productType,
                CostPerSquareFoot = costPerSquareFoot,
                LaborCostPerSquareFoot = laborCostPerSquareFoot
            };


            Order order = new Order();
            order.OrderNumber = 1;
            order.OrderDate = date;
            order.CustomerName = "Wise";
            order.StateTaxData = stateTaxInfo;
            order.ProductDetail = productDetail;
            order.Area = 100.00M;

            var insertResponse = manager.SaveNewOrder(order);
            Assert.IsTrue(insertResponse.Success);

            var postInsertResponse = manager.LookupOrder(date);
            Assert.AreEqual(preInsertResponse.Orders.Count + 1, postInsertResponse.Orders.Count);
        }


        [TestCase(1, "01/10/1984", "Wise", 150)]
        public void CanEditOrder(int orderNumber, string orderDate, string customerName, decimal newArea)
        {
            OrderManager manager = new OrderManager(new MockOrderRepo(), new MockTaxRepo(), new MockProductRepo());
            DateTime date = DateTime.Parse(orderDate);

            var loadOrderResponse = manager.LoadRequestedOrder(date, orderNumber);

            loadOrderResponse.Order.CustomerName = customerName;
            loadOrderResponse.Order.Area = newArea;

            var response = manager.SaveCurrentOrder(loadOrderResponse.Order);

            var confirmationResponse = manager.LoadRequestedOrder(date, orderNumber);
            Assert.AreEqual(customerName, confirmationResponse.Order.CustomerName);
            Assert.AreEqual(newArea, confirmationResponse.Order.Area);




        }

        [TestCase(1, "01/10/1984")]
        public void CanDeleteOrder(int orderNumber, string orderDate)
        {
            DateTime date = DateTime.Parse(orderDate);
            OrderManager manager = new OrderManager(new MockOrderRepo(), new MockTaxRepo(), new MockProductRepo());

            var preDeleteResponse = manager.LookupOrder(date);
            var orderResponse = manager.LoadRequestedOrder(date, orderNumber);
            manager.RemoveOrder(orderResponse.Order);

            var postDeleteResponse = manager.LookupOrder(date);

            Assert.AreEqual(postDeleteResponse.Orders.Count + 1, preDeleteResponse.Orders.Count);

        }
    }
}



