using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;
using NewFlooringMastery.Data;
using NewFlooringMastery.Models;
using NewFlooringMastery.Models.Interfaces;

namespace NewFlooringMasteryTest
{
    class TaxTest : ITaxRepo
    {
        public StateTaxInfo LoadTaxForState(string StateAbbreviation)
        {
            throw new NotImplementedException();
        }
    }
}
    
        