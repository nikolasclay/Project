using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;

namespace SGBank.Data
{
    public class PremiumAccountTestRepository : IAccountRepository
    {
        private static Account _account = new Account
        {
            Name = "Premium Account",
            Balance = 500M,
            AccountNumber = "96789",
            Type = AccountType.Premium
        };
        public Account LoadAccount(string AccountNumber)
        {
            if (_account.AccountNumber == AccountNumber)
            {
                return _account;
            }
            else
            {
                return null;
            }
        }
        public void SaveAccount(Account account)
        {
            _account = account;
        }
    }
}
