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
            if (ModelState.IsValid)
            {
                accountData.EmailAccount = peopleData.EMail;
                accountData.PassWord = peopleData.IdebtityNumber;
                actiondbController.Create(db, db.AccountData, accountData);
                var countPeopleDatas = db.PeopleData.Count() + 1;
                peopleData.PeopleID = "A" + countPeopleDatas.ToString().PadLeft(9, '0');  //自動加編號A000000000，新增一筆自動+1
                return actiondbController.Create(db, db.PeopleData, peopleData);
            }
            return View();
        }
    }
}