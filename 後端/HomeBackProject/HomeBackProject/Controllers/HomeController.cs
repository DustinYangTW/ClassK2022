﻿using HomeBackProject.library;
using HomeBackProject.Models;
using HomeBackProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace HomeBackProject.Controllers
{
    public class HomeController : Controller
    {
        private HomeDataEntities db = new HomeDataEntities(); 
        private SearchPhotos searchPhotos = new SearchPhotos();

        // GET: HomeManager
        public ActionResult Index()
        {
            var City = db.CityTypeData;
            //ViewBag.HomeDatas = (from h in db.HomeData
            //                     join city in db.CityTypeData on h.HomeCity equals city.CityIDTW
            //                     where (h.HomeADLevel > 1)
            //                     select new { h, city.CityTW }).ToList();

            //List<HomeData> HomeDatas = (from h in db.HomeData
            //                           join city in db.CityTypeData on h.HomeCity equals city.CityIDTW
            //                           where (h.HomeADLevel > 1) 
            //                           select).ToList();

            ViewBag.People = db.PeopleData.OrderByDescending(m => m.PeopleCash).Take(3);

            List < HomeData > HomeDatas = db.HomeData.Where(h => h.HomeADLevel > 1).ToList();

            List<string> Highphotos = new List<string>();
            List<HomeData> HighhomeDatas = new List<HomeData>();
            List<string> HighCity = new List<string>();

            List<string> Midphotos = new List<string>();
            List<HomeData> MidhomeDatas = new List<HomeData>();
            List<string> MidhCity = new List<string>();

            List<PeopleData> peopleDatas = new List<PeopleData>();
            List<string> peoplePhotoss = new List<string>();

            foreach(var peoplePhoto in ViewBag.People)
            {
                string autoFile = Server.MapPath("~/AllPhoto/PeopleImage" + "/" + peoplePhoto.PeopleID);
                List<string> peopelePhotos = searchPhotos.searchPhotos(autoFile, peoplePhoto.PeopleID);
                peoplePhotoss.Add(peopelePhotos.OrderBy(m => m).FirstOrDefault());
                if (peopelePhotos.Count() == 0) { peoplePhotoss.Add("../../AllPhoto/unKnow/NoResult.png"); }
                peopleDatas.Add(peoplePhoto);
            }

            foreach (var ADHomeID in HomeDatas)
            {
                if (ADHomeID.HomeADLevel == 4)
                {
                    string autoFile = Server.MapPath("~/AllPhoto/Home" + "/" + ADHomeID.HomeID);
                    List<string> Highphoto = searchPhotos.searchPhotos(autoFile, ADHomeID.HomeID);
                    if (Highphoto.Count() == 0) { Highphoto.Add("../../AllPhoto/unKnow/NoResult.png"); }
                    Highphotos.Add(Highphoto.OrderBy(m => m).FirstOrDefault());
                    HighCity.Add(City.Find(ADHomeID.HomeCity).CityTW);
                    ADHomeID.HomeMoney = Math.Round(ADHomeID.HomeMoney, 2);
                    HighhomeDatas.Add(ADHomeID);
                }     
                if (ADHomeID.HomeADLevel > 2)
                {
                    string autoFile = Server.MapPath("~/AllPhoto/Home" + "/" + ADHomeID.HomeID);
                    List<string> Midphoto = searchPhotos.searchPhotos(autoFile, ADHomeID.HomeID);
                    if (Midphoto.Count() == 0) { Midphoto.Add("../../AllPhoto/unKnow/NoResult.png"); }
                    Midphotos.Add(Midphoto.OrderBy(m => m).FirstOrDefault());
                    MidhCity.Add(City.Find(ADHomeID.HomeCity).CityTW);
                    ADHomeID.HomeMoney = Math.Round(ADHomeID.HomeMoney, 2);
                    MidhomeDatas.Add(ADHomeID);
                }
            }


            ViewBag.HighhomeDatas = HighhomeDatas;
            ViewBag.HighCity = HighCity;
            ViewBag.HighhomeDatasCount = HighhomeDatas.Count();
            ViewBag.Highphotos = Highphotos;

            ViewBag.Midphotos = Midphotos;
            ViewBag.MidhomeDatasCount = MidhomeDatas.Count();
            ViewBag.MidhCity = MidhCity;
            ViewBag.MidhomeDatas = MidhomeDatas;
            ViewBag.MidhCity = MidhCity;


            ViewBag.peopleDatas = peopleDatas;
            ViewBag.peopleDatasCount = peopleDatas.Count();
            ViewBag.peoplePhotoss = peoplePhotoss;

            return View();
        }
    }
}
