using CarDealership.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Model
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public int PurchaseTypeId { get; set; }
        public int VehicleId { get; set; }
        public string UserId { get; set; }
        public int CustomerId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal PurchasePrice { get; set; }


        public virtual Vehicle Vehicle { get; set; }
        public virtual PurchaseType PurchaseType { get; set; }
        public virtual AppUser User{ get; set; }
        public virtual Customer Customer { get; set; }



    }
}
