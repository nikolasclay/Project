using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Model
{
    public class SalesReport
    {
        public int UserId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int PurchaseId { get; set; }
        public decimal TotalSales { get; set; }
        public decimal TotalVehicles { get; set; }

        public virtual Purchase Purchase { get; set; }
        public virtual User User { get; set; }
    }
}
