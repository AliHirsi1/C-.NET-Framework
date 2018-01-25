using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models.Responses
{
    public class RemoveOrderResponse : Response
    {
        public List<Order> Orders {get; set;}
        public DateTime Date { get; set; }
        public int OrderNumber { get; set; }
    }
}
