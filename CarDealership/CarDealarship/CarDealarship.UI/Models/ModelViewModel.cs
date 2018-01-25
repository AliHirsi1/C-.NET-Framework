using CarDealarship.Model.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealarship.UI.Models
{
    public class ModelViewModel
    {


        public List<CarDealarship.Model.Tables.Models> Models { get; set; }

        [Required]
        public string ModelName { get; set; }
        public int MakeId { get; set; }




        public List<SelectListItem> MakesItems { get; set; }


        public ModelViewModel()
        {
            MakesItems = new List<SelectListItem>();

        }

        public void SetMakeItems(IEnumerable<Make> Makes)
        {
            Makes = Makes.OrderBy(m => m.MakeName).ToList();

            foreach (var m in Makes)
            {
                MakesItems.Add(new SelectListItem()
                {
                    Value = m.MakeId.ToString(),
                    Text = m.MakeName

                });
            }
        }
    }
}