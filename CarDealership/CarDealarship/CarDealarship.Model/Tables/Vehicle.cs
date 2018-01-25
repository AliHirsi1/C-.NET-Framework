using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealarship.Model.Tables
{
    public class Vehicle
    {


        public int VehicleId { get; set; }

        public virtual Make MakeId { get; set; }

        public virtual Models ModelId { get; set; }

        [Required]
        public string Interior { get; set; }

        [Required]
        public string VehicleType { get; set; }

        [Required]
        public decimal SalesPrice { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public int Mileage { get; set; }


        [Required]
        public string VinNumber { get; set; }

        [Required]
        public decimal MSRP { get; set; }

        [Required]
        public string Transmission { get; set; }

        [Required]
        public bool IsFeatured { get; set; }

        //[Required]
        public string ImageFileName { get; set; }
        public Byte[] Image { get; set; }
        public bool IsNew { get; set; }
        public string Description { get; set; }


    }


}
