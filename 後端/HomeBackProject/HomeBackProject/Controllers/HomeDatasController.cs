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
using System.Web.UI;
using PagedList;

namespace HomeBackProject.Controllers
{
    public class HomeDatasController : Controller
    {
        private HomeDataEntities db = new HomeDataEntities();
        private ActiondbController actiondbController = new ActiondbController();
        private AccountData accountData = new AccountData();
        private ChangIDAuto changIDAuto = new ChangIDAuto();
        private PostPhotos postPhotos = new PostPhotos();
        private searchData searchData = new searchData();
        private SearchPhotos searchPhotos = new SearchPhotos();

        // GET: HomeDatas
        [LoginCkeck]
        public ActionResult Index(int page = 1)
        {
            string userID = Session["userID"].ToString();
            var homeData = db.HomeData.Include(h => h.ADTypeData).Include(h => h.CarTypeData).Include(h => h.CityTypeData).Include(h => h.HomeTypeData).Include(h => h.PeopleData).Include(h => h.SaleTypeData).OrderByDescending(h => h.HomeID).OrderByDescending(h => h.HomeSaleType).Where(h => h.HomePeopleID == userID);

            int pagesize = 10;
            var pagedList = homeData.ToPagedList(page, pagesize);
            ViewBag.countyID = db.CityTypeData.ToList();
            ViewBag.HomeTypeData = db.HomeTypeData.ToList();
            ViewBag.CarTypeData = db.CarTypeData.ToList();
            ViewBag.HomeSaleType = db.SaleTypeData.ToList();

            return View(pagedList);
        }


        [LoginCkeck]
        [HttpPost]
        public ActionResult Index(string SearchFast, string County, string Town, int SquareMeters, int HomeTypeDatas, int CarTypeDatas, int AllMoney, int HomeAge, int HomeFlortDatas, int HomeRoomDatas, bool? HomeSaleDatas, int page = 1)
        {
            string userID = Session["userID"].ToString();
            var homeData = db.HomeData.Include(h => h.ADTypeData).Include(h => h.CarTypeData).Include(h => h.CityTypeData).Include(h => h.HomeTypeData).Include(h => h.PeopleData).Include(h => h.SaleTypeData).OrderByDescending(h => h.HomeID).OrderByDescending(h => h.HomeID).OrderByDescending(h => h.HomeSaleType).Where(h => h.HomePeopleID == userID);

            searchData.SquareMeters(SquareMeters);//0.1
            searchData.moneyGetData(AllMoney);//2,3
            searchData.ageHome(HomeAge);//4,5

            List<int> changeInt = searchData.Flort(HomeFlortDatas);//6,7


            var SquareMetersLow = changeInt[0];
            var SquareMetersHigh = changeInt[1];
            var AllMoneyLow = changeInt[2];
            var AllMoneyHigh = changeInt[3];
            var HomeAgeLow = changeInt[4];
            var HomeAgeHigh = changeInt[5];
            var HomeFlortDatasLow = changeInt[6];
            var HomeFlortDatasHigh = changeInt[7];

            if (SearchFast != "")
            {
                homeData = homeData.Where(p => p.HomeName.Contains(SearchFast) || p.HomeStreet.Contains(SearchFast));
            }
            homeData = HomeSaleDatas != null ? homeData.Where(p => p.HomeSaleAndLease == HomeSaleDatas) : homeData;
            ViewBag.HomeSaleDatas = homeData.ToList();
            homeData = HomeTypeDatas != 0 ? homeData.Where(p => p.HomeType == HomeTypeDatas) : homeData;
            ViewBag.HomeHomeType = homeData.ToList();
            homeData = CarTypeDatas != 0 ? homeData.Where(p => p.HomeCarID == CarTypeDatas) : homeData;
            ViewBag.HomeHomeCarID = homeData.ToList();
            homeData = County != null ? homeData.Where(p => p.HomeCity == County) : homeData;
            ViewBag.HomeHomeCity = homeData.ToList();

            homeData = County != null && Town != "" ? homeData.Where(p => p.HomeTown == Town) : homeData;

            homeData = County == null && Town != null ? homeData.Where(p => p.HomeTown == Town) : homeData;

            ViewBag.HomeHomeTown = homeData.ToList();
            homeData = homeData.Where(p => p.HomeAges >= HomeAgeLow && p.HomeAges < HomeAgeHigh);
            ViewBag.HomeHomeAges = homeData.ToList();
            homeData = HomeFlortDatas < 6 ? homeData.Where(p => p.HomeFloor >= HomeFlortDatasLow && p.HomeFloor <= HomeFlortDatasHigh) : homeData;
            ViewBag.HomeHomeFloors = homeData.ToList();
            homeData = homeData.Where(p => p.HomeHighFloor >= HomeFlortDatasLow && p.HomeHighFloor <= HomeFlortDatasHigh);
            ViewBag.HomeHomeHighFloor = homeData.ToList();
            homeData = HomeRoomDatas != 0 ? homeData.Where(p => p.HomeRoom == HomeRoomDatas) : homeData;//沒有選的時候
            ViewBag.HomeHomeRoom01 = homeData.ToList();
            homeData = HomeRoomDatas >= 5 ? homeData.Where(p => p.HomeRoom >= HomeRoomDatas) : homeData;//大於等於5層樓
            ViewBag.HomeHomeRoom = homeData.ToList();
            homeData = homeData.Where(p => p.HomeSquareMeters >= SquareMetersLow && p.HomeSquareMeters < SquareMetersHigh);
            ViewBag.HomeHomeSquareMeters = homeData.ToList();
            homeData = homeData.Where(p => p.HomeMoney >= AllMoneyLow && p.HomeMoney < AllMoneyHigh);
            ViewBag.HomeHomeMoney = homeData.ToList();

            int pagesize = 10;
            var pagedList = homeData.ToPagedList(page, pagesize);
            ViewBag.countyID = db.CityTypeData.ToList();
            ViewBag.HomeTypeData = db.HomeTypeData.ToList();
            ViewBag.CarTypeData = db.CarTypeData.ToList();
            ViewBag.HomeSaleType = db.SaleTypeData.ToList();
            return View(pagedList);
        }

        // GET: HomeDatas/Details/H0000000006
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeData homeData = db.HomeData.Find(id);

            string autoFile = Server.MapPath("~/AllPhoto/Home" + "/" + id);
            List<string> photo = searchPhotos.searchPhotos(autoFile, id);

            ViewBag.allPhoto = photo.OrderBy(m => m).Skip(photo.Count() - 6).OrderByDescending(m => m).ToList();
            //ViewBag.allPhoto = photo;


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
                homeData.HomeID = changIDAuto.changIDNumber(countHomeDatas.HomeID);  //自動加編號H000000000，新增一筆自動+1
                homeData.HomePeopleID = Session["userID"].ToString();
                homeData.HomeManageTip = homeData.HomeManageTip > 0 ? homeData.HomeManageTip : 0;
                homeData.HomeADLevel = 1;
                actiondbController.Create(db, db.HomeData, homeData);
                string autoFile = Server.MapPath("~/AllPhoto");
                return actiondbController.SavePhoto(autoFile, photoList, Session["userID"].ToString(), homeData.HomeID);
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
            var countyTownlast = db.HomeData.Where(p => p.HomeID == homeData.HomeID).FirstOrDefault();
            ViewBag.HomeTownlast = countyTownlast.HomeTown;
            //var countyCountylast = db.CityTypeData.Where(p => p.CityIDTW == homeData.HomeCity).FirstOrDefault();
            ViewBag.countyTWlast = countyTownlast.HomeCity;

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
                //return actiondbController.Edit(db, homeData);
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

        //// POST: HomeDatas/Delete/5
        //[LoginCkeck]
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    HomeData homeData = db.HomeData.Find(id);
        //    return actiondbController.Delete(db, db.PeopleData, homeData);
        //}

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
