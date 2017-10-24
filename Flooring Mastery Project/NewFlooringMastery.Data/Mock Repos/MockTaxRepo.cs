using NewFlooringMastery.Models;
using NewFlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFlooringMastery.Data
{
    public class MockTaxRepo : ITaxRepo
    {
        private static List<StateName> stateNameList = new List<StateName>()
        {
            new StateName("MI", "Michigan", 7.00M),
            new StateName("IN", "Indiana", 6.00M)
        };

        public StateName GetStateName(string stateName)
        {
            return stateNameList.FirstOrDefault(s => s.StateAbbreviation == stateName || s.State == stateName);
        }

        public StateTaxInfo LoadTax(string StateAbbreviation)
        {
            throw new NotImplementedException();
        }

        public StateTaxInfo LoadTaxForState(string StateAbbreviation)
        {
            throw new NotImplementedException();
        }
    }
}
