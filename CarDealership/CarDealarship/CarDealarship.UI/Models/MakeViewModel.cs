using CarDealarship.Model.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDealarship.UI.Models
{
    public class MakeViewModel
    {
        public int id { get; set; }
        public int MakeId { get; set; }
        public Make Make { get; set; }

        [Required]
        public string MakeName { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<Make> Makes { get; set; }

    }
}