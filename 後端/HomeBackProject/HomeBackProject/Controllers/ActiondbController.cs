using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using HomeBackProject.Models;
using System.IO;
using HomeBackProject.library;
using System.Net;

namespace HomeBackProject.Controllers
{
    public class ActiondbController : Controller
    {
        private PostPhotos postPhotos = new PostPhotos();
        private SearchPhotos searchPhotos = new SearchPhotos();
        private List<string> searchPhotosName = new List<string>();
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
        /// item是存入的資料格式;
        /// id是要做資料驗證的
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="db"></param>
        /// <param name="dbSet"></param>
        /// <param name="item"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteConfirmed<T>(DbContext db, DbSet dbSet, T item,string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (dbSet == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                dbSet.Remove(item);
                db.SaveChanges();
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
        public ActionResult SavePhoto(string autoFile, List<HttpPostedFileBase> photo, string peopleID, string actionName, string cName)
        {
            //string goTitle = "E:/Git2/後端/HomeBackProject/HomeBackProject"; //Home
            //string goTitle = "D:/Git2/後端/HomeBackProject/HomeBackProject"; //school

            string filename = autoFile + "/" + "PeopleImage" + "/" + peopleID;
            string checkid = "";

            if (Directory.Exists(@filename) == false)
            {
                Directory.CreateDirectory(@filename);
            }
            else
            {
                this.searchPhotosName = searchPhotos.searchPhotos(filename);
                searchPhotos.DeletePhoto(filename, this.searchPhotosName[0], "A000000001");
            }

            filename = autoFile + "/" + "PeopleImage" + "/" + peopleID + "/";

            for (int i = 0; i < photo.Count; i++)
            {
                checkid = photo[i].FileName.Substring(photo[i].FileName.IndexOf("."));
                photo[i].SaveAs(filename + string.Concat(i, checkid));
            }
            return RedirectToAction(actionName, cName);
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


            //如果沒有這個路徑就是要新增路徑
            if (Directory.Exists(@filename) == false)
            {
                Directory.CreateDirectory(@filename);
            }
            else
            {
                //如果有這路徑，去查詢裡面有幾個檔案
                this.searchPhotosName = searchPhotos.searchPhotos(filename);
            }

            //當圖片 > 6張時，重第一章開始做刪除
            //if ((searchPhotosName.Count + photo.Count) > 6)
            //{
            //    for (int i = 0; i < (searchPhotosName.Count + photo.Count - 6); i++)
            //    {
            //        searchPhotos.DeletePhoto(filename, searchPhotosName[i], caseID);
            //    }
            //}

            filename = autoFile + "/" + allName + "/" + caseID + "/";
            var searchPhotosNameCount = this.searchPhotosName.Count();
            string test = searchPhotosNameCount == 0? "0.jpg" : this.searchPhotosName[searchPhotosName.Count - 1].ToString();
            int testtt = test.ToString().IndexOf(".");
            //抓取最後一個檔案名子2.jpg            轉換成字串       從0開始到.結束的文字擷取        最後再轉成int       
            int lastPhotoNumber = this.searchPhotosName.Count() == 0 ? 0 : Int16.Parse(test.Substring(0, testtt)) + 1;
            //後面是做抓取最後一筆相片的編號!!!

            int getData;
            for (int i = lastPhotoNumber; i < photo.Count; i++)
            {
                getData = lastPhotoNumber == 0 ? i :i-1;
                checkid = photo[getData].FileName.Substring(photo[getData].FileName.IndexOf("."));
                photo[getData].SaveAs(filename + string.Concat(i, checkid));
            }

            return RedirectToAction("Index");

        }
    }
}
