using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW7Project.Controllers
{
    public class HomeManagerController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }        
        public ActionResult Login()
        {
            return View();
        }      
        public ActionResult Logout()
        {

            return RedirectToAction("Index","Home");
        }
    }
}