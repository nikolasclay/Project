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
    class TaxTest
    {
        private const string _filePath = @"C:\SoftwareGuild\dotnet-nikolas-clay\Flooring Mastery Project\NewFlooring\Taxes.txt";
        private const string _originalFilePath = @"C:\SoftwareGuild\dotnet-nikolas-clay\Flooring Mastery Project\NewFlooring\SeedTaxes.txt";

        [SetUp]
        public void Setup()
        {
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }
            File.Copy(_originalFilePath, _filePath);
        }
        [Test]
        public void CanReadDataFromFile()
        {

            StateTaxRepo repo = new StateTaxRepo();

            List<StateTaxInfo> tax = repo.LoadTaxData();

            Assert.IsTrue(tax.Count > 0);

        }
    }
}

    
        