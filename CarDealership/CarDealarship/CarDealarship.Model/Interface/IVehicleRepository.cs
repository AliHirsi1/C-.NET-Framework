using CarDealarship.Model.Queries;
using CarDealarship.Model.Tables;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CarDealarship.Model.Interface
{
    public interface IVehicleRepository
    {
        List<Vehicle> GetFeaturedVehicles();
        List<Vehicle> GetAll();
        List<Vehicle> GetByYear(int year);
        List<Vehicle> GetByPrice(decimal price);
        Vehicle GetVehicleById(int id);
        List<Vehicle> GetByMake(string make);
        List<Vehicle> GetByModel(string model);
        List<Vehicle> Search(VehicleSearchParameters pram);
        List<Vehicle> SearchOldCars(VehicleSearchParameters pram);
        List<Specials> GetAllSpecials();
        void AddSpecial(Specials special);
        List<Vehicle> SearchSales(VehicleSearchParameters pram);
        List<Make> GetAllMakes();
        List<Models> GetAllModel();
        void AddVehicle(Vehicle car);
        void EditVehicle(Vehicle car);
        Make GetMakeById(int id);
        Models GetModelById(int id);
        List<Users> GetAllUsers();
        Users GetUserById(string role);
        void AddUser(Users user);
        void AddMake(Make newMake);
        void AddModel(Models newModel);
        void AddContactUs(ContactUs contact);
        void PurchaseVehicle(Sales sale);
        Specials GetSpecialById(int id);
        void DeleteSpecial(int specialId);
        List<IdentityRole> GetAllRoles();
        //void PurchaseVehicle(SalesViewModel model, int SalesPerson);





    }
}
