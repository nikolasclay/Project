using FlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMastery.Data
{
    public class ProdTaxRepo : ITaxRepo
    {
        public StateName GetStateName(string stateName)
        {
            throw new NotImplementedException();
        }

        public Tax LoadTax(string StateAbbreviation)
        {
            throw new NotImplementedException();
        }
    }
}
