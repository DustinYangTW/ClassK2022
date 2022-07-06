using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeBackProject.Controllers
{
    public class ActiondbController : Controller
    {
        public ActionResult Create<T>()
        {
            return View();
        }
    }
}