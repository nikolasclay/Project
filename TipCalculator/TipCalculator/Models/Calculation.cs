using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TipCalculator.Models
{
    public class Calculation
    {
        public decimal Amount { get; set; }
        public decimal Percentage { get; set; }
        public decimal TipCalculation => Amount * (Percentage / 100);

        public decimal CalculateTotal()
        {
            return Amount + TipCalculation;
        }
    }
}