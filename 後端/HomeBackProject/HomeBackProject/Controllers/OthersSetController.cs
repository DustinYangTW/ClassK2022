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

        public ActionResult Index()
        {
            VMOthersSet vMOthersSet = new VMOthersSet()
            {
                TerritoryTypeData = db.TerritoryTypeData.ToList(),
                SaleTypeData = db.SaleTypeData.ToList(),
                ProgramData = db.ProgramData.ToList(),
                PeopleRankData = db.PeopleRankData.ToList(),
                HomeTypeData = db.HomeTypeData.ToList(),
                CityTypeData = db.CityTypeData.ToList(),
                CarTypeData = db.CarTypeData.ToList(),
                ADTypeData = db.ADTypeData.ToList()
            };

            

            return View(vMOthersSet);
        }
    }
}