using SGBank.Data;
using SGBank.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL
{
    public static class AccountManagerFactory
    {
        public static AccountManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
            string filePath = ConfigurationManager.AppSettings["FileLocation"].ToString();
            var accounts = LoadData(filePath);

            switch (mode)
            {
                case "FreeTest":
                    return new AccountManager(new FreeAccountTestRepository(accounts.First(c => c.Type == AccountType.Free)));
                case "BasicTest":
                    return new AccountManager(new BasicAccountTestRepository(accounts.First(c => c.Type == AccountType.Basic)));
                case "PremiumTest":
                    return new AccountManager(new PremiumAccountTestRepository(accounts.First(c => c.Type == AccountType.Premium)));
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }

        public static List<Account> LoadData(string filePath)
        {
            var lineContent = string.Empty;
            var accountList = new List<Account>();
            var isHeader = true;
            using (var streamReader = new StreamReader(filePath))
            {
                while (lineContent != null)
                {
                    lineContent = streamReader.ReadLine();

                    if (isHeader)
                    {
                        isHeader = false;
                        continue;
                    }

                    if (lineContent != null)
                    {
                        var contentArray = lineContent.Split(',');
                        AccountType type = AccountType.Basic;
                        switch (contentArray[3].ToUpper())
                        {
                            case "F":
                                type = AccountType.Free;
                                break;
                            case "B":
                                type = AccountType.Basic;
                                break;
                            case "P":
                                type = AccountType.Premium;
                                break;
                        }
                        accountList.Add(new Account()
                        {
                            Name = contentArray[1],
                            AccountNumber = contentArray[0],
                            Balance = decimal.Parse(contentArray[2]),
                            Type = type,
                        });
                    }
                }
            }
            return accountList;
        }
    }
}
