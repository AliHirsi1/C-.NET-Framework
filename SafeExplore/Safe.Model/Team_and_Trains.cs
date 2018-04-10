using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safe.Model
{
    public class Team_and_Trains
    {
        [Key]
        public string TeamID { get; set; }
        public string  Type { get; set; }
        public string Name { get; set; }
        public string Parent { get; set; }
    }
}
