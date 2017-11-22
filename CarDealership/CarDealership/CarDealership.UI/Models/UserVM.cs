using CarDealership.Model;
using CarDealership.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Models
{
    public class UserVM
    {
        public AppUser User { get; set; }
        public List<SelectListItem> Roles { get; set; }

        public UserVM()
        {
            Roles = new List<SelectListItem>();
        }
        public void SetRoles(IEnumerable<AppUser> user)
        {
            foreach(var u in user)
            {
                Roles.Add(new SelectListItem()
                {
                    Value = u.Id.ToString(),
                    Text = u.Role
                });
            }
        }
    }
}