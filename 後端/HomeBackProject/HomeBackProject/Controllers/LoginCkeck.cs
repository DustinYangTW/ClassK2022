using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeBackProject.Controllers
{
    public class LoginCkeck : ActionFilterAttribute
    {
        void LoginState(HttpContext context)
        {
            if (context.Session["userID"] == null)
            {
                context.Response.Redirect("/Home/Index");
            }
        }

        //只要下面被call就會來檢查上面的資料
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext context = HttpContext.Current;
            LoginState(context);
        }
    }
}