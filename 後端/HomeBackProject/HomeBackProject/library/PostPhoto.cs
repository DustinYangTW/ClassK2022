using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeBackProject.library
{
    public class PostPhotos
    {
        public string checkPhoto(string fileName, int contentLength)
        {
            string checkid = fileName.Substring(fileName.IndexOf(".")).ToUpper();
            if (checkid == "JPG" || checkid == "JPEG" || checkid == "GIF" || checkid == "PNG")
            {
                return "檔案不正確，只能上傳JPG,JPEG,GIF,PNG檔案";
            }
            else if (contentLength < 50000)
            {
                return "檔案只能上傳大於0.05MB的檔案";
            }
            else if (contentLength > 15728640)
            {
                return "檔案只能上傳小於15MB的檔案";
            }
            return "OK";
        }

        public string ChangeAllName(string id)
        {
            //傳ID進來後，自動判別
            string firstName = id[0].ToString();
            if (firstName == "A")
            {
                return "PeopleImage";
            }
            else if (firstName == "H")
            {
                return "Home";
            }
            else if (firstName == "F")
            {
                return "Factory";
            }
            else if (firstName == "T")
            {
                return "Territory";
            }
            else
            {
                return "else";
            }
        }
    }
}