using CarDealarship.Bll;
using CarDealarship.Data.EF;
using CarDealarship.Model.Interface;
using CarDealarship.Model.Tables;
using CarDealarship.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealarship.UI.Controllers
{
    public class HomeController : Controller
    {

        IVehicleRepository ctxs = CarFactory.Create();
        public ActionResult Index()
        {
            //var vehicles = this.featured.GetFeaturedVehicles();
            return View(/*vehicles*/);
        }

        public ActionResult SearchVehicle()
        {
            ViewBag.IsNew = true;
            ViewBag.Title = "New Vehicles.";

            return View();
        }

        public ActionResult SearchOldVehicle()
        {
            ViewBag.isNew = false;
            ViewBag.Title = "Used Vehicles";
            return View();
        }

        [HttpGet]
        public ActionResult Purchase()
        {
            var model = new SalesViewModel();
            string vehicleId = Request.QueryString["id"];
            model.VehicleId = int.Parse(vehicleId);



            model.SetStatesItems();
            model.SetPurchaseTypeItems();
            return View(model);
        }

        [HttpPost]
        public ActionResult Purchase(SalesViewModel model)
        {


            Sales carToBuy = new Sales();
            carToBuy.FirstName = model.FirstName;
            carToBuy.LastName = model.LastName;
            carToBuy.Phone = model.Phone;
            carToBuy.Email = model.Email;
            carToBuy.Street1 = model.Street1;
            carToBuy.Street2 = model.Street2;
            carToBuy.State = model.State;
            carToBuy.City = model.City;
            carToBuy.Date = DateTime.Now;

            if (model.ZipCode == 0)
            {
                ModelState.AddModelError("ZipCode", " five digit zip is required!");
            }
            carToBuy.ZipCode = model.ZipCode;
            carToBuy.PurchasePrice = model.PurchasePrice.Value;
            carToBuy.PurchaseType = model.PurchaseType;
            carToBuy.VehicleId = model.VehicleId;

            ctxs.PurchaseVehicle(carToBuy);

            return RedirectToAction("Sales");

        }

        public ActionResult Details(int id)
        {
            Vehicle vehicle = new Vehicle();
            var repo = CarFactory.Create();
            vehicle = repo.GetVehicleById(id);
            return View(vehicle);

        }

        public ActionResult Specials()
        {

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            var model = new ContactVM();

            return View(model);
        }

        [HttpPost]
        public ActionResult ContactUs(ContactVM contact)
        {
            ContactUs newContact = new Model.Tables.ContactUs();
            newContact.FirstName = contact.FirstName;
            newContact.LastName = contact.LastName;
            newContact.Email = contact.Email;
            newContact.Phone = contact.Phone;
            newContact.Message = contact.Message;

            ctxs.AddContactUs(newContact);

            return RedirectToAction("Index");
        }

        public ActionResult Sales()
        {
            ViewBag.Title = "Sales";
            return View();
        }

        public ActionResult AddVehicle()
        {
            ViewBag.Title = "AddVehicle";
            return View();
        }
    }
}