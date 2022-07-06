using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeBackProject.Models;

namespace HomeBackProject.Controllers
{
    public class PeopleController : Controller
    {
        ActiondbController actiondbController = new ActiondbController();
        HomeDataEntities db = new HomeDataEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult Create(AccountData accountData)
        //{
        //    return actiondbController.Create(db, db.AccountDatas, accountData);
        //}
        [HttpPost]
        public ActionResult Create(PeopleData peopleData)
        {
            AccountData accountData = new AccountData();
            accountData.EmailAccount = peopleData.EMail;
            accountData.PassWord = peopleData.PeopleID;
            actiondbController.Create(db, db.AccountDatas, accountData);
            return actiondbController.Create(db,db.PeopleDatas, peopleData);
        }
    }
}