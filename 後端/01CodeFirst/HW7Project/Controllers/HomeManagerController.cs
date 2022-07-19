using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HW7Project.Models;

namespace HW7Project.Controllers
{
    public class HomeManagerController : Controller
    {
        HW7ProjectContext db = new HW7ProjectContext();
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
            var user = db.Employees.Where(m=>m.Account == vMLogin.Account  &&  m.Password == vMLogin.Password).FirstOrDefault();
            if(user == null)
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
            return RedirectToAction("Index","Home");
        }
    }
}