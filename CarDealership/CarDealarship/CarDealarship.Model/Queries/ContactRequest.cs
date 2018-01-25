using CarDealarship.Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealarship.Model.Queries
{
   public class ContactRequest
    {
        public int ContactId { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
    }
}
