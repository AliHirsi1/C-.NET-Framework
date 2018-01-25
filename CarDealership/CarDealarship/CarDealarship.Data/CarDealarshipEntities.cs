using CarDealarship.Model.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CarDealarship.Data
{
    public class CarDealarshipEntities : IdentityDbContext<Users>
    {
        public CarDealarshipEntities()
            : base("CarDealarship")
        {

        }

        public DbSet<City> City { get; set; }       
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Make> Make { get; set; }
        public DbSet<Models> Models { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<States> States { get; set; }
        public DbSet<Specials> Specials { get; set; }       
        public DbSet<Vehicle> Vehicle { get; set; }
        


    }

   
}
