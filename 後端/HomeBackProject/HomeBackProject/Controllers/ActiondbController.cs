using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using HomeBackProject.Models;
using System.IO;
using HomeBackProject;
using HomeBackProject.library;
using System.Data.Entity.Validation;

namespace HomeBackProject.Controllers
{
    public class ActiondbController : Controller
    {
        private  PostPhotos postPhotos = new PostPhotos();
        //private string goTitle = "E:/Git2/後端/HomeBackProject/HomeBackProject"; //Home
        //private string goTitle = "D:/Git2/後端/HomeBackProject/HomeBackProject"; //school

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
        public ActionResult Edit<T>(DbContext db, T item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 透過傳入的值來達成，上傳照片
        /// </summary>
        /// <param name="photo"></param>
        /// <param name="peopleID"></param>
        /// <param name="caseID"></param>
        /// <returns></returns>
        public ActionResult SavePhoto(string autoFile, List<HttpPostedFileBase> photo, string peopleID, string caseID)
        {
            string allName = postPhotos.ChangeAllName(caseID);
            string filename = autoFile + "/" + allName + "/" + caseID;
            string checkid = "";


            if (Directory.Exists(@filename) == false)
            {
                Directory.CreateDirectory(@filename);
            }

            filename = autoFile + "/" + allName + "/" + caseID + "/";

            for (int i = 0; i < photo.Count; i++)
            {
                checkid = photo[i].FileName.Substring(photo[i].FileName.IndexOf("."));
                photo[i].SaveAs(filename + string.Concat(i, checkid));
            }
            return RedirectToAction("Index");
        }



        /// <summary>
        /// 透過傳入的值來新增照片，並導向會員登入
        /// </summary>
        /// <param name="photo"></param>
        /// <param name="peopleID"></param>
        /// <param name="actionName"></param>
        /// <param name="cName"></param>
        /// <returns></returns>
        public ActionResult SavePhoto(string autoFile,List<HttpPostedFileBase> photo, string peopleID, string actionName, string cName)
        {
            //string goTitle = "E:/Git2/後端/HomeBackProject/HomeBackProject"; //Home
            //string goTitle = "D:/Git2/後端/HomeBackProject/HomeBackProject"; //school
            
            string filename = autoFile + "/" + "PeopleImage" + "/" +peopleID;
            string checkid = "";

            if (Directory.Exists(@filename) == false)
            {
                Directory.CreateDirectory(@filename);
            }

            filename = autoFile + "/" + "PeopleImage" + "/" + peopleID + "/";

            for (int i = 0; i < photo.Count; i++)
            {
                checkid = photo[i].FileName.Substring(photo[i].FileName.IndexOf("."));
                photo[i].SaveAs(filename + string.Concat(i, checkid));
            }
            return RedirectToAction(actionName, cName);
        }

    }
}
