using HomeBackProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HomeBackProject.Controllers
{
    public class PeopleBuySomethingController : Controller
    {
        private HomeDataEntities db = new HomeDataEntities();
        // GET: PeopleBuySomething
        [LoginCkeck]
        public ActionResult buyPoints()
        {
            return View();
        }

        [LoginCkeck]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult buyPoints(string id,int point)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeopleData peopleData = db.PeopleData.Find(id);
            peopleData.PeopleCash = peopleData.PeopleCash + point;
            db.Entry(peopleData).State = EntityState.Modified;
            db.SaveChanges();
            ViewBag.Win = "購買成功!! 儲值 " + point + " 點 " + " ， 您目前共有 : " + Math.Round((double)peopleData.PeopleCash,0)+" 點";
            return View("buyPoints");
        }
    }
}