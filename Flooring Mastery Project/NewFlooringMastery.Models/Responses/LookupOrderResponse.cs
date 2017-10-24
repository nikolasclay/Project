using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFlooringMastery.Models.Responses
{
    public class LookupOrderResponse : Response
    {
        public List<Order> Orders { get; set; }
    }
}
