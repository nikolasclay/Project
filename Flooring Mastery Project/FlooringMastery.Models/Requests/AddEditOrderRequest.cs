using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models.Requests
{
    public class AddEditOrderRequest
    {
        public Order Order { get; set; }
        public string FileDateTime { get; set; }
    }
}
