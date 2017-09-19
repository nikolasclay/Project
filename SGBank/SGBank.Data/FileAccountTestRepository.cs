using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using SGBank.Models;
using System.IO;
using System.Configuration;

namespace SGBank.Data
{

    public class FileAccountTestRepository : IAccountRepository
    {

        
        string filePath = @"C:\SoftwareGuild\dotnet-nikolas-clay\SGBank\Data\Accounts.txt";
       
        public List<Account> GetData()
        {
            List<Account> DataLoad = new List<Account>();
            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException();
                }
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine("Your file was not found!");
            }
            using (StreamReader sr = new StreamReader(filePath))
            {
                
                string lineContent = sr.ReadLine();
                while ((lineContent = sr.ReadLine()) != null)
                {
                    Account account = new Account();
                    string[] columns = lineContent.Split(',');


                    account.AccountNumber = columns[0];
                    account.Name = columns[1];
                    account.Balance = decimal.Parse(columns[2]);

                    switch (columns[3].ToUpper())
                    {
                        case "F":
                            account.Type = AccountType.Free;
                            break;
                        case "B":
                            account.Type = AccountType.Basic;
                            break;
                        case "P":
                            account.Type = AccountType.Premium;
                            break;
                        default:
                            throw new Exception("That account type does not exist!");
                    }
                    DataLoad.Add(account);

                }
                return DataLoad;
            }
        }
        public Account LoadAccount(string AccountNumber)
        {
            var AccountLoad = GetData();
            var Loading = AccountLoad.SingleOrDefault(l => l.AccountNumber == AccountNumber);

            return Loading;
        }

        public void SaveAccount(Account account)
        {
            var filePath = ConfigurationManager.AppSettings["FileLocation"].ToString();
            var lineContent = string.Empty;
            var contentLine = File.ReadLines(filePath).ToList();

            for (var lineNumber = 1; lineNumber < contentLine.Count(); lineNumber++)
            {
                var lineArray = contentLine[lineNumber].Split(',');
                if (lineArray[0] == account.AccountNumber)
                {
                    lineArray[2] = account.Balance.ToString();
                    contentLine[lineNumber] = lineArray[0] + "," + lineArray[1] + "," + lineArray[2] + "," + lineArray[3];
                    break;
                }
            }

            File.WriteAllLines(filePath, contentLine.ToArray());
        }
    }
}

