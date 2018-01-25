using CarDealarship.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealarship.Model.Tables;
using CarDealarship.Model.Queries;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CarDealarship.Data.Mock
{
    public class MockRepo : IVehicleRepository
    {

        private static List<Vehicle> _vehicle;

        //public MockRepo()
        //{
        //    _vehicle = new List<Vehicle>()
        //    {
        //        new Vehicle
        //        {

        //            VehicleId = 1,
        //            Make = new Make
        //            {
        //                MakeId = 1,
        //                MakeName = "Nissan",
        //            },
        //            Model = new Models
        //            {
        //                ModelId = 1,
        //                ModelName = "Altima"
        //            },

        //            VehicleType = new VehicleType
        //            {
        //                VehicleId = 1,
        //                Type = "SUV"

        //            },
        //            IsNew = true,
        //            ImageFileName="Images/Nissan.jpg",
        //            Transmission = "Automatic",
        //            Interior = "Black",
        //            Color="Red",
        //            SalePrice = 21000M,
        //            Mileage = 10,
        //            Year = 2017,
        //            VinNumber = "1XP7DU9X48D704313",
        //            MSRP = 22500,
        //            IsFeatured = false

        //        },

        //        new Vehicle
        //        {
        //             VehicleId = 2,
        //             Make = new Make
        //            {
        //                MakeId = 2,
        //                MakeName = "Chevy",
        //            },
        //            Model = new Models
        //            {
        //                ModelId = 2,
        //                ModelName = "Camero"
        //            },

        //             VehicleType = new VehicleType
        //            {
        //                VehicleId = 2,
        //                Type = "Crossover",

        //            },
        //             IsNew = true,
        //             ImageFileName = "Images/camero.jpg",
        //             Color="Silver",
        //             Transmission = "Automatic",
        //             Interior = "Leather",
        //            SalePrice = 17000M,
        //            Mileage = 2500,
        //            Year = 2017,
        //            IsFeatured =  true,
        //            VinNumber = "1XP7DU9X48D704313",
        //            MSRP = 35500
        //        },

        //        new Vehicle
        //        {
        //             VehicleId = 3,
        //             Make = new Make
        //            {
        //                MakeId = 3,
        //                MakeName = "Chevy",
        //            },
        //            Model = new Models
        //            {
        //                ModelId = 3,
        //                ModelName = "Chevelle SS 454"
        //            },

        //            VehicleType = new VehicleType
        //            {
        //                VehicleId = 1,
        //                Type = "Sedan"
        //            },
        //            IsNew = false,
        //            ImageFileName = "Images/SS454.jpg",
        //            Color = "Yellow",
        //            Transmission = "Manual",
        //            Interior = "Fabric",
        //            SalePrice = 40000M,
        //            Mileage = 86000,
        //            Year = 1970,
        //            VinNumber = "1XP7DU9X48D726313",
        //            MSRP = 65000,
        //            IsFeatured = true
        //        },

        //        new Vehicle
        //        {
        //             VehicleId = 4,
        //             Make = new Make
        //            {
        //                MakeId = 4,
        //                MakeName = "BMW",
        //            },
        //            Model = new Models
        //            {
        //                ModelId = 4,
        //                ModelName = "i8"
        //            },

        //            VehicleType = new VehicleType
        //            {
        //                VehicleId = 4,
        //                Type = "SubCompact",
        //            },
        //            IsNew = true,
        //            ImageFileName = "Images/i8.jpg",
        //            Color = "White",
        //            Transmission = "Automatic",
        //            Interior = "Black with Red",
        //            SalePrice = 95000M,
        //            Mileage = 86000,
        //            Year = 2018,
        //            VinNumber = "1XP7DU9X48D72632665",
        //            MSRP = 144395,
        //            IsFeatured = true

        //        },

        //        new Vehicle
        //        {
        //             VehicleId = 5,
        //             Make = new Make
        //            {
        //                MakeId = 5,
        //                MakeName = "BMW",
        //            },
        //            Model = new Models
        //            {
        //                ModelId = 5,
        //                ModelName = "E21"
        //            },

        //            VehicleType = new VehicleType
        //            {
        //                VehicleId = 5,
        //                Type = "Convertible",
        //            },
        //            IsNew = false,
        //            ImageFileName = "Images/e21.jpg",
        //            SalePrice = 4500M,
        //            Color = "Blue",
        //            Interior = "Black",
        //            Transmission = "Manual",
        //            Mileage = 150000,
        //            Year = 1980,
        //            VinNumber = "1XP7DU9X48D72632668",
        //            MSRP = 8000,
        //            IsFeatured = true
        //        },

        //        new Vehicle
        //        {
        //             VehicleId = 6,
        //             Make = new Make
        //            {
        //                MakeId = 6,
        //                MakeName = "Tesla",
        //            },

        //            Model = new Models
        //            {
        //                ModelId = 6,
        //                ModelName = "3"
        //            },
        //            IsNew = true,
        //            ImageFileName = "Images/telsa3.jpg",
        //            Interior = "Black",
        //            SalePrice = 4500M,
        //            Color = "Black",
        //            Transmission = "Automatic",
        //            Mileage = 160000,
        //            Year = 1981,
        //            VinNumber = "1XP7DU9X48D72632068",
        //            MSRP = 8000,
        //            IsFeatured = true
        //        },


        //        new Vehicle
        //        {
        //             VehicleId = 7,
        //             Make = new Make
        //            {
        //                MakeId = 7,
        //                MakeName = "Audi",
        //            },
        //            Model = new Models
        //            {
        //                ModelId = 7,
        //                ModelName = "F103"
        //            },
        //            VehicleType = new VehicleType
        //            {
        //                VehicleId = 7,
        //                Type = "MPV",
        //            },
        //            IsNew = true,
        //            ImageFileName = "Images/f103.jpg",
        //            Color= "White",
        //            Transmission = "Manual",
        //            Interior = "Compact",
        //            SalePrice = 50000M,
        //            Mileage = 120000,
        //            Year = 1970,
        //            VinNumber = "1XP7DU9X48D72632690",
        //            MSRP = 65000,
        //            IsFeatured = true
        //        },



        //    };
        //}
        public List<Vehicle> GetAll()
        {
            return _vehicle;
        }

        public List<Vehicle> GetFeaturedVehicles()
        {
            return _vehicle.Where(f => f.IsFeatured == true).ToList();
        }

        public List<Vehicle> GetByMake(string make)
        {
            
            return _vehicle.Where(m => m.MakeId.MakeName == make).ToList();
        }

        public List<Vehicle> GetByModel(string model)
        {
            throw new NotImplementedException();
            //return _vehicle.Where(m => m.Model.ModelName == model).ToList();
        }

        public List<Vehicle> GetByPrice(decimal price)
        {
            throw new NotImplementedException();
            //return _vehicle.Where(p => p.SalePrice == price).ToList();         
        }

        public List<Vehicle> GetByYear(int year)
        {
            return _vehicle.Where(y => y.Year == year).ToList();
        }

        //public List<Vehicle> Search(string type, string SearchKey, int minYear, int maxYear, int minPrice, int maxPrice)
        //{
        //    List<Vehicle> newVehicles = new List<Vehicle>();
        //    List<Vehicle> toReturn = new List<Vehicle>();

        //    if(type == "new")
        //    {
        //        newVehicles = (_vehicle.Where(v => v.IsNew == true)).ToList();
        //        foreach(var car in newVehicles)
        //        {
        //            if(car.Make.MakeName.Contains(SearchKey) || car.Model.ModelName.Contains(SearchKey) || car.Year.ToString() == SearchKey
        //                && car.Year >= minYear && car.Year <= maxYear && car.SalePrice >= minPrice && car.SalePrice <= maxPrice)
        //            {
        //                toReturn.Add(car);
        //            }
        //        }
        //    }

        //    return toReturn;           
        //}

        public List<Vehicle> Search(VehicleSearchParameters pram)
        {
            //List<Vehicle> newVehicles = new List<Vehicle>();
            //List<Vehicle> toReturn = new List<Vehicle>();

            //var query = _vehicle.Where(i => i.IsNew == pram.IsNew);

            //if (!String.IsNullOrWhiteSpace(pram.SearchKey))
            //{
            //    query = query.Where(i => i.Make.MakeName.Contains(pram.SearchKey)
            //    || i.Model.ModelName.Contains(pram.SearchKey));
            //}

            //if (pram.MinPrice.HasValue)
            //{
            //    query = query.Where(i => i.SalePrice > pram.MinPrice.Value);
            //}
            //if (pram.MaxPrice.HasValue)
            //{
            //    query = query.Where(i => i.SalePrice < pram.MaxPrice.Value);
            //}
            //if (pram.MinYear.HasValue)
            //{
            //    query = query.Where(i => i.Year > pram.MinYear);
            //}
            //if (pram.MaxYear.HasValue)
            //{
            //    query = query.Where(i => i.Year < pram.MaxYear);
            //}

            //return query.ToList();
            throw new NotImplementedException();

        }

        public List<Specials> GetAllSpecials()
        {
            throw new NotImplementedException();
        }

        List<Specials> IVehicleRepository.GetAllSpecials()
        {
            throw new NotImplementedException();
        }

        public Vehicle GetVehicleById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> SearchOldCars(VehicleSearchParameters pram)
        {
            throw new NotImplementedException();
        }

        public Sales GetSalesById(int id)
        {
            throw new NotImplementedException();
        }

        public Sales GetSales(VehicleSearchParameters pram)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> SearchSales(VehicleSearchParameters pram)
        {
            throw new NotImplementedException();
        }

        public List<Make> GetAllMakes()
        {
            throw new NotImplementedException();
        }

        public List<Models> GetAllModel()
        {
            throw new NotImplementedException();
        }

        public void AddVehicle(Vehicle car)
        {
            throw new NotImplementedException();
        }

        public Make GetMakeById(int id)
        {
            throw new NotImplementedException();
        }

        public Models GetModelById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Users> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Users GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public Users GetUserById(string role)
        {
            throw new NotImplementedException();
        }

        public void AddUser(Users user)
        {
            throw new NotImplementedException();
        }

        public List<Make> GetAllMake()
        {
            throw new NotImplementedException();
        }

        public void EditVehicle(Vehicle car)
        {
            throw new NotImplementedException();
        }

        public void AddMake(string newMake)
        {
            throw new NotImplementedException();
        }

        public void PurchaseVehicle(Sales sale)
        {
            throw new NotImplementedException();
        }

        public void AddMake(Make newMake)
        {
            throw new NotImplementedException();
        }

        public void AddSpecial(Specials special)
        {
            throw new NotImplementedException();
        }

        public void AddModel(Models newModel)
        {
            throw new NotImplementedException();
        }

        public void DeleteSpecial(int specialId)
        {
            throw new NotImplementedException();
        }

        public Specials GetSpecialById(int id)
        {
            throw new NotImplementedException();
        }

        public void AddContactUs(ContactUs contact)
        {
            throw new NotImplementedException();
        }

        public List<IdentityRole> GetAllRoles()
        {
            throw new NotImplementedException();
        }
    }


}
