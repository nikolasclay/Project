using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NewFlooringMastery.Models.Interfaces;
using NewFlooringMastery.Models;
using System.IO;
using NewFlooringMastery.Data;

namespace NewFlooringMasteryTest
{
    class ProductTest
    {
        private const string _filePath = @"C:\SoftwareGuild\dotnet-nikolas-clay\Flooring Mastery Project\NewFlooring\Products.txt";
        private const string _originalFilePath = @"C:\SoftwareGuild\dotnet-nikolas-clay\Flooring Mastery Project\NewFlooring\SeedProducts.txt";

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

            ProductRepo repo = new ProductRepo();
            StateTaxRepo taxRepo = new StateTaxRepo();

            List<ProductDetail> product = repo.LoadProducts();

            Assert.IsTrue(product.Count > 0);

        }
    }
}
