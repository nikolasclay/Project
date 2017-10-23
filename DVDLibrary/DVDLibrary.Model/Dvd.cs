using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Model
{
    public class Dvd
    {
        public int DvdId { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Directors { get; set; }
        public string Ratings { get; set; }
        public string Notes { get; set; }
    }
}
