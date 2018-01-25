using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CarDealarship.Model.Interface;
using CarDealarship.Data.EF;
using CarDealarship.Bll;
using CarDealarship.Model.Queries;
using CarDealarship.Model.Tables;

namespace CarDealarship.Test.IntegrationTest
{
    [TestFixture]
    public class EFTesting
    {
        [SetUp]
        public void Init()
        {
            
        }
        [Test]
        public void CanLoadCarsEF()
        {
            IVehicleRepository repo = new EFRepo();
            var vehicle = repo.GetAll();
            Assert.AreEqual(9, vehicle.Count);
            Assert.AreEqual("Silver", vehicle[0].Color);
            Assert.AreEqual("White", vehicle[0].Interior);
            Assert.AreEqual("Manual", vehicle[0].Transmission);
            Assert.AreEqual("1XP7DU9X48D704313", vehicle[0].VinNumber);
        }

        [Test]
        public void CanGetCarByYearEF()
        {
            IVehicleRepository repo = new EFRepo();
            var vehicle = repo.GetByYear(2017);
            Assert.AreEqual(1, vehicle.Count);
            Assert.AreEqual(250, vehicle[0].Mileage);
            Assert.AreEqual("Red", vehicle[0].Color);

        }

        [Test]
        public void CanGetCarByMakeEF()
        {
            IVehicleRepository repo = new EFRepo();
            var vehicle = repo.GetByMake("Audi");
            Assert.AreEqual(17000.00M, vehicle[0].MSRP);
            Assert.AreEqual(16560M, vehicle[0].SalesPrice);

        }

        [Test]
        public void CanGetCarByModelEF()
        {
            IVehicleRepository repo = new EFRepo();
            var vehicle = repo.GetByModel("Altima");          
            Assert.AreEqual("Red", vehicle[0].Color);
            Assert.AreEqual("Nylon", vehicle[0].Interior);
            Assert.AreEqual("SUV", vehicle[0].VehicleType);
        }


        [Test]
        public void CanGetCarByPriceEF()
        {
            IVehicleRepository repo = new EFRepo();
            var vehicle = repo.GetByPrice(52000.00m);

            Assert.AreEqual(1, vehicle.Count);
            Assert.AreEqual("Automatic", vehicle[0].Transmission);
            Assert.AreEqual("1XP7DU9X48D705213", vehicle[0].VinNumber);
        }

        [Test]
        public void CanSearchFeaturedVehiclesEF()
        {
            IVehicleRepository repo = new EFRepo();
            var vehicle = repo.GetFeaturedVehicles();

            Assert.AreEqual(8, vehicle.Count);
            Assert.AreEqual(true, vehicle[0].IsFeatured);
            Assert.AreEqual("White", vehicle[7].Color);

        }

        [Test]
        public void CanSearchVehicleEF()
        {
            IVehicleRepository repo = new EFRepo();
            var search = repo.Search(new VehicleSearchParameters { SearchKey = "Chevy" });
            search = repo.Search(new VehicleSearchParameters { SearchKey = "Camero" });            
            Assert.AreEqual(1, search.Count);
        }

        [Test]
        public void CanGetAllNewCarsEF()
        {
            IVehicleRepository repo = new EFRepo();
            var search = repo.Search(new VehicleSearchParameters {MinPrice = 0, MaxPrice = 100000, IsNew = true });
            Assert.AreEqual(8, search.Count);
            
        }


        [Test]
        public void CanGetAllSpeicals()
        {
            IVehicleRepository repo = new EFRepo();
            var special = repo.GetAllSpecials();
            Assert.AreEqual(3, special.Count);
            Assert.AreEqual(3, special[0].SpecialId);
            Assert.AreEqual("College Graduate Program", special[0].Title);

        }

        [Test]
        public void CanGetVehicleById()
        {
            IVehicleRepository repo = new EFRepo();
            var vehicle = repo.GetVehicleById(2);
            Assert.AreEqual("BMW", vehicle.MakeId.MakeName);

        }

        [Test]
        public void CanGetAllMakes()
        {
            IVehicleRepository repo = new EFRepo();
            var vehicle = repo.GetAllMakes();
            Assert.AreEqual(9, vehicle.Count());
        }

        [Test]
        public void CanGetAllModels()
        {
            IVehicleRepository repo = new EFRepo();
            var vehicle = repo.GetAllModel();
            Assert.AreEqual(9, vehicle.Count());
        }

        [Test]
        public void CanGetMakeById()
        {
            IVehicleRepository repo = new EFRepo();
            var make = repo.GetMakeById(1);
            Assert.AreEqual("Chevy", make.MakeName);
        }

        [Test]
        public void CanGetModeById()
        {
            IVehicleRepository repo = new EFRepo();
            var model = repo.GetModelById(1);
            Assert.AreEqual("Camero", model.ModelName);
        }

        [Test]
        public void CanGetAllUsers()
        {
            IVehicleRepository repo = new EFRepo();
            var user = repo.GetAllUsers();
            Assert.AreEqual(5, user.Count());
           
        }

        [Test]
        public void CanAddUser()
        {
            Users userToAdd = new Users();
            IVehicleRepository repo = new EFRepo();
            userToAdd.Id = "1aa288eb-815c-4d3e-b018-f39c280b630j";
            userToAdd.FirstName = "Jordan";
            userToAdd.LastName = "Watts";
            userToAdd.Email = "jordan@guild.com";

            repo.AddUser(userToAdd);

            var addTest = repo.GetUserById(userToAdd.Id);

            Assert.AreEqual(userToAdd.Id, addTest.Id);
            

        }

        [Test]
        public void CanAddVehicle()
        {
            Vehicle vehicleToAdd = new Vehicle();
            IVehicleRepository repo = new EFRepo();
            vehicleToAdd.VehicleId = 10;
            ////vehicleToAdd.MakeId.MakeId = 10;
            //vehicleToAdd.MakeId.MakeName = "Honda";
            //vehicleToAdd.ModelId.ModelId = 10;
            //vehicleToAdd.ModelId.ModelName = "Acura";
            vehicleToAdd.Interior = "Black Leather";
            vehicleToAdd.VehicleType = "SUV";
            vehicleToAdd.SalesPrice = 1000000M;
            vehicleToAdd.Year = 2032;
            vehicleToAdd.Color = "Red";
            vehicleToAdd.Mileage = 0;
            vehicleToAdd.VinNumber = "1234567asdfg";
            vehicleToAdd.MSRP = 1000000M;
            vehicleToAdd.Transmission = "Automatic";
            vehicleToAdd.IsFeatured = false;
            vehicleToAdd.IsNew = true;
            vehicleToAdd.Description = "This is one of the future cars in the world";

            repo.AddVehicle(vehicleToAdd);

            var vehicleAdded = repo.GetVehicleById(10);

            Assert.AreEqual("1234567asdfg", vehicleAdded.VinNumber);


           

        }

        [Test]
        public void CanAddMake()
        {
            Make MakeToAdd = new Make();
            IVehicleRepository repo = new EFRepo();

            MakeToAdd.Date = DateTime.Now;
            MakeToAdd.MakeName = "VW";
            repo.AddMake(MakeToAdd);

            var addMake = repo.GetMakeById(MakeToAdd.MakeId);

            Assert.AreEqual(MakeToAdd.MakeId, addMake.MakeId);
        }
    }
}
