using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealarship.Model.Tables
{
    public class ContactUs
    {       
        public int ContactUsId { get; set; }
        [Required]
        [StringLength(55)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(55)]
        public string LastName { get; set; }

        [Required]
        [StringLength(30)]
        public string Email { get; set; }

        [Required]
        [StringLength(15)]
        public string Phone { get; set; }

        [Required]
        [StringLength(128)]
        public string Message { get; set; }
        

    }
}
