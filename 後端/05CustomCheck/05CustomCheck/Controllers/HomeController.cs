using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _05CustomCheck.Models;

namespace _05CustomCheck.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Member member)
        {
            if(ModelState.IsValid)
                return RedirectToAction("Index");
            else
                return View(member);
        }
    }
}