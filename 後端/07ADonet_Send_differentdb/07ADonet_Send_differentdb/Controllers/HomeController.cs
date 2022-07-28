using _07ADonet_Send_differentdb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace _07ADonet_Send_differentdb.Controllers
{
    public class HomeController : Controller
    {
        GetData GD = new GetData();
        public ActionResult Index()
        {
            return View(GD.querySql("select * from 學生",CommandType.Text));
        }    
        public ActionResult Employee()
        {
            return View(GD.querySql("getCoursePivot",CommandType.StoredProcedure));
        }
    }
}