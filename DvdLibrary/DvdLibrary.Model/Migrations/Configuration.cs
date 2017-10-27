namespace DvdLibrary.Model.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DvdLibrary.Model.DvdLibraryEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

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
