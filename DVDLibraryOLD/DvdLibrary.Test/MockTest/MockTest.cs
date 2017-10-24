using DvdLibrary.Data.Mock;
using DVDLibrary.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Test.MockTest
{
    [TestFixture]
    public class MockTest
    {
        [Test]
        public void GetAllDvds()
        {
            var repo = new MockDvdRepository();

            var dvd = repo.GetAll();

            Assert.AreEqual(3, dvd.Count);
        }

        [Test]
        public void GetDvdById()
        {
            var repo = new MockDvdRepository();

            var dvd = repo.GetDvdById(2);

            Assert.AreEqual(2, dvd.DvdId);
        }

        [Test]
        public void GetDvdByTitle()
        {
            var repo = new MockDvdRepository();

            var dvd = repo.GetDvdsByTitle("True Hollywood Stories");

            Assert.AreEqual("True Hollywood Stories", dvd[0].Title);
        }
        [Test]
        public void GetDvdbyRating()
        {
            var repo = new MockDvdRepository();

            var dvd = repo.GetDvdsbyRating("R");

            Assert.AreEqual("R", dvd[0].RatingType);

        }
        [Test]
        public void GetDvdByReleaseYear()
        {
            var repo = new MockDvdRepository();

            var dvd = repo.GetDvdsByReleaseYear(2012);

            Assert.AreEqual(2012, dvd[0].ReleaseYear);
        }

        [Test]
        public void AddDvd()
        {
            var repo = new MockDvdRepository();

            //var preAdd = repo.GetAll();

            Dvd dvdAdd = new Dvd();

            dvdAdd.Title = "Making the Band";
            dvdAdd.ReleaseYear = 2000;
            dvdAdd.DirectorName = "Dylan";
            dvdAdd.RatingType = "PG";
            dvdAdd.Notes = "I spit hot fire!";

            repo.AddDvd(dvdAdd);

            //var postAdd = repo.GetAll();
            //Assert.AreEqual(preAdd.Count + 1, postAdd.Count);

            var dvd = repo.GetDvdById(4);
            Assert.AreEqual("Making the Band", dvd.Title);
            Assert.AreEqual(2000, dvd.ReleaseYear);
            Assert.AreEqual("Dylan", dvd.DirectorName);
            Assert.AreEqual("PG", dvd.RatingType);
            Assert.AreEqual("I spit hot fire!", dvd.Notes);
        }

        [Test]
        public void EditDvd()
        {
            var repo = new MockDvdRepository();

            Dvd editDvd = new Dvd();
            editDvd.DvdId = 4;
            editDvd.Title = "When Keeping It Real Goes Wrong";
            editDvd.ReleaseYear = 2013;
            editDvd.DirectorName = "Tyrone Biggums";
            editDvd.RatingType = "G";
            editDvd.Notes = "It always goes wrong.";

            repo.EditDvd(editDvd);

            var dvdToEdit = repo.GetDvdById(4);
            Assert.AreEqual("Tyrone Biggums", dvdToEdit.DirectorName);
        }
        [Test]
        public void DeleteDvd()
        {
            var repo = new MockDvdRepository();

            repo.DeleteDvd(1);

            Assert.AreEqual(3, repo.GetAll().Count);


            
        }
    }
}

