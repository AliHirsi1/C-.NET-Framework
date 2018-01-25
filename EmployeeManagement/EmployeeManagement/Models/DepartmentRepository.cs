using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Models
{
    public class DepartmentRepository
    {
        private static List<Department> _departments;
        static DepartmentRepository()
        {
            _departments = new List<Department>
            {
                new Department  { DepartmentName = "Computer Science", DepartmentId = 1 },
                new Department { DepartmentName = "Finanace", DepartmentId = 2  },
                 new Department {DepartmentName = "Sales", DepartmentId = 3  }

            };

        }
        public static List<Department> GetAll()
        {
            return _departments;
        }
    }
}