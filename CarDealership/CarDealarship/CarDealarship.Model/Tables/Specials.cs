using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealarship.Model.Tables
{
    public class Specials
    {

        [Key]
        public int SpecialId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
