using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeBackProject.library;
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
            var password = HashPassword.getHashPassword(vMLogin.PassWord);
            var user = db.AccountData.Where(userEmailFind => userEmailFind.EmailAccount == vMLogin.EmailAccount && userEmailFind.PassWord == password).FirstOrDefault();


            if (user == null)
            {
                ViewBag.ErrMsg = "**帳號或密碼有錯誤";
                return View("Login");
            }
            var userID = db.PeopleData.Where(userIDFind => userIDFind.EMail == vMLogin.EmailAccount).FirstOrDefault();

            Session["userID"] = userID.PeopleID;
            Session["userNmae"] = userID.PeopleName;
            Session["userRank"] = userID.SaleStateID;
            return RedirectToAction("Index");
        }
        public ActionResult Logout()
        {
            Session["userID"] = null;
            Session["userNmae"] = null;
            Session["userRank"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ForgetPW()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgetPW(VMForgetPassWord vMForgetPassWord)
        {
            //驗證是否有帳號跟身分證確認
            var people = db.PeopleData.Where(p=>p.IdebtityNumber == vMForgetPassWord.IdebtityNumber && p.EMail == vMForgetPassWord.EmailAccount).FirstOrDefault();

            //驗證是否有抓到值
            if(people == null)
            {
                ViewBag.Error = "**查無此帳號或身分證輸入錯誤";
            }

            AccountData accountData = db.AccountData.Find(vMForgetPassWord.EmailAccount);
            if (ModelState.IsValid)
            {
                //修改密碼
                accountData.PassWord = HashPassword.getHashPassword( vMForgetPassWord.PassWord);
                //存入資料庫
                db.Entry(accountData).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                //存入資料庫

                //導回登入介面，並且顯示修改成功
                TempData["Loginsusses"] = "密碼修改完成，請重新嘗試登入";
                return RedirectToAction("Login","LogInOut");
            }

            return View();
        }
    }
}
