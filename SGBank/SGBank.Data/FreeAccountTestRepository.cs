using SGBank.Models.Interfaces;
using SGBank.Models;

namespace SGBank.Data
{
    public class FreeAccountTestRepository : IAccountRepository
    {
        public Account _account { private get; set; }

        public Account LoadAccount(string AccountNumber)
        {
            if(_account.AccountNumber != AccountNumber)
            {
                return null;
            }
                return _account;

        }

        public void SaveAccount(Account account)
        {
            _account = account;
        }

        public FreeAccountTestRepository(Account account)
        {
            _account = account;
        }
    }
}
