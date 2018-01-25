using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models.Responses
{
    public class StateLookupResponse : Response
    {
        public StateTax Tax { get; set; }
    }
}
