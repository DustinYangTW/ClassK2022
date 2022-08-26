using HomeBackProject.Models;
using HomeBackProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using HomeBackProject.library;

namespace HomeBackProject.Controllers
{
    public class OthersSetController : Controller
    {
        private HomeDataEntities db = new HomeDataEntities();
        private ActiondbController actiondbController = new ActiondbController();

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

                //int pagesize = 10;
                //var pagedList = vMOthersSet.PeopleRankData.OrderBy(m=>m.PeopleRank).ToPagedList(page, pagesize);
                return View(vMOthersSet);
            }

            else if (idNmae == "Program")
            {
                VMOthersSet vMOthersSet = new VMOthersSet()
                {
                    ProgramData = db.ProgramData.ToList()
                };
                ViewBag.CheckData = idNmae;
                ViewBag.CheckView = "會員方案設定";
                return View(vMOthersSet);
            }

            else if (idNmae == "Home")
            {
                VMOthersSet vMOthersSet = new VMOthersSet()
                {
                    HomeTypeData = db.HomeTypeData.ToList()
                };
                ViewBag.CheckData = idNmae;
                ViewBag.CheckView = "房屋類型設定";
                return View(vMOthersSet);
            }

            else if (idNmae == "Territory")
            {
                VMOthersSet vMOthersSet = new VMOthersSet()
                {
                    TerritoryTypeData = db.TerritoryTypeData.ToList()
                };
                ViewBag.CheckData = idNmae;
                ViewBag.CheckView = "土地類型設定";
                return View(vMOthersSet);
            }

            else if (idNmae == "Car")
            {
                VMOthersSet vMOthersSet = new VMOthersSet()
                {
                    CarTypeData = db.CarTypeData.ToList()
                };
                ViewBag.CheckData = idNmae;
                ViewBag.CheckView = "車位類型設定"; 
                return View(vMOthersSet);
            }

            else if (idNmae == "Sale")
            {
                VMOthersSet vMOthersSet = new VMOthersSet()
                {
                    SaleTypeData = db.SaleTypeData.ToList()
                };
                ViewBag.CheckData = idNmae;
                ViewBag.CheckView = "銷售類型設定";
                return View(vMOthersSet);
            }

            else if (idNmae == "AD")
            {
                VMOthersSet vMOthersSet = new VMOthersSet()
                {
                    ADTypeData = db.ADTypeData.ToList()
                };
                ViewBag.CheckData = idNmae;
                ViewBag.CheckView = "廣告設定";
                return View(vMOthersSet);
            }

            else if (idNmae == "City")
            {
                VMOthersSet vMOthersSet = new VMOthersSet()
                {
                    CityTypeData = db.CityTypeData.ToList()
                };
                ViewBag.CheckData = idNmae;
                ViewBag.CheckView = "縣市設定";
                return View(vMOthersSet);
            }


            ViewBag.CheckView = "請在左側選擇要操作的系統";
            return View();
        }

        [HttpPost]
        public ActionResult Create(string idNmae,string toDBName)
        {
            if (ModelState.IsValid)
            {
                PeopleRankData peopleRankData = new PeopleRankData();
                peopleRankData.PeopleRank = toDBName;
                return actiondbController.Create(db, db.PeopleRankData, peopleRankData);
            }

            return View();
        }
    }
}