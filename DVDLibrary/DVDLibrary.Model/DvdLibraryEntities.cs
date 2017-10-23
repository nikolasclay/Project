using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Model
{
    public class DvdLibraryEntities : DbContext
    {
        public DvdLibraryEntities()
            :base("DvdLibrary")
        {

        }

        public DbSet<Dvd> Dvds { get; set; }
    }
}
