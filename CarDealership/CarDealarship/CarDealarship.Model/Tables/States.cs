using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealarship.Model.Tables
{
    public class States
    {
        [Key]
        public int StateId { get; set; }
        public String StateAbbreviation { get; set; }
        public string StateName { get; set; }

    }
}
