using CarDealership.Data;
using CarDealership.Data.Interface;
using CarDealership.Model;
using CarDealership.UI.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
            var model = new VehicleVM();
            model.SetMakes(_repo.GetAllMakes());
            model.SetModels(_repo.GetAllModels());
            model.SetStyles(_repo.GetAllStyles());
            model.SetInterior(_repo.GetAllInterior());
            model.SetExterior(_repo.GetAllExterior());
            model.SetTypes(_repo.GetAllTypes());

            return View(model);
        }
        [HttpPost]
        public ActionResult Add(VehicleVM model)
        {

            if (ModelState.IsValid)
            {
                Vehicle newVehicle = new Vehicle();
                {
                    newVehicle.BodyStyleId= model.BodyStyleId;
                    newVehicle.VehicleModelId = model.VehicleModelId;
                    newVehicle.VehicleMakeId = model.VehicleMakeId;
                    newVehicle.ExteriorColorId = model.ExteriorColorId;
                    newVehicle.InteriorColorId = model.InteriorColorId;
                    newVehicle.Transmission = model.Transmission;
                    newVehicle.Feature = model.Feature;
                    if (ModelState.IsValid)
                    {
                        if(model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
                        {
                            string path = Path.Combine(Server.MapPath("~/Content/img"),
                                Path.GetFileName(model.ImageUpload.FileName));

                            model.ImageUpload.SaveAs(path);
                        }
                    }
                    newVehicle.Image = model.Image;
                    newVehicle.Mileage = model.Mileage;
                    newVehicle.MSRP = model.MSRP;
                    newVehicle.New = model.New;
                    newVehicle.SalePrice = model.SalePrice;
                    newVehicle.VIN = model.VIN;
                    newVehicle.Year = model.Year;
                }
                _repo.AddVehicle(newVehicle);
            }
            return RedirectToAction("Admin");

        }
        [HttpGet]       
        public ActionResult Edit(int id)
        {
            //var vehicle = _repo.GetVehicleById(id);
            var model = new VehicleVM();

            model.SetMakes(_repo.GetAllMakes());
            model.SetModels(_repo.GetAllModels());
            model.SetStyles(_repo.GetAllStyles());
            model.SetInterior(_repo.GetAllInterior());
            model.SetExterior(_repo.GetAllExterior());
            model.SetTypes(_repo.GetAllTypes());
            model.Vehicle = _repo.GetVehicleById(id);

            return View(model);
        }
        public ActionResult AddMake()
        {
            return View(new VehicleMake());
        }
        public ActionResult AddModel()
        {
            var model = new VehicleVM();
            return View(model);
        }
        public ActionResult Users()
        {
            var model = _repo.GetAllUsers();
            return View(model);
        }
        public ActionResult AddUser()
        {
            var model = new UserVM();
            model.SetRoles(_repo.GetAllUsers());
            return View(model);
        }
        public ActionResult EditUser()
        {
            return View();
        }
        public ActionResult Reports()
        {
            return View();
        }
        public ActionResult AddSpecial()
        {
            return View();
        }
    }
}