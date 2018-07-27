using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PriceConfigurator.Model
{
    public class App
    {
        public int AppId { get; set; }
        public string Title { get; set; }
        public double CurrentPrice { get; set; }
        public double SuggestedPrice { get; set; }
        public string CsvUpload { get; set; }

    }
}
