using NewFlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewFlooringMastery.Models;

namespace NewFlooringMastery.Data
{
    public class MockProductRepo : IProductRepo
    {
        private static List<ProductName> productNameList = new List<ProductName>()
        {
            new ProductName("Plywood", 5.00M, 2.15M),
            new ProductName("Stone", 3.50M, 5.00M)
        };

        public ProductDetail FindProductByType(string productType)
        {
            throw new NotImplementedException();
        }

        //public ProductDetail FindProductByType(string productType)
        //{
        //    //return productNameList.FirstOrDefault(p => p.ProductType == productType);
        //}

        public ProductDetail GetProduct(string productType)
        {
            throw new NotImplementedException();
        }

    }
}
