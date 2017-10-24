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

        private const string _dirPath = @"C:\SoftwareGuild\dotnet-nikolas-clay\Flooring Mastery Project\NewFlooring\TestData";
        private const string _seedPath = @"C:\SoftwareGuild\dotnet-nikolas-clay\Flooring Mastery Project\NewFlooring\SeedData";

        [SetUp]
        public void Setup()
        {
            DirectoryInfo dataInfo = new DirectoryInfo(_dirPath);
            foreach (var fileToDelete in dataInfo.EnumerateFiles())
            {
                fileToDelete.Delete();
            }

            DirectoryInfo newDataInfo = new DirectoryInfo(_seedPath);
            foreach (var fileToCopy in newDataInfo.EnumerateFiles())
            {
                fileToCopy.CopyTo(Path.Combine(_dirPath, fileToCopy.Name));
            }

        }
        [Test]
        public void CanReadDataFromFile()
        {

            OrderRepo repo = new OrderRepo(_dirPath);
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

            DateTime date = new DateTime(2017, 11, 01);
            Order order = new Order();
            order.OrderNumber = 1;
            order.OrderDate = date;
            order.CustomerName = "Clay";
            order.StateTaxData = taxInfo;
            order.ProductDetail = productDetail;
            order.Area = 100.00M;

            OrderRepo repo = new OrderRepo(_dirPath);
            var preAddResponse = repo.LoadAllOrders(date);

            var response = repo.SaveNewOrder(order);

            var postAdd = repo.LoadAllOrders(date);

            Assert.AreEqual(preAddResponse.Count + 1, postAdd.Count);

            //SaveNewOrderResponse response = new SaveNewOrderResponse();
            //response.Order;

            Assert.IsTrue(response);
        }

        [Test]
        public void CanEditOrder()
        {
            OrderRepo repo = new OrderRepo(_dirPath);
            DateTime orderDate = new DateTime(2013, 6, 1);

            var preEditResponse = repo.LoadOrder(orderDate, 1);
            preEditResponse.CustomerName = "Wise";
            preEditResponse.Area = 200.00M;

            repo.SaveCurrentOrder(preEditResponse);

            var postEditResponse = repo.LoadOrder(orderDate, 1);

            Assert.AreEqual("Wise", preEditResponse.CustomerName);
            Assert.AreEqual(200.00M, preEditResponse.Area);



        }

        [Test]
        public void CanDeleteOrder()
        {
            OrderRepo repo = new OrderRepo(_dirPath);
            DateTime orderDate = new DateTime(2013, 6, 1);

            var toRemove = repo.LoadOrder(orderDate, 1);

            var preDeleteCount = repo.LoadAllOrders(orderDate).Count;

            repo.RemoveOrder(toRemove);

            var postRemove = repo.LoadAllOrders(orderDate).Count;

            Assert.AreEqual(preDeleteCount - 1, postRemove);

        }
        

    }
}

    

