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
    public class StateTaxRepo : ITaxRepo
    {
        private const string _filePath = @"C:\SoftwareGuild\dotnet-nikolas-clay\Flooring Mastery Project\NewFlooring\Taxes.txt";
        Dictionary<string, StateTaxInfo> taxCollection;

        public StateTaxRepo()
        {
            taxCollection = LoadTaxData().ToDictionary(t => t.StateAbbreviation);
        }

        public List<StateTaxInfo> LoadTaxData()
        {
            List<StateTaxInfo> dataLoad = new List<StateTaxInfo>();
            try
            {
                using (StreamReader sr = new StreamReader(_filePath))
                {
                    sr.ReadLine();
                    string line = String.Empty;

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] columns = line.Split(',');

                        StateTaxInfo stateTaxInfo = new StateTaxInfo();

                        stateTaxInfo.StateAbbreviation = columns[0];
                        stateTaxInfo.StateName = columns[1];
                        stateTaxInfo.TaxRate = decimal.Parse(columns[2]);

                        dataLoad.Add(stateTaxInfo);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dataLoad;
        }

        public StateTaxInfo LoadTaxForState(string stateTaxInfo)
        {
            if (taxCollection.ContainsKey(stateTaxInfo))
            {
                return taxCollection[stateTaxInfo];
            }
            else
            {
                return null;
            }
        }
    }
}
