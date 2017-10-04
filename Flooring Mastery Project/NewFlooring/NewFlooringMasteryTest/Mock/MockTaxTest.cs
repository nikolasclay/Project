using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NewFlooringMastery.Models.Responses;
using NewFlooringMastery.Data;

namespace NewFlooringMasteryTest.Mock
{
    [TestFixture]
    public class MockTaxTest
    {
        [TestCase("MI", "Michigan", 5.75)]
        public void GetStateTaxDataTest(string stateAbbreviation, string stateName, decimal taxRate)
        {
            MockTaxRepo taxRepo = new MockTaxRepo();
            GetStateResponse response = new GetStateResponse();

            var result = taxRepo.LoadTaxForState(stateAbbreviation);

            Assert.AreEqual(stateAbbreviation, result.StateAbbreviation);
        }
    }
}
