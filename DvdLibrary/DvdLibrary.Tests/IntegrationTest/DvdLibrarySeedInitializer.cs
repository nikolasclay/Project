using DvdLibrary.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Tests.IntegrationTest
{
    class DvdLibrarySeedInitializer : DropCreateDatabaseAlways<DvdLibraryEntities>
    {
        protected override void Seed(DvdLibrary.Model.DvdLibraryEntities context)
        {

            context.Dvds.AddOrUpdate(
            d => d.DvdId,
            new Dvd
            {
                DvdId = 1,
                Title = "True Hollywood Stories",
                ReleaseYear = 2017,
                DirectorName = "Charlie Murphy",
                RatingType = "R",
                Notes = "Game, blouses."
            },

            new Dvd
            {
                DvdId = 2,
                Title = "East West Bowl",
                ReleaseYear = 1999,
                DirectorName = "Hingle McCringleberry",
                RatingType = "R",
                Notes = "A movie so bad, it's good!"
            },
            new Dvd
            {
                DvdId = 3,
                Title = "The Mad Real World",
                ReleaseYear = 2012,
                DirectorName = "Tron",
                RatingType = "R",
                Notes = "Hot hand in the dice game, baby!"
            }
            );
            context.SaveChanges();
        }
    }
}
