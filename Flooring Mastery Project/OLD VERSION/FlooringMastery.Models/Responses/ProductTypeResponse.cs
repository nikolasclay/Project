using NewFlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models.Responses
{
    class ProductTypeResponse : Response
    {
        public ProductDetail ProductTypeInfo { get; set; }
    }
}
