using DvdLibrary.Data.EF;
using DvdLibrary.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Tests.IntegrationTest
{
    //[TestFixture]
    //public class EFTest
    //{
    //    [SetUp]
    //    public void resetDbFile()
    //    {
    //        Database.SetInitializer(new DvdLibrarySeedInitializer());
    //    }
    //    [Test]
    //    public void GetallDvds()
    //    {
    //        var repo = new DvdRepositoryEF();

    //        var allDvds = repo.GetAll();

    //        Assert.AreEqual(3, allDvds.Count);
    //    }
    //    [Test]
    //    public void CanAddDvd()
    //    {
    //        var repo = new DvdRepositoryEF();

    //        var preAdd = repo.GetAll();

    //        Dvd newDvd = new Dvd();
    //        newDvd.Title = "A Player Hater's Ball";
    //        newDvd.ReleaseYear = 1977;
    //        newDvd.DirectorName = "Silky Johnson";
    //        newDvd.RatingType = "G";
    //        newDvd.Notes = "The most diabolical haters this side of the Mississippi!";

    //        repo.AddDvd(newDvd);

    //        var postAdd = repo.GetAll();

    //        Assert.AreEqual(preAdd.Count + 1, postAdd.Count);
    //    }
    //}
}
