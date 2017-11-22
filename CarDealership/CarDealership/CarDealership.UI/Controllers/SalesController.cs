using CarDealership.Data;
using CarDealership.Data.Interface;
using CarDealership.Model;
using CarDealership.Model.Users;
using CarDealership.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    public class SalesController : Controller
    {
        ICarRepository _repo = CarFactory.Create();
        // GET: Sales
        public ActionResult Sales()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Purchase(int id)
        {
            var model = new PurchaseVM();
            model.VehicleId = id;
            return View(model);
        }
        [HttpPost]
        public ActionResult Purchase(PurchaseVM model)
        {
            var purchase = new Purchase();
            purchase.VehicleId = model.VehicleId;
            purchase.Customer = new Customer()
            {
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                Street1 = model.Street1,
                Street2 = model.Street2,
                City = model.City,
                State = model.State,
                ZipCode = model.Zipcode,
            };
            purchase.PurchaseDate = DateTime.Now;
            purchase.PurchasePrice = model.PurchasePrice;
            purchase.PurchaseType = model.PurchaseType;
            purchase.User = new AppUser()
            {
                UserName = User.Identity.Name,
            };
            _repo.AddPurchase(purchase);

            return RedirectToAction("Sales");

        }
    }
}