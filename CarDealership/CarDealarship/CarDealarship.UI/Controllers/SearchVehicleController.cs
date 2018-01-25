using CarDealarship.Bll;
using CarDealarship.Model.Interface;
using CarDealarship.Model.Queries;
using CarDealarship.Model.Tables;
using CarDealarship.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CarDealarship.UI.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SearchVehicleController : ApiController
    {
        IVehicleRepository repo = CarFactory.Create();
        [Route("api/vehicles/featured")]
        [AcceptVerbs("GET")]
        public IHttpActionResult FeaturedVehicles()
        {
            var featured = repo.GetFeaturedVehicles();
            return Ok(featured);
        }

        [Route("api/vehicles/special")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetSpecial()
        {
            var specials = repo.GetAllSpecials();
            return Ok(specials);
        }


        [Route("api/SearchNewVehicle/SearchVehicle")]
        [AcceptVerbs("POST")]
        public IHttpActionResult SearchNewVehicle(VehicleSearchParameters pram)
        {

            pram.IsNew = true;

            var result = repo.Search(pram);

            return Ok(result);
        }


        [Route("api/SearchOdVehicle/SearchVehicle")]
        [AcceptVerbs("POST")]
        public IHttpActionResult SearchOldVehicle(VehicleSearchParameters prams)
        {

            prams.IsNew = false;

            var result = repo.SearchOldCars(prams);

            return Ok(result);
        }

        [Route("api/SearchSales/Sales")]
        [AcceptVerbs("POST")]
        public IHttpActionResult SearchSales(VehicleSearchParameters prams)
        {
            prams.IsNew = true;
            prams.IsNew = false;

            var result = repo.SearchSales(prams);
            return Ok(result);
        }

        [Route("api/Admin/Vehicle")]
        [AcceptVerbs("POST")]
        public IHttpActionResult AdminSearch(VehicleSearchParameters prams)
        {
            prams.IsNew = true;
            prams.IsNew = false;

            var result = repo.SearchSales(prams);
            return Ok(result);
        }


        [Route("api/Purchase/Sales/{id}")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Purchase(SalesViewModel model)
        {
            var vehicle = repo.GetVehicleById(model.VehicleForPurchase.VehicleId);
            return Ok(vehicle);

        }


        [Route("api/SearchNewVehicle/Details/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetById(int id)
        {
            var toReturn = repo.GetVehicleById(id);
            return Ok(toReturn);
        }

        //[Route("api/Make/GetAllMakes")]
        //[AcceptVerbs("GET")]
        //public IHttpActionResult GetAllMakes()
        //{
        //    var toReturn = repo.GetAllMakes();
        //    return Ok(toReturn);
        //}

        [Route("api/Specials/GetAllSpecials")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllSpecials()
        {
            var specials = repo.GetAllSpecials();
            return Ok(specials);
        }



    }

}
    

