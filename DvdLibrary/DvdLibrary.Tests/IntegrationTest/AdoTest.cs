using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DvdLibrary.Data.ADO;
using DvdLibrary.Model;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SqlClient;

namespace DvdLibrary.Tests.IntegrationTest
{
    [TestFixture]
    public class AdoTest
    {
        [SetUp]
        public void Init()
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "DbReset";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
            
        [Test]
        public void CanLoadDvds()
        {
            var repo = new DvdRepositoryADO();

            var dvd = repo.GetAll();

            Assert.AreEqual(3, dvd.Count);
            Assert.AreEqual("True Hollywood Stories", dvd[0].Title);
        }
        [Test]
        public void GetDvdById()
        {
            var repo = new DvdRepositoryADO();

            var dvd = repo.GetDvdById(1);

            Assert.AreEqual("True Hollywood Stories", dvd.Title);
            Assert.AreEqual(2017, dvd.ReleaseYear);
            Assert.AreEqual("Charlie Murphy", dvd.DirectorName);
            Assert.AreEqual("R", dvd.RatingType);    
        }
        [Test]
        public void GetDvdByDirector()
        {
            var repo = new DvdRepositoryADO();

            List<Dvd> dvds = repo.GetDvdsbyDirector("Tron");

            Assert.AreEqual(3, dvds[0].DvdId);
            Assert.AreEqual("The Mad Real World", dvds[0].Title);
            Assert.AreEqual(2012, dvds[0].ReleaseYear);
            Assert.AreEqual("R", dvds[0].RatingType);
            
        }
        [Test]
        public void GetDvdByRating()
        {
            var repo = new DvdRepositoryADO();

            List<Dvd> dvds = repo.GetDvdsbyRating("R");

            Assert.AreEqual(3, dvds.Count);
        }
        [Test]
        public void GetDvdByTitle()
        {
            var repo = new DvdRepositoryADO();

            List<Dvd> dvds = repo.GetDvdsByTitle("East West Bowl");

            Assert.AreEqual(2, dvds[0].DvdId);
            Assert.AreEqual("Hingle McCringleberry", dvds[0].DirectorName);
        }
        [Test]
        public void CanAddDvd()
        {
            var repo = new DvdRepositoryADO();
            Dvd dvdAdd = new Dvd();

            dvdAdd.Title = "A Player Hater's Ball";
            dvdAdd.ReleaseYear = 1977;
            dvdAdd.DirectorName = "Silky Johnson";
            dvdAdd.RatingType = "G";
            dvdAdd.Notes = "The most diabolical haters this side of the Mississippi!";

            repo.AddDvd(dvdAdd);
            var newDvd = repo.GetDvdById(4);
            
            Assert.AreEqual("A Player Hater's Ball", newDvd.Title);
            Assert.AreEqual(1977, newDvd.ReleaseYear);
            Assert.AreEqual("Silky Johnson", newDvd.DirectorName);
            Assert.AreEqual("G", newDvd.RatingType);
        }
        [Test]
        public void CanDeleteDvd()
        {
            var repo = new DvdRepositoryADO();

            var preDelete = repo.GetAll();
            repo.DeleteDvd(3);

            var postDelete = repo.GetAll();

            Assert.AreEqual(preDelete.Count -1, postDelete.Count());
        }
        [Test]
        public void CanEditDvd()
        {
            var repo = new DvdRepositoryADO();

            //Dvd dvd = new Dvd();
            var preEdit = repo.GetDvdById(1);
            preEdit.Title = "Pimp Chronicles";
            preEdit.DirectorName = "Buck Nasty";

            repo.EditDvd(preEdit);

            var postEdit = repo.GetDvdById(1);

            Assert.AreEqual("Pimp Chronicles", postEdit.Title);
            Assert.AreEqual("Buck Nasty", postEdit.DirectorName);
        }
    }

}

