using HomeBackProject.library;
using HomeBackProject.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace HomeBackProject.Controllers
{
    public class PeopleDatasController : Controller
    {
        private HomeDataEntities db = new HomeDataEntities();
        private ActiondbController actiondbController = new ActiondbController();
        private  AccountData accountData = new AccountData();
        private ChangIDAuto changIDAuto = new ChangIDAuto();
        private PostPhotos postPhotos = new PostPhotos(); 
        private SearchPhotos searchPhotos = new SearchPhotos();


        // GET: PeopleDatas
        [LoginCkeck]
        public ActionResult Index(int page = 1)
        {
            string data = Session["userRank"].ToString();
            if (Int16.Parse(data) == 4)
            {
                var peopleData = db.PeopleData.Include(p => p.AccountData).Include(p => p.CityTypeData).Include(p => p.PeopleRankData).Include(p => p.ProgramData).OrderByDescending(p => p.PeopleID);
                int pagesize = 10;
                var pagedList = peopleData.ToPagedList(page, pagesize);

                return View(pagedList);
            }
            else
            {
                return RedirectToAction("DetailsMyself", new { id = Session["userID"].ToString() });
            }
        }

        [LoginCkeck]
        [HttpPost]
        public ActionResult Index(string name, int page = 1)
        {
            int pagesize = 10;
            if (name == "")
            {
                var peopleData = db.PeopleData.Include(p => p.AccountData).Include(p => p.CityTypeData).Include(p => p.PeopleRankData).Include(p => p.ProgramData).OrderByDescending(p => p.PeopleID);
                var pagedList = peopleData.ToPagedList(page, pagesize);
                return View(pagedList);
            }
            else if (name.Contains("09"))
            {
                var peopleData = db.PeopleData.Include(p => p.AccountData).Include(p => p.CityTypeData).Include(p => p.PeopleRankData).Include(p => p.ProgramData).OrderByDescending(p => p.PeopleID).Where(p => p.PhoneNumber.Contains(name));
                var pagedList = peopleData.ToPagedList(page, pagesize);
                return View(pagedList);
            }
            else
            {
                var peopleData = db.PeopleData.Include(p => p.AccountData).Include(p => p.CityTypeData).Include(p => p.PeopleRankData).Include(p => p.ProgramData).OrderByDescending(p => p.PeopleID).Where(p => p.PeopleName.Contains(name));
                var pagedList = peopleData.ToPagedList(page, pagesize);
                return View(pagedList);
            }

        }

        // GET: PeopleDatas/Details/5
        [LoginCkeck]
        //[ChildActionOnly]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
               //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeopleData peopleData = db.PeopleData.Find(id);
            if (peopleData == null)
            {
                //return HttpNotFound();
                return RedirectToAction("Index", "Home");
            }

            //找照片
            string autoFile = Server.MapPath("~/AllPhoto/PeopleImage/" + id);
            List<string> photo = searchPhotos.searchPhotos(autoFile, id);
            ViewBag.photoHeadShot = photo.Count() > 0 ? photo[0] : "../../AllPhoto/PeopleImage/all/people.jpg";
            //找照片

            ViewBag.CompanyName = peopleData.CompanyName != null ? peopleData.CompanyName :"無";

            if (peopleData == null)
            {
                //return RedirectToAction("Index", "Home");
                return HttpNotFound();
            }
            return PartialView(peopleData);
        }     
        [LoginCkeck]
        public ActionResult DetailsMyself(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeopleData peopleData = db.PeopleData.Find(id);
            if (peopleData == null)
            {
                //return HttpNotFound();
                return RedirectToAction("Index", "Home");
            }

            //找照片
            string autoFile = Server.MapPath("~/AllPhoto/PeopleImage/" + id);
            List<string> photo = searchPhotos.searchPhotos(autoFile, id);
            ViewBag.photoHeadShot = photo.Count() > 0 ? photo[0] : "../../AllPhoto/PeopleImage/all/people.jpg";
            //找照片

            ViewBag.CompanyName = peopleData.CompanyName != null ? peopleData.CompanyName :"無";

            if (peopleData == null)
            {
                //return HttpNotFound();
                return RedirectToAction("Index", "Home");
            }
            return View(peopleData);
        }

        // GET: PeopleDatas/Create
        public ActionResult Create()
        {
            ViewBag.countyID = db.CityTypeData.ToList();
            ViewBag.SaleStateID = db.PeopleRankData.ToList();
            return View();
        }

        // POST: PeopleDatas/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        //[LoginCkeck]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PeopleData peopleData, HttpPostedFileBase[] photo, string PassWord)
        {
            List<HttpPostedFileBase> photoList = new List<HttpPostedFileBase>();
            string checkdataPhoto = "";
            if (photo[0] != null)
            {
                for (int i = 0; i < photo.Length; i++)
                {
                    if (photo[i] == null)
                    {
                        break;
                    }
                    checkdataPhoto = postPhotos.checkPhoto(photo[i].FileName, photo[i].ContentLength);
                    if (checkdataPhoto != "OK")
                    {
                        ViewBag.countyID = db.CityTypeData.ToList();
                        ViewBag.SaleStateID = db.PeopleRankData.ToList();
                        ViewBag.checkdataPhoto = "**"+checkdataPhoto;
                        return View();
                    }
                    
                    photoList.Add(photo[i]);
                }
            }

            var account = db.AccountData.Find(peopleData.EMail);

            if (account != null)
            {
                ViewBag.countyID = db.CityTypeData.ToList();
                ViewBag.SaleStateID = db.PeopleRankData.ToList();
                ViewBag.EmailErrorMessage = "**此帳號(E-mail)有人使用";
                return View();
            }


            if (ModelState.IsValid)
            {

                accountData.EmailAccount = peopleData.EMail;
                accountData.PassWord = PassWord;
                actiondbController.Create(db, db.AccountData, accountData);

                var PeopleCountID = db.PeopleData.OrderByDescending(m => m.PeopleID).FirstOrDefault();//存入最後一筆的資料
                peopleData.PeopleID = changIDAuto.changIDNumber(PeopleCountID.PeopleID);  //自動加編號A000000000，新增一筆自動+1

                peopleData.PeopleCash = 0;

                actiondbController.Create(db, db.PeopleData, peopleData, "Login", "LogInOut");

                string autoFile = Server.MapPath("~/AllPhoto");
                return actiondbController.SavePhoto(autoFile, photoList, peopleData.PeopleID, "Login", "LogInOut");
            }
            else
            {
                ViewBag.countyID = db.CityTypeData.ToList();
                ViewBag.SaleStateID = db.PeopleRankData.ToList();
                return View();
            }
        }

        // GET: PeopleDatas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                //return RedirectToAction("Index", "Home");
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeopleData peopleData = db.PeopleData.Find(id);
            //找照片
            string autoFile = Server.MapPath("~/AllPhoto/PeopleImage/" + id);
            List<string> photo = searchPhotos.searchPhotos(autoFile, id);
            ViewBag.photoHeadShot = photo.Count() > 0 ? photo[0] : "../../AllPhoto/PeopleImage/all/people.jpg";
            //找照片

            if (peopleData == null)
            {
                //return HttpNotFound();
                return RedirectToAction("Index", "Home");
            }
            //if (peopleData == null)
            //{
            //    return HttpNotFound();
            //}

            string adnimID = Session["userID"].ToString();
            ViewBag.BirthDay = peopleData.Birthday;
            ViewBag.Rank = db.PeopleData.Where(m => m.PeopleID == adnimID).FirstOrDefault().SaleStateID;
            ViewBag.Gender = peopleData.Gender == true ? "男" : "女";
            ViewBag.countyID = db.CityTypeData.ToList();
            var countyTownlast = db.PeopleData.Where(p => p.PeopleID == id.ToString()).FirstOrDefault();
            ViewBag.Townlast = countyTownlast.Town;
            var countyCountylast = db.CityTypeData.Where(p => p.CityIDTW == peopleData.County).FirstOrDefault();
            ViewBag.countyIDlast = peopleData.County;
            ViewBag.countyTWlast = countyCountylast.CityTW;
            ViewBag.NowSaleStateID = peopleData.SaleStateID;
            ViewBag.SaleStateID = db.PeopleRankData.ToList();

            return View(peopleData);
        }

        // POST: PeopleDatas/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PeopleData peopleData, HttpPostedFileBase[] photo)
        {
            List<HttpPostedFileBase> photoList = new List<HttpPostedFileBase>();
            string checkdataPhoto = "";
            if (photo[0] != null)
            {
                for (int i = 0; i < photo.Length; i++)
                {
                    if (photo[i] == null)
                    {
                        break;
                    }
                    checkdataPhoto = postPhotos.checkPhoto(photo[i].FileName, photo[i].ContentLength);
                    if (checkdataPhoto != "OK")
                    {
                        ViewBag.countyID = db.CityTypeData.ToList();
                        ViewBag.SaleStateID = db.PeopleRankData.ToList();
                        return View();
                    }

                    photoList.Add(photo[i]);
                }
            }
            //ModelState.Remove("EMail");
            if (ModelState.IsValid)
            {
                db.Entry(peopleData).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                string autoFile = Server.MapPath("~/AllPhoto");
                return actiondbController.SavePhoto(autoFile, photoList, peopleData.PeopleID, "Index", "PeopleDatas");
            }

            string id = peopleData.PeopleID;
            string adnimID = Session["userID"].ToString();
            ViewBag.BirthDay = peopleData.Birthday;
            ViewBag.Rank = db.PeopleData.Where(m => m.PeopleID == adnimID).FirstOrDefault().SaleStateID;
            ViewBag.Gender = peopleData.Gender == true ? "男" : "女";
            ViewBag.countyID = db.CityTypeData.ToList();
            var countyTownlast = db.PeopleData.Where(p => p.PeopleID == id.ToString()).FirstOrDefault();
            ViewBag.Townlast = countyTownlast.Town;
            var countyCountylast = db.CityTypeData.Where(p => p.CityIDTW == peopleData.County).FirstOrDefault();
            ViewBag.countyIDlast = peopleData.County;
            ViewBag.countyTWlast = countyCountylast.CityTW;
            ViewBag.NowSaleStateID = peopleData.SaleStateID;
            ViewBag.SaleStateID = db.PeopleRankData.ToList();

            return View(peopleData);
        }

        // GET: PeopleDatas/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    PeopleData peopleData = db.PeopleData.Find(id);
        //    if (peopleData == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(peopleData);
        //}

        //// POST: PeopleDatas/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    PeopleData peopleData = db.PeopleData.Find(id);
        //    db.PeopleData.Remove(peopleData);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
