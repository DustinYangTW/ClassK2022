using HomeBackProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

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
    }
}