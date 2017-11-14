using CarDealership.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Models
{
    public class AddVM
    {
        public Vehicle Vehicle { get; set; }
        public List<SelectListItem> Makes { get; set; }
        public List<SelectListItem> Models { get; set; }
        public List<SelectListItem> BodyStyles { get; set; }
        public List<SelectListItem> Transmission { get; set; }
        public List<SelectListItem> InteriorColors { get; set; }
        public List<SelectListItem> ExteriorColors { get; set; }
        public List<SelectListItem> PurchaseTypes { get; set; }
        public PurchaseType PurchaseType { get; set; }

        public AddVM()
        {
            Makes = new List<SelectListItem>();
            Models = new List<SelectListItem>();
            BodyStyles = new List<SelectListItem>();
            Transmission = new List<SelectListItem>();
            InteriorColors = new List<SelectListItem>();
            ExteriorColors = new List<SelectListItem>();
            PurchaseTypes = new List<SelectListItem>();
        }
        public void SetMakes(IEnumerable<VehicleMake> vehicleMake)
        {
            foreach(var make in vehicleMake)
            {
                Makes.Add(new SelectListItem()
                {
                    Value = make.VehicleMakeId.ToString(),
                    Text = make.Make
                });
            }
        }
        public void SetModels(IEnumerable<VehicleModel> vehicleModel)
        {
            foreach (var model in vehicleModel)
            {
                Models.Add(new SelectListItem()
                {
                    Value = model.VehicleModelId.ToString(),
                    Text = model.ModelType
                });
            }
        }
        public void SetStyles(IEnumerable<BodyStyle> bodyStyle)
        {
            foreach (var body in bodyStyle)
            {
                BodyStyles.Add(new SelectListItem()
                {
                    Value = body.BodyStyleId.ToString(),
                    Text = body.Description
                });
            }
        }
        public void SetInterior(IEnumerable<InteriorColor> interiorColor)
        {
            foreach (var color in interiorColor)
            {
                InteriorColors.Add(new SelectListItem()
                {
                    Value = color.InteriorColorId.ToString(),
                    Text = color.Description
                });
            }
        }
        public void SetExterior(IEnumerable<ExteriorColor> exteriorColor)
        {
            foreach (var ex in exteriorColor)
            {
                ExteriorColors.Add(new SelectListItem()
                {
                    Value = ex.ExteriorColorId.ToString(),
                    Text = ex.Description
                });
            }
        }
        public void SetTypes(IEnumerable<PurchaseType> purchaseType)
        {
            foreach(var p in purchaseType)
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