using PriceConfigurator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PriceConfigurator.Models
{
    public class AppVM
    {
        //public int AppId { get; set; }
        //public string Title { get; set; }
        //public double CurrentPrice { get; set; }
        //public double SuggestedPrice { get; set; }
        public HttpPostedFileBase CsvUpload { get; set; }
        public App App { get; set; }

        public IEnumerable<App> Apps { get; set; }
    }
}