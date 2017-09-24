using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models.Requests
{
    public class RemoveOrderRequest
    {
        public string OrderFileName{ get; set; }
        public string OrderID { get; set; }
    }
}
