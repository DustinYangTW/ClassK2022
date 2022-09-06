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
    public class HomeController : Controller
    {
        private HomeDataEntities db = new HomeDataEntities();
        private SearchPhotos searchPhotos = new SearchPhotos();
        private searchData searchData = new searchData();
        private getPhotoToView _getPhotoToView = new getPhotoToView();

        // GET: HomeManager
        public ActionResult Index()
        {
            string peopleImgFile = Server.MapPath("~/AllPhoto/PeopleImage" + "/");
            string homeImgFile = Server.MapPath("~/AllPhoto/Home" + "/");

            List<HomeData> HomeDatas = db.HomeData.Where(h => h.HomeADLevel > 1).ToList();
            ViewBag.ALLList = _getPhotoToView.photoIndexSearch(HomeDatas, peopleImgFile, homeImgFile);

            //var City = db.CityTypeData;
            ////ViewBag.HomeDatas = (from h in db.HomeData
            ////                     join city in db.CityTypeData on h.HomeCity equals city.CityIDTW
            ////                     where (h.HomeADLevel > 1)
            ////                     select new { h, city.CityTW }).ToList();

            ////List<HomeData> HomeDatas = (from h in db.HomeData
            ////                           join city in db.CityTypeData on h.HomeCity equals city.CityIDTW
            ////                           where (h.HomeADLevel > 1) 
            ////                           select).ToList();

            //ViewBag.People = db.PeopleData.OrderByDescending(m => m.PeopleCash).Where(p => p.SaleStateID != 4).Take(3);

            //List<HomeData> HomeDatas = db.HomeData.Where(h => h.HomeADLevel > 1).ToList();

            //List<string> Highphotos = new List<string>();
            //List<HomeData> HighhomeDatas = new List<HomeData>();
            //List<string> HighCity = new List<string>();

            //List<string> Midphotos = new List<string>();
            //List<HomeData> MidhomeDatas = new List<HomeData>();
            //List<string> MidhCity = new List<string>();

            //List<PeopleData> peopleDatas = new List<PeopleData>();
            //List<string> peoplePhotoss = new List<string>();

            //foreach (var peoplePhoto in ViewBag.People)
            //{
            //    string autoFile = Server.MapPath("~/AllPhoto/PeopleImage" + "/" + peoplePhoto.PeopleID);
            //    List<string> peopelePhotos = searchPhotos.searchPhotos(autoFile, peoplePhoto.PeopleID);
            //    peoplePhotoss.Add(peopelePhotos.OrderByDescending(m => m).FirstOrDefault());
            //    if (peopelePhotos.Count() == 0) { peoplePhotoss.Add("../../AllPhoto/unKnow/NoResult.png"); }
            //    peopleDatas.Add(peoplePhoto);
            //}

            //foreach (var ADHomeID in HomeDatas)
            //{
            //    if (ADHomeID.HomeADLevel == 4)
            //    {
            //        string autoFile = Server.MapPath("~/AllPhoto/Home" + "/" + ADHomeID.HomeID);
            //        List<string> Highphoto = searchPhotos.searchPhotos(autoFile, ADHomeID.HomeID);
            //        if (Highphoto.Count() == 0) { Highphoto.Add("../../AllPhoto/unKnow/NoResult.png"); }
            //        Highphotos.Add(Highphoto.OrderByDescending(m => m).FirstOrDefault());
            //        HighCity.Add(City.Find(ADHomeID.HomeCity).CityTW);
            //        ADHomeID.HomeMoney = Math.Round(ADHomeID.HomeMoney, 2);
            //        HighhomeDatas.Add(ADHomeID);
            //    }
            //    if (ADHomeID.HomeADLevel > 2)
            //    {
            //        string autoFile = Server.MapPath("~/AllPhoto/Home" + "/" + ADHomeID.HomeID);
            //        List<string> Midphoto = searchPhotos.searchPhotos(autoFile, ADHomeID.HomeID);
            //        if (Midphoto.Count() == 0) { Midphoto.Add("../../AllPhoto/unKnow/NoResult.png"); }
            //        Midphotos.Add(Midphoto.OrderByDescending(m => m).FirstOrDefault());
            //        MidhCity.Add(City.Find(ADHomeID.HomeCity).CityTW);
            //        ADHomeID.HomeMoney = Math.Round(ADHomeID.HomeMoney, 2);
            //        MidhomeDatas.Add(ADHomeID);
            //    }
            //}


            //ViewBag.HighhomeDatas = HighhomeDatas;
            //ViewBag.HighCity = HighCity;
            //ViewBag.HighhomeDatasCount = HighhomeDatas.Count();
            //ViewBag.Highphotos = Highphotos;

            //ViewBag.Midphotos = Midphotos;
            //ViewBag.MidhomeDatasCount = MidhomeDatas.Count();
            //ViewBag.MidhCity = MidhCity;
            //ViewBag.MidhomeDatas = MidhomeDatas;
            //ViewBag.MidhCity = MidhCity;


            //ViewBag.peopleDatas = peopleDatas;
            //ViewBag.peopleDatasCount = peopleDatas.Count();
            //ViewBag.peoplePhotoss = peoplePhotoss;

            return View();
        }


        public ActionResult houseIndex(int page = 1)
        {

            var homeData = db.HomeData.Where(h => h.HomeADLevel > 1).OrderByDescending(h => h.HomeADLevel);
            var HomeDatas = homeData.ToList();
            var homeImgFile = Server.MapPath("~/AllPhoto/Home" + "/");
            ViewBag.ALLList = _getPhotoToView.photoIndexSearch(HomeDatas, homeImgFile);

            //var City = db.CityTypeData;

            //List<string> Midphotos = new List<string>();
            //List<HomeData> MidhomeDatas = new List<HomeData>();
            //List<string> MidhCity = new List<string>();

            //foreach (var ADHomeID in homeData)
            //{
            //    string autoFile = Server.MapPath("~/AllPhoto/Home" + "/" + ADHomeID.HomeID);
            //    List<string> Midphoto = searchPhotos.searchPhotos(autoFile, ADHomeID.HomeID);
            //    if (Midphoto.Count() == 0) { Midphoto.Add("../../AllPhoto/unKnow/NoResult.png"); }
            //    Midphotos.Add(Midphoto.OrderByDescending(m => m).FirstOrDefault());
            //    ADHomeID.HomeMoney = Math.Round(ADHomeID.HomeMoney, 2);
            //    MidhCity.Add(City.Find(ADHomeID.HomeCity).CityTW);
            //    MidhomeDatas.Add(ADHomeID);
            //}

            //ViewBag.MidhomeDatas = MidhomeDatas;
            //ViewBag.MidhomeDatasCount = MidhomeDatas.Count();
            //ViewBag.MidhCity = MidhCity;
            //ViewBag.Midphotos = Midphotos;

            int pagesize = 6;
            // ViewBag.pagesize = ViewBag.ALLList[2] > 6 ? ViewBag.ALLList[2] - (page*6) : pagesize - ViewBag.ALLList[2];
            int allCount = ViewBag.ALLList[2];
            ViewBag.pagesize = ChangIDAuto.AutoPage(allCount, pagesize, page);


            var pagedList = homeData.ToPagedList(page, pagesize);
            ViewBag.countyID = db.CityTypeData.ToList();
            ViewBag.HomeTypeData = db.HomeTypeData.ToList();
            ViewBag.CarTypeData = db.CarTypeData.ToList();
            ViewBag.HomeSaleType = db.SaleTypeData.ToList();

            return View(pagedList);
        }

        //[HttpPost]
        public ActionResult searchhouseIndex(string cityid, int page = 1)
        {
            ViewBag.cityid = cityid;
            var City = db.CityTypeData;
            var homeData = db.HomeData.OrderByDescending(h => h.HomeADLevel).Where(h => h.HomeADLevel >= 1);
            if (cityid == "top")
            {
                homeData = homeData.Where(h => h.HomeCity == "A" || h.HomeCity == "C" || h.HomeCity == "F" || h.HomeCity == "J" || h.HomeCity == "K" || h.HomeCity == "O");
                ViewBag.titleCity = "北部";
            }
            else if (cityid == "mid")
            {
                homeData = homeData.Where(h => h.HomeCity == "B" || h.HomeCity == "I" || h.HomeCity == "M" || h.HomeCity == "N" || h.HomeCity == "Q");
                ViewBag.titleCity = "中部";
            }
            else if (cityid == "south")
            {
                homeData = homeData.Where(h => h.HomeCity == "D" || h.HomeCity == "E" || h.HomeCity == "M" || h.HomeCity == "T" | h.HomeCity == "P");
                ViewBag.titleCity = "南部";
            }
            else if (cityid == "eath")
            {
                homeData = homeData.Where(h => h.HomeCity == "G" || h.HomeCity == "U" || h.HomeCity == "V");
                ViewBag.titleCity = "東部";
            }

            var HomeDatas = homeData.ToList();
            var homeImgFile = Server.MapPath("~/AllPhoto/Home" + "/");
            ViewBag.ALLList = _getPhotoToView.photoIndexSearch(HomeDatas, homeImgFile);

            //List<string> Midphotos = new List<string>();
            //List<HomeData> MidhomeDatas = new List<HomeData>();
            //List<string> MidhCity = new List<string>();

            //foreach (var ADHomeID in homeData)
            //{
            //    string autoFile = Server.MapPath("~/AllPhoto/Home" + "/" + ADHomeID.HomeID);
            //    List<string> Midphoto = searchPhotos.searchPhotos(autoFile, ADHomeID.HomeID);
            //    if (Midphoto.Count() == 0) { Midphoto.Add("../../AllPhoto/unKnow/NoResult.png"); }
            //    Midphotos.Add(Midphoto.OrderByDescending(m => m).FirstOrDefault());
            //    ADHomeID.HomeMoney = Math.Round(ADHomeID.HomeMoney, 2);
            //    MidhCity.Add(City.Find(ADHomeID.HomeCity).CityTW);
            //    MidhomeDatas.Add(ADHomeID);

            //}

            //ViewBag.MidhomeDatas = MidhomeDatas;
            //ViewBag.MidhomeDatasCount = MidhomeDatas.Count();
            //ViewBag.MidhCity = MidhCity;
            //ViewBag.Midphotos = Midphotos;

            int pagesize = 6;
            // ViewBag.pagesize = ViewBag.ALLList[2] > 6 ? ViewBag.ALLList[2] - (page*6) : pagesize - ViewBag.ALLList[2];
            int allCount = ViewBag.ALLList[2];
            ViewBag.pagesize = ChangIDAuto.AutoPage(allCount, pagesize,page);


            var pagedList = homeData.ToPagedList(page, pagesize);
            ViewBag.countyID = db.CityTypeData.ToList();
            ViewBag.HomeTypeData = db.HomeTypeData.ToList();
            ViewBag.CarTypeData = db.CarTypeData.ToList();
            ViewBag.HomeSaleType = db.SaleTypeData.ToList();

            return View(pagedList);
        }


        [HttpPost]
        public ActionResult searchhouseIndex(string cityid,string SearchFast, string County, string Town, int SquareMeters, int HomeTypeDatas, int CarTypeDatas, int AllMoney, int HomeAge, int HomeFlortDatas, int HomeRoomDatas, bool? HomeSaleDatas, int page = 1)
        {
            ViewBag.cityid = cityid;
            var City = db.CityTypeData;
            var homeData = db.HomeData.Include(h => h.ADTypeData).Include(h => h.CarTypeData).Include(h => h.CityTypeData).Include(h => h.HomeTypeData).Include(h => h.PeopleData).Include(h => h.SaleTypeData).OrderByDescending(h => h.HomeID).OrderByDescending(h => h.HomeID).OrderByDescending(h => h.HomeSaleType).Where(p => p.HomeADLevel >= 0);
            
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

            ViewBag.Errorr = homeData.ToList().Count() == 0 ? "查無資料，請重新查詢" : "";

            var HomeDatas = homeData.ToList();
            var homeImgFile = Server.MapPath("~/AllPhoto/Home" + "/");
            ViewBag.ALLList = _getPhotoToView.photoIndexSearch(HomeDatas, homeImgFile);

            //List<string> Midphotos = new List<string>();
            //List<HomeData> MidhomeDatas = new List<HomeData>();
            //List<string> MidhCity = new List<string>();

            //foreach (var ADHomeID in homeData)
            //{
            //    string autoFile = Server.MapPath("~/AllPhoto/Home" + "/" + ADHomeID.HomeID);
            //    List<string> Midphoto = searchPhotos.searchPhotos(autoFile, ADHomeID.HomeID);
            //    if (Midphoto.Count() == 0) { Midphoto.Add("../../AllPhoto/unKnow/NoResult.png"); }
            //    Midphotos.Add(Midphoto.OrderByDescending(m => m).FirstOrDefault());
            //    ADHomeID.HomeMoney = Math.Round(ADHomeID.HomeMoney, 2);
            //    MidhCity.Add(City.Find(ADHomeID.HomeCity).CityTW);
            //    MidhomeDatas.Add(ADHomeID);

            //}

            //ViewBag.MidhomeDatas = MidhomeDatas;
            //ViewBag.MidhomeDatasCount = MidhomeDatas.Count();
            //ViewBag.MidhCity = MidhCity;
            //ViewBag.Midphotos = Midphotos;


            int pagesize = 6;
            var pagedList = homeData.ToPagedList(page, pagesize);
            ViewBag.countyID = db.CityTypeData.ToList();
            ViewBag.HomeTypeData = db.HomeTypeData.ToList();
            ViewBag.CarTypeData = db.CarTypeData.ToList();
            ViewBag.HomeSaleType = db.SaleTypeData.ToList();
            return View(pagedList);
        }
    }
}
