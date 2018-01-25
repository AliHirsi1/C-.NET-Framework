using Flooring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models.Responses
{
    public class AddOrderResponse :Response 
    {
        public Order Order { get; set; }
        public DateTime Date  { get; set; }
        public string CustomerName { get; set; }
        public string State { get; set; }
        public string ProductType { get; set; }
        public int Area { get; set; }
    }
}
