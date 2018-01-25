using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models.Responses
{
    public class EditOrderResponse : Response
    {

        public DateTime Date { get; set; }
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public string State { get; set; }
        public string ProductType { get; set; }
        public int Area { get; set; }


    }
}
