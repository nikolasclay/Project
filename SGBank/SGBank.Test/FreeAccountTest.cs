using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGBank.BLL;
using SGBank.Models.Responses;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawRules;

namespace SGBank.Test
{

    [TestFixture]
    public class FreeAccountTest
    {
        [Test]
        public void CanLoadFreeAccountTestData()
        {
            AccountManager manager = AccountManagerFactory.Create();

            AccountLookupResponse response = manager.LookupAccount("");

            Assert.IsNotNull(response.Account);
            Assert.IsTrue(response.Success);
            Assert.AreEqual("12345", response.Account.AccountNumber);
        }
        [TestCase("12345","Free Account", 100.00, AccountType.Free, 250.00, false)]
        [TestCase("12345", "Free Account", 100.00, AccountType.Free, -100.00, false)]
        [TestCase("12345", "Free Account", 100.00, AccountType.Basic, 50.00, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Free, 50.00, true)]
        public void FreeAccountDepositRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, bool expected)
        {
            IDeposit deposit = new FreeAccountDepositRule();
            Account account = new Account();
            {
                account.AccountNumber = accountNumber;
                account.Name = name;
                account.Balance = balance;
                account.Type = accountType;
            }

            AccountDepositResponse response = deposit.Deposit(account, amount);
            Assert.AreEqual(expected, response.Success);
            if (response.Success)
            {
                Assert.AreEqual(response.OldBalance += amount, response.Account.Balance);
            }


        }
        [TestCase("12345", "Free Account", 100.00, AccountType.Free, 50.00, false)]
        [TestCase("12345", "Free Account", 100.00, AccountType.Free, -150.00, false)]
        [TestCase("12345", "Free Account", 100.00, AccountType.Basic, -100.00, false)]
        [TestCase("12345", "Free Account", 100.00, AccountType.Free, -101.00, false)]
        [TestCase("12345", "Free Account", 100.00, AccountType.Free, -50.00, true)]
        public void FreeAccountWithdrawRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, bool expected)
        {
            IWithdraw withdraw = new FreeAccountWithdrawRule();
            Account account = new Account();
            {
                account.AccountNumber = accountNumber;
                account.Name = name;
                account.Balance = balance;
                account.Type = accountType;

            }
            AccountWithdrawResponse response = withdraw.Withdraw(account, amount);
            Assert.AreEqual(expected, response.Success);
            if (response.Success)
            {
                Assert.AreEqual(response.OldBalance += amount, response.Account.Balance);
            }
        }
    }
}
