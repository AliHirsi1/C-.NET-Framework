using CarDealarship.Model.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using System.Web.WebPages.Html;

namespace CarDealarship.UI.Models
{
    public class AddVehicleViewModel
    {
        public int VehicleId { get; set; }
        public Vehicle AddVehicles { get; set; }
        public int VehicleMakeId { get; set; }
        public int VehicleModelId { get; set; }


        [Required]
        public HttpPostedFileBase ImageFile { get; set; }

        public List<SelectListItem> MakeItems { get; set; }
        public List<SelectListItem> ModelItems { get; set; }
        public List<SelectListItem> TypeItems { get; set; }
        public List<SelectListItem> BodyStyleItems { get; set; }
        public List<SelectListItem> TransmissionItems { get; set; }
        public List<SelectListItem> ColorItems { get; set; }
        public List<SelectListItem> InteriorItems { get; set; }

        public AddVehicleViewModel()
        {
            MakeItems = new List<SelectListItem>();
            ModelItems = new List<SelectListItem>();
            TypeItems = new List<SelectListItem>();
            BodyStyleItems = new List<SelectListItem>();
            TransmissionItems = new List<SelectListItem>();
            ColorItems = new List<SelectListItem>();
            InteriorItems = new List<SelectListItem>();
        }

        public void SetMakeItems(IEnumerable<Make> makes)
        {
            foreach (var make in makes)
            {
                MakeItems.Add(new SelectListItem()
                {
                    Value = make.MakeId.ToString(),
                    Text = make.MakeName
                });
            }
        }

        public void SetModelItems(IEnumerable<CarDealarship.Model.Tables.Models> models)
        {
            foreach (var model in models)
            {
                ModelItems.Add(new SelectListItem()
                {
                    Value = model.ModelId.ToString(),
                    Text = model.ModelName
                });
            }
        }

        public void SetTypeItems()
        {

            TypeItems.Add(new SelectListItem
            {
                Value = "true",
                Text = "true",

            });

            TypeItems.Add(new SelectListItem
            {
                Value = "false",
                Text = "false"

            });


        }

        public void SetBodyStyleItems()
        {

            BodyStyleItems.Add(new SelectListItem()
            {
                Value = "Sedan",
                Text = "Sedan",
            });
            BodyStyleItems.Add(new SelectListItem()
            {
                Value = "SUV",
                Text = "SUV"
            });

        }

        public void SetTransmissionItems()
        {

            TransmissionItems.Add(new SelectListItem
            {
                Value = "Automatic",
                Text = "Automatic"
            });
            TransmissionItems.Add(new SelectListItem
            {
                Value = "Manual",
                Text = "Manual"
            });

        }

        public void SetColorItems()
        {
            ColorItems.Add(new SelectListItem
            {
                Value = "Red",
                Text = "Red"

            });
            ColorItems.Add(new SelectListItem
            {
                Value = "White",
                Text = "White"

            });
            ColorItems.Add(new SelectListItem
            {
                Value = "Silver",
                Text = "Silver"

            });
        }

        public void SetInteriorItems()
        {

            InteriorItems.Add(new SelectListItem
            {
                Value = "White",
                Text = "White"
            });
            InteriorItems.Add(new SelectListItem
            {
                Value = "Black",
                Text = "Black"
            });
            InteriorItems.Add(new SelectListItem
            {
                Value = "Fabric",
                Text = "Fabric"
            });

        }




    }
}