using HomeBackProject.Models;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace HomeBackProject.Controllers
{
    public class PeopleDatasController : Controller
    {
        private HomeDataEntities db = new HomeDataEntities();
        private ActiondbController actiondbController = new ActiondbController();
        private AccountData accountData = new AccountData();

        // GET: PeopleDatas
        [LoginCkeck]
        public ActionResult Index()
        {
            var peopleData = db.PeopleData.Include(p => p.AccountData).Include(p => p.CityTypeData).Include(p => p.PeopleRankData).Include(p => p.ProgramData);
            return View(peopleData.ToList());
        }

        // GET: PeopleDatas/Details/5
        public ActionResult Details(string id)
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
            return View(peopleData);
        }

        // GET: PeopleDatas/Create
        public ActionResult Create()
        {
            ViewBag.EMail = new SelectList(db.AccountData, "EmailAccount", "PassWord");
            //ViewBag.County = new SelectList(db.CityTypeData, "CityIDTW", "CityTW");
            ViewBag.SaleStateID = new SelectList(db.PeopleRankData, "HomeTSaleStateID", "PeopleRank");
            ViewBag.SchemeName = new SelectList(db.ProgramData, "ProgramSerialID", "ProgramName");
            ViewBag.countyID = db.CityTypeData.ToList();
            ViewBag.SaleStateID = db.PeopleRankData.ToList();
            return View();
        }

        // POST: PeopleDatas/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [LoginCkeck]
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "PeopleName,IdebtityNumber,Birthday,Gender,PhoneNumber,EMail,County,Town,RoadAndNumber,CompanyName,SaleStateID")] PeopleData peopleData)
        //public ActionResult Create([Bind(Include = "PeopleID,PeopleName,IdebtityNumber,Birthday,Gender,PhoneNumber,EMail,County,Town,RoadAndNumber,CompanyName,PeopleAge,PeopleCash,AuthorizationTime,SaleStateID,SchemeName")] PeopleData peopleData)
        public ActionResult Create(PeopleData peopleData)
        {
            //ArrayList checkOption = new ArrayList();
            //checkOption.Add(peopleData.Gender);
            //checkOption.Add(peopleData.County);
            //checkOption.Add(peopleData.Town);
            //checkOption.Add(peopleData.SaleStateID);

            //var EmailCheck = db.AccountData.Where(email => email.EmailAccount == peopleData.EMail).FirstOrDefaultAsync();
            var EmailCheck = db.AccountData.Find(peopleData.EMail);
            //驗證是否有重複Email
            if(EmailCheck != null) {
                ViewBag.countyID = db.CityTypeData.ToList();
                ViewBag.SaleStateID = db.PeopleRankData.ToList();
                ViewBag.checkErrorEmailCheck = "電子信箱已重複";
                return View(peopleData);
            }

            if (peopleData.SaleStateID == 0)
            {
                ViewBag.countyID = db.CityTypeData.ToList();
                ViewBag.SaleStateID = db.PeopleRankData.ToList();
                ViewBag.checkErrorSaleStateID = "必填欄位";
                return View(peopleData);
            }



            if (ModelState.IsValid)
            {
                accountData.EmailAccount = peopleData.EMail;
                accountData.PassWord = peopleData.IdebtityNumber;
                actiondbController.Create(db, db.AccountData, accountData);

                var countPeopleDatas = db.PeopleData.Count() + 1;
                peopleData.PeopleID = "A" + countPeopleDatas.ToString().PadLeft(9, '0');  //自動加編號A000000000，新增一筆自動+1
                peopleData.PeopleCash = 0; 
                return actiondbController.Create(db, db.PeopleData, peopleData);
            }
            else
            {
                ViewBag.countyID = db.CityTypeData.ToList();
                ViewBag.SaleStateID = db.PeopleRankData.ToList();
                return View(peopleData);
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
        public ActionResult Edit([Bind(Include = "PeopleID,PeopleName,IdebtityNumber,Birthday,Gender,PhoneNumber,EMail,County,Town,RoadAndNumber,CompanyName,PeopleAge,PeopleCash,AuthorizationTime,SaleStateID,SchemeName")] PeopleData peopleData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(peopleData).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EMail = new SelectList(db.AccountData, "EmailAccount", "PassWord", peopleData.EMail);
            ViewBag.County = new SelectList(db.CityTypeData, "CityIDTW", "CityTW", peopleData.County);
            ViewBag.SaleStateID = new SelectList(db.PeopleRankData, "HomeTSaleStateID", "PeopleRank", peopleData.SaleStateID);
            ViewBag.SchemeName = new SelectList(db.ProgramData, "ProgramSerialID", "ProgramName", peopleData.SchemeName);
            return View(peopleData);
        }

        // GET: PeopleDatas/Delete/5
        public ActionResult Delete(string id)
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
            return View(peopleData);
        }

        // POST: PeopleDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PeopleData peopleData = db.PeopleData.Find(id);
            db.PeopleData.Remove(peopleData);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
