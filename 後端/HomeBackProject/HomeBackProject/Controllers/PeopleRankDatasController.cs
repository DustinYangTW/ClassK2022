using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeBackProject.Models;

namespace HomeBackProject.Controllers
{
    public class PeopleRankDatasController : Controller
    {
        private HomeDataEntities db = new HomeDataEntities();

        // GET: PeopleRankDatas
        public ActionResult Index()
        {
            return View(db.PeopleRankData.ToList());
        }

        // GET: PeopleRankDatas/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeopleRankData peopleRankData = db.PeopleRankData.Find(id);
            if (peopleRankData == null)
            {
                return HttpNotFound();
            }
            return View(peopleRankData);
        }

        // GET: PeopleRankDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PeopleRankDatas/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HomeTSaleStateID,PeopleRank")] PeopleRankData peopleRankData)
        {
            if (ModelState.IsValid)
            {
                db.PeopleRankData.Add(peopleRankData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(peopleRankData);
        }

        // GET: PeopleRankDatas/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeopleRankData peopleRankData = db.PeopleRankData.Find(id);
            if (peopleRankData == null)
            {
                return HttpNotFound();
            }
            return View(peopleRankData);
        }

        // POST: PeopleRankDatas/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HomeTSaleStateID,PeopleRank")] PeopleRankData peopleRankData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(peopleRankData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(peopleRankData);
        }

        // GET: PeopleRankDatas/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeopleRankData peopleRankData = db.PeopleRankData.Find(id);
            if (peopleRankData == null)
            {
                return HttpNotFound();
            }
            return View(peopleRankData);
        }

        // POST: PeopleRankDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            PeopleRankData peopleRankData = db.PeopleRankData.Find(id);
            db.PeopleRankData.Remove(peopleRankData);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
