using CarDealership.Data.Interface;
using CarDealership.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Model.Queries;
using CarDealership.Model.Users;

namespace CarDealership.Data
{

    public class TestRepository : ICarRepository
    {
        private static List<Customer> _customers;
        private static List<Contact> _contacts;
        private static List<VehicleMake> _makes;
        private static List<VehicleModel> _models;
        private static List<Purchase> _purchases;
        private static List<PurchaseType> _purchaseTypes;
        private static List<Vehicle> _vehicles;
        private static List<Special> _specials;
        private static List<AppUser> _users;
        private static List<BodyStyle> _bodyStyles;
        private static List<InteriorColor> _interiorColors;
        private static List<ExteriorColor> _exteriorColors;



        public TestRepository()
        {
            _contacts = new List<Contact>
            {
                new Contact{ContactId = 1, Name = "Nikolas Clay", Email = "nikolasclay@generic.com", Phone = "808-555-1234", Message = "Interested in 2017 Audi R8"},
                new Contact{ContactId = 2, Name = "Lydia Habte", Email = "lydiahabte@generic.com", Phone = "651-555-1234", Message = "Interested in 2017 BMW i8"}
            };

            _makes = new List<VehicleMake>
            {
                new VehicleMake{VehicleMakeId = 1, Make = "Audi", Added = new DateTime(2017, 01, 10)},
                new VehicleMake{VehicleMakeId = 2, Make = "BMW", Added = new DateTime(2017, 01, 02)},
                new VehicleMake{VehicleMakeId = 3, Make = "Lamborghini", Added = new DateTime(2017, 01, 03)},
                new VehicleMake{VehicleMakeId = 4, Make = "Nissan", Added = new DateTime(2017, 11, 01)},
                new VehicleMake{VehicleMakeId = 5, Make = "Aston Martin", Added = new DateTime(2017, 11, 02)},
                new VehicleMake{VehicleMakeId = 6, Make = "Mercedes", Added = new DateTime(2017,11,17) },
                new VehicleMake{VehicleMakeId = 7, Make = "Porsche", Added = new DateTime(2017,11,17) },
                new VehicleMake{VehicleMakeId = 8, Make = "Jaguar", Added = new DateTime(2017,11,17) },
                new VehicleMake{VehicleMakeId = 9, Make = "Maserati", Added = new DateTime(2017,11,17) },
                new VehicleMake{VehicleMakeId = 10, Make = "Lexus", Added = new DateTime(2017,11,17) }
            };

            _users = new List<AppUser>
            {
                new AppUser{ Id= "1", FirstName = "Nikolas", LastName = "Clay", Email = "nikolasclay@generic.com", Role = "Admin", },
                new AppUser{ Id= "2", FirstName = "Lydia", LastName = "Habte", Email = "lydiahabte@generic.com", Role = "Sales", },
                new AppUser{ Id= "3", FirstName = "Blake", LastName = "Moses", Email = "blakemoses@generic.com", Role = "Disabled", }
            };
            _models = new List<VehicleModel>
            {
            new VehicleModel { VehicleModelId = 1, VehicleMakeId = _makes[0].VehicleMakeId, ModelType = "R8", VehicleMake = _makes[0], UserId = _users[1].Id, User = _users[1], Added = _makes[0].Added },
            new VehicleModel { VehicleModelId = 2, VehicleMakeId = _makes[1].VehicleMakeId, ModelType = "i8", VehicleMake = _makes[1], UserId = _users[1].Id, User = _users[1], Added = _makes[1].Added },
            new VehicleModel { VehicleModelId = 3, VehicleMakeId = _makes[2].VehicleMakeId, ModelType = "Centenario", VehicleMake = _makes[2], UserId = _users[1].Id, User = _users[1], Added = _makes[2].Added },
            new VehicleModel { VehicleModelId = 4, VehicleMakeId = _makes[3].VehicleMakeId, ModelType = "GTR", VehicleMake = _makes[3], UserId = _users[1].Id, User = _users[1], Added = _makes[3].Added },
            new VehicleModel { VehicleModelId = 5, VehicleMakeId = _makes[4].VehicleMakeId, ModelType = "Vanquish", VehicleMake = _makes[4], UserId = _users[1].Id, User = _users[1], Added = _makes[4].Added },
            new VehicleModel { VehicleModelId = 6, VehicleMakeId = _makes[5].VehicleMakeId, ModelType = "CLS", VehicleMake = _makes[5], UserId = _users[1].Id, User = _users[1], Added = _makes[5].Added },
            new VehicleModel { VehicleModelId = 7, VehicleMakeId = _makes[6].VehicleMakeId, ModelType = "911 GT2", VehicleMake = _makes[6], UserId = _users[1].Id, User = _users[1], Added = _makes[6].Added },
            new VehicleModel { VehicleModelId = 8, VehicleMakeId = _makes[7].VehicleMakeId, ModelType = "C-X75", VehicleMake = _makes[7], UserId = _users[1].Id, User = _users[1], Added = _makes[7].Added },
            new VehicleModel { VehicleModelId = 9, VehicleMakeId = _makes[8].VehicleMakeId, ModelType = "GranTurismo", VehicleMake = _makes[8], UserId = _users[1].Id, User = _users[1], Added = _makes[8].Added },
            new VehicleModel { VehicleModelId = 10, VehicleMakeId = _makes[9].VehicleMakeId, ModelType = "LC", VehicleMake = _makes[9], UserId = _users[1].Id, User = _users[1], Added = _makes[9].Added },
            new VehicleModel { VehicleModelId = 11, VehicleMakeId = _makes[5].VehicleMakeId, ModelType = "SLS", VehicleMake = _makes[5], UserId = _users[1].Id, User = _users[1], Added = _makes[5].Added },
            
            };

            _bodyStyles = new List<BodyStyle>
            {
                new BodyStyle{BodyStyleId = 1, Description = "Car"},
                new BodyStyle{BodyStyleId = 2, Description = "SUV"},
                new BodyStyle{BodyStyleId = 3, Description = "Truck"},
                new BodyStyle{BodyStyleId = 4, Description = "Van"},
            };

            _interiorColors = new List<InteriorColor>
            {
                new InteriorColor{InteriorColorId = 1, Description = "Black"},
                new InteriorColor{InteriorColorId = 2, Description = "White"},
                new InteriorColor{InteriorColorId = 3, Description = "Red"},
                new InteriorColor{InteriorColorId = 4, Description = "Brown"},
                new InteriorColor{InteriorColorId = 5, Description = "Gray"},
            };

            _exteriorColors = new List<ExteriorColor>
            {
                new ExteriorColor{ExteriorColorId = 1, Description = "Black"},
                new ExteriorColor{ExteriorColorId = 2, Description = "White"},
                new ExteriorColor{ExteriorColorId = 3, Description = "Gray"},
                new ExteriorColor{ExteriorColorId = 4, Description = "Silver"},
                new ExteriorColor{ExteriorColorId = 5, Description = "Red"},
            };

            _vehicles = new List<Vehicle>
            {
                new Vehicle{ VehicleId = 1, VehicleModelId = _models[0].VehicleModelId, VehicleModel = _models[0], VehicleMakeId = _makes[0].VehicleMakeId, Year = 2017, VIN = "12345678901234567",
                             Mileage = 10000, New = true, Transmission = "Manual", MSRP = 35000.00M, SalePrice = 40000.00M, Feature = true, Description = "Class meets speed.", Image = "http://localhost:51989/Content/img/AudiR8.jpg",
                             BodyStyle = _bodyStyles[0], BodyStyleId = _bodyStyles[0].BodyStyleId, ExteriorColor = _exteriorColors[1], ExteriorColorId = _exteriorColors[1].ExteriorColorId,
                             InteriorColorId = _interiorColors[0].InteriorColorId, InteriorColor = _interiorColors[0] },

                new Vehicle{ VehicleId = 2, VehicleModelId = _models[1].VehicleModelId, VehicleModel = _models[1], VehicleMakeId = _makes[1].VehicleMakeId, Year = 2015, VIN = "01234567891011121",
                             Mileage = 0, New = false, Transmission = "Automatic", MSRP = 20000.00M, SalePrice = 100000.00M, Feature = true, Description = "You're sure to turn heads with this car.", Image = "http://localhost:51989/Content/img/BMWi8.jpg",
                             BodyStyle = _bodyStyles[0], BodyStyleId = _bodyStyles[0].BodyStyleId, ExteriorColor = _exteriorColors[0], ExteriorColorId = _exteriorColors[0].ExteriorColorId,
                             InteriorColorId = _interiorColors[1].InteriorColorId, InteriorColor = _interiorColors[1] },

                new Vehicle{ VehicleId = 3, VehicleModelId = _models[4].VehicleModelId, VehicleModel = _models[4], VehicleMakeId = _makes[4].VehicleMakeId, Year = 2014, VIN = "01010101010101011",
                             Mileage = 5000, New = false, Transmission = "Manual", MSRP = 60000.00M, SalePrice = 55000.00M, Feature = true, Description = "It's an Aston Martin.", Image = "http://localhost:51989/Content/img/AstonMartin.jpg",
                             BodyStyle = _bodyStyles[0], BodyStyleId = _bodyStyles[0].BodyStyleId, ExteriorColor = _exteriorColors[3], ExteriorColorId = _exteriorColors[3].ExteriorColorId,
                             InteriorColorId = _interiorColors[0].InteriorColorId, InteriorColor = _interiorColors[0] },
                new Vehicle{ VehicleId = 4, VehicleModelId = _models[3].VehicleModelId, VehicleModel = _models[3], VehicleMakeId = _makes[3].VehicleMakeId, Year = 2013, VIN = "01010101010101012",
                             Mileage = 5000, New = true, Transmission = "Automatic", MSRP = 60000.00M, SalePrice = 75000.00M, Feature = true, Description = "It's a Nissan GTR.", Image = "http://localhost:51989/Content/img/NissanGTR.jpg",
                             BodyStyle = _bodyStyles[0], BodyStyleId = _bodyStyles[0].BodyStyleId, ExteriorColor = _exteriorColors[2], ExteriorColorId = _exteriorColors[2].ExteriorColorId,
                             InteriorColorId = _interiorColors[2].InteriorColorId, InteriorColor = _interiorColors[3] },
                new Vehicle{ VehicleId = 5, VehicleModelId = _models[2].VehicleModelId, VehicleModel = _models[2], VehicleMakeId = _makes[2].VehicleMakeId, Year = 2014, VIN = "01010101010101111",
                             Mileage = 5000, New = false, Transmission = "Automatic", MSRP = 60000.00M, SalePrice = 85000.00M, Feature = true, Description = "It's a Lamborghini.", Image = "http://localhost:51989/Content/img/Lamborghini.jpg",
                             BodyStyle = _bodyStyles[0], BodyStyleId = _bodyStyles[0].BodyStyleId, ExteriorColor = _exteriorColors[1], ExteriorColorId = _exteriorColors[1].ExteriorColorId,
                             InteriorColorId = _interiorColors[3].InteriorColorId, InteriorColor = _interiorColors[4] },
                new Vehicle{ VehicleId = 6, VehicleModelId = _models[5].VehicleModelId, VehicleModel = _models[5], VehicleMakeId = _makes[5].VehicleMakeId, Year = 2016, VIN = "01010101010101103",
                             Mileage = 5000, New = true, Transmission = "Automatic", MSRP = 60000.00M, SalePrice = 67000.00M, Feature = true, Description = "It's a Mercedes.", Image = "http://localhost:51989/Content/img/MercedesCLS.jpg",
                             BodyStyle = _bodyStyles[0], BodyStyleId = _bodyStyles[0].BodyStyleId, ExteriorColor = _exteriorColors[1], ExteriorColorId = _exteriorColors[2].ExteriorColorId,
                             InteriorColorId = _interiorColors[3].InteriorColorId, InteriorColor = _interiorColors[4] },
                new Vehicle{ VehicleId = 7, VehicleModelId = _models[6].VehicleModelId, VehicleModel = _models[6], VehicleMakeId = _makes[6].VehicleMakeId, Year = 2016, VIN = "01010101010101013",
                             Mileage = 5000, New = true, Transmission = "Automatic", MSRP = 60000.00M, SalePrice = 85000.00M, Feature = true, Description = "It's a Porsche.", Image = "http://localhost:51989/Content/img/Porsche.jpg",
                             BodyStyle = _bodyStyles[0], BodyStyleId = _bodyStyles[0].BodyStyleId, ExteriorColor = _exteriorColors[1], ExteriorColorId = _exteriorColors[3].ExteriorColorId,
                             InteriorColorId = _interiorColors[3].InteriorColorId, InteriorColor = _interiorColors[4] },
                new Vehicle{ VehicleId = 8, VehicleModelId = _models[7].VehicleModelId, VehicleModel = _models[7], VehicleMakeId = _makes[7].VehicleMakeId, Year = 2017, VIN = "01010101010101301",
                             Mileage = 5000, New = true, Transmission = "Automatic", MSRP = 60000.00M, SalePrice = 85000.00M, Feature = true, Description = "It's a Jaguar.", Image = "http://localhost:51989/Content/img/Jaguar.jpg",
                             BodyStyle = _bodyStyles[0], BodyStyleId = _bodyStyles[0].BodyStyleId, ExteriorColor = _exteriorColors[1], ExteriorColorId = _exteriorColors[1].ExteriorColorId,
                             InteriorColorId = _interiorColors[3].InteriorColorId, InteriorColor = _interiorColors[4] },
                new Vehicle{ VehicleId = 9, VehicleModelId = _models[8].VehicleModelId, VehicleModel = _models[8], VehicleMakeId = _makes[8].VehicleMakeId, Year = 2016, VIN = "01010101010101113",
                             Mileage = 5000, New = true, Transmission = "Automatic", MSRP = 60000.00M, SalePrice = 85000.00M, Feature = true, Description = "It's a Maserati.", Image = "http://localhost:51989/Content/img/Maserati.jpg",
                             BodyStyle = _bodyStyles[0], BodyStyleId = _bodyStyles[0].BodyStyleId, ExteriorColor = _exteriorColors[1], ExteriorColorId = _exteriorColors[0].ExteriorColorId,
                             InteriorColorId = _interiorColors[3].InteriorColorId, InteriorColor = _interiorColors[4] },
                new Vehicle{ VehicleId = 10, VehicleModelId = _models[9].VehicleModelId, VehicleModel = _models[9], VehicleMakeId = _makes[9].VehicleMakeId, Year = 2017, VIN = "01010101010101114",
                             Mileage = 5000, New = true, Transmission = "Automatic", MSRP = 60000.00M, SalePrice = 85000.00M, Feature = true, Description = "It's a Lexus.", Image = "http://localhost:51989/Content/img/Lexus.jpg",
                             BodyStyle = _bodyStyles[0], BodyStyleId = _bodyStyles[0].BodyStyleId, ExteriorColor = _exteriorColors[1], ExteriorColorId = _exteriorColors[1].ExteriorColorId,
                             InteriorColorId = _interiorColors[3].InteriorColorId, InteriorColor = _interiorColors[4] },
                new Vehicle{ VehicleId = 11, VehicleModelId = _models[10].VehicleModelId, VehicleModel = _models[10], VehicleMakeId = _makes[5].VehicleMakeId, Year = 2016, VIN = "01010101010101115",
                             Mileage = 5000, New = true, Transmission = "Automatic", MSRP = 60000.00M, SalePrice = 85000.00M, Feature = true, Description = "It's a Mercedes SLS.", Image = "http://localhost:51989/Content/img/MercedesSLS.jpg",
                             BodyStyle = _bodyStyles[0], BodyStyleId = _bodyStyles[0].BodyStyleId, ExteriorColor = _exteriorColors[1], ExteriorColorId = _exteriorColors[1].ExteriorColorId,
                             InteriorColorId = _interiorColors[3].InteriorColorId, InteriorColor = _interiorColors[4] }
            };
            _specials = new List<Special>
            {
                new Special{SpecialId = 1, Title = "HUGE", Description = "Buy one, get one free."},
                new Special{SpecialId = 2, Title = "BIG", Description = "Buy one, get one half off"},
                new Special{SpecialId = 3, Title = "DEAL", Description = "10% off first purchase."}
            };

            _customers = new List<Customer>
            {
                new Customer{ CustomerId = 1, Name = "Nikolas Clay", Phone ="808-555-1234", Email= "nikolasclay@generic.com", Street1 = "123 Anywhere Street", Street2 = "", City = "Honolulu", State = "HI", ZipCode = 96789},
                new Customer{ CustomerId = 2, Name = "Lydia Habte", Phone ="951-555-1234", Email= "lydiahabte@generic.com", Street1 = "456 Anywhere Street", Street2 = "", City = "Honolulu", State = "HI", ZipCode = 96789},
                new Customer{ CustomerId = 3, Name = "Blake Moses", Phone ="612-555-1234", Email= "blakemoses@generic.com", Street1 = "789 Anywhere Street", Street2 = "", City = "Honolulu", State = "HI", ZipCode = 96789}
            };

            _purchaseTypes = new List<PurchaseType>
            {
                new PurchaseType{ PurchaseTypeId = 1, Description = "Bank"},
                new PurchaseType{ PurchaseTypeId = 2, Description = "Cash"},
                new PurchaseType{ PurchaseTypeId = 3, Description = "Dealer"}
            };

            _purchases = new List<Purchase>
            {
                new Purchase{ PurchaseId = 1, PurchasePrice = 10000.00M, PurchaseTypeId = _purchaseTypes[0].PurchaseTypeId, PurchaseType = _purchaseTypes[0],
                              UserId = _users[1].Id, User = _users[1], Vehicle = _vehicles[0], VehicleId = _vehicles[0].VehicleId,
                              CustomerId = _customers[0].CustomerId, Customer = _customers[0], PurchaseDate = new DateTime(2017, 01, 10), },

                new Purchase{ PurchaseId = 2, PurchasePrice = 10000.00M, PurchaseTypeId = _purchaseTypes[1].PurchaseTypeId, PurchaseType = _purchaseTypes[1],
                              UserId = _users[1].Id, User = _users[1], Vehicle = _vehicles[1], VehicleId = _vehicles[1].VehicleId,
                              CustomerId = _customers[1].CustomerId, Customer = _customers[1], PurchaseDate = new DateTime(2017, 01, 10), },

                new Purchase{ PurchaseId = 3, PurchasePrice = 10000.00M, PurchaseTypeId = _purchaseTypes[2].PurchaseTypeId, PurchaseType = _purchaseTypes[2],
                              UserId = _users[1].Id, User = _users[1], Vehicle = _vehicles[2], VehicleId = _vehicles[1].VehicleId,
                              CustomerId = _customers[2].CustomerId, Customer = _customers[2], PurchaseDate = new DateTime(2017, 01, 10), }
            };
        }

        public void AddContact(Contact contact)
        {
            if(_contacts.Count == 0)
            {
                contact.ContactId = 1;
            }
            else
            {
                contact.ContactId = _contacts.Max(c => c.ContactId) + 1;
            }
            _contacts.Add(contact);
        }

        public void AddMake(VehicleMake make)
        {
            if (_makes.Count == 0)
            {
                make.VehicleMakeId = 1;
            }
            else
            {
                make.VehicleMakeId = _makes.Max(m => m.VehicleMakeId) + 1;
            }
            _makes.Add(make);
        }

        public void AddModel(VehicleModel model)
        {
            if (_models.Count == 0)
            {
                model.VehicleModelId = 1;
            }
            else
            {
                model.VehicleModelId = _models.Max(m => m.VehicleModelId) + 1;
            }
            _models.Add(model);
        }

        public void AddPurchase(Purchase purchase)
        {
            if (_purchases.Count == 0)
            {
                purchase.PurchaseId = 1;
            }
            else
            {
                purchase.PurchaseId = _purchases.Max(p => p.PurchaseId) + 1;
            }
                _purchases.Add(purchase);
        }

        public void AddSpecial(Special special)
        {
            if (_specials.Count == 0)
            {
                special.SpecialId = 1;
            }
            else
            {
                special.SpecialId = _specials.Max(s => s.SpecialId) + 1;
            }
            _specials.Add(special);
        }

        public void AddUser(AppUser user)
        {
            if (_users.Count == 0)
            {
                user.Id = "1";
            }
            else
            {
                user.Id = _users.Max(s => s.Id) + 1;
            }
            _users.Add(user);
        }

        public void AddVehicle(Vehicle vehicle)
        {
            if (_vehicles.Count == 0)
            {
                vehicle.VehicleId = 1;
            }
            else
            {
                vehicle.VehicleId = _vehicles.Max(v => v.VehicleId) + 1;
            }
            _vehicles.Add(vehicle);
        }

        public void DeleteContact(int id)
        {
            _contacts.RemoveAll(c => c.ContactId == id);
        }

        public void DeleteMake(int id)
        {
            _makes.RemoveAll(m => m.VehicleMakeId == id);
        }

        public void DeleteModel(int id)
        {
            _models.RemoveAll(m => m.VehicleModelId == id);
        }

        public void DeletePurchase(int id)
        {
            _purchases.RemoveAll(p => p.PurchaseId == id);
        }

        public void DeleteSpecial(int id)
        {
            _specials.RemoveAll(s => s.SpecialId == id);
        }

        public void DeleteUser(int id)
        {
            _users.RemoveAll(u => u.Id == id.ToString());
        }

        public void DeleteVehicle(int id)
        {
            _vehicles.RemoveAll(v => v.VehicleId == id);
        }

        public void EditContact(Contact contact)
        {
            var editContact = _contacts.FirstOrDefault(c => c.ContactId == contact.ContactId);
            editContact.Name = contact.Name;
            editContact.Email = contact.Email;
            editContact.Phone = contact.Phone;
            editContact.Message = contact.Message;

            editContact = contact;

        }

        public void EditMake(VehicleMake make)
        {
            var editMake = _makes.FirstOrDefault(m => m.VehicleMakeId == make.VehicleMakeId);
            editMake.Make = make.Make;
            editMake.Added = make.Added;
            editMake = make;
        }

        public void EditModel(VehicleModel model)
        {
            var editModel = _models.FirstOrDefault(m => m.VehicleModelId == model.VehicleModelId);
            editModel.ModelType = model.ModelType;
            editModel.VehicleMake = model.VehicleMake;
            editModel.User = model.User;
            editModel.UserId = model.UserId;
            editModel = model;
        }

        public void EditPurchase(Purchase purchase)
        {
            var editPurchase = _purchases.FirstOrDefault(p => p.PurchaseId == purchase.PurchaseId);
            editPurchase.PurchaseDate = purchase.PurchaseDate;
            editPurchase.PurchasePrice = purchase.PurchasePrice;
            editPurchase.PurchaseType = purchase.PurchaseType;
            editPurchase.PurchaseTypeId = purchase.PurchaseTypeId;
            editPurchase.Vehicle = purchase.Vehicle;
            editPurchase.VehicleId = purchase.VehicleId;
            editPurchase.User = purchase.User;
            editPurchase.UserId = purchase.UserId;
            editPurchase.Customer = purchase.Customer;
            editPurchase.CustomerId = purchase.CustomerId;
            editPurchase = purchase;
        }

        public void EditUser(AppUser user)
        {
            var editUser = _users.FirstOrDefault(u => u.Id == user.Id);
            editUser.FirstName = user.FirstName;
            editUser.LastName = user.LastName;
            editUser.Email = user.Email;
            editUser.Role = user.Role;
        }

        public void EditVehicle(Vehicle vehicle)
        {
            var editVehicle = _vehicles.FirstOrDefault(v => v.VehicleId == vehicle.VehicleId);
            editVehicle.BodyStyle = vehicle.BodyStyle;
            editVehicle.BodyStyleId = vehicle.BodyStyleId;
            editVehicle.Description = vehicle.Description;
            editVehicle.ExteriorColor = vehicle.ExteriorColor;
            editVehicle.ExteriorColorId = vehicle.ExteriorColorId;
            editVehicle.Feature = vehicle.Feature;
            editVehicle.Image = vehicle.Image;
            editVehicle.InteriorColor = vehicle.InteriorColor;
            editVehicle.InteriorColor = vehicle.InteriorColor;
            editVehicle.Mileage = vehicle.Mileage;
            editVehicle.MSRP = vehicle.MSRP;
            editVehicle.New = vehicle.New;
            editVehicle.SalePrice = vehicle.SalePrice;
            editVehicle.Transmission = vehicle.Transmission;
            editVehicle.VehicleId = vehicle.VehicleId;
            editVehicle.VehicleMakeId = vehicle.VehicleMakeId;
            editVehicle.VehicleModel = vehicle.VehicleModel;
            editVehicle.VehicleModelId = vehicle.VehicleModelId;
            editVehicle.VIN = vehicle.VIN;
            editVehicle.Year = vehicle.Year;
            editVehicle = vehicle;
        }

        public List<Vehicle> GetAll()
        {
            return _vehicles;
        }

        public List<Vehicle> GetAllFeatured()
        {
            return _vehicles.Where(v => v.Feature == true).ToList();
        }

        public List<VehicleMake> GetAllMakes()
        {
            return _makes;
        }

        public List<VehicleModel> GetAllModels()
        {
            return _models;
        }

        public List<Vehicle> GetAllNew()
        {
            return _vehicles.Where(v => v.New == true).ToList();
        }

        public List<Vehicle> GetAllUsed()
        {
            return _vehicles.Where(v => v.New == false).ToList();
        }

        public List<Vehicle> GetByYear(int year)
        {
            return _vehicles.Where(v => v.Year == year).ToList();
        }

        public VehicleMake GetMakeById(int id)
        {
            return _makes.FirstOrDefault(m => m.VehicleMakeId == id);
        }

        public VehicleModel GetModelById(int id)
        {
            return _models.FirstOrDefault(m => m.VehicleModelId == id);
        }

        public List<Vehicle> QuickSearch(VehicleSearchParameters parameters)
        {
            var result = GetAll();
            #region With Quick Search
            if (!String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MinPrice.HasValue)
            {
                result = result.Where(r => r.SalePrice >= parameters.MinPrice).ToList();
            }
            if (!String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MaxPrice.HasValue)
            {
                result = result.Where(r => r.SalePrice <= parameters.MaxPrice).ToList();
            }
            if (!String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MinYear.HasValue)
            {
                result = result.Where(r => r.Year >= parameters.MinYear).ToList();
            }
            if (!String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MaxYear.HasValue)
            {
                result = result.Where(r => r.Year <= parameters.MaxYear).ToList();
            }
            if (!String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MinPrice.HasValue && parameters.MaxPrice.HasValue
                && parameters.MinYear.HasValue && parameters.MaxYear.HasValue)
            {
                result = result.Where(r => r.SalePrice > +parameters.MinPrice && r.SalePrice <= parameters.MaxPrice
                && r.Year >= parameters.MinYear && r.Year <= parameters.MaxYear).ToList();
            }
            if (!String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MinYear.HasValue && parameters.MaxYear.HasValue)
            {
                result = result.Where(r => r.Year >= parameters.MinYear && r.Year <= parameters.MaxYear).ToList();
            }
            if (!String.IsNullOrWhiteSpace(parameters.QuickSearch))
            {
                result = result.Where(s => s.VehicleModel.VehicleMake.Make.Contains(parameters.QuickSearch) || s.VehicleModel.ModelType.Contains(parameters.QuickSearch)).ToList();
            }
            #endregion
            #region Without Quick Search
            if (String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MinPrice.HasValue && parameters.MaxPrice.HasValue
                && parameters.MinYear.HasValue && parameters.MaxYear.HasValue)
            {
                result = result.Where(r => r.SalePrice >= parameters.MinPrice && r.SalePrice <= parameters.MaxPrice && r.Year >= parameters.MinYear && r.Year <= parameters.MaxYear).ToList();
            }
            else if (String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MinPrice.HasValue && parameters.MaxPrice.HasValue)
            {
                result = result.Where(r => r.SalePrice >= parameters.MinPrice && r.SalePrice <= parameters.MaxPrice).ToList();
            }
            else if (String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MinYear.HasValue && parameters.MaxYear.HasValue)
            {
                result = result.Where(r => r.Year >= parameters.MinYear && r.Year <= parameters.MaxYear).ToList();
            }
            else if (String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MinPrice.HasValue && parameters.MaxPrice.HasValue && parameters.MinYear.HasValue)
            {
                result = result.Where(r => r.Year >= parameters.MinYear && r.Year <= parameters.MaxYear && r.SalePrice >= parameters.MinPrice || r.SalePrice <= parameters.MaxPrice).ToList();
            }
            else if (String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MinPrice.HasValue && parameters.MinYear.HasValue && parameters.MaxYear.HasValue)
            {
                result = result.Where(r => r.SalePrice >= parameters.MinPrice && r.SalePrice <= parameters.MaxPrice && r.Year <= parameters.MaxYear).ToList();
            }
            else if (String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MaxPrice.HasValue && parameters.MinYear.HasValue && parameters.MaxYear.HasValue)
            {
                result = result.Where(r => r.SalePrice <= parameters.MaxPrice && r.Year <= parameters.MinYear && r.Year <= parameters.MaxYear).ToList();
            }
            else if (String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MinPrice.HasValue)
            {
                result = result.Where(r => r.SalePrice >= parameters.MinPrice).ToList();
            }
            else if (String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MaxPrice.HasValue)
            {
                result = result.Where(r => r.SalePrice <= parameters.MaxPrice).ToList();
            }
            else if (String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MinYear.HasValue)
            {
                result = result.Where(r => r.Year >= parameters.MinYear).ToList();
            }
            else if (String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MaxYear.HasValue)
            {
                result = result.Where(r => r.Year <= parameters.MaxYear).ToList();
            }

#endregion
            return result;
        }

        public Vehicle GetVehicleById(int id)
        {
            return _vehicles.FirstOrDefault(v => v.VehicleId == id);
        }

        public List<Vehicle> QuickSearchNew(VehicleSearchParameters parameters)
        {
            var result = GetAllNew();
            #region With Quick Search
            if (!String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MinPrice.HasValue)
            {
                result = result.Where(r => r.SalePrice >= parameters.MinPrice).ToList();
            }
            if (!String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MaxPrice.HasValue)
            {
                result = result.Where(r => r.SalePrice <= parameters.MaxPrice).ToList();
            }
            if (!String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MinYear.HasValue)
            {
                result = result.Where(r => r.Year >= parameters.MinYear).ToList();
            }
            if (!String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MaxYear.HasValue)
            {
                result = result.Where(r => r.Year <= parameters.MaxYear).ToList();
            }
            if (!String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MinPrice.HasValue && parameters.MaxPrice.HasValue
                && parameters.MinYear.HasValue && parameters.MaxYear.HasValue)
            {
                result = result.Where(r => r.SalePrice > +parameters.MinPrice && r.SalePrice <= parameters.MaxPrice
                && r.Year >= parameters.MinYear && r.Year <= parameters.MaxYear).ToList();
            }
            if (!String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MinYear.HasValue && parameters.MaxYear.HasValue)
            {
                result = result.Where(r => r.Year >= parameters.MinYear && r.Year <= parameters.MaxYear).ToList();
            }
            if (!String.IsNullOrWhiteSpace(parameters.QuickSearch))
            {
                result = result.Where(s => s.VehicleModel.VehicleMake.Make.Contains(parameters.QuickSearch) || s.VehicleModel.ModelType.Contains(parameters.QuickSearch)).ToList();
            }
            #endregion
            #region Without Quick Search
            if (String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MinPrice.HasValue && parameters.MaxPrice.HasValue
                && parameters.MinYear.HasValue && parameters.MaxYear.HasValue)
            {
                result = result.Where(r => r.SalePrice >= parameters.MinPrice && r.SalePrice <= parameters.MaxPrice && r.Year >= parameters.MinYear && r.Year <= parameters.MaxYear).ToList();
            }
            else if (String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MinPrice.HasValue && parameters.MaxPrice.HasValue)
            {
                result = result.Where(r => r.SalePrice >= parameters.MinPrice && r.SalePrice <= parameters.MaxPrice).ToList();
            }
            else if (String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MinYear.HasValue && parameters.MaxYear.HasValue)
            {
                result = result.Where(r => r.Year >= parameters.MinYear && r.Year <= parameters.MaxYear).ToList();
            }
            else if (String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MinPrice.HasValue && parameters.MaxPrice.HasValue && parameters.MinYear.HasValue)
            {
                result = result.Where(r => r.Year >= parameters.MinYear && r.Year <= parameters.MaxYear && r.SalePrice >= parameters.MinPrice || r.SalePrice <= parameters.MaxPrice).ToList();
            }
            else if (String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MinPrice.HasValue && parameters.MinYear.HasValue && parameters.MaxYear.HasValue)
            {
                result = result.Where(r => r.SalePrice >= parameters.MinPrice && r.SalePrice <= parameters.MaxPrice && r.Year <= parameters.MaxYear).ToList();
            }
            else if (String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MaxPrice.HasValue && parameters.MinYear.HasValue && parameters.MaxYear.HasValue)
            {
                result = result.Where(r => r.SalePrice <= parameters.MaxPrice && r.Year <= parameters.MinYear && r.Year <= parameters.MaxYear).ToList();
            }
            else if (String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MinPrice.HasValue)
            {
                result = result.Where(r => r.SalePrice >= parameters.MinPrice).ToList();
            }
            else if (String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MaxPrice.HasValue)
            {
                result = result.Where(r => r.SalePrice <= parameters.MaxPrice).ToList();
            }
            else if (String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MinYear.HasValue)
            {
                result = result.Where(r => r.Year >= parameters.MinYear).ToList();
            }
            else if (String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MaxYear.HasValue)
            {
                result = result.Where(r => r.Year <= parameters.MaxYear).ToList();
            }
            return result;
        }

        public List<Vehicle> QuickSearchUsed(VehicleSearchParameters parameters)
        {
            var result = GetAllUsed();
            #region With Quick Search
            if (!String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MinPrice.HasValue)
            {
                result = result.Where(r => r.SalePrice >= parameters.MinPrice).ToList();
            }
            if (!String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MaxPrice.HasValue)
            {
                result = result.Where(r => r.SalePrice <= parameters.MaxPrice).ToList();
            }
            if (!String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MinYear.HasValue)
            {
                result = result.Where(r => r.Year >= parameters.MinYear).ToList();
            }
            if (!String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MaxYear.HasValue)
            {
                result = result.Where(r => r.Year <= parameters.MaxYear).ToList();
            }
            if (!String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MinPrice.HasValue && parameters.MaxPrice.HasValue
                && parameters.MinYear.HasValue && parameters.MaxYear.HasValue)
            {
                result = result.Where(r => r.SalePrice > +parameters.MinPrice && r.SalePrice <= parameters.MaxPrice
                && r.Year >= parameters.MinYear && r.Year <= parameters.MaxYear).ToList();
            }
            if (!String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MinYear.HasValue && parameters.MaxYear.HasValue)
            {
                result = result.Where(r => r.Year >= parameters.MinYear && r.Year <= parameters.MaxYear).ToList();
            }
            if (!String.IsNullOrWhiteSpace(parameters.QuickSearch))
            {
                result = result.Where(s => s.VehicleModel.VehicleMake.Make.Contains(parameters.QuickSearch) || s.VehicleModel.ModelType.Contains(parameters.QuickSearch)).ToList();
            }
            #endregion
            #region Without Quick Search
            if (String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MinPrice.HasValue && parameters.MaxPrice.HasValue
                && parameters.MinYear.HasValue && parameters.MaxYear.HasValue)
            {
                result = result.Where(r => r.SalePrice >= parameters.MinPrice && r.SalePrice <= parameters.MaxPrice && r.Year >= parameters.MinYear && r.Year <= parameters.MaxYear).ToList();
            }
            else if (String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MinPrice.HasValue && parameters.MaxPrice.HasValue)
            {
                result = result.Where(r => r.SalePrice >= parameters.MinPrice && r.SalePrice <= parameters.MaxPrice).ToList();
            }
            else if (String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MinYear.HasValue && parameters.MaxYear.HasValue)
            {
                result = result.Where(r => r.Year >= parameters.MinYear && r.Year <= parameters.MaxYear).ToList();
            }
            else if (String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MinPrice.HasValue && parameters.MaxPrice.HasValue && parameters.MinYear.HasValue)
            {
                result = result.Where(r => r.Year >= parameters.MinYear && r.Year <= parameters.MaxYear && r.SalePrice >= parameters.MinPrice || r.SalePrice <= parameters.MaxPrice).ToList();
            }
            else if (String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MinPrice.HasValue && parameters.MinYear.HasValue && parameters.MaxYear.HasValue)
            {
                result = result.Where(r => r.SalePrice >= parameters.MinPrice && r.SalePrice <= parameters.MaxPrice && r.Year <= parameters.MaxYear).ToList();
            }
            else if (String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MaxPrice.HasValue && parameters.MinYear.HasValue && parameters.MaxYear.HasValue)
            {
                result = result.Where(r => r.SalePrice <= parameters.MaxPrice && r.Year <= parameters.MinYear && r.Year <= parameters.MaxYear).ToList();
            }
            else if (String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MinPrice.HasValue)
            {
                result = result.Where(r => r.SalePrice >= parameters.MinPrice).ToList();
            }
            else if (String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MaxPrice.HasValue)
            {
                result = result.Where(r => r.SalePrice <= parameters.MaxPrice).ToList();
            }
            else if (String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MinYear.HasValue)
            {
                result = result.Where(r => r.Year >= parameters.MinYear).ToList();
            }
            else if (String.IsNullOrWhiteSpace(parameters.QuickSearch) && parameters.MaxYear.HasValue)
            {
                result = result.Where(r => r.Year <= parameters.MaxYear).ToList();
            }

            return result;
        }
#endregion
        public void CanAddColor(InteriorColor interior)
        {
            if (_interiorColors.Count == 0)
            {
                interior.InteriorColorId = 1;
            }
            else
            {
                interior.InteriorColorId = _interiorColors.Max(v => v.InteriorColorId);
            }
            _interiorColors.Add(interior);
        }

        public void CanAddExteriorColor(ExteriorColor exterior)
        {
            if (_exteriorColors.Count == 0)
            {
                exterior.ExteriorColorId = 1;
            }
            else
            {
                exterior.ExteriorColorId = _exteriorColors.Max(v => v.ExteriorColorId);
            }
            _exteriorColors.Add(exterior);
        }

        public void CanDeleteColor(InteriorColor interior)
        {
            _interiorColors.RemoveAll(i => i.InteriorColorId == interior.InteriorColorId);
        }

        public void CanDeleteExterior(ExteriorColor exterior)
        {
            _exteriorColors.RemoveAll(e => e.ExteriorColorId == exterior.ExteriorColorId);
        }

        public List<Special> GetAllSpecials()
        {
            return _specials;
        }

        public List<BodyStyle> GetAllStyles()
        {
            return _bodyStyles;
        }

        public List<InteriorColor> GetAllInterior()
        {
            return _interiorColors;
        }

        public List<ExteriorColor> GetAllExterior()
        {
            return _exteriorColors;
        }

        public List<PurchaseType> GetAllTypes()
        {
            return _purchaseTypes;
        }

        public List<AppUser> GetAllUsers()
        {
            return _users;
        }

        public List<Contact> GetAllContacts()
        {
            return _contacts;
        }
    }
}
#endregion