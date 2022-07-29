using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeBackProject.Models;

namespace HomeBackProject.Controllers
{
    public class HomeDatasController : Controller
    {
        private HomeDataEntities db = new HomeDataEntities();
        private ActiondbController actiondbController = new ActiondbController();

        // GET: HomeDatas
        [LoginCkeck]
        public ActionResult Index()
        {
            var homeData = db.HomeData.Include(h => h.ADTypeData).Include(h => h.CarTypeData).Include(h => h.CityTypeData).Include(h => h.HomeTypeData).Include(h => h.PeopleData).Include(h => h.SaleTypeData);
            return View(homeData.ToList());
        }

        // GET: HomeDatas/Details/5
        [LoginCkeck]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeData homeData = db.HomeData.Find(id);
            if (homeData == null)
            {
                return HttpNotFound();
            }
            return View(homeData);
        }

        // GET: HomeDatas/Create
        [LoginCkeck]
        public ActionResult Create()
        {
            ViewBag.HomeADLevel = new SelectList(db.ADTypeData, "ADID", "ADName");
            ViewBag.HomeCarID = new SelectList(db.CarTypeData, "CarTypeID", "CarTypeName");
            ViewBag.HomeCity = new SelectList(db.CityTypeData, "CityIDTW", "CityTW");
            ViewBag.HomeType = new SelectList(db.HomeTypeData, "HomeTypeID", "HomeTypeName");
            ViewBag.HomePeopleID = new SelectList(db.PeopleData, "PeopleID", "PeopleID");
            ViewBag.HomeSaleType = new SelectList(db.SaleTypeData, "SaleStateID", "SaleState");
            return View();
        }

        // POST: HomeDatas/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HomeData homeData)
        {
            if (ModelState.IsValid)
            {
                var countHomeDatas = db.HomeData.Count() + 1;
                homeData.HomeID = "A" + countHomeDatas.ToString().PadLeft(9, '0');  //自動加編號A000000000，新增一筆自動+1
              
                return actiondbController.Create(db, db.PeopleData, homeData);
            }

            ViewBag.HomeADLevel = new SelectList(db.ADTypeData, "ADID", "ADName", homeData.HomeADLevel);
            ViewBag.HomeCarID = new SelectList(db.CarTypeData, "CarTypeID", "CarTypeName", homeData.HomeCarID);
            ViewBag.HomeCity = new SelectList(db.CityTypeData, "CityIDTW", "CityTW", homeData.HomeCity);
            ViewBag.HomeType = new SelectList(db.HomeTypeData, "HomeTypeID", "HomeTypeName", homeData.HomeType);
            ViewBag.HomePeopleID = new SelectList(db.PeopleData, "PeopleID", "PeopleID", homeData.HomePeopleID);
            ViewBag.HomeSaleType = new SelectList(db.SaleTypeData, "SaleStateID", "SaleState", homeData.HomeSaleType);
            return View(homeData);
        }

        // GET: HomeDatas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeData homeData = db.HomeData.Find(id);
            if (homeData == null)
            {
                return HttpNotFound();
            }
            ViewBag.HomeADLevel = new SelectList(db.ADTypeData, "ADID", "ADName", homeData.HomeADLevel);
            ViewBag.HomeCarID = new SelectList(db.CarTypeData, "CarTypeID", "CarTypeName", homeData.HomeCarID);
            ViewBag.HomeCity = new SelectList(db.CityTypeData, "CityIDTW", "CityTW", homeData.HomeCity);
            ViewBag.HomeType = new SelectList(db.HomeTypeData, "HomeTypeID", "HomeTypeName", homeData.HomeType);
            ViewBag.HomePeopleID = new SelectList(db.PeopleData, "PeopleID", "PeopleName", homeData.HomePeopleID);
            ViewBag.HomeSaleType = new SelectList(db.SaleTypeData, "SaleStateID", "SaleState", homeData.HomeSaleType);
            return View(homeData);
        }

        // POST: HomeDatas/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [LoginCkeck]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HomeID,HomeName,HomeMoney,HomeSquareMeters,HomeMetersMoney,HomeCity,HomeTown,HomeStreet,HomeFloor,HomeHighFloor,HomeSaleAndLease,HomeAges,HomeRoom,HomeHall,HomeBathroom,HomeBalcony,HomeFeatures,HomeManageTip,HomeCarID,HomeSaleType,HomeType,HomePeopleID,HomeADLevel")] HomeData homeData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(homeData).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HomeADLevel = new SelectList(db.ADTypeData, "ADID", "ADName", homeData.HomeADLevel);
            ViewBag.HomeCarID = new SelectList(db.CarTypeData, "CarTypeID", "CarTypeName", homeData.HomeCarID);
            ViewBag.HomeCity = new SelectList(db.CityTypeData, "CityIDTW", "CityTW", homeData.HomeCity);
            ViewBag.HomeType = new SelectList(db.HomeTypeData, "HomeTypeID", "HomeTypeName", homeData.HomeType);
            ViewBag.HomePeopleID = new SelectList(db.PeopleData, "PeopleID", "PeopleName", homeData.HomePeopleID);
            ViewBag.HomeSaleType = new SelectList(db.SaleTypeData, "SaleStateID", "SaleState", homeData.HomeSaleType);
            return View(homeData);
        }

        // GET: HomeDatas/Delete/5
        [LoginCkeck]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeData homeData = db.HomeData.Find(id);
            if (homeData == null)
            {
                return HttpNotFound();
            }
            return View(homeData);
        }

        // POST: HomeDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HomeData homeData = db.HomeData.Find(id);
            db.HomeData.Remove(homeData);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
