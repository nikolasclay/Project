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

        [TestCase("1", "01/10/1984", "Wise", "MI", "Michigan", 6.75, "Carpet", 2.50, 5.00, false)]
        [TestCase("1", "01/10/1984", "Clay", "OH", "Ohio", 7.00, "Wood", 2.50, 5.00, false)]
        [TestCase("1", "01/10/1984", "Wise", "MI", "Michigan", 1.00, "Tile", 5.00, 6.00, false)]
        public void CanAddOrder(string orderNumber, string orderDate, string CustomerName,
            string stateAbbreviation, string stateName, decimal taxRate,
            string productType, decimal costPerSquareFoot, decimal laborCostPerSquareFoot, bool expected)
        {
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

            OrderManager manager = OrderManagerFactory.Create();
            DateTime.Parse(orderDate);

            OrderRepo repo = new OrderRepo();
            Order order = new Order();
            order.OrderNumber = "1";
            order.OrderDate = new DateTime(1984, 01, 10);
            order.CustomerName = "Wise";
            order.StateTaxData = stateTaxInfo;
            order.ProductDetail = productDetail;
            order.Area = 100.00M;

            var response = repo.SaveNewOrder(order);
            Assert.IsTrue(response);
        }


        [TestCase("1", "01/10/1988", "Wise", "MI", "Michigan", 1.00, "Tile", 5.00, 6.00)]
        public void CanEditOrder(string orderNumber, string orderDate, string CustomerName,
        string stateAbbreviation, string stateName, decimal taxRate,
        string productType, decimal costPerSquareFoot, decimal laborCostPerSquareFoot)
        {
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

            OrderManager manager = OrderManagerFactory.Create();
            //DateTime.Parse(orderDate);

            MockOrderRepo repo = new MockOrderRepo();
            Order order = new Order();
            order.OrderNumber = "1";
            order.OrderDate = new DateTime(1984, 01, 10);
            order.CustomerName = "Wise";
            order.StateTaxData = stateTaxInfo;
            order.ProductDetail = productDetail;
            order.Area = 100.00M;

            var response = repo.SaveCurrentOrder(order);

            var result = repo.LoadOrder(order.OrderDate, order.OrderNumber);

            Assert.IsTrue(response);
            Assert.AreEqual("01/10/1984", result.OrderDate.ToString("MM/dd/yyyy"));
            Assert.AreEqual("Clay", result.CustomerName);

        }

        [TestCase("1", "01/10/1988", "Wise", "MI", "Michigan", 1.00, "Tile", 5.00, 6.00, false)]
        public void CanDeleteOrder(string orderNumber, string orderDate, string CustomerName,
    string stateAbbreviation, string stateName, decimal taxRate,
    string productType, decimal costPerSquareFoot, decimal laborCostPerSquareFoot, bool expected)
        {
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

            OrderManager manager = OrderManagerFactory.Create();
            DateTime.Parse(orderDate);

            OrderRepo repo = new OrderRepo();
            Order order = new Order();
            order.OrderNumber = "1";
            order.OrderDate = new DateTime(1984, 01, 10);
            order.CustomerName = "Wise";
            order.StateTaxData = stateTaxInfo;
            order.ProductDetail = productDetail;
            order.Area = 100.00M;

            var response = repo.RemoveOrder(order);
            Assert.IsTrue(response);
        }
    }
}



