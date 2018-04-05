using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safe.Model
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public int EmployeeNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int ManagerID { get; set; }
        public string Email { get; set; }
        public int CostCenter { get; set; }
        public string Status { get; set; }
        public string PrimaryTeam { get; set; }

    }
}
