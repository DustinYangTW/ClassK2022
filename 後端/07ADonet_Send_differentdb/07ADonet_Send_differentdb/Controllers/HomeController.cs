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
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["aaa"].ConnectionString);
        
        public ActionResult Index()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select * from 學生", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            return View();
        }
    }
}