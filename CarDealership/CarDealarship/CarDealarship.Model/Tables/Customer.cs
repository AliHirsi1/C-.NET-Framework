using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealarship.Model.Tables
{
    public class Customer
    {
        

        public int CustomerId { get; set; }

        [Required]
        [StringLength(30)]
        public string Firstname { get; set; }
        [Required]
        [StringLength(30)]
        public string LastName { get; set; }
        [Required]
        [StringLength(30)]
        public string Email { get; set; }
        [Required]
        [StringLength(30)]
        public string Phone { get; set; }
        [Required]
        [StringLength(100)]
        public string Street1 { get; set; }
        public string street2 { get; set; }
        [Required]        
        public int ZipCode { get; set; }
        [Required]
        [StringLength(30)]
        public City CityId { get; set; }
        [Required]
        [StringLength(30)]
        public States StateId { get; set; }
        public Sales Sale { get; set; }


        
    }
}
