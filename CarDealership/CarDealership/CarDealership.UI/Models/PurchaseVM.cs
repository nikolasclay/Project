using CarDealership.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Models
{
    public class PurchaseVM
    {
        public int VehicleId { get; set; }
        [Required(ErrorMessage = "A name is required", AllowEmptyStrings = false)]
        public string Name { get; set; }
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$", ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Street is required", AllowEmptyStrings = false)]
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        [Required(ErrorMessage ="Phone number is required", AllowEmptyStrings = false)]
        public string Phone { get; set; }
        [Required(ErrorMessage ="City is required.", AllowEmptyStrings = false)]
        public string City { get; set; }
        [Required(ErrorMessage ="Zipcode is required.", AllowEmptyStrings = false)]
        public int Zipcode { get; set; }
        [Required(ErrorMessage ="State is required.", AllowEmptyStrings = false)]
        public string State { get; set; }
        [Required(ErrorMessage ="You must enter a purchase price.", AllowEmptyStrings = false)]
        public int PurchasePrice { get; set; }
        [Required(ErrorMessage = "You must select a purchase type.", AllowEmptyStrings = false)]

        public PurchaseType PurchaseType { get; set; }


        public List<SelectListItem> PurchaseTypes { get; set; }

        public PurchaseVM()
        {
            PurchaseTypes = new List<SelectListItem>();
        }

        public void SetTypes(IEnumerable<PurchaseType> purchaseType)
        {
            foreach (var p in purchaseType)
            {
                PurchaseTypes.Add(new SelectListItem()
                {
                    Value = p.PurchaseTypeId.ToString(),
                    Text = p.Description
                });
            }
        }

    }
}