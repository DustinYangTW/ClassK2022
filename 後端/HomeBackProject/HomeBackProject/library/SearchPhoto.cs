using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace HomeBackProject.library
{
    public class SearchPhotos
    {
        //自動抓取資料夾檔案
        public List<string> searchPhotos(string autoFile, string id)
        {
            PostPhotos postPhotos = new PostPhotos();
            DirectoryInfo d = new DirectoryInfo(autoFile);
            FileInfo[] files = d.GetFiles();

            string allName = postPhotos.ChangeAllName(id[0].ToString());

            string directory = "../../AllPhoto/" + allName + "/" + id + "/";
                                                         //"../../AllPhoto/" + "Peopleimage" + "/" + id + "/";

            List<string> lstImg = new List<string>();

            foreach (FileInfo fileName in files)

            {
                lstImg.Add(directory + fileName.Name);
            }

            return lstImg;
        }
    }
}