using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TipCalculator.Models;

namespace TipCalculator.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Tip(decimal amount, decimal percentage)
        {
            var model = new Calculation();

            model.Amount = amount;
            model.Percentage = percentage;

            return View("Tip", model);
        }
    }
}
