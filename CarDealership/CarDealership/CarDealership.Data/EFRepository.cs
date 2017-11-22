using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Model;
using System.Data.Entity;
using CarDealership.Data.Interface;
using CarDealership.Model.Queries;
using System.Data.SqlClient;
using CarDealership.Model.Users;
using CarDealership.Data.DBContext;

namespace CarDealership.Data
{
    public class EFRepository : ICarRepository
    {
        VehicleDbContext _ctx = new VehicleDbContext();
        public void AddContact(Contact contact)
        {
            if (_ctx.Contacts.Count() == 0)
            {
                contact.ContactId = 1;
            }
            else
            {
                var maxID = _ctx.Contacts.Max(c => c.ContactId);
                contact.ContactId = maxID + 1;
            }
            _ctx.Contacts.Add(contact);
            _ctx.SaveChanges();

        }

        public void AddMake(VehicleMake make)
        {
            if (_ctx.VehicleMakes.Count() == 0)
            {
                make.VehicleMakeId = 1;
            }
            else
            {
                var maxID = _ctx.VehicleMakes.Max(c => c.VehicleMakeId);
                make.VehicleMakeId = maxID + 1;
            }
            _ctx.VehicleMakes.Add(make);
            _ctx.SaveChanges();
        }

        public void AddModel(VehicleModel model)
        {
            if (_ctx.VehicleModels.Count() == 0)
            {
                model.VehicleModelId = 1;
            }
            else
            {
                var maxID = _ctx.VehicleModels.Max(c => c.VehicleModelId);
                model.VehicleModelId = maxID + 1;
            }
            _ctx.VehicleModels.Add(model);
            _ctx.SaveChanges();
        }

        public void AddPurchase(Purchase purchase)
        {
            if (_ctx.Purchases.Count() == 0)
            {
                purchase.PurchaseId = 1;
            }
            else
            {
                var maxID = _ctx.Purchases.Max(c => c.PurchaseId);
                purchase.PurchaseId = maxID + 1;
            }
            _ctx.Purchases.Add(purchase);
            _ctx.SaveChanges();
        }

        public void AddSpecial(Special special)
        {
            if (_ctx.Specials.Count() == 0)
            {
                special.SpecialId = 1;
            }
            else
            {
                var maxID = _ctx.Specials.Max(c => c.SpecialId);
                special.SpecialId = maxID + 1;
            }
            _ctx.Specials.Add(special);
            _ctx.SaveChanges();
        }

        public void AddUser(AppUser user)
        {
            if (_ctx.Users.Count() == 0)
            {
                user.Id = "1";
            }
            else
            {
                var maxID = _ctx.Users.Max(c => c.Id);
                user.Id = maxID + "1";
            }
            _ctx.Users.Add(user);
            _ctx.SaveChanges();
        }

        public void AddVehicle(Vehicle vehicle)
        {
            if (_ctx.Vehicles.Count() == 0)
            {
                vehicle.VehicleId = 1;
            }
            else
            {
                var maxID = _ctx.Vehicles.Max(c => c.VehicleId);
                vehicle.VehicleId = maxID + 1;
            }
            _ctx.Vehicles.Add(vehicle);
            _ctx.SaveChanges();
        }

        public void CanAddColor(InteriorColor interior)
        {
            throw new NotImplementedException();
        }

        public void CanAddExteriorColor(ExteriorColor exterior)
        {
            throw new NotImplementedException();
        }

        public void CanDeleteColor(InteriorColor interior)
        {
            throw new NotImplementedException();
        }

        public void CanDeleteExterior(ExteriorColor exterior)
        {
            throw new NotImplementedException();
        }

        public void DeleteContact(int id)
        {
            Contact c = _ctx.Contacts.Find(id);
            _ctx.Contacts.Remove(c);
            _ctx.SaveChanges();
        }

        public void DeleteMake(int id)
        {
            VehicleMake m = _ctx.VehicleMakes.Find(id);
            _ctx.VehicleMakes.Remove(m);
            _ctx.SaveChanges();
        }

        public void DeleteModel(int id)
        {
            VehicleModel m = _ctx.VehicleModels.Find(id);
            _ctx.VehicleModels.Remove(m);
            _ctx.SaveChanges();
        }

        public void DeletePurchase(int id)
        {
            Purchase p = _ctx.Purchases.Find(id);
            _ctx.Purchases.Remove(p);
            _ctx.SaveChanges();
        }

        public void DeleteSpecial(int id)
        {
            Special s = _ctx.Specials.Find(id);
            _ctx.Specials.Remove(s);
            _ctx.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            AppUser u = _ctx.Users.Find(id);
            _ctx.Users.Remove(u);
            _ctx.SaveChanges();
        }

        public void DeleteVehicle(int id)
        {
            Vehicle v = _ctx.Vehicles.Find(id);
            _ctx.Vehicles.Remove(v);
            _ctx.SaveChanges();
        }

        public void EditContact(Contact contact)
        {
            _ctx.Entry(contact).State = EntityState.Modified;
        }

        public void EditMake(VehicleMake make)
        {
            _ctx.Entry(make).State = EntityState.Modified;
        }

        public void EditModel(VehicleModel model)
        {
            _ctx.Entry(model).State = EntityState.Modified;
        }

        public void EditPurchase(Purchase purchase)
        {
            _ctx.Entry(purchase).State = EntityState.Modified;
        }

        public void EditUser(AppUser user)
        {
            _ctx.Entry(user).State = EntityState.Modified;
        }

        public void EditVehicle(Vehicle vehicle)
        {
            _ctx.Entry(vehicle).State = EntityState.Modified;
        }

        public List<Vehicle> GetAll()
        {
            return _ctx.Vehicles.ToList();
        }

        public List<Contact> GetAllContacts()
        {
            return _ctx.Contacts.ToList();
        }

        public List<ExteriorColor> GetAllExterior()
        {
            return _ctx.ExteriorColors.ToList();
        }

        public List<Vehicle> GetAllFeatured()
        {
            return _ctx.Vehicles.Where(v => v.Feature == true).ToList();
        }

        public List<InteriorColor> GetAllInterior()
        {
            return _ctx.InteriorColors.ToList();
        }

        public List<VehicleMake> GetAllMakes()
        {
            return _ctx.VehicleMakes.ToList();
        }

        public List<VehicleModel> GetAllModels()
        {
            return _ctx.VehicleModels.ToList();
        }

        public List<Vehicle> GetAllNew()
        {
            return _ctx.Vehicles.Where(v => v.New == true).ToList();
        }

        public List<Special> GetAllSpecials()
        {
            return _ctx.Specials.ToList();
        }

        public List<BodyStyle> GetAllStyles()
        {
            return _ctx.BodyStyles.ToList();
        }

        public List<PurchaseType> GetAllTypes()
        {
            return _ctx.PurchaseTypes.ToList();
        }

        public List<Vehicle> GetAllUsed()
        {
            return _ctx.Vehicles.Where(v => v.New == false).ToList();
        }

        public List<AppUser> GetAllUsers()
        {
            return _ctx.Users.ToList();
        }

        public List<Vehicle> GetByYear(int year)
        {
            return _ctx.Vehicles.Where(v => v.Year == year).ToList();
        }

        public VehicleMake GetMakeById(int id)
        {
            return _ctx.VehicleMakes.FirstOrDefault(m => m.VehicleMakeId == id);
        }

        public VehicleModel GetModelById(int id)
        {
            return _ctx.VehicleModels.FirstOrDefault(m => m.VehicleModelId == id);
        }

        public Vehicle GetVehicleById(int id)
        {
            return _ctx.Vehicles.FirstOrDefault(v => v.VehicleId == id);
        }

        public List<Vehicle> QuickSearch(VehicleSearchParameters parameters)
        {
            var result = GetAllUsed();
            if (!String.IsNullOrWhiteSpace(parameters.QuickSearch))
            {
                result = result.Where(s => s.VehicleModel.VehicleMake.Make.Contains(parameters.QuickSearch) || s.VehicleModel.ModelType.Contains(parameters.QuickSearch)).ToList();
            }
            result = result.Where(r => r.SalePrice >= parameters.MinPrice).ToList();
            result = result.Where(r => r.SalePrice <= parameters.MaxPrice).ToList();
            result = result.Where(r => r.Year >= parameters.MinYear).ToList();
            result = result.Where(r => r.Year <= parameters.MaxYear).ToList();

            return result;
        }

        public List<Vehicle> QuickSearchNew(VehicleSearchParameters parameters)

        {
            var result = GetAllUsed();
            if (!String.IsNullOrWhiteSpace(parameters.QuickSearch))
            {
                result = result.Where(s => s.VehicleModel.VehicleMake.Make.Contains(parameters.QuickSearch) || s.VehicleModel.ModelType.Contains(parameters.QuickSearch)).ToList();
            }
            result = result.Where(r => r.SalePrice >= parameters.MinPrice).ToList();
            result = result.Where(r => r.SalePrice <= parameters.MaxPrice).ToList();
            result = result.Where(r => r.Year >= parameters.MinYear).ToList();
            result = result.Where(r => r.Year <= parameters.MaxYear).ToList();

            return result;
        }

        public List<Vehicle> QuickSearchUsed(VehicleSearchParameters parameters)
        {
            var result = GetAllUsed();
            if (!String.IsNullOrWhiteSpace(parameters.QuickSearch))
            {
                result = result.Where(s => s.VehicleModel.VehicleMake.Make.Contains(parameters.QuickSearch) || s.VehicleModel.ModelType.Contains(parameters.QuickSearch)).ToList();
            }
            result = result.Where(r => r.SalePrice >= parameters.MinPrice).ToList();
            result = result.Where(r => r.SalePrice <= parameters.MaxPrice).ToList();
            result = result.Where(r => r.Year >= parameters.MinYear).ToList();
            result = result.Where(r => r.Year <= parameters.MaxYear).ToList();

            return result;
        }
    }
}
