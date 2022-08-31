using HomeBackProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

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

        //[LoginCkeck]
        public ActionResult buyADForHome(string id)
        {
            var homeData = db.HomeData.Find(id);
            ViewBag.HomeID = homeData.HomeID;
            return View(db.ADTypeData.ToList());
        }

        [LoginCkeck]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult buyADForHouse(string id, int point,short ADNumber)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeData homeData = db.HomeData.Find(id);
            PeopleData peopleData = db.PeopleData.Find(homeData.HomePeopleID);

            int cash = Session["userRank"].ToString() == "4"? 500000 : (int)peopleData.PeopleCash;

            if (cash < point)
            {
                ViewBag.Win = "點數不足，點選旁邊按鈕購買點數!!!";
                return View("buyPoints");
            }

            
            homeData.HomeADLevel = (short)ADNumber;
            peopleData.PeopleCash = Session["userRank"].ToString() == "4" ? peopleData.PeopleCash : peopleData.PeopleCash - (decimal)point;
            db.Entry(peopleData).State = EntityState.Modified;
            db.Entry(homeData).State = EntityState.Modified;
            db.SaveChanges();
            //ViewBag.Win = "購買成功!! 儲值方案為 " + ADName + " ， 您點數剩餘 : " + Math.Round((double)peopleData.PeopleCash, 0) + " 點";
            return RedirectToAction("Index", "HomeDatas");
        }

    }
}