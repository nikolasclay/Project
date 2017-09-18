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
        public Account _account { get; private set; }

        public Account LoadAccount(string AccountNumber)
        {
            if (_account.AccountNumber != AccountNumber)
            {
                return null;
            }
            return _account;

        }

        public void SaveAccount(Account account)
        {
            _account = account;
        }

        public PremiumAccountTestRepository(Account account)
        {
            _account = account;
        }
    }
}
