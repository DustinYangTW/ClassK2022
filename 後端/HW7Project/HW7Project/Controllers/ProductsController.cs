﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HW7Project.Models;

namespace HW7Project.Controllers
{
    public class ProductsController : Controller
    {
        private HW7ProjectContext db = new HW7ProjectContext();

        // GET: Products
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        public FileContentResult GetImage(string id)
        {
            var photo = db.Products.Find(id);
            if(photo == null)
            {
                return null;
            }
            return File(photo.PhotoFile, photo.ImageMimeType);
        }

        // GET: Products/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return PartialView(products);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Products products,HttpPostedFileBase photo)
        {
            if(photo == null)
            {
                ViewBag.ErrMessage = "請上傳商品照片";
                return View(products);
            }

            if(db.Products.Find(products.ProductID )!= null)
            {
                ViewBag.ErrMessageID = "請上傳商品照片";
            }


            products.ImageMimeType = photo.ContentType;
            products.PhotoFile = new byte[photo.ContentLength];
            photo.InputStream.Read(products.PhotoFile, 0, photo.ContentLength);
            //Read,讀哪個檔案陣列,起始位置,最後位置
            ModelState.Remove("PhotoFile");
            //取消這個的驗證狀態

            products.CreatedDate = DateTime.Today;
            products.Discontinued = false;

            if (ModelState.IsValid)
            {
                db.Products.Add(products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        // GET: Products/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Products/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductName,PhotoFile,ImageMimeType,UnitPrice,Description,UnitsInStock,Discontinued,CreatedDate")] Products products)
        {
            if (ModelState.IsValid)
            {
                db.Entry(products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(products);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Products products = db.Products.Find(id);
            db.Products.Remove(products);
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
