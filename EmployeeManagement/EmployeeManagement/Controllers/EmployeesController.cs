using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeesController : Controller
    {
        [HttpGet]
        public ActionResult List()
        {
            IEnumerable<EmployeeListViewModel> model = from employee in EmployeeRepository.GetAll()
                                                       join department in DepartmentRepository.GetAll()
                                                       on employee.DepartmentId equals department.DepartmentId
                                                       select new EmployeeListViewModel
                                                       {
                                                           Name = employee.FirstName + " " + employee.LastName,
                                                           Department = department.DepartmentName,
                                                           Phone = employee.Phone,
                                                           EmployeeID = employee.EmployeeId,

                                                       };
             
            return View(model);
        }
       
    }
}