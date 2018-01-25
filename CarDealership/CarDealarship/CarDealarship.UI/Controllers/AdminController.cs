using CarDealarship.Bll;
using CarDealarship.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarDealarship.Model.Tables;
using System.IO;
using CarDealarship.Model.Interface;
using CarDealarship.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using CarDealarship.UI.Models;

namespace CarDealarship.UI.Controllers
{

    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        IVehicleRepository ctxs = CarFactory.Create();
        CarDealarshipEntities context = new CarDealarshipEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Vehicle()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddVehicle()
        {
            var model = new AddVehicleViewModel();
            model.SetMakeItems(CarFactory.Create().GetAllMakes());
            model.SetModelItems(CarFactory.Create().GetAllModel());
            model.SetBodyStyleItems();
            model.SetTypeItems();
            model.SetTransmissionItems();
            model.SetColorItems();
            model.SetInteriorItems();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddVehicle(AddVehicleViewModel model)
        {

            if (model.ImageFile == null || model.ImageFile.ContentLength <= 0)
            {
                ModelState.AddModelError(model.ImageFile.ToString(), "Image is required");
            }
            if (model.ImageFile != null && model.ImageFile.ContentLength > 0)
            {
                var path = Server.MapPath("~/Images");

                string file = Path.GetFileName(model.ImageFile.FileName);
                string filePath = Path.GetExtension(model.ImageFile.FileName);

                var wholefile = Path.Combine(path, file + filePath);

                int counter = 1;
                while (System.IO.File.Exists(filePath))
                {
                    wholefile = Path.Combine(path, file + counter.ToString() + filePath);
                    counter++;
                }

                model.ImageFile.SaveAs(wholefile);



            }

            if (ModelState.IsValid)
            {

                Vehicle vehicleToAdd = new Vehicle();
                vehicleToAdd.VehicleId = model.VehicleId;
                vehicleToAdd.Color = model.AddVehicles.Color;
                vehicleToAdd.Interior = model.AddVehicles.Interior;
                vehicleToAdd.IsNew = model.AddVehicles.IsNew;
                vehicleToAdd.Mileage = model.AddVehicles.Mileage;
                vehicleToAdd.MSRP = model.AddVehicles.MSRP;
                vehicleToAdd.Transmission = model.AddVehicles.Transmission;
                vehicleToAdd.Year = model.AddVehicles.Year;
                vehicleToAdd.VinNumber = model.AddVehicles.VinNumber;
                vehicleToAdd.SalesPrice = model.AddVehicles.SalesPrice;
                vehicleToAdd.Description = model.AddVehicles.Description;
                vehicleToAdd.MakeId = ctxs.GetMakeById(model.VehicleMakeId);
                vehicleToAdd.ModelId = ctxs.GetModelById(model.VehicleModelId);
                vehicleToAdd.VehicleType = model.AddVehicles.VehicleType;
                vehicleToAdd.ImageFileName = "Images/" + model.ImageFile.FileName;

                ctxs.AddVehicle(vehicleToAdd);

            }

            return RedirectToAction("Vehicle");

        }

        [HttpGet]
        public ActionResult EditVehicle(int id)
        {

            var model = new AddVehicleViewModel();
            model.AddVehicles = ctxs.GetVehicleById(id);
            

            model.SetMakeItems(CarFactory.Create().GetAllMakes());
            model.SetModelItems(CarFactory.Create().GetAllModel());
            model.SetBodyStyleItems();
            model.SetTransmissionItems();
            model.SetTypeItems();
            model.SetColorItems();
            model.SetInteriorItems();
            

           
            return View(model);
        }


        [HttpPost]
        public ActionResult EditVehicle(AddVehicleViewModel model)
        {
            if (model.ImageFile == null || model.ImageFile.ContentLength <= 0)
            {
                ModelState.AddModelError(model.ImageFile.ToString(), "Image is required");
            }
            if (model.ImageFile != null && model.ImageFile.ContentLength > 0)
            {
                var path = Server.MapPath("~/Images");

                string file = Path.GetFileName(model.ImageFile.FileName);
                string filePath = Path.GetExtension(model.ImageFile.FileName);

                var wholefile = Path.Combine(path, file + filePath);

                int counter = 1;
                while (System.IO.File.Exists(filePath))
                {
                    wholefile = Path.Combine(path, file + counter.ToString() + filePath);
                    counter++;
                }

                model.ImageFile.SaveAs(wholefile);


                if (ModelState.IsValid)
                {


                    Vehicle vehicleToEdit = new Vehicle();
                    vehicleToEdit.Color = model.AddVehicles.Color;
                    vehicleToEdit.Interior = model.AddVehicles.Interior;
                    vehicleToEdit.IsNew = model.AddVehicles.IsNew;
                    vehicleToEdit.Mileage = model.AddVehicles.Mileage;
                    vehicleToEdit.MSRP = model.AddVehicles.MSRP;
                    vehicleToEdit.Transmission = model.AddVehicles.Transmission;
                    vehicleToEdit.Year = model.AddVehicles.Year;
                    vehicleToEdit.VinNumber = model.AddVehicles.VinNumber;
                    vehicleToEdit.SalesPrice = model.AddVehicles.SalesPrice;
                    vehicleToEdit.Description = model.AddVehicles.Description;
                    vehicleToEdit.MakeId = ctxs.GetMakeById(model.VehicleMakeId);
                    vehicleToEdit.ModelId = ctxs.GetModelById(model.VehicleModelId);
                    vehicleToEdit.VehicleType = model.AddVehicles.VehicleType;
                    vehicleToEdit.VehicleId = model.AddVehicles.VehicleId;
                    vehicleToEdit.ImageFileName = "Images/" + model.ImageFile.FileName;

                    ctxs.EditVehicle(vehicleToEdit);
                }
            }
            return RedirectToAction("Vehicle");

        }

        [HttpGet]
        public ActionResult Users()
        {
            List<UserViewModel> listUsers = new List<UserViewModel>();
            var model = ctxs.GetAllUsers();
            foreach (var u in model)
            {
                var rol = u.Roles.Take(1).ToList()[0];
                listUsers.Add(new UserViewModel()
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Role = context.Roles.First(r => r.Id == rol.RoleId).Name


                });
            }
            return View(listUsers);
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            var model = new UserViewModel();
            model.SetRoleItems();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddUser(UserViewModel model)
        {
            Users user = new Model.Tables.Users();
            var usr = new UserManager<Users>(new UserStore<Users>(context));

            if (model.Password != model.ConfirmPassword)
            {
                ModelState.AddModelError("Password", "Password do not match!");
                model.SetRoleItems();
                return View(model);
            }

            if (ModelState.IsValid)
            {
                
                              
                user.UserName = model.Email;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;


                if (!usr.Users.Any(u => u.UserName == user.UserName))
                {
                    var createResult = usr.Create(user, model.Password);
                }
                else
                {
                    ModelState.AddModelError("Email", "Email do exist!");
                    model.SetRoleItems();
                    return View(model);
                }

                var userRole = usr.FindByName(user.UserName);

                if (!usr.IsInRole(userRole.Id, model.Role))
                {
                    usr.AddToRole(userRole.Id, model.Role);
                }


                return RedirectToAction("Users");
            }
            else
            {
                return View(model);
            }

        }

        [HttpGet]
        public ActionResult EditUser(string id)
        {
            var model = new EditUserViewModel();
            model.SetRoleItems();
            model.User = ctxs.GetUserById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditUser(EditUserViewModel model)
        {

            var usr = new UserManager<Users>(new UserStore<Users>(context));
            var findUser = usr.FindById(model.User.Id);
            if (model.Password != model.ConfirmPassword)
            {

                ModelState.AddModelError("Password", "Passwords do not match!");
                model.SetRoleItems();
                return View(model);

            }
            else
            {
                usr.ChangePassword(model.User.Id, model.Password, model.ConfirmPassword);
            }

            if (ModelState.IsValid)
            {
                var userbyId = usr.FindById(findUser.Id);
                var userRole = usr.GetRoles(findUser.Id);

                usr.RemoveFromRoles(userbyId.Id, userRole.ToArray());

                usr.AddToRole(userbyId.Id, model.Role);

                userbyId.FirstName = model.User.FirstName;
                userbyId.LastName = model.User.LastName;
                userbyId.Email = model.User.Email;
                

                usr.Update(userbyId);

               
            }

            return RedirectToAction("Users");
        }

        [HttpGet]
        public ActionResult Make()
        {
            var model = new MakeViewModel();
            model.Makes = ctxs.GetAllMakes();
            return View(model);
        }

        [HttpPost]
        public ActionResult Make(MakeViewModel model)
        {
            Make makeToAdd = new Model.Tables.Make();
            makeToAdd.MakeName = model.MakeName;
            makeToAdd.Date = DateTime.Now;
            makeToAdd.UserId = UserLogIn.User.Id;
            ctxs.AddMake(makeToAdd);

            return RedirectToAction("Make");

        }

        [HttpGet]
        public ActionResult Modells()
        {
            var model = new ModelViewModel();

            model.Models = ctxs.GetAllModel();
            model.SetMakeItems(CarFactory.Create().GetAllMakes());
            return View(model);

        }

        [HttpPost]
        public ActionResult Modells(ModelViewModel model)
        {
            CarDealarship.Model.Tables.Models modelToAdd = new CarDealarship.Model.Tables.Models();
            modelToAdd.MakeId = model.MakeId;
            modelToAdd.ModelName = model.ModelName;
            modelToAdd.Date = DateTime.Now;
            modelToAdd.UserId = UserLogIn.User.Id;


            ctxs.AddModel(modelToAdd);

            return RedirectToAction("Modells");
        }


        [HttpGet]
        public ActionResult Specials()
        {
            var model = new SpecialVM();
            model.Special = ctxs.GetAllSpecials();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddSpecials(SpecialVM sp)
        {
            Specials specialToAdd = new Model.Tables.Specials();
            specialToAdd.Title = sp.Title;
            specialToAdd.Message = sp.Message;

            ctxs.AddSpecial(specialToAdd);

            return RedirectToAction("Specials");

        }

        [HttpGet]
        public ActionResult DeleteSpecial(int id)
        {
            var model = CarFactory.Create();
            model.GetSpecialById(id);

            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteSpecials(Specials sp)
        {
            var repo = CarFactory.Create();
            repo.DeleteSpecial(sp.SpecialId);
            return RedirectToAction("Specials");

        }



    }
}