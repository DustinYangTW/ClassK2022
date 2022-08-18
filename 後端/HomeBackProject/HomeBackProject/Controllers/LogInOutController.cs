using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeBackProject.Models;
using HomeBackProject.ViewModel;

namespace HomeBackProject.Controllers
{
    public class LogInOutController : Controller
    {
        private HomeDataEntities db = new HomeDataEntities();
        [LoginCkeck]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(VMLogin vMLogin)
        {
            //selece * from Employee where account=@account and password=@password
            var user = db.AccountData.Where(userEmailFind => userEmailFind.EmailAccount == vMLogin.EmailAccount && userEmailFind.PassWord == vMLogin.PassWord).FirstOrDefault();


            if (user == null)
            {
                ViewBag.ErrMsg = "**帳號或密碼有錯誤";
                return View("Login");
            }
            var userID = db.PeopleData.Where(userIDFind => userIDFind.EMail == vMLogin.EmailAccount).FirstOrDefault();

            Session["userID"] = userID.PeopleID;
            Session["userNmae"] = userID.PeopleName;
            return RedirectToAction("Index");
        }
        public ActionResult Logout()
        {
            Session["userID"] = null;
            Session["userNmae"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}
