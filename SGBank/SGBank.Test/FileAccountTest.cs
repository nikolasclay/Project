using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGBank.Data;
using SGBank.Models;
using System.IO;

namespace SGBank.Test
{
    [TestFixture]
    public class FileAccountTest
    {
        private const string _filePath = @"C:\SoftwareGuild\dotnet-nikolas-clay\SGBank\Data\Accounts.txt";
        private const string _originalFilePath = @"C:\SoftwareGuild\dotnet-nikolas-clay\SGBank\Data\AccountsSeed.txt";

        [SetUp]
        public void Setup()
        {
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }
            File.Copy(_originalFilePath, _filePath);
        }
        [Test]
        public void CanReadDataFromFile()
        {
            FileAccountRepository repo = new FileAccountRepository();
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
