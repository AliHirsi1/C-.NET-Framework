using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Models
{
    public class EmployeeRepository
    {
        private static List<Employee> _employees;

        static EmployeeRepository()
        {
            _employees = new List<Employee>
            {
                new Employee  { EmployeeId =1, FirstName = "Jenny", LastName = "Jones", Phone = "888-888-88880", DepartmentId = 1 },
                new Employee { EmployeeId = 2, FirstName = "Bob", LastName = "Ross", Phone = "555-555-5555", DepartmentId = 2 },
                 new Employee { EmployeeId = 3, FirstName = "Jane", LastName = "Smith", Phone = "333-333-3333", DepartmentId = 3 }

            };

        }

        public static void Add(Employee emplyee)
        {
            if (_employees.Any())
            {
                emplyee.EmployeeId = _employees.Max(e => e.EmployeeId) + 1;
            }
            else
            {
                emplyee.EmployeeId = 1;
               
            }

            _employees.Add(emplyee);
        }

        public static void Edit(Employee employee)
        {
            Employee found = _employees.First(e => employee.EmployeeId == e.EmployeeId);
            found = employee;
        }

        public static void Delete(int employeeID)
        {
            _employees.RemoveAll(e => e.EmployeeId == employeeID);
        }

        public static Employee Get(int empployeeID)
        {
            return _employees.FirstOrDefault(e => e.EmployeeId == empployeeID);
        }

        public static List<Employee> GetAll()
        {
            return _employees;
        }

    }
}