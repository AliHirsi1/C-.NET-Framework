namespace CarDealarship.Data.Migrations
{
    using CarDealarship.Model.Tables;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarDealarship.Data.CarDealarshipEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CarDealarship.Data.CarDealarshipEntities context)
        {
            var userMgr = new UserManager<Users>(new UserStore<Users>(context));
            var roleMgr = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleMgr.RoleExists("Sales"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Sales";
                roleMgr.Create(role);
            }

            if (!userMgr.Users.Any(u => u.UserName == "Sales1"))
            {
                var user = new Users()
                {
                    UserName = "Sales1",
                    FirstName = "Nah",
                    LastName = "Doul",
                    Email = "nah@guild.com"
                };
                userMgr.Create(user, "car123456789");
            }
            var findmanager = userMgr.FindByName("Sales1");
            // create the user with the manager class
            if (!userMgr.IsInRole(findmanager.Id, "Sales1"))
            {
                userMgr.AddToRole(findmanager.Id, "Sales");
            }

            if (!roleMgr.RoleExists("IsDisabled"))
            {
                roleMgr.Create(new IdentityRole()
                {
                    Name = "IsDisabled"

                });
            }



            if (!userMgr.Users.Any(u => u.UserName == "Sales2"))
            {
                var user = new Users()
                {
                    UserName = "Sales2",
                    FirstName = "Hanad",
                    LastName = "Abdulahi",
                    Email = "hanad@guild.com"
                };
                userMgr.Create(user, "car123456789");
            }
            findmanager = userMgr.FindByName("Sales2");
            // create the user with the manager class
            if (!userMgr.IsInRole(findmanager.Id, "Sales2"))
            {
                userMgr.AddToRole(findmanager.Id, "Sales");
            }



            if (!userMgr.Users.Any(u => u.UserName == "Sales3"))
            {
                var user = new Users()
                {
                    UserName = "Sales3",
                    FirstName = "Milaho",
                    LastName = "Weholu",
                    Email = "Mila@guild.com"
                };
                userMgr.Create(user, "car123456789");
            }
            findmanager = userMgr.FindByName("Sales3");
            // create the user with the manager class
            if (!userMgr.IsInRole(findmanager.Id, "Sales3"))
            {
                userMgr.AddToRole(findmanager.Id, "Sales");
            }

            if (!userMgr.Users.Any(u => u.UserName == "Sales4"))
            {
                var user = new Users()
                {
                    UserName = "Sales4",
                    FirstName = "James",
                    LastName = "Smith",
                    Email = "jsmith@guild.com"
                };
                userMgr.Create(user, "car123456789");
            }
            findmanager = userMgr.FindByName("Sales4");
            // create the user with the manager class
            if (!userMgr.IsInRole(findmanager.Id, "Sales"))
            {
                userMgr.AddToRole(findmanager.Id, "Sales");
            }


            if (!roleMgr.RoleExists("Admin"))
            {
                roleMgr.Create(new IdentityRole() { Name = "Admin" });
            }

            if (!userMgr.Users.Any(u => u.UserName == "Admin"))
            {
                var user = new Users()
                {
                    UserName = "Admin",
                    FirstName = "Ali",
                    LastName = "Hirsi",
                    Email = "ali@guild.com"
                };
                userMgr.Create(user, "car123456789");
            }
            var finduser = userMgr.FindByName("Admin");
            // create the user with the manager class
            if (!userMgr.IsInRole(finduser.Id, "Admin"))
            {
                userMgr.AddToRole(finduser.Id, "Admin");
            }

        }
    }
}
