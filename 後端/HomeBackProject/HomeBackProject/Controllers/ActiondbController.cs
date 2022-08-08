﻿using System;
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
        /// <summary>
        /// 透過這個統一建立資料
        /// db，是資料庫實體化;
        /// dbSet是哪一個資料表;
        /// item是存入的資料格式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="db"></param>
        /// <param name="dbSet"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public ActionResult Create<T>(DbContext db, DbSet dbSet, T item)
        {
            if (ModelState.IsValid)
            {
                dbSet.Add(item);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        /// <summary>
        /// 透過這個統一建立資料
        /// db，是資料庫實體化;
        /// dbSet是哪一個資料表;
        /// item是存入的資料格式;
        /// actionName控制器下面的class;
        /// cName控制器名稱;
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="db">資料庫實體化</param>
        /// <param name="dbSet">哪一個資料表</param>
        /// <param name="item">存入的資料格式</param>
        /// <param name="actionName">控制器下面的class</param>
        /// <param name="cName">控制器名稱</param>
        /// <returns></returns>
        public ActionResult Create<T>(DbContext db, DbSet dbSet, T item, string actionName, string cName)
        {
            if (ModelState.IsValid)
            {
                dbSet.Add(item);
                db.SaveChanges();
            }
            return RedirectToAction(actionName, cName);
        }




        /// <summary>
        /// 透過這個統一刪除資料
        /// db，是資料庫實體化;
        /// dbSet是哪一個資料表;
        /// item是存入的資料格式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="db"></param>
        /// <param name="dbSet"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public ActionResult Delete<T>(DbContext db, DbSet dbSet, T item)
        {
            if (ModelState.IsValid)
            {
                dbSet.Remove(item);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        /// <summary>
        /// 透過這個統一修改資料
        /// db，是資料庫實體化;
        /// dbSet是哪一個資料表;
        /// item是存入的資料格式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="db"></param>
        /// <param name="dbSet"></param>
        /// <param name="item"></param>
        /// <returns></returns>
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