using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFlooringMastery.Models.Interfaces
{
    public interface IProductRepo
    {
        ProductDetail FindProductByType(string productType);
    }
}
