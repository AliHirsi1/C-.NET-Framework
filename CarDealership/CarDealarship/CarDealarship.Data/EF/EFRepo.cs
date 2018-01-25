using CarDealarship.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using CarDealarship.Model.Tables;
using CarDealarship.Model.Queries;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CarDealarship.Data.EF
{
    public class EFRepo : IVehicleRepository
    {
        CarDealarshipEntities context = new CarDealarshipEntities();
        public List<Make> _makes;

        public List<Specials> _spcials;

        public List<Vehicle> GetAll()
        {
            using (var ctx = new CarDealarshipEntities())
            {
                return ctx.Vehicle.ToList();
            }
           
        }

        public List<Vehicle> GetByMake(string make)
        {
            using (var ctx = new CarDealarshipEntities())
            {
                return ctx.Vehicle.Where(v => v.ModelId.Make.MakeName == make).ToList();
            }           
        }

        public List<Vehicle> GetByModel(string model)
        {
            using (var ctx = new CarDealarshipEntities())
            {
                return ctx.Vehicle.Where(v => v.ModelId.ModelName == model).ToList();
            }
        }

        public List<Vehicle> GetByPrice(decimal price)
        {
            using (var ctx = new CarDealarshipEntities())
            {
                return ctx.Vehicle.Where(v => v.SalesPrice == price).ToList();
            }

        }

        public List<Vehicle> GetByYear(int year)
        {
            return context.Vehicle.Where(y => y.Year == year).ToList();

        }

        public Vehicle GetVehicleById(int id)
        {
            using (var ctx = new CarDealarshipEntities())
            {
                return ctx.Vehicle.Include("MakeId").Include("ModelId").Where(v => v.VehicleId == id).FirstOrDefault();
            }
        }

        public List<Vehicle> GetFeaturedVehicles()
        {
            using (var ctx = new CarDealarshipEntities())
            {
                
                return ctx.Vehicle.Include("MakeId").Include("ModelId").Where(f => f.IsFeatured == true && !ctx.Sales.Any(s => s.VehicleId == f.VehicleId)).ToList();
            }          
        }

        public List<Specials> GetAllSpecials()
        {

            return context.Specials.ToList();
        }

        public List<Vehicle> Search(VehicleSearchParameters pram)
        {
         
            var query = context.Vehicle.Where(i => i.IsNew == pram.IsNew && !context.Sales.Any(s => s.VehicleId == i.VehicleId));

            
            if (!String.IsNullOrWhiteSpace(pram.SearchKey))
            {
                query = query.Where(i => i.MakeId.MakeName.Contains(pram.SearchKey)
                || i.ModelId.ModelName.Contains(pram.SearchKey)
                || i.Year.ToString() == pram.SearchKey);
            }

            if (pram.MinPrice.HasValue && pram.MaxPrice.HasValue)
            {
                query = query.Where(i => i.SalesPrice >= pram.MinPrice.Value && i.SalesPrice <= pram.MaxPrice.Value);
            }
            else
            {
                if (pram.MinPrice.HasValue)
                {
                    query = query.Where(i => i.SalesPrice >= pram.MaxPrice.Value);
                }
                if (pram.MaxPrice.HasValue)
                {
                    query = query.Where(i => i.SalesPrice <= pram.MaxPrice.Value);
                }

            }
            
            if (pram.MinYear.HasValue && pram.MaxYear.HasValue)
            {
                query = query.Where(i => i.Year >= pram.MinYear.Value && i.Year <= pram.MaxYear.Value);
            }
            else
            {
                if (pram.MinYear.HasValue)
                {
                    query = query.Where(i => i.Year > pram.MinYear);
                }
                if (pram.MaxYear.HasValue)
                {
                    query = query.Where(i => i.Year > pram.MaxYear);
                }

            }

            
            
                return query.ToList();
        }

        public List<Vehicle>SearchOldCars(VehicleSearchParameters prams)
        {

            var query = context.Vehicle.Where(i => i.IsNew != prams.IsNew && !context.Sales.Any(s => s.VehicleId == i.VehicleId));


            if (!String.IsNullOrWhiteSpace(prams.SearchKey))
            {
                query = query.Where(i => i.MakeId.MakeName.Contains(prams.SearchKey)
                || i.ModelId.ModelName.Contains(prams.SearchKey)
                || i.Year.ToString() == prams.SearchKey);
            }

            if (prams.MinPrice.HasValue && prams.MaxPrice.HasValue)
            {
                query = query.Where(i => i.SalesPrice >= prams.MinPrice.Value && i.SalesPrice <= prams.MaxPrice.Value);
            }
            else
            {
                if (prams.MinPrice.HasValue)
                {
                    query = query.Where(i => i.SalesPrice >= prams.MaxPrice.Value);
                }
                if (prams.MaxPrice.HasValue)
                {
                    query = query.Where(i => i.SalesPrice <= prams.MaxPrice.Value);
                }

            }

            if (prams.MinYear.HasValue && prams.MaxYear.HasValue)
            {
                query = query.Where(i => i.Year >= prams.MinYear.Value && i.Year <= prams.MaxYear.Value);
            }
            else
            {
                if (prams.MinYear.HasValue)
                {
                    query = query.Where(i => i.Year > prams.MinYear);
                }
                if (prams.MaxYear.HasValue)
                {
                    query = query.Where(i => i.Year > prams.MaxYear);
                }

            }


            return query.ToList();
        }

        //public Sales GetSalesById(int UserId)
        //{
        //    using (var ctx = new CarDealarshipEntities())
        //    {
        //        return ctx.Sales.FirstOrDefault(s => s.SaleId == UserId);
        //    }
        //}
                

        public List<Vehicle> SearchSales(VehicleSearchParameters pram)
        {
            var query = context.Vehicle.Where(i => i.IsNew == pram.IsNew || i.IsNew != pram.IsNew && !context.Sales.Any(s => s.VehicleId == i.VehicleId));


            if (!String.IsNullOrWhiteSpace(pram.SearchKey))
            {
                query = query.Where(i => i.MakeId.MakeName.Contains(pram.SearchKey)
                || i.ModelId.ModelName.Contains(pram.SearchKey)
                || i.Year.ToString() == pram.SearchKey);
            }

            if (pram.MinPrice.HasValue && pram.MaxPrice.HasValue)
            {
                query = query.Where(i => i.SalesPrice >= pram.MinPrice.Value && i.SalesPrice <= pram.MaxPrice.Value);
            }
            else
            {
                if (pram.MinPrice.HasValue)
                {
                    query = query.Where(i => i.SalesPrice >= pram.MaxPrice.Value);
                }
                if (pram.MaxPrice.HasValue)
                {
                    query = query.Where(i => i.SalesPrice <= pram.MaxPrice.Value);
                }

            }

            if (pram.MinYear.HasValue && pram.MaxYear.HasValue)
            {
                query = query.Where(i => i.Year >= pram.MinYear.Value && i.Year <= pram.MaxYear.Value);
            }
            else
            {
                if (pram.MinYear.HasValue)
                {
                    query = query.Where(i => i.Year > pram.MinYear);
                }
                if (pram.MaxYear.HasValue)
                {
                    query = query.Where(i => i.Year > pram.MaxYear);
                }

            }


            return query.Take(5).ToList();
        }

        public List<Make> GetAllMakes()
        {
            using (var ctx = new CarDealarshipEntities())
            {
                var ur = ctx.Users.ToList();
                var result = ctx.Make.ToList();
                foreach (var r in result)
                {
                    r.user = ctx.Users.First(u => u.Id == r.UserId);
                }
                //result.First().user.c
                return result.ToList();
            }
        }

        public List<Models> GetAllModel()
        {
            using (var ctx = new CarDealarshipEntities())
            {
                var ur = ctx.Users.ToList();
                var result = ctx.Models.Include("Make").ToList();
                foreach (var r in result)
                {
                    r.user = ctx.Users.First(u => u.Id == r.UserId);
                }

                return ctx.Models.ToList();
            }
        }

        public void AddVehicle(Vehicle car)
        {
            using (var ctx = new CarDealarshipEntities())
            {
                if(ctx.Vehicle.Count()== 0)
                {
                    car.VehicleId = 1;
                }
                else
                {
                    car.VehicleId = ctx.Vehicle.Include("MakeId").Include("ModelId").Max(v => v.VehicleId) + 1;
                }
                ctx.Vehicle.Add(car);
                ctx.SaveChanges();
            }            
        }

        public void EditVehicle(Vehicle car)
        {
            using (var ctx = new CarDealarshipEntities())
            {
                var original = ctx.Vehicle.FirstOrDefault(m => m.VehicleId == car.VehicleId);
                original.ModelId = ctx.Models.FirstOrDefault(m => m.ModelId == car.ModelId.ModelId);
                original.MakeId = ctx.Make.FirstOrDefault(m => m.MakeId == car.MakeId.MakeId);

                original.Color = car.Color;
                original.Description = car.Description;
                original.Color = car.Color;
                original.Interior = car.Interior;
                original.IsNew = car.IsNew;
                original.Mileage = car.Mileage;
                original.MSRP = car.MSRP;
                original.Transmission = car.Transmission;
                original.Year = car.Year;
                original.VinNumber = car.VinNumber;
                original.SalesPrice = car.SalesPrice;
                original.Description = car.Description;
                original.VehicleType = car.VehicleType;
                original.VehicleId = car.VehicleId;
                original.ImageFileName = "Images/" + car.ImageFileName;
               

                ctx.SaveChanges();
            }

        }

        public Make GetMakeById(int id)
        {
            using (var ctx = new CarDealarshipEntities())
            {
               return ctx.Make.Where(m => m.MakeId == id).FirstOrDefault();
            }
        }

        public Models GetModelById(int id)
        {
            using (var ctx = new CarDealarshipEntities())
            {
                return ctx.Models.Where(m => m.ModelId == id).FirstOrDefault();
            }
        }

        public List<Users> GetAllUsers()
        {
            using (var ctx = new CarDealarshipEntities())
            {
                return ctx.Users.Include("Roles").ToList();
            }
        }
        

        public Users GetUserById(string role)
        {
            using (var ctx = new CarDealarshipEntities())
            {
                return ctx.Users.FirstOrDefault(m => m.Id == role);
            }

        }

        public void AddUser(Users user)
        {
            var userMgr = new UserManager<Users>(new UserStore<Users>(context));

        }

        public void AddMake(Make newMake)
        {

            using (var ctx = new CarDealarshipEntities())
            {
                if (ctx.Make.Count() == 0)
                {
                    newMake.MakeId = 1;
                }
                else
                {
                    newMake.MakeId = ctx.Make.Max(m => m.MakeId) + 1;
                }
                ctx.Make.Add(newMake);
                ctx.SaveChanges();
            }

        }

        public void PurchaseVehicle(Sales sale)
        {
            using (var ctx = new CarDealarshipEntities())
            {
                if (ctx.Sales.Count() == 0)
                {
                    sale.SaleId = 1;
                }
                else
                {
                    sale.SaleId = ctx.Sales.Max(s => s.SaleId) + 1;
                }
                ctx.Sales.Add(sale);
                ctx.SaveChanges();
            }
        }

        public void AddSpecial(Specials special)
        {
            using (var ctx = new CarDealarshipEntities())
            {
                if (ctx.Specials.Count() == 0)
                {
                    special.SpecialId = 1;
                }
                else
                {
                    special.SpecialId = ctx.Specials.Max(m => m.SpecialId) + 1;
                }
                ctx.Specials.Add(special);
                ctx.SaveChanges();
            }

        }

        public void AddModel(Models newModel)
        {
            using (var ctx = new CarDealarshipEntities())
            {
                if (ctx.Models.Count() == 0)
                {
                     newModel.ModelId = 1;
                }
                else
                {
                    newModel.ModelId = ctx.Models.Max(m => m.ModelId) + 1;
                }
                ctx.Models.Add(newModel);
                ctx.SaveChanges();
            }
        }

        public void DeleteSpecial(int specialId)
        {
            Specials sp = context.Specials.Find(specialId);
            context.Specials.Remove(sp);
            context.SaveChanges();
        }

        public Specials GetSpecialById(int id)
        {
            return context.Specials.FirstOrDefault(sp => sp.SpecialId == id);
        }

        public void AddContactUs(ContactUs contact)
        {
            using (var ctx = new CarDealarshipEntities())
            {
                if (ctx.ContactUs.Count() == 0)
                {
                    contact.ContactUsId = 1;
                }
                else
                {
                    contact.ContactUsId = ctx.ContactUs.Max(c => c.ContactUsId) + 1;
                }
                ctx.ContactUs.Add(contact);
                ctx.SaveChanges();
            }
        }

       
        public List<IdentityRole> GetAllRoles()
        {
            throw new NotImplementedException();
        }
    }
}
