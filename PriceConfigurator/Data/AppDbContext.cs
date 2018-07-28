using PriceConfigurator.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
            :base("PriceConfigurator")
        {
        }
        public DbSet<App> Apps { get; set; }
    }
}
