using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _07ADonet_Send_differentdb.Models;

namespace _07ADonet_Send_differentdb.Controllers
{

    public class CourseController : Controller
    { 
        private SetDatas setDatas = new SetDatas();
        // GET: Course
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string cid,string cname ,int credit)
        {
            //string sql = "insert into 課程 values('C654','asdfdfjagk',3)";

            List<SqlParameter> list = new List<SqlParameter>
            {
                new SqlParameter("cid", cid),
                new SqlParameter("cname", cname),
                new SqlParameter("credit", credit)
            };
            string sql = "insert into 課程 values(@cid,@cname,@credit)";
            setDatas.executeSql(sql, list); 
            return View();
        }
    }
}