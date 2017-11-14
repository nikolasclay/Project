using CarDealership.Data;
using CarDealership.Data.Interface;
using CarDealership.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    
    public class AdminController : Controller
    {
        ICarRepository _repo = CarFactory.Create();
        // GET: Admin
        public ActionResult Admin()
        {
            return View();
        }
        public ActionResult Add()
        {
            var model = new AddVM();
            model.SetMakes(_repo.GetAllMakes());
            model.SetModels(_repo.GetAllModels());
            model.SetStyles(_repo.GetAllStyles());
            model.SetInterior(_repo.GetAllInterior());
            model.SetExterior(_repo.GetAllExterior());
            model.SetTypes(_repo.GetAllTypes());

            return View(model);
        }
        [HttpPost]
        public ActionResult Add(AddVM model)
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            var v = _repo.GetVehicleById(id);

            var model = new AddVM();

            return View(model);
        }
        public ActionResult AddMake()
        {
            return View();
        }
        public ActionResult AddModel()
        {
            return View();
        }
    }
}