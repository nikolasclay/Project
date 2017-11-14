using CarDealership.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Model;
using CarDealership.Model.Queries;
using NUnit.Framework;
using CarDealership.Data;

namespace CarDealership.Tests
    
{
    [TestFixture]
    public class MockTest
    {

        [Test]
        public void CanQuickSearch()
        {
            var repo = new TestRepository();
            var found = repo.QuickSearch(new VehicleSearchParameters { QuickSearch = "Audi" });

            Assert.AreEqual(1, found.Count());
        }
        [Test]
        public void CanSearchByMinPrice()
        {
            var repo = new TestRepository();
            var found = repo.QuickSearch(new VehicleSearchParameters { MinPrice = 50000.00M });

            Assert.AreEqual(4, found.Count());
        }
        [Test]
        public void CanSearchByAll()
        {
            var repo = new TestRepository();
            var found = repo.QuickSearch(new VehicleSearchParameters { QuickSearch = "Audi", MinPrice = 100.00M, MaxPrice = 100000.00M, MinYear = 2015, MaxYear = 2017 });

            Assert.AreEqual(1, found.Count());
        }
        [Test]
        public void CanSearchByMinAndMax()
        {
            var repo = new TestRepository();
            var found = repo.QuickSearch(new VehicleSearchParameters { MinPrice = 50000.00M, MaxPrice = 60000.00M });

            Assert.AreEqual(1, found.Count());
        }
        [Test]
        public void CanSearchByQuickAndPrice()
        {
            var repo = new TestRepository();

            var found = repo.QuickSearch(new VehicleSearchParameters { QuickSearch = "BMW", MinPrice = 70000.00M });

            Assert.AreEqual(1, found.Count());
        }
        [Test]
        public void CanSearchByDates()
        {
            var repo = new TestRepository();
            var found = repo.QuickSearch(new VehicleSearchParameters { MinYear = 2015, MaxYear = 2017 });

            Assert.AreEqual(3, found.Count());
        }
        [Test]
        public void CanSearchByMaxYear()
        {
            var repo = new TestRepository();

            var found = repo.QuickSearch(new VehicleSearchParameters { MaxYear = 2017 });

            Assert.AreEqual(5, found.Count());
        }
        [Test]
        public void CanSearchByMinYear()
        {
            var repo = new TestRepository();
            var found = repo.QuickSearch(new VehicleSearchParameters { MinYear = 2015 });

            Assert.AreEqual(3, found.Count());
        }
        [Test]
        public void SearchByLetters()
        {
            var repo = new TestRepository();
            var found = repo.QuickSearch(new VehicleSearchParameters { QuickSearch = "BM", });

            Assert.AreEqual(1, found.Count);
        }
        [Test]
        public void SearchBySearchAndMinPrice()
        {
            var repo = new TestRepository();
            var found = repo.QuickSearch(new VehicleSearchParameters { QuickSearch = "Audi", MinPrice = 50000.00M });

            Assert.AreEqual(0, found.Count());
        }
        [Test]
        public void SearchByQuickAndMaxPrice()
        {
            var repo = new TestRepository();
            var found = repo.QuickSearch(new VehicleSearchParameters { QuickSearch = "Aston Martin", MaxPrice = 55000.00M });

            Assert.AreEqual(0, found.Count);
        }
        [Test]
        public void SearchByQuickAndDates()
        {
            var repo = new TestRepository();
            var found = repo.QuickSearch(new VehicleSearchParameters { QuickSearch = "Aston Martin", MinYear = 2013, MaxYear = 2016 });

            Assert.AreEqual(1, found.Count);
        }
        [Test]
        public void SearchByMinYearAndMaxPrice()
        {
            var repo = new TestRepository();
            var found = repo.QuickSearch(new VehicleSearchParameters { MinYear = 2013, MaxPrice = 200000.00M });

            Assert.AreEqual(5, found.Count);
        }
        [Test]
        public void CanAddVehicle()
        {
            var repo = new TestRepository();

            Vehicle vehicle = new Vehicle();

            var preAdd = repo.GetAll();

            VehicleMake vehicleMake = new VehicleMake()
            {

                Make = "Lamborghini",
                Added = new DateTime(2017, 11, 17)

            };
            VehicleModel vehicleModel = new VehicleModel()
            {
                ModelType = "Centenario"
            };

            
            vehicle.BodyStyle.Description = "Car";
            vehicle.ExteriorColor.Description = "Black";
            vehicle.InteriorColor.Description = "Black";
            vehicle.Feature = true;
            vehicle.Image = "Content/img/Lamborghini.jpg";
            vehicle.Mileage = 1000;
            vehicle.MSRP = 150000.00M;
            vehicle.New = true;
            vehicle.SalePrice = 160000.00M;
            vehicle.Transmission = "Manual";
            vehicle.VIN = "11111111111111111";
            vehicle.Year = 2017;
            vehicle.Description = "It's a Lamborghini.";

            repo.AddVehicle(vehicle);

            var postAdd = repo.GetAll();

            Assert.AreEqual(preAdd.Count + 1, postAdd.Count);
        }
    }
}
