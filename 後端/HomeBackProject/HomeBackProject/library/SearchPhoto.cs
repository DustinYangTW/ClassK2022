using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeBackProject.library
{
    public class SearchPhotos
    {
        private PostPhotos postPhotos = new PostPhotos();
        //自動抓取資料夾檔案
        /// <summary>
        /// 抓取資料夾內部的檔案
        /// </summary>
        /// <param name="autoFile">實體路徑完整的</param>
        /// <param name="id">要查詢的案件BID</param>
        /// <returns></returns>
        public List<string> searchPhotos(string autoFile, string id)
        {
            PostPhotos postPhotos = new PostPhotos();
            DirectoryInfo d = new DirectoryInfo(autoFile);
            FileInfo[] files = d.GetFiles();

            string allName = postPhotos.ChangeAllName(id[0].ToString());

            string directory = "../../AllPhoto/" + allName + "/" + id + "/";
            //"../../AllPhoto/" + "Peopleimage" + "/" + id + "/";

            List<string> lstImg = new List<string>();
            List<string> phtotoName = new List<string>();

            foreach (FileInfo fileName in files)

            {
                lstImg.Add(directory + fileName.Name);
                phtotoName.Add(fileName.Name);
            }

            return lstImg;
        }    
        
        /// <summary>
        /// 這是在做查詢圖片的名稱
        /// </summary>
        /// <param name="autoFile">實體路徑要完整的</param>
        /// <returns></returns>
        public List<string> searchPhotos(string autoFile)
        {
            DirectoryInfo d = new DirectoryInfo(autoFile);
            FileInfo[] files = d.GetFiles();

            List<string> phtotoName = new List<string>();

            foreach (FileInfo fileName in files)
            {
                phtotoName.Add(fileName.Name);
            }

            return phtotoName;
        }

        /// <summary>
        /// 自動刪除圖片
        /// </summary>
        /// <param name="autoFile">自動化路徑</param>
        /// <param name="photo">照片檔案名稱</param>
        /// <param name="caseID">那個的ID</param>
        public void DeletePhoto(string autoFile, string photo, string caseID)
        {
            string allName = postPhotos.ChangeAllName(caseID);
            string filename = autoFile + "/AllPhoto/" + allName + "/" + caseID + "/";
            string checkid = photo;

            FileInfo fi = new FileInfo(filename + checkid);
            if (fi.Exists)
            {
                fi.Delete();
            }
        }
    }
}