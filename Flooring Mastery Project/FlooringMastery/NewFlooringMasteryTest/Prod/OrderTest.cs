using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;
using NewFlooringMastery.Data;
using NewFlooringMastery.Models;
using NewFlooringMastery.UI;
using NewFlooringMastery.BLL;
using NewFlooringMastery.Models.Responses;

namespace NewFlooringMasteryTest
{
    [TestFixture]
    class OrderTest
    {

        private const string _filePath = @"C:\SoftwareGuild\dotnet-nikolas-clay\Flooring Mastery Project\NewFlooring\Orders_06012013.txt";
        private const string _originalFilePath = @"C:\SoftwareGuild\dotnet-nikolas-clay\Flooring Mastery Project\NewFlooring\SeedOrders_06012013.txt";

        [SetUp]
        public void Setup()
        {
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }
            File.Copy(_originalFilePath, _filePath);
        }
        [Test]
        public void CanReadDataFromFile()
        {

            OrderRepo repo = new OrderRepo();
            StateTaxRepo taxRepo = new StateTaxRepo();

            DateTime orderDate = new DateTime(2013, 6, 1);


            List<Order> order = repo.LoadAllOrders(orderDate);

            Assert.IsTrue(order.Count > 0);

        }
            [Test]
            public void CanAddOrder()
        {
            StateTaxInfo taxInfo = new StateTaxInfo()
            {
                StateAbbreviation = "OH",
                StateName = "Ohio",
                TaxRate = 6.75M

            };
            ProductDetail productDetail = new ProductDetail()
            {
                ProductType = "Wood",
                CostPerSquareFoot = 5.00M,
                LaborCostPerSquareFoot = 2.50M

            };

            
            Order order = new Order();
            order.OrderNumber = "1";
            order.OrderDate = new DateTime(2017, 11, 01);
            order.CustomerName = "Clay";
            order.StateTaxData = taxInfo;
            order.ProductDetail = productDetail;
            order.Area = 100.00M;

            OrderRepo repo = new OrderRepo();
            var response = repo.SaveNewOrder(order);

            //SaveNewOrderResponse response = new SaveNewOrderResponse();
            //response.Order;

            Assert.IsTrue(response); 
        }

        [Test]
        public void CanEditOrder()
        {
            StateTaxInfo taxInfo = new StateTaxInfo()
            {
                StateAbbreviation = "OH",
                StateName = "Ohio",
                TaxRate = 6.25M

            };
            ProductDetail productDetail = new ProductDetail()
            {
                ProductType = "Wood",
                CostPerSquareFoot = 5.15M,
                LaborCostPerSquareFoot = 4.75M

            };


            Order order = new Order();
            order.OrderNumber = "1";
            order.OrderDate = new DateTime(2017, 11, 01);
            order.CustomerName = "Wise";
            order.StateTaxData = taxInfo;
            order.ProductDetail = productDetail;
            order.Area = 100.00M;

            OrderRepo repo = new OrderRepo();
            var response = repo.SaveCurrentOrder(order);

            //SaveNewOrderResponse response = new SaveNewOrderResponse();
            //response.Order;

            Assert.IsTrue(response);
        }

            //Order check = order[0];

            //Assert.AreEqual("1", check.OrderNumber);
            //Assert.AreEqual("Wise", check.CustomerName);
            //Assert.AreEqual("OH", check.StateTaxData.StateAbbreviation);
            //Assert.AreEqual(6.25M, check.StateTaxData.TaxRate);
            //Assert.AreEqual("Wood", check.ProductDetail.ProductType);
            //Assert.AreEqual(100.00, check.Area);
            //Assert.AreEqual(5.15, check.ProductDetail.CostPerSquareFoot);
            //Assert.AreEqual(4.75, check.ProductDetail.LaborCostPerSquareFoot);
            //Assert.AreEqual(515.0000, check.MaterialCost);
            //Assert.AreEqual(475.0000, check.LaborCost);
            //Assert.AreEqual(61.87500000, check.Tax);
            //Assert.AreEqual(1051.87500000, check.Total);
        }
    }

    

