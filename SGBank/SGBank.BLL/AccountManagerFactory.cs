﻿using SGBank.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL
{
    //A Factory class sole purpose is to instantiate objets that require setup(like dependency injection)
    public static class AccountManagerFactory
    {
        public static AccountManager Create()
        {
            //AppSettings is a dictionary
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
            
            switch (mode)
            {
                case "FreeTest":
                    return new AccountManager(new FreeAccountTestRepository());
                case "BasicTest":
                    return new AccountManager(new BasicAccountTestRepository());
                case "PremiumTest":
                    return new AccountManager(new PremiumAccountTestRepository());
                case "FileAccount":
                    return new AccountManager(new FileAccountTestRepository());
                default:
                    throw new Exception("Mode value in app config is not valid.");
            }
        }
    }
}
