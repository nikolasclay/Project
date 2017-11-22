using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarDealership.Data.Interface;
using CarDealership.Data;
using CarDealership.UI.Models;
using CarDealership.Model.Users;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using CarDealership.Model;

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
            return View(new Contact());
        }
        [HttpPost]
        public ActionResult Contact(Contact model)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                ModelState.AddModelError("Name", "Name is required.");
            }
            else if(string.IsNullOrEmpty(model.Email))
            {
                ModelState.AddModelError("Email", "Email is required.");
            }
            else if (string.IsNullOrEmpty(model.Phone))
            {
                ModelState.AddModelError("Phone", "Phone number is required.");
            }
            else if (string.IsNullOrEmpty(model.Message))
            {
                ModelState.AddModelError("Message", "Message is required.");
                
            }
            ModelState.AddModelError("Contact", "Cannot add the contact");
            return View(model);
        }

    }
}
