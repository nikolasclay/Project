using CarDealership.Model;
using CarDealership.Model.Queries;
using CarDealership.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Interface
{
    public interface ICarRepository
    {
        List<Vehicle> GetAll();
        List<Vehicle> GetAllNew();
        List<Vehicle> GetAllFeatured();
        List<Vehicle> QuickSearchNew(VehicleSearchParameters parameters);
        List<Vehicle> GetAllUsed();
        List<Vehicle> QuickSearchUsed(VehicleSearchParameters parameters);
        List<Vehicle> QuickSearch(VehicleSearchParameters parameters);
        List<Special> GetAllSpecials();
        List<BodyStyle> GetAllStyles();
        List<InteriorColor> GetAllInterior();
        List<ExteriorColor> GetAllExterior();
        List<PurchaseType> GetAllTypes();
        List<AppUser> GetAllUsers();
        List<Contact> GetAllContacts();

        List<VehicleModel> GetAllModels();
        VehicleMake GetMakeById(int id);
        List<VehicleMake> GetAllMakes();
        VehicleModel GetModelById(int id);
        List<Vehicle> GetByYear(int year);
        Vehicle GetVehicleById(int id);

        void AddVehicle(Vehicle vehicle);
        void AddMake(VehicleMake make);
        void AddModel(VehicleModel model);
        void AddSpecial(Special special);
        void AddContact(Contact contact);
        void AddPurchase(Purchase purchase);
        void AddUser(AppUser user);

        void DeleteVehicle(int id);
        void DeleteMake(int id);
        void DeleteModel(int id);
        void DeleteSpecial(int id);
        void DeleteContact(int id);
        void DeletePurchase(int id);
        //void DeleteUser(int id);
        

        void EditVehicle(Vehicle vehicle);
        void EditMake(VehicleMake make);
        void EditModel(VehicleModel model);
        void EditContact(Contact contact);
        void EditPurchase(Purchase purchase);
        void EditUser(AppUser user);

        void CanAddColor(InteriorColor interior);
        void CanAddExteriorColor(ExteriorColor exterior);
        void CanDeleteColor(InteriorColor interior);
        void CanDeleteExterior(ExteriorColor exterior);
    }
}
