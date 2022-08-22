using HomeBackProject.library;
using HomeBackProject.Models;
using PagedList;
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
<<<<<<< HEAD
        private PostPhotos postPhotos = new PostPhotos();
=======
        private PostPhotos postPhotos = new PostPhotos(); 
        private SearchPhotos searchPhotos = new SearchPhotos();
>>>>>>> 6d669b8f9a6a990e254f8581850905404b86abd5


        // GET: PeopleDatas
        [LoginCkeck]
        public ActionResult Index(int page = 1)
        {
            var peopleData = db.PeopleData.Include(p => p.AccountData).Include(p => p.CityTypeData).Include(p => p.PeopleRankData).Include(p => p.ProgramData).OrderByDescending(p => p.PeopleID);
            int pagesize = 10;
<<<<<<< HEAD
            var pagedList = peopleData.ToPagedList(page, pagesize);
=======
            var pagedList = peopleData.ToPagedList(page, pagesize);  
>>>>>>> 6d669b8f9a6a990e254f8581850905404b86abd5

            return View(pagedList);
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
<<<<<<< HEAD

=======
>>>>>>> 6d669b8f9a6a990e254f8581850905404b86abd5
                return View(pagedList);
            }
            else if (name.Contains("09"))
            {
                var peopleData = db.PeopleData.Include(p => p.AccountData).Include(p => p.CityTypeData).Include(p => p.PeopleRankData).Include(p => p.ProgramData).OrderByDescending(p => p.PeopleID).Where(p => p.PhoneNumber.Contains(name));
                var pagedList = peopleData.ToPagedList(page, pagesize);
<<<<<<< HEAD

=======
>>>>>>> 6d669b8f9a6a990e254f8581850905404b86abd5
                return View(pagedList);
            }
            else
            {
                var peopleData = db.PeopleData.Include(p => p.AccountData).Include(p => p.CityTypeData).Include(p => p.PeopleRankData).Include(p => p.ProgramData).OrderByDescending(p => p.PeopleID).Where(p => p.PeopleName.Contains(name));
                var pagedList = peopleData.ToPagedList(page, pagesize);
<<<<<<< HEAD

=======
>>>>>>> 6d669b8f9a6a990e254f8581850905404b86abd5
                return View(pagedList);
            }

        }

        // GET: PeopleDatas/Details/5
        [LoginCkeck]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeopleData peopleData = db.PeopleData.Find(id);
            string autoFile = Server.MapPath("~/AllPhoto/PeopleImage/" + id);
            List<string> photo = searchPhotos.searchPhotos(autoFile, id);

            int count = photo.Count();
            ViewBag.photoHeadShot = count > 0 ? photo[0] : "../../AllPhoto/PeopleImage/all/people.jpg";

            ViewBag.CompanyName = peopleData.CompanyName != null ? peopleData.CompanyName :"無";

            if (peopleData == null)
            {
                return HttpNotFound();
            }
            return PartialView(peopleData);
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
                        return View();
                    }
                    
                    photoList.Add(photo[i]);
                }
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
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeopleData peopleData = db.PeopleData.Find(id);
            if (peopleData == null)
            {
                return HttpNotFound();
            }
            ViewBag.BirthDay = db.PeopleData.Where(m => m.PeopleID == id.ToString()).FirstOrDefault().Birthday;
            ViewBag.EMail = new SelectList(db.AccountData, "EmailAccount", "PassWord", peopleData.EMail);
            ViewBag.County = new SelectList(db.CityTypeData, "CityIDTW", "CityTW", peopleData.County);
            ViewBag.SaleStateID = new SelectList(db.PeopleRankData, "HomeTSaleStateID", "PeopleRank", peopleData.SaleStateID);
            ViewBag.SchemeName = new SelectList(db.ProgramData, "ProgramSerialID", "ProgramName", peopleData.SchemeName);
            return View(peopleData);
        }

        // POST: PeopleDatas/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PeopleData peopleData)
        {
            if (ModelState.IsValid)
            {
                return actiondbController.Edit(db, peopleData);
            }
            ViewBag.EMail = new SelectList(db.AccountData, "EmailAccount", "PassWord", peopleData.EMail);
            ViewBag.County = new SelectList(db.CityTypeData, "CityIDTW", "CityTW", peopleData.County);
            ViewBag.SaleStateID = new SelectList(db.PeopleRankData, "HomeTSaleStateID", "PeopleRank", peopleData.SaleStateID);
            ViewBag.SchemeName = new SelectList(db.ProgramData, "ProgramSerialID", "ProgramName", peopleData.SchemeName);
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
