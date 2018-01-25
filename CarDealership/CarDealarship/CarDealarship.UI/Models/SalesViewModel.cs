using CarDealarship.Model.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealarship.UI.Models
{
    public class SalesViewModel
    {
        public int id { get; set; }
        public int VehicleId { get; set; }

        public Vehicle VehicleForPurchase { get; set; }

        public int SalesId { get; set; }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Street1 { get; set; }

        public string Street2 { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [StringLength(2)]
        public string State { get; set; }

        [Required]
        public int ZipCode { get; set; }

        [Required]
        public decimal? PurchasePrice { get; set; }

        [Required]
        public string PurchaseType { get; set; }

        [Required]
        public int PurchaseId { get; set; }


        public List<SelectListItem> StatesItems { get; set; }
        public List<SelectListItem> PurchaseTypeItems { get; set; }


        public SalesViewModel()
        {
            StatesItems = new List<SelectListItem>();
            PurchaseTypeItems = new List<SelectListItem>();
        }


        public void SetStatesItems()
        {

            StatesItems.Add(new SelectListItem()
            {
                Value = "MN",
                Text = "MN"
            });

            StatesItems.Add(new SelectListItem()
            {
                Value = "OH",
                Text = "OH"
            });

            StatesItems.Add(new SelectListItem()
            {
                Value = "WI",
                Text = "WI"
            });

        }

        public void SetPurchaseTypeItems()
        {
            PurchaseTypeItems.Add(new SelectListItem()
            {
                Value = "Dealar Finance",
                Text = "Dealar Finance"
            });

            StatesItems.Add(new SelectListItem()
            {
                Value = "Bank Finance",
                Text = "Bank Finance"
            });

            StatesItems.Add(new SelectListItem()
            {
                Value = "Cash",
                Text = "Cash"
            });

        }
    }
}