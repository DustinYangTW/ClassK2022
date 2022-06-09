using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC0601.Models;

namespace MVC0601.Controllers
{
    public class DefaultController : Controller
    {
        dbSutdentEntities dbSutdent = new dbSutdentEntities();
        public ActionResult Index()
        {
            var tStudent = dbSutdent.tStudent;
            return View(tStudent);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tStudent tStudent)
        {

            return View();
        }


    }
    
}