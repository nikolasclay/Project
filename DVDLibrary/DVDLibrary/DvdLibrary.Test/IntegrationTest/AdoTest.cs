using DVDLibrary.Data.ADO;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DvdLibrary.Test.IntegrationTest
{
    [TestFixture]
    public class AdoTest
    {
        [Test]
        public void CanLoadDvds()
        {
            var repo = new DvdRepositoryADO();

            var dvd = repo.GetAll();

            Assert.AreEqual(3, dvd.Count);
            Assert.AreEqual("True Hollywood Stories", dvd[0].Title);
        }
    }
}
