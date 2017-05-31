using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;

namespace FirstMVC.Controllers
{
    public class EmployeeBLController : Controller
    {
        public ActionResult Index()
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            List<Employee> employees = employeeBusinessLayer.Employees.ToList();

            return View(employees);
        }

        public ActionResult Details(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            Employee employee = employeeBusinessLayer.Employees.Single(e => e.ID == id);

            return View(employee);
        }
        #region AddData --------------

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Create(FormCollection formCollection)
        //{
        //    //foreach (string key in formCollection.AllKeys)
        //    //{
        //    //    Response.Write("Key = " + key + "   ");
        //    //    Response.Write(formCollection[key]);
        //    //    Response.Write("<br/>");
        //    //}
        //    Employee employee = new Employee();
        //    employee.Name = formCollection["Name"];
        //    employee.Gender = formCollection["Gender"];
        //    employee.City = formCollection["City"];
        //    employee.DateOfBirth = Convert.ToDateTime(formCollection["DateOfBirth"]);

        //    EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
        //    employeeBusinessLayer.AddEmployee(employee);

        //    return RedirectToAction("Index");
        //}

        //[HttpPost]
        //public ActionResult Create(Employee employee)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
        //        employeeBusinessLayer.AddEmployee(employee);

        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        //[HttpPost]
        //[ActionName("Create")]
        //public ActionResult Create_Post()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Employee employee = new Employee();
        //        UpdateModel(employee);

        //        EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
        //        employeeBusinessLayer.AddEmployee(employee);

        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        //[HttpPost]
        //[ActionName("Create")]
        //public ActionResult Create_Post()
        //{
        //    Employee employee = new Employee();
        //    TryUpdateModel(employee);

        //    if (ModelState.IsValid)
        //    {
        //        EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
        //        employeeBusinessLayer.AddEmployee(employee);

        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post(Employee employee)
        {
            //Employee employee = new Employee();
            //TryUpdateModel(employee);

            if (ModelState.IsValid)
            {
                EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
                employeeBusinessLayer.AddEmployee(employee);

                return RedirectToAction("Index");
            }
            return View();
        }
        #endregion

        #region EditData --------------
        [HttpGet]
        public ActionResult Edit(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            Employee employee = employeeBusinessLayer.Employees.Single(emp => emp.ID == id);

            return View(employee);
        }

        // ini contoh buruk bisa diinject pake fiddler
        //[HttpPost]
        //public ActionResult Edit(Employee employee)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
        //        employeeBusinessLayer.SaveEmployee(employee);

        //        return RedirectToAction("Index");
        //    }

        //    return View(employee);
        //}

        //[HttpPost]
        //[ActionName("Edit")]
        //public ActionResult Edit_Post(int id)
        //{
        //    EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
        //    Employee employee= employeeBusinessLayer.Employees.Single(x => x.ID == id);
        //    //ini contoh include parameter
        //    //UpdateModel(employee,new string[] {"ID","Gender","City","DateOfBirth"});

        //    //ini contoh exclude parameter
        //    UpdateModel(employee,null,null, new string[] { "Name" });

        //    if (ModelState.IsValid)
        //    {
        //        employeeBusinessLayer.SaveEmployee(employee);

        //        return RedirectToAction("Index");
        //    }

        //    return View(employee);
        //}

        //[HttpPost]
        //[ActionName("Edit")]
        //public ActionResult Edit_Post([Bind(Exclude = "Name")] Employee employee)
        ////public ActionResult Edit_Post([Bind(Include = "ID, Gender, City, DateOfBirth")] Employee employee)
        //{
        //    EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
        //    employee.Name = employeeBusinessLayer.Employees.Single(x => x.ID == employee.ID).Name;
        //    //ini contoh include parameter
        //    //UpdateModel(employee,new string[] {"ID","Gender","City","DateOfBirth"});

        //    //ini contoh exclude parameter
        //    //UpdateModel(employee, null, null, new string[] { "Name" });

        //    if (ModelState.IsValid)
        //    {
        //        employeeBusinessLayer.SaveEmployee(employee);

        //        return RedirectToAction("Index");
        //    }

        //    return View(employee);
        //}

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(int id)
        //public ActionResult Edit_Post([Bind(Include = "ID, Gender, City, DateOfBirth")] Employee employee)
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            Employee employee = employeeBusinessLayer.Employees.Single(x => x.ID == id);

            UpdateModel<IEmployee>(employee);
            //ini contoh include parameter
            //UpdateModel(employee,new string[] {"ID","Gender","City","DateOfBirth"});

            //ini contoh exclude parameter
            //UpdateModel(employee, null, null, new string[] { "Name" });

            if (ModelState.IsValid)
            {
                employeeBusinessLayer.SaveEmployee(employee);

                return RedirectToAction("Index");
            }

            return View(employee);
        }

        #endregion

        #region DeleteData --------------
        [HttpPost]
        public ActionResult Delete(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            employeeBusinessLayer.DeleteEmployee(id);

            return RedirectToAction("Index");
        }
        #endregion
    }
}