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
            string userRank = Session["userRank"].ToString();
            var homeData = userRank == "4" ? db.HomeData.Include(h => h.ADTypeData).Include(h => h.CarTypeData).Include(h => h.CityTypeData).Include(h => h.HomeTypeData).Include(h => h.PeopleData).Include(h => h.SaleTypeData).OrderByDescending(h => h.HomeSaleType).OrderByDescending(h => h.HomeID)
                                       : db.HomeData.Include(h => h.ADTypeData).Include(h => h.CarTypeData).Include(h => h.CityTypeData).Include(h => h.HomeTypeData).Include(h => h.PeopleData).Include(h => h.SaleTypeData).OrderByDescending(h => h.HomeSaleType).OrderByDescending(h => h.HomeID).Where(h => h.HomePeopleID == userID & h.HomeSaleType != 4);
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
            string userRank = Session["userRank"].ToString();
            var homeData = db.HomeData.Include(h => h.ADTypeData).Include(h => h.CarTypeData).Include(h => h.CityTypeData).Include(h => h.HomeTypeData).Include(h => h.PeopleData).Include(h => h.SaleTypeData).OrderByDescending(h => h.HomeID).OrderByDescending(h => h.HomeID).OrderByDescending(h => h.HomeSaleType).Where(p => p.HomeADLevel >= 0);
            homeData = userRank == "4" ? homeData : homeData.Where(p => p.HomePeopleID == userID & p.HomeSaleType != 4);

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

            homeData = County != null && Town != "" && Town != null ? homeData.Where(p => p.HomeTown == Town) : homeData;

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

            TempData["Win"] = homeData.ToList().Count() == 0 ? "查無資料，請重新查詢" : "";

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
                return RedirectToAction("Index", "Home");
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeData homeData = db.HomeData.Find(id);
            if (homeData == null)
            {
                //return HttpNotFound();
                return RedirectToAction("Index", "Home");
            }

            string autoFile = Server.MapPath("~/AllPhoto/Home" + "/" + id);
            List<string> photo = searchPhotos.searchPhotos(autoFile, id);

            if (photo.Count() == 0) { photo.Add("../../AllPhoto/unKnow/NoResult.png"); }
            var allphoto = photo.OrderBy(m => m).Skip(photo.Count() - 6).OrderByDescending(m => m).ToList();


            PeopleData peopleData= db.PeopleData.Find(homeData.HomePeopleID);
            string PeopelautoFile = Server.MapPath("~/AllPhoto/PeopleImage" + "/" + homeData.HomePeopleID);
            List<string> Peoplephoto = searchPhotos.searchPhotos(PeopelautoFile, homeData.HomePeopleID);
            if (Peoplephoto.Count() == 0) { Peoplephoto.Add("../../AllPhoto/unKnow/NoResult.png"); }
            ViewBag.Peoplephoto = Peoplephoto[0];
            ViewBag.People = peopleData;

            ViewBag.allPhoto = allphoto;
            //ViewBag.allPhoto = photo;
            ViewBag.allPhotoCount = allphoto.Count();

            var homedataRamdom = db.HomeData.Where(h=>h.HomeCity == homeData.HomeCity);

            var homedataRamdomList = homedataRamdom.ToList();
            List<string> homedataRamdomIDList = new List<string>();
            foreach (var Ramdoncount in homedataRamdomList)
            {
                homedataRamdomIDList.Add(Ramdoncount.HomeID);
            }

            ViewBag.homedataRamdom = homedataRamdom.ToList();
            var homedataRamdomall = db.HomeData;
            Random random = new Random();
            List<string> randinAllNum = new List<string>();           
            randinAllNum.Add(homedataRamdomIDList[random.Next(0, homedataRamdomIDList.Count())]);
            randinAllNum.Add(homedataRamdomIDList[random.Next(0, homedataRamdomIDList.Count())]);
            randinAllNum.Add(homedataRamdomIDList[random.Next(0, homedataRamdomIDList.Count())]);
            randinAllNum.Add(homedataRamdomIDList[random.Next(0, homedataRamdomIDList.Count())]);

            var City = db.CityTypeData;

            List<string> Midphotos = new List<string>();
            List<HomeData> MidhomeDatas = new List<HomeData>();
            List<string> MidhCity = new List<string>();
            for(int i = 0;i< randinAllNum.Count(); i++)
            {
                var homedataRamdomID = homedataRamdomall.Find(randinAllNum[i]);
                string autoFileRamdom = Server.MapPath("~/AllPhoto/Home" + "/" + randinAllNum[i]);
                List<string> Midphoto = searchPhotos.searchPhotos(autoFileRamdom, randinAllNum[i]);
                if (Midphoto.Count() == 0) { Midphoto.Add("../../AllPhoto/unKnow/NoResult.png"); }
                Midphotos.Add(Midphoto.OrderByDescending(m => m).FirstOrDefault());
                homedataRamdomID.HomeMoney = Math.Round(homedataRamdomID.HomeMoney, 2);
                MidhCity.Add(City.Find(homedataRamdomID.HomeCity).CityTW);
                MidhomeDatas.Add(homedataRamdomID);
            }
            ViewBag.MidhomeDatas = MidhomeDatas;
            ViewBag.MidhomeDatasCount = MidhomeDatas.Count();
            ViewBag.MidhCity = MidhCity;
            ViewBag.Midphotos = Midphotos;


            if (homeData == null)
            {
                //return HttpNotFound();
                return RedirectToAction("Index", "Home");
            }
            return View(homeData);
        }
        //// GET: HomeDatas/DetailsModal/H0000000006
        //public ActionResult DetailsModal(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    HomeData homeData = db.HomeData.Find(id);

        //    string autoFile = Server.MapPath("~/AllPhoto/Home" + "/" + id);
        //    List<string> photo = searchPhotos.searchPhotos(autoFile, id);

        //    if (photo.Count() == 0) { photo.Add("../../AllPhoto/unKnow/NoResult.png"); }
        //    var allphoto = photo.OrderBy(m => m).Skip(photo.Count() - 6).OrderByDescending(m => m).ToList();



        //    ViewBag.allPhoto = allphoto;
        //    //ViewBag.allPhoto = photo;
        //    ViewBag.allPhotoCount = allphoto.Count();

        //    if (homeData == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(homeData);
        //}
        // GET: HomeDatas/DetailsModal/H0000000006

        //[ChildActionOnly]
        [LoginCkeck]
        public ActionResult DetailsModal(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeData homeData = db.HomeData.Find(id);
            if (homeData == null)
            {
                //return HttpNotFound();
                return RedirectToAction("Index", "Home");
            }

            string autoFile = Server.MapPath("~/AllPhoto/Home" + "/" + id);
            List<string> photo = searchPhotos.searchPhotos(autoFile, id);

            if (photo.Count() == 0) { photo.Add("../../AllPhoto/unKnow/NoResult.png"); }
            var allphoto = photo.OrderBy(m => m).Skip(photo.Count() - 6).OrderByDescending(m => m).ToList();
            ViewBag.allPhoto = allphoto;
            //ViewBag.allPhoto = photo;
            ViewBag.allPhotoCount = allphoto.Count();



            if (homeData == null)
            {
                //return HttpNotFound();
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
        [LoginCkeck]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return RedirectToAction("Index", "Home");
            }

            HomeData homeData = db.HomeData.Find(id);
            if (homeData == null)
            {
                //return HttpNotFound();
                return RedirectToAction("Index", "Home");
            }

            //找照片
            string autoFile = Server.MapPath("~/AllPhoto/Home" + "/" + id);
            List<string> photo = searchPhotos.searchPhotos(autoFile, id);
            if (photo.Count() == 0) { photo.Add("../../AllPhoto/unKnow/NoResult.png"); }
            var allphoto = photo.OrderBy(m => m).Skip(photo.Count() - 6).OrderByDescending(m => m).ToList();

            ViewBag.allPhoto = allphoto;
            ViewBag.allPhotoCount = allphoto.Count();
            //找照片

            //if (homeData == null)
            //{
            //    return HttpNotFound();
            //}
            if (homeData == null)
            {
                return HttpNotFound();
                //return RedirectToAction("Index", "Home");
            }

            //ViewBag.HomeADLevel = new SelectList(db.ADTypeData, "ADID", "ADName", homeData.HomeADLevel);
            //ViewBag.HomeCarID = new SelectList(db.CarTypeData, "CarTypeID", "CarTypeName", homeData.HomeCarID);
            //ViewBag.HomeType = new SelectList(db.HomeTypeData, "HomeTypeID", "HomeTypeName", homeData.HomeType);
            //ViewBag.HomePeopleID = new SelectList(db.PeopleData, "PeopleID", "PeopleName", homeData.HomePeopleID);
            //ViewBag.HomeSaleType = new SelectList(db.SaleTypeData, "SaleStateID", "SaleState", homeData.HomeSaleType);

            ViewBag.HomeTypeName = db.HomeTypeData.Find(homeData.HomeType).HomeTypeName;
            ViewBag.HomeSaleState = db.SaleTypeData.Find(homeData.HomeSaleType).SaleState;
            ViewBag.HomeCarName = db.CarTypeData.Find(homeData.HomeCarID).CarTypeName;

            ViewBag.HomeADLevel = db.ADTypeData.ToList();
            ViewBag.HomeCarID = db.CarTypeData.ToList();
            ViewBag.HomeType = db.HomeTypeData.ToList();
            ViewBag.HomePeopleID = homeData.HomePeopleID;
            ViewBag.HomeSaleType = db.SaleTypeData.ToList();

            ViewBag.countyID = db.CityTypeData.ToList();
            var countyTownlast = db.HomeData.Where(p => p.HomeID == id.ToString()).FirstOrDefault();
            ViewBag.Townlast = countyTownlast.HomeTown;
            var countyCountylast = db.CityTypeData.Where(p => p.CityIDTW == homeData.HomeCity).FirstOrDefault();
            ViewBag.countyIDlast = homeData.HomeCity;
            ViewBag.countyTWlast = countyCountylast.CityTW;


            return View(homeData);
        }

        // POST: HomeDatas/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [LoginCkeck]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HomeData homeData, HttpPostedFileBase[] photo)
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
                        ViewBag.countyID = db.CityTypeData.ToList();
                        ViewBag.SaleStateID = db.PeopleRankData.ToList();
                        return View();
                    }

                    photoList.Add(photo[i]);
                }
            }

            if (ModelState.IsValid)
            {
                db.Entry(homeData).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                string autoFiles = Server.MapPath("~/AllPhoto");
                actiondbController.SavePhoto(autoFiles, photoList,homeData.HomePeopleID, homeData.HomeID);

                TempData["Win"] = homeData.HomeName+"  修改成功";
                return RedirectToAction("Index");
            }

            var id = homeData.HomeID;

            string autoFile = Server.MapPath("~/AllPhoto/Home" + "/" + id);
            List<string> photoOld = searchPhotos.searchPhotos(autoFile, id);
            if (photoOld.Count() == 0) { photoOld.Add("../../AllPhoto/unKnow/NoResult.png"); }
            var allphoto = photoOld.OrderBy(m => m).Skip(photoOld.Count() - 6).OrderByDescending(m => m).ToList();

            ViewBag.allPhoto = allphoto;
            ViewBag.allPhotoCount = allphoto.Count();

            ViewBag.HomeTypeName = db.HomeTypeData.Find(homeData.HomeType).HomeTypeName;
            ViewBag.HomeSaleState = db.SaleTypeData.Find(homeData.HomeSaleType).SaleState;
            ViewBag.HomeCarName = db.CarTypeData.Find(homeData.HomeCarID).CarTypeName;

            ViewBag.HomeADLevel = db.ADTypeData.ToList();
            ViewBag.HomeCarID = db.CarTypeData.ToList();
            ViewBag.HomeType = db.HomeTypeData.ToList();
            ViewBag.HomePeopleID = homeData.HomePeopleID;
            ViewBag.HomeSaleType = db.SaleTypeData.ToList();

            ViewBag.countyID = db.CityTypeData.ToList();
            var countyTownlast = db.HomeData.Where(p => p.HomeID == homeData.HomeID.ToString()).FirstOrDefault();
            ViewBag.Townlast = countyTownlast.HomeTown;
            var countyCountylast = db.CityTypeData.Where(p => p.CityIDTW == homeData.HomeCity).FirstOrDefault();
            ViewBag.countyIDlast = homeData.HomeCity;
            ViewBag.countyTWlast = countyCountylast.CityTW;
            return View(homeData);
        }


        public ActionResult HomeSaleTypeDelete(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeData homeData = db.HomeData.Find(id);
            if (homeData == null)
            {
                return RedirectToAction("Index", "Home");
                //return HttpNotFound();
            }
            homeData.HomeSaleType = 4;
            homeData.HomeManageTip = homeData.HomeManageTip > 0 ? homeData.HomeManageTip : 0;
            db.Entry(homeData).State = EntityState.Modified;
            //try
            //{
                db.SaveChanges();
            //}
            ////catch(Exception ex)
            //{
            //    throw;
            //}
            return RedirectToAction("Index");
        }
        // GET: HomeDatas/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    HomeData homeData = db.HomeData.Find(id);
        //    if (homeData == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(homeData);
        //}

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
