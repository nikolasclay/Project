using IdentityFromScratch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace IdentityFromScratch.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login(string returnUrl)
        {
            var model = new LoginModel
            {
                ReturnUrl = returnUrl
            };
            
            return View(model);
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (!(ModelState.IsValid))
            {
                return View(model);
            }
           //if(model.Email == "admin@thesoftwareguild.com" && model.Password == "password123")
           // {
           //     var identity = new ClaimsIdentity(new[]
           //     {
           //         new Claim(ClaimTypes.Name, "Bob"),
           //         new Claim(ClaimTypes.Email, "admin@thesoftwareguild.com"),
           //         new Claim(ClaimTypes.Country, "USA")
           //     },
           //     "ApplicationCookie");

            var ctx = HttpContext.GetOwinContext();
            var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<IdentityUser>>();
            var user = userManager.Find(model.Email, model.Password);
            var authMgr = ctx.Authentication;
            if (user == null)
            {
            ModelState.AddModelError("", "invalid user name and password.");
            return View(model);
            }
            else
            {
                var identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                authMgr.SignIn(identity);
                if (string.IsNullOrEmpty(model.ReturnUrl) || !Url.IsLocalUrl(model.ReturnUrl))
                {
                    return Redirect(Url.Action("Index", "Home"));
                }
                return Redirect(model.ReturnUrl);
            }

        }
        [HttpGet]
        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authMgr = ctx.Authentication;

            authMgr.SignOut("ApplicationCookie");
            return RedirectToAction("Login");
        }
        
    }
}