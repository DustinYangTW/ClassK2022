using HomeBackProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace HomeBackProject.library
{
    public class ChangIDAuto
    {      
        /// <summary>
        /// 主要功能是自動編碼ID(抓DB最後一碼資料)；
        /// idIn，db裡面的ID最後一碼；
        /// </summary>
        /// <param name="idIn">db裡面的ID最後一碼</param>
        /// <returns></returns>
        public string changIDNumber(string idIn)
        {
            int id = Int32.Parse(idIn.Substring(2)) + 1;

            string CheckID = idIn[0] + id.ToString().PadLeft(9, '0');

            return CheckID;
        }


        public static List<int> AutoPage(int allCount,int pagesize,int page)
        {
            List<int> pageList = new List<int>();
            int first, last;
            if (allCount < 6)
            {
                first = 0;
                last = allCount;
                pageList.Add(first);
                pageList.Add(last);
            }
            else if (allCount > 6 && page == 1)
            {
                first = 0;
                last = pagesize;
                pageList.Add(first);
                pageList.Add(last);
            }
            else
            {
                first = ((page - 1) * pagesize);
                last = first + pagesize < allCount ? first + pagesize+1 : allCount;
                pageList.Add(first);
                pageList.Add(last);
            }

            return pageList;
        }
    }
}