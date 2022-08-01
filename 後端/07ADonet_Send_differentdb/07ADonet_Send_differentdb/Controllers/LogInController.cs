using _07ADonet_Send_differentdb.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _07ADonet_Send_differentdb.Controllers
{
    public class LogInController : Controller
    {
        GetData gd = new GetData();
        public ActionResult LogIn()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult LogIn(string id ,string name)
        //{

        //    //string sql = "select * from 學生 where 學號 = '"+id+ "' and 姓名= '" + name + "'";

        //    string sql = "select * from 學生 where 學號 = @id and 姓名= @name";

        //    var dt = gd.querySql(sql,System.Data.CommandType.Text,id,name);
        //    if(dt.Rows.Count == 0)
        //    {
        //        ViewBag.Msg = "帳號或密碼有誤";
        //        return View();
        //    }
        //    return RedirectToAction("Index", "Home");
        //}

        [HttpPost]
        public ActionResult Login(string id, string name)
        {
            //select * from student where 學號 = 'S001' and 姓名 = '陳小安'
            //string sql = "select * from 學生 where 學號= '"+id+"' and 姓名='"+ name+"'";
            List<SqlParameter> list = new List<SqlParameter>
            {
                new SqlParameter("id", id),
                new SqlParameter("name", name)
            };
            string sql = "select * from 學生 where 學號=@id and 姓名=@name";
            var dt = gd.querySql(sql, System.Data.CommandType.Text, list);
            if (dt.Rows.Count == 0)
            {
                ViewBag.Msg = "帳號或密碼有誤!";
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

    }
}