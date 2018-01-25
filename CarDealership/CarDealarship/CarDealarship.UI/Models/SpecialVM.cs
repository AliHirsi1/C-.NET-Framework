using CarDealarship.Model.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDealarship.UI.Models
{
    public class SpecialVM
    {
        public List<Specials> Special { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Message { get; set; }

    }
}