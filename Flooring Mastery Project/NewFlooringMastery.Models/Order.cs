using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFlooringMastery.Models
{
    public class Order
    {
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public string State { get; set; }
        public TaxInfo StateTaxRate { get; set; }
        public ProductDetail ProductInfo { get; set; }
        public decimal Area { get; set; }
        public decimal MaterialCost { get { return ProductInfo.CostPerSquareFoot * Area; } }
        public decimal LaborCost { get { return ProductInfo.LaborCostPerSquareFoot * Area; } }
        public decimal Tax { get { return (MaterialCost + LaborCost) * StateTaxRate.TaxRate / 100; } }
        public decimal Total { get { return MaterialCost + LaborCost + Tax; } }
    }
}
