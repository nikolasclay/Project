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
        //public string State { get; set; }
        public StateTaxInfo StateTaxData { get; set; }
        public ProductDetail ProductDetail{ get; set; }
        public decimal Area { get; set; }
        //public decimal CostPerSquareFoot { get; set; }
        //public decimal LaborCostPerSquareFoot { get; set; }
        public decimal MaterialCost => ProductDetail.CostPerSquareFoot * Area;
        public decimal LaborCost => ProductDetail.LaborCostPerSquareFoot * Area;
        public decimal Tax => (MaterialCost + LaborCost) * (StateTaxData.TaxRate / 100);
        public decimal Total => MaterialCost + LaborCost + Tax;
      
    }
}
