using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Model
{
    public class VehicleModel
    {
        public int VehicleModelId { get; set; }
        public int VehicleMakeId { get; set; }
        public string ModelType { get; set; }
        public int UserId { get; set; }
        public DateTime Added { get; set; }

        public virtual VehicleMake VehicleMake { get; set; }
        public virtual User User { get; set; }
    }
}
