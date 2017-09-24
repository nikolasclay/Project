using FlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMastery.Data
{
    public class MockProductsRepo : IProductsRepo
    {
        public Products LoadProduct(Products ProductType)
        {
            throw new NotImplementedException();
        }
    }
}
