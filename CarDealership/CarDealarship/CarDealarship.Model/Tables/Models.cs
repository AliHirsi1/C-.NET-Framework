using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealarship.Model.Tables
{
    public class Models
    {
        [Key]
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public int MakeId { get; set; }
        public Make Make { get; set; }
        public DateTime Date { get; set; }
        public Users user { get; set; }
        public string UserId { get; set; }
    }

}
