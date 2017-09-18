using SGBank.Models.Interfaces;
using System;
using SGBank.Models;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace SGBank.Data
{
    public class FileAccountRepository : IAccountRepository
    {
        public Account _account { private get; set; }
  
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
        public FileAccountRepository(Account account)
        {
            _account = account;
        }
    }
}

