using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstMVC.Models;

namespace FirstMVC.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Details(int id)
        {
            EmployeeContext employeeContext = new EmployeeContext();
            Employee employee= employeeContext.Employees.Single(e => e.EmployeeId == id);

            return View(employee);
        }
    }
}