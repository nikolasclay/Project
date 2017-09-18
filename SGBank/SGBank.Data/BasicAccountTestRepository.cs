﻿using SGBank.Models;
using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Data
{
    public class BasicAccountTestRepository : IAccountRepository
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

        public BasicAccountTestRepository(Account account)
        {
            _account = account;
        }
    }
}
