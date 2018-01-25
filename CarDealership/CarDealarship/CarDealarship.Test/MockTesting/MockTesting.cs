using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CarDealarship.Model.Interface;
//using CarDealarship.Data.Mock;
using CarDealarship.Model.Queries;
using CarDealarship.Data.Mock;

namespace CarDealarship.Test.MockTesting
{
    [TestFixture]
    public class MockTesting
    {
        [Test]
        public void CanLoadCarsFromMockRepo()
        {
            IVehicleRepository repo = new MockRepo();
            //var vehicle = repo.GetAll();

            //Assert.AreEqual(7, vehicle.Count);

            //Assert.AreEqual(1, vehicle[0].VehicleId);
            //Assert.AreEqual("Nissan", vehicle[0].Make.MakeName);
            //Assert.AreEqual("Altima", vehicle[0].Model.ModelName);
            //Assert.AreEqual("Red", vehicle[0].Color);
            //Assert.AreEqual("Black", vehicle[0].Interior);
            //Assert.AreEqual("Automatic", vehicle[0].Transmission);
            //Assert.AreEqual("1XP7DU9X48D704313", vehicle[0].VinNumber);




        }

        [Test]
        public void CanGetCarByYearMockRepo()
        {
            //IVehicleRepository repo = new MockRepo();
            //var vehicle = repo.GetByYear(1980);

            //Assert.AreEqual(5, vehicle);
            //Assert.AreEqual("BMW", vehicle);
            //Assert.AreEqual("E21", vehicle.Model.ModelName);
            //Assert.AreEqual("White", vehicle.Color.ColorName);

        }

        [Test]
        public void CanGetCarByPriceMockRepo()
        {
            //IVehicleRepository repo = new MockRepo();
            //var vehicle = repo.GetByPrice(4500M);

            //Assert.AreEqual("1XP7DU9X48D72632668", vehicle[0].VinNumber);
            //Assert.AreEqual("1XP7DU9X48D72632068", vehicle[1].VinNumber);
            //Assert.AreEqual(150000, vehicle[0].Mileage);

           

        }

        [Test]
        public void CanGetCarByMakeMockRepo()
        {
            //IVehicleRepository repo = new MockRepo();
            //var vehicle = repo.GetByMake("Audi");

            //Assert.AreEqual("F103", vehicle[0].Model.ModelName);
            //Assert.AreEqual(65000, vehicle[0].MSRP);
            //Assert.AreNotEqual(40000M, vehicle[0].SalePrice);

        }

        [Test]
        public void CanGetCarByModelMockRepo()
        {
            //IVehicleRepository repo = new MockRepo();
            //var vehicle = repo.GetByModel("Altima");
            //Assert.AreEqual(1, vehicle.Count);
            //Assert.AreEqual("Red", vehicle[0].Color);
            //Assert.AreEqual("Black", vehicle[0].Interior);



        }

        [Test]
        public void NewCarSearchResultMockRepo()
        {
            //IVehicleRepository repo = new MockRepo();
           

            //var search = repo.Search(new VehicleSearchParameters { SearchKey = "Tesla" });
            //var search = repo.Search(new VehicleSearchParameters { SearchKey = "3" });

            ////  var search = repo.Search(new VehicleSearchParameters { Make = "Telsa", Model = "3", MaxPrice = 85000, MinPrice = 0, MaxYear = 1970, MinYear = 2017, SearchKey = "Telsa"});
            //Assert.AreEqual(1,search.Count);
          
        }

        [Test]
        public void NewCarSearchByPrice()
        {
            //IVehicleRepository repo = new MockRepo();
            //var minPrice = repo.Search(new VehicleSearchParameters {MinPrice = 94000M });
            //Assert.AreEqual(1, minPrice.Count);
            //Assert.AreNotEqual(2, minPrice.Count);
        }

        [Test]
        public void NewCarSearchByYear()
        {
            //IVehicleRepository repo = new MockRepo();
            //var year = repo.Search(new VehicleSearchParameters { MinYear = 2017 });
            //Assert.AreEqual(1, year.Count);
           
        }
      
    }
}
