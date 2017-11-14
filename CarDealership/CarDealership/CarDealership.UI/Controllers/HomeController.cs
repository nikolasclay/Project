using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarDealership.Data.Interface;
using CarDealership.Data;
using CarDealership.UI.Models;

namespace CarDealership.UI.Controllers
{
    public class HomeController : Controller
    {
        ICarRepository _repo = CarFactory.Create();
        public ActionResult Index()
        {

            var viewModel = new HomeVM();
            viewModel.Vehicles = _repo.GetAll();
            return View(viewModel);
        }
        [HttpGet]
        public ActionResult New()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Used()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Special()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }
    }
}
