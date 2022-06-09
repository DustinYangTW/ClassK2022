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
            
            dbSutdent.tStudent.Add(tStudent);
            dbSutdent.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            //SQL
            //delete from tStudent where fStuId = '88888'

            //var student = from s in dbSutdent.tStudent
            //              where s.fStuId == id
            //              select s;

            var student = dbSutdent.tStudent.Where(s => s.fStuId == id).FirstOrDefault();
            if (student != null)
            {
                dbSutdent.tStudent.Remove(student);
                dbSutdent.SaveChanges();
            }
            return View();
        }

    }
    
}