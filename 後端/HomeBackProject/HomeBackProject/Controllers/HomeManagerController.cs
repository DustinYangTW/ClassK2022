using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeBackProject.Models;
using HomeBackProject.ViewModel;

namespace HomeBackProject.Controllers
{
    public class HomeManagerController : Controller
    {
        HomeDataEntities db = new HomeDataEntities();

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
            var user = db.AccountData.Where(m => m.EmailAccount == vMLogin.EmailAccount && m.PassWord == vMLogin.PassWord).FirstOrDefault();
            if (user == null)
            {
                ViewBag.ErrMsg = "帳號或密碼有錯誤";
                return View(vMLogin);
            }
            Session["user"] = user;
            return RedirectToAction("Index");
        }
        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}