using CarDealarship.Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealarship.Model.Queries
{
   public class VehicleSearchParameters
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int? Year { get; set; }
        public int? MinYear { get; set; }
        public int? MaxYear { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string SearchKey { get; set; }
        public bool IsNew { get; set; }
        



    }


}
