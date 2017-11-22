using CarDealership.Model;
using CarDealership.Model.Users;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.DBContext
{
    public class VehicleDbContext : IdentityDbContext<AppUser>
    {
        public VehicleDbContext() : base("GuildCars")
        {

        }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseType> PurchaseTypes { get; set; }
        public DbSet<Special> Specials { get; set; }
        public DbSet<InteriorColor> InteriorColors { get; set; }
        public DbSet<ExteriorColor> ExteriorColors { get; set; }
        public DbSet<BodyStyle> BodyStyles { get; set; }
    }
}
