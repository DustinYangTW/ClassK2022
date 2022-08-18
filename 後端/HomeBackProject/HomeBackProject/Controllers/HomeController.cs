using HomeBackProject.library;
using HomeBackProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace HomeBackProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeManager
        public ActionResult Index()
        {
            return View();
        }
    }
}
