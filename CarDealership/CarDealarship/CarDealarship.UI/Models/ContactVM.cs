using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDealarship.UI.Models
{
    public class ContactVM
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }



        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Message { get; set; }

    }
}