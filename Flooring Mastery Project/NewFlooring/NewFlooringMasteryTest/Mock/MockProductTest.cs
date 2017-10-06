using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NewFlooringMastery.Data;
using NewFlooringMastery.BLL;

namespace NewFlooringMasteryTest.Mock
{
    [TestFixture]
    public class MockProductTest
    {
        [TestCase("Plywood", 5.00, 2.15)]
        public void GetProductTest(string productType, decimal costPerSquareFoot, decimal laborCost)
        {
            MockProductRepo productRepo = new MockProductRepo();
            ProductTypeResponse response = new ProductTypeResponse();

            var result = productRepo.FindProductType(productType);

            Assert.IsNotNull(result);
            Assert.AreEqual(productType, result.ProductType);
            
        }
    }
}
