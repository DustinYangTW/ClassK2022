using HomeBackProject.Models;
using HomeBackProject.ViewModel;
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


        [LoginCkeck]
        public ActionResult buyADForHome(string id)
        {
            List<HomeData> homeData = new List<HomeData>();
            homeData.Add(db.HomeData.Find(id));
            VMHouseAD vMHouseAD = new VMHouseAD()
            {
                ADTypeData = db.ADTypeData.ToList(),
                HomeData = homeData
            };
            return View(vMHouseAD);
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
            ADTypeData aDTypeData = db.ADTypeData.Find(ADNumber);
            PeopleData peopleData = db.PeopleData.Find(homeData.HomePeopleID);

            if((int)peopleData.PeopleCash < point)
            {
                ViewBag.Win = "點數不足，點選旁邊按鈕購買點數!!!";
                return View("buyPoints");
            }

            string ADName = aDTypeData.ADName;
            homeData.HomeADLevel = ADNumber;
            peopleData.PeopleCash = peopleData.PeopleCash - point;
            db.Entry(peopleData).State = EntityState.Modified;
            db.SaveChanges();
            ViewBag.Win = "購買成功!! 儲值方案為 " + ADName + " ， 您點數剩餘 : " + Math.Round((double)peopleData.PeopleCash, 0) + " 點";
            return View("buyPoints");
        }

    }
}