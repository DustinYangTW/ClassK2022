using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeBackProject.library;
using HomeBackProject.Models;
using System.IO;

namespace HomeBackProject.Controllers
{
    public class HomeDatasController : Controller
    {
        private HomeDataEntities db = new HomeDataEntities();
        private ActiondbController actiondbController = new ActiondbController();
        private AccountData accountData = new AccountData();
        private ChangIDAuto changIDAuto = new ChangIDAuto();
        private PostPhotos postPhotos = new PostPhotos();

        // GET: HomeDatas
        [LoginCkeck]
        public ActionResult Index()
        {
            var homeData = db.HomeData.Include(h => h.ADTypeData).Include(h => h.CarTypeData).Include(h => h.CityTypeData).Include(h => h.HomeTypeData).Include(h => h.PeopleData).Include(h => h.SaleTypeData).OrderByDescending(h => h.HomeID);
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
            //ViewBag.HomeADLevel = new SelectList(db.ADTypeData, "ADID", "ADName");
            //ViewBag.HomeCity = new SelectList(db.CityTypeData, "CityIDTW", "CityTW");
            //ViewBag.HomeType = new SelectList(db.HomeTypeData, "HomeTypeID", "HomeTypeName");
            //ViewBag.HomePeopleID = new SelectList(db.PeopleData, "PeopleID", "PeopleID");
            ViewBag.HomeSaleType = db.SaleTypeData.ToList();
            ViewBag.HomeCarID = db.CarTypeData.ToList();
            ViewBag.countyID = db.CityTypeData.ToList();
            ViewBag.homeTypeData = db.HomeTypeData.ToList();
            return View();
        }

        [LoginCkeck]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HomeData homeData, HttpPostedFileBase[] photo)
        {
            List<HttpPostedFileBase> photoList = new List<HttpPostedFileBase>();
            string checkdataPhoto = "";
            if (photo[0] != null)
            {
                for (int i = 0; i < photo.Length; i++)
                {
                    if (photo[i] == null)
                    {
                        break;
                    }

                    checkdataPhoto = postPhotos.checkPhoto(photo[i].FileName, photo[i].ContentLength);

                    if (checkdataPhoto != "OK")
                    {
                        ViewBag.HomeSaleType = db.SaleTypeData.ToList();
                        ViewBag.HomeCarID = db.CarTypeData.ToList();
                        ViewBag.countyID = db.CityTypeData.ToList();
                        ViewBag.homeTypeData = db.HomeTypeData.ToList();
                        return View(homeData);
                    }
                    
                    photoList.Add(photo[i]);
                }
            }

            if (ModelState.IsValid)
            {
                var countHomeDatas = db.HomeData.OrderByDescending(m => m.HomeID).FirstOrDefault();

                homeData.HomeFloor = homeData.HomeFloor == null ? 0 : homeData.HomeFloor;
                homeData.HomeID = changIDAuto.changIDNumber(countHomeDatas.HomeID, "H");  //自動加編號H000000000，新增一筆自動+1
                homeData.HomePeopleID = Session["userID"].ToString();
                homeData.HomeManageTip = homeData.HomeManageTip > 0 ? homeData.HomeManageTip : 0;
                homeData.HomeADLevel = 1;
                actiondbController.Create(db, db.HomeData, homeData);
                string autoFile = Server.MapPath("~/AllPhoto");
                return actiondbController.SavePhoto(autoFile,photoList, Session["userID"].ToString(), homeData.HomeID);
            }

            ViewBag.HomeSaleType = db.SaleTypeData.ToList();
            ViewBag.HomeCarID = db.CarTypeData.ToList();
            ViewBag.countyID = db.CityTypeData.ToList();
            ViewBag.homeTypeData = db.HomeTypeData.ToList();
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
            ViewBag.countyID = db.CityTypeData.ToList();
            ViewBag.countyIDlast = homeData.HomeCity;
            var countyTWlast = db.CityTypeData.Where(m => m.CityIDTW == homeData.HomeCity).FirstOrDefault();
            ViewBag.countyTWlast = countyTWlast.CityTW;
            var countyTownlast = db.HomeData.Where(p => p.HomeID == homeData.HomeID).FirstOrDefault();
            ViewBag.HomeTownlast = countyTownlast.HomeTown;

            return View(homeData);
        }

        // POST: HomeDatas/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [LoginCkeck]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HomeData homeData)
        {
            if (ModelState.IsValid)
            {
                homeData.HomePeopleID = Session["userID"].ToString();
                return actiondbController.Edit(db, homeData);
            }
            ViewBag.HomeADLevel = new SelectList(db.ADTypeData, "ADID", "ADName", homeData.HomeADLevel);
            ViewBag.HomeCarID = new SelectList(db.CarTypeData, "CarTypeID", "CarTypeName", homeData.HomeCarID);
            ViewBag.HomeCity = new SelectList(db.CityTypeData, "CityIDTW", "CityTW", homeData.HomeCity);
            ViewBag.HomeType = new SelectList(db.HomeTypeData, "HomeTypeID", "HomeTypeName", homeData.HomeType);
            ViewBag.HomePeopleID = new SelectList(db.PeopleData, "PeopleID", "PeopleName", homeData.HomePeopleID);
            ViewBag.HomeSaleType = new SelectList(db.SaleTypeData, "SaleStateID", "SaleState", homeData.HomeSaleType);
            ViewBag.countyID = db.CityTypeData.ToList();
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
            return actiondbController.Delete(db, db.PeopleData, homeData);
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
