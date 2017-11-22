namespace CarDealership.Data.Migrations
{
    using CarDealership.Model.Users;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarDealership.Data.DBContext.VehicleDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CarDealership.Data.DBContext.VehicleDbContext context)
        {
            var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(context));
            var roleMgr = new RoleManager<AppRole>(new RoleStore<AppRole>(context));

            if (roleMgr.RoleExists("admin"))
                return;

            roleMgr.Create(new AppRole() { Name = "admin" });

            var user = new AppUser()
            {
                UserName = "admin"
            };

            userMgr.Create(user, "testing123");
            userMgr.AddToRole(user.Id, "admin");

            if (roleMgr.RoleExists("sales"))
                return;

            roleMgr.Create(new AppRole() { Name = "sales" });

            var role = new AppUser()
            {
                UserName = "sales"
            };

            userMgr.Create(role, "password123");
            userMgr.AddToRole(role.Id, "sales");
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
