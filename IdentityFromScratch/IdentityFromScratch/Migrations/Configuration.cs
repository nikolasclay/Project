namespace IdentityFromScratch.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IdentityFromScratch.ScratchDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(IdentityFromScratch.ScratchDBContext context)
        {
            var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!(roleManager.RoleExists("admin")))
            {
                roleManager.Create(new IdentityRole() { Name = "admin@thesoftwareguild.com" });
            }
            if (!(userManager.Users.Any(u => u.UserName == "admin@thesoftwareguild.com")))
            {
                var username = new IdentityUser()
                {
                    UserName = "admin@thesoftwareguild.com"
                };
                userManager.Create(username, "password123");
                //userManager.AddToRole(user.Id, "admin");

            }
            var user = userManager.FindByName("admin@thesoftwareguild.com"); 
            if (!(userManager.IsInRole(user.Id, "admin")))
            {
                userManager.AddToRole(user.Id, "admin");
            }
            

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
