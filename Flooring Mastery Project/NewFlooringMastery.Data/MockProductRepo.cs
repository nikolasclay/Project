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
        public ProductDetail FindProductByType(string productType)
        {
            throw new NotImplementedException();
        }

        public ProductDetail GetProduct(string productType)
        {
            throw new NotImplementedException();
        }

    }
}
