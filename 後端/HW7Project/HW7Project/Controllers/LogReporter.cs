﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using HW7Project.Models;
using System.IO;//寫讀都要用這個
using System.Text;

namespace HW7Project.Controllers
{
    public class LogReporter : ActionFilterAttribute
    {
        HttpContext context;
        //上面是要接收Http的資料

        void LogValues(RouteData routeData, HttpContext context)
        {
            var logTime = DateTime.Now.ToShortTimeString();
            var controllersName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var idName = routeData.Values["id"] == null ? "N/A" : routeData.Values["id"];
            //他這邊是抓App_Start裡面的資料
            var user = ((Employees)context.Session["user"]) == null ? "Guest" : ((Employees)context.Session["user"]).EmployeeID.ToString(); //紀錄是誰

            //寫入txt檔案
            StreamWriter sw = new StreamWriter(context.Server.MapPath("\\ValueLog.csv"), true,Encoding.Default);

            sw.WriteLine(logTime+","+ controllersName + "," + actionName + "," + idName +","+user);
            sw.Close();
        }

        void RequestLog(HttpContext context)
        {
            var ip = context.Request.ServerVariables["REMOTE_ADDR"];
            var host = context.Request.ServerVariables["REMOTE_HOST"];
            var browser = context.Request.ServerVariables["HTTP_USER_AGENT"];

            var requestType = context.Request.RequestType;
            var userHostAddress = context.Request.UserHostAddress;
            var userHostName = context.Request.UserHostName;
            var httpMethod = context.Request.HttpMethod;
            var userAgent = context.Request.UserAgent;
            var requestTime = DateTime.Now;

            StreamWriter sw = new StreamWriter(context.Server.MapPath("\\RequestLog.txt"), true, Encoding.Default);

            sw.WriteLine(requestTime + ", " + ip + ", " + host + ", " + browser + ", " + requestType + ", "
                + userHostAddress + ", " + userHostName + ", " + httpMethod + ", " + userAgent);

            sw.Close();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            context = HttpContext.Current;
            LogValues(filterContext.RouteData, context);
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            context = HttpContext.Current;
            RequestLog(context);
        }
    }
}