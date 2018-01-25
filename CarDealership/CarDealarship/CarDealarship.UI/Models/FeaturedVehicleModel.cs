using CarDealarship.Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealarship.UI.Models
{
    public class FeaturedVehicleModel
    {
        public int Year { get; set; }
        public Make Make { get; set; }
        //public Models Model { get; set; }
        public string Interior { get; set; }
        public string TransmissionType { get; set; }
        public string Color { get; set; }
        public int MyProperty { get; set; }
        public string VehicleType { get; set; }
        public int Mileage { get; set; }
        public string VinNumber { get; set; }
        public decimal Price { get; set; }
        public decimal MSRP { get; set; }
    }
}