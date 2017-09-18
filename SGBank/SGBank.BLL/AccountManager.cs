using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawRules;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL
{
    public class AccountManager
    {
        private IAccountRepository _accountRepository;

        public AccountManager(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public AccountLookupResponse LookupAccount(string accountNumber)
        {
            AccountLookupResponse response = new AccountLookupResponse();

            response.Account = _accountRepository.LoadAccount(accountNumber);

            if (response.Account == null)
            {
                response.Success = false;
                response.Message = $"{accountNumber} is not a valid account.";
            }
            else
            {
                response.Success = true;
            }

            return response;
        }

        public AccountDepositResponse Deposit(string accountNumber, decimal amount)
        {
            AccountDepositResponse response = new AccountDepositResponse();

            response.Account = _accountRepository.LoadAccount(accountNumber);

            if (response.Account == null)
            {
                response.Success = false;
                response.Message = $"{accountNumber} is not a valid account.";
                return response;
            }
            else
            {
                response.Success = true;
            }

            IDeposit depositRule = DepositRulesFactory.Create(response.Account.Type);
            response = depositRule.Deposit(response.Account, amount);

            if (response.Success)
            {
                _accountRepository.SaveAccount(response.Account);
                SaveData(response.Account);
            }

            return response;
        }

        public AccountWithdrawResponse Withdraw(string accountNumber, decimal amount)
        {
            AccountWithdrawResponse response = new AccountWithdrawResponse();

            response.Account = _accountRepository.LoadAccount(accountNumber);

            if (response.Account == null)
            {
                response.Success = false;
                response.Message = $"{accountNumber} was not valid account number: ";
                return response;

            }
            else
            {
                response.Success = true;
            }

            IWithdraw withdrawRule = WithdrawRulesFactory.Create(response.Account.Type);
            response = withdrawRule.Withdraw(response.Account, amount);

            if (response.Success)
            {
                _accountRepository.SaveAccount(response.Account);
                SaveData(response.Account);
            }

            return response;
        }

        private static void SaveData(Account account)
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
