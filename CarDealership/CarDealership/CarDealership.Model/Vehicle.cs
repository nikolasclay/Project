using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Model
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public int VehicleMakeId { get; set; }
        public int VehicleModelId { get; set; }
        public int BodyStyleId { get; set; }
        public int ExteriorColorId { get; set; }
        public int InteriorColorId { get; set; }
        public string VIN { get; set; }
        public bool New { get; set; }
        public int Year { get; set; }
        public decimal MSRP { get; set; }
        public decimal SalePrice { get; set; }
        public int Mileage { get; set; }
        public bool Feature { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Transmission { get; set; }

        public virtual VehicleModel VehicleModel { get; set; }
        public virtual BodyStyle BodyStyle { get; set; }
        public virtual InteriorColor InteriorColor { get; set; }
        public virtual ExteriorColor ExteriorColor { get; set; }


    }
}
