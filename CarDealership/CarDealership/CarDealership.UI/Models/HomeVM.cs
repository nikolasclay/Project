using CarDealership.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Models
{
    public class HomeVM
    {
        public IEnumerable<Vehicle> Vehicles { get; set; }

        public List<SelectListItem> FeaturedItems { get; set; }


        public HomeVM()
        {
            FeaturedItems = new List<SelectListItem>();
        }
    }
}