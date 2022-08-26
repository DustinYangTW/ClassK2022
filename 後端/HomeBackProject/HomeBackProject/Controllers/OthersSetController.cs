using HomeBackProject.Models;
using HomeBackProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeBackProject.Controllers
{
    public class OthersSetController : Controller
    {
        private HomeDataEntities db = new HomeDataEntities();
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Index(string idNmae)
        {
            if (idNmae == "Rank")
            {
                VMOthersSet vMOthersSet = new VMOthersSet()
                {
                    PeopleRankData = db.PeopleRankData.ToList()
                };
                ViewBag.CheckData = idNmae;
                ViewBag.CheckView = "會員身份設定";
                return View(vMOthersSet);
            }
            //VMOthersSet vMOthersSet = new VMOthersSet()
            //{
            //    //TerritoryTypeData = db.TerritoryTypeData.ToList(),
            //    //SaleTypeData = db.SaleTypeData.ToList(),
            //    //ProgramData = db.ProgramData.ToList(),
            //    //PeopleRankData = db.PeopleRankData.ToList(),
            //    //HomeTypeData = db.HomeTypeData.ToList(),
            //    //CityTypeData = db.CityTypeData.ToList(),
            //    //CarTypeData = db.CarTypeData.ToList(),
            //    //ADTypeData = db.ADTypeData.ToList()
            //};
            ViewBag.CheckView = "請在左側選擇要操作的系統";
            return View();
        }
    }
}