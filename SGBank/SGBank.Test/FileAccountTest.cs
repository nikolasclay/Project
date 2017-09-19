using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGBank.Data;
using SGBank.Models;

namespace SGBank.Test
{
    [TestFixture]
    public class FileAccountTest
    {
        [Test]
        public void CanReadDataFromFile()
        {
            FileAccountTestRepository repo = new FileAccountTestRepository();
            List<Account> account = repo.GetData();

            Assert.AreEqual(3, account.Count());

            Account check = account[2];

            Assert.AreEqual("33333", check.AccountNumber);
            Assert.AreEqual("Premium Customer", check.Name);
            Assert.AreEqual(1000, check.Balance);
            Assert.AreEqual(AccountType.Premium, AccountType.Premium);
        }
    }
}
