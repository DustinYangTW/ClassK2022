using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace HomeBackProject.library
{
    public class SearchPhotos
    {
        public List<string> searchPhotos(string autoFile, string id)
        {
            PostPhotos postPhotos = new PostPhotos();
            DirectoryInfo d = new DirectoryInfo(autoFile);
            FileInfo[] files = d.GetFiles();

            string allName = postPhotos.ChangeAllName(id[0].ToString());

            string directory = id[0].ToString() != "P" ? "../../AllPhoto/" + allName + "/" + id + "/" : 
                                                    "../../AllPhoto/" + id + "/" + "Peopleimage" + "/";

            List<string> lstImg = new List<string>();

            foreach (FileInfo fileName in files)

            {
                lstImg.Add(directory + fileName.Name);
            }

            return lstImg;
        }
    }
}