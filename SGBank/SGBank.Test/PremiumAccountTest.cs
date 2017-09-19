using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGBank.Models.Interfaces;
using SGBank.Models;
using SGBank.Models.Responses;
using SGBank.BLL.WithdrawRules;
using SGBank.BLL.DepositRules;

namespace SGBank.Test
{
        [TestFixture]
        public class PremiumAccountTest
        {
        [TestCase("96789", "Premium Account", 500, AccountType.Premium, 1000, 1500, true)]
        [TestCase("96789", "Premium Account", 500, AccountType.Free, 100, 600, false)]
        [TestCase("96789", "Premium Account", 500, AccountType.Premium, 100, 600, true)]
        [TestCase("96789", "Premium Account", 500, AccountType.Premium, -50, 550, false)]
        [TestCase("96789", "Premium Account", 500, AccountType.Premium, 1, 501, true)]
        public void PremiumAccountDepositRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, decimal newBalance, bool expectedResult)
            {
                IDeposit deposit = new NoLimitDepositRule();
                Account account = new Account();
                {
                    account.AccountNumber = accountNumber;
                    account.Name = name;
                    account.Balance = balance;
                    account.Type = accountType;
                }
                AccountDepositResponse response = deposit.Deposit(account, amount);
                Assert.AreEqual(expectedResult, response.Success);
            if (response.Success)
            {
                Assert.AreEqual(newBalance, response.Account.Balance);
            }
            }
        [TestCase("96789", "Premium Account", 500, AccountType.Premium, -1000, -500, true)]
        [TestCase("96789", "Premium Account", 500, AccountType.Free, -500, 0, false)]
        [TestCase("96789", "Premium Account", 500, AccountType.Premium, -900, -400, true)]
        [TestCase("96789", "Premium Account", 500, AccountType.Premium, 500, 0, false)]
        [TestCase("96789", "Premium Account", 500, AccountType.Premium, -1100, -600, false)]
        public void PremiumWithdrawRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, decimal newBalance, bool expectedResult)
            {
                IWithdraw withdraw = new PremiumAccountWithdrawRule();
                Account account = new Account();
                {
                    account.AccountNumber = accountNumber;
                    account.Name = name;
                    account.Balance = balance;
                    account.Type = accountType;
                }
                AccountWithdrawResponse response = withdraw.Withdraw(account, amount);
                Assert.AreEqual(expectedResult, response.Success);
                if (response.Success)
                {
                    Assert.AreEqual(newBalance, response.Account.Balance);
                }
            }
        }
    }

