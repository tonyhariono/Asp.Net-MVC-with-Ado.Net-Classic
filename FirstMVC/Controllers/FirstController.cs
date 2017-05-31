using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMVC.Controllers
{
    public class FirstController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Countries"] = new List<string>()
            {
                "India",
                "Hongkong",
                "Indonesia"
            };

            return View();
        }

    }
}