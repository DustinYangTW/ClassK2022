using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using HomeBackProject.Models;

namespace HomeBackProject.Controllers
{
    public class ActiondbController : Controller
    {
        public ActionResult Create<T>(DbContext db, DbSet dbSet, T item)
        {
            if (ModelState.IsValid)
            {
                dbSet.Add(item);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete<T>(DbContext db, DbSet dbSet, T item)
        {
            if (ModelState.IsValid)
            {
                dbSet.Remove(item);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }     

        public ActionResult Edit<T>(DbContext db, DbSet dbSet, T item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}