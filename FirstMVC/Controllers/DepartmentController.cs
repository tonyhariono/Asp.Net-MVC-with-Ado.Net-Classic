using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstMVC.Models;

namespace FirstMVC.Controllers
{
    public class DepartmentController : Controller
    {
       public ActionResult Index()
        {
            EmployeeContext employeecontext = new EmployeeContext();
            List<Department> departments= employeecontext.Departments.ToList();

            return View(departments);
        }
    }
}