using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Models.Interfaces
{
    public interface IAccountRepository
    {
        //should take an action to load an account
        Account LoadAccount(string AccountNumber);

        //should take an action to save an account
        void SaveAccount(Account account);
    }
}
