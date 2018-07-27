namespace Data.Migrations
{
    using PriceConfigurator.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Apps.AddOrUpdate(a => a.AppId,
            new App { Title = "Fan Duel", CurrentPrice = 1.99, },
            new App { Title = "Wall Street Journal", CurrentPrice = 2.50 },
            new App { Title = "ESPN", CurrentPrice = .99 },
            new App { Title = "Facebook", CurrentPrice = 2.99 });
            context.SaveChanges();
        }
    }
}
