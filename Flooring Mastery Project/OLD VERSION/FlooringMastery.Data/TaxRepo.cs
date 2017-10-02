using NewFlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewFlooringMastery.Models;
using System.IO;

namespace NewFlooringMastery.Data
{
    public class TaxRepo : ITaxRepo
    {
        private const string _filePath = @"C:\SoftwareGuild\dotnet-nikolas-clay\Flooring Mastery Project\Products.txt";
        Dictionary<string, TaxInfo> taxCollection;

        public TaxRepo()
        {
            taxCollection = LoadTaxData().ToDictionary(t => t.StateAbbreviation);
        }

        private List<TaxInfo> LoadTaxData()
        {
            List<TaxInfo> dataLoad = new List<TaxInfo>();
            try
            {
                using (StreamReader sr = new StreamReader(_filePath))
                {
                    sr.ReadLine();
                    string line = String.Empty;

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] columns = line.Split(',');
                        TaxInfo taxInfo = new TaxInfo();

                        taxInfo.StateAbbreviation = columns[0];
                        taxInfo.StateName = columns[1];
                        taxInfo.TaxRate = decimal.Parse(columns[2]);

                        dataLoad.Add(taxInfo);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dataLoad;
        }

        public StateName GetStateName(string stateName)
        {
            throw new NotImplementedException();
        }

        public TaxInfo LoadTaxForState(string taxInfo)
        {
            if (taxCollection.ContainsKey(taxInfo))
            {
                return taxCollection[taxInfo];
            }
            else
            {
                return null;
            }
        }
    }
}
