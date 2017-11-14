using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Model
{
    public class Inventory
    {
        public int VehicleId { get; set; }
        public int Count { get; set; }
        public decimal StockValue { get; set; }


        public virtual Vehicle Vehicle { get; set; }
    }
}
