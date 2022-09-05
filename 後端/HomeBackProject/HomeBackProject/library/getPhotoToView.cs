using HomeBackProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeBackProject.library
{
    public class getPhotoToView
    {
        private HomeDataEntities db = new HomeDataEntities();
        private SearchPhotos searchPhotos = new SearchPhotos();

        public List<Object> photoIndexSearch(List<HomeData> HomeDatas, string peopleImg, string homeImg)
        {
            var City = db.CityTypeData;
            var People = db.PeopleData.OrderByDescending(m => m.PeopleCash).Where(p => p.SaleStateID != 4).Take(3);

            List<HomeData> HomeDatass = HomeDatas;

            List<string> Highphotos = new List<string>();
            List<HomeData> HighhomeDatas = new List<HomeData>();
            List<string> HighCity = new List<string>();

            List<string> Midphotos = new List<string>();
            List<HomeData> MidhomeDatas = new List<HomeData>();
            List<string> MidhCity = new List<string>();

            List<PeopleData> peopleDatas = new List<PeopleData>();
            List<string> peoplePhotoss = new List<string>();

            foreach (var peoplePhoto in People)
            {
                List<string> peopelePhotos = searchPhotos.searchPhotos(peopleImg + peoplePhoto.PeopleID, peoplePhoto.PeopleID);
                peoplePhotoss.Add(peopelePhotos.OrderByDescending(m => m).FirstOrDefault());
                if (peopelePhotos.Count() == 0) { peoplePhotoss.Add("../../AllPhoto/unKnow/NoResult.png"); }
                peopleDatas.Add(peoplePhoto);
            }

            foreach (var ADHomeID in HomeDatas)
            {
                if (ADHomeID.HomeADLevel == 4)
                {
                    List<string> Highphoto = searchPhotos.searchPhotos(homeImg + ADHomeID.HomeID, ADHomeID.HomeID);
                    if (Highphoto.Count() == 0) { Highphoto.Add("../../AllPhoto/unKnow/NoResult.png"); }
                    Highphotos.Add(Highphoto.OrderByDescending(m => m).FirstOrDefault());
                    HighCity.Add(City.Find(ADHomeID.HomeCity).CityTW);
                    ADHomeID.HomeMoney = Math.Round(ADHomeID.HomeMoney, 2);
                    HighhomeDatas.Add(ADHomeID);
                }
                if (ADHomeID.HomeADLevel > 2)
                {
                    List<string> Midphoto = searchPhotos.searchPhotos(homeImg + ADHomeID.HomeID, ADHomeID.HomeID);
                    if (Midphoto.Count() == 0) { Midphoto.Add("../../AllPhoto/unKnow/NoResult.png"); }
                    Midphotos.Add(Midphoto.OrderByDescending(m => m).FirstOrDefault());
                    MidhCity.Add(City.Find(ADHomeID.HomeCity).CityTW);
                    ADHomeID.HomeMoney = Math.Round(ADHomeID.HomeMoney, 2);
                    MidhomeDatas.Add(ADHomeID);
                }
            }

            List<Object> photoIndexSearchList = new List<Object>();
            photoIndexSearchList.Add(Highphotos);//0
            photoIndexSearchList.Add(HighhomeDatas);//1
            photoIndexSearchList.Add(HighhomeDatas.Count());//2
            photoIndexSearchList.Add(HighCity);//3
            photoIndexSearchList.Add(Midphotos);//4
            photoIndexSearchList.Add(MidhomeDatas);//5
            photoIndexSearchList.Add(MidhomeDatas.Count());//6
            photoIndexSearchList.Add(MidhCity);//7
            photoIndexSearchList.Add(peopleDatas);//8
            photoIndexSearchList.Add(peopleDatas.Count());//9
            photoIndexSearchList.Add(peoplePhotoss);//10

            return photoIndexSearchList;
        }

        public List<Object> photoIndexSearch(List<HomeData> HomeDatas, string homeImg)
        {
            var City = db.CityTypeData;

            List<string> Midphotos = new List<string>();
            List<HomeData> MidhomeDatas = new List<HomeData>();
            List<string> MidhCity = new List<string>();

            foreach (var ADHomeID in HomeDatas)
            {
                List<string> Midphoto = searchPhotos.searchPhotos(homeImg+ ADHomeID.HomeID, ADHomeID.HomeID);
                if (Midphoto.Count() == 0) { Midphoto.Add("../../AllPhoto/unKnow/NoResult.png"); }
                Midphotos.Add(Midphoto.OrderByDescending(m => m).FirstOrDefault());
                ADHomeID.HomeMoney = Math.Round(ADHomeID.HomeMoney, 2);
                MidhCity.Add(City.Find(ADHomeID.HomeCity).CityTW);
                MidhomeDatas.Add(ADHomeID);
            }

            List<Object> photoIndexSearchList = new List<Object>();
            photoIndexSearchList.Add(Midphotos);//0
            photoIndexSearchList.Add(MidhomeDatas);//1
            photoIndexSearchList.Add(MidhomeDatas.Count());//2
            photoIndexSearchList.Add(MidhCity);//3


            return photoIndexSearchList;

        }
    }
}