using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safe.Model
{
   public class Membership
    {
        public int MembershipID { get; set; }
        public virtual Employee EmployeeID { get; set; }
        public virtual Team_and_Trains TeamID { get; set; }
        public string Role { get; set; }

    }
}
