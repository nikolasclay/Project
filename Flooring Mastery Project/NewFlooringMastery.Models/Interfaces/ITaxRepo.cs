using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFlooringMastery.Models.Interfaces
{
    public interface ITaxRepo
    {
        TaxInfo LoadTaxForState(string StateAbbreviation);
        StateName GetStateName(string stateName);
    }
}
