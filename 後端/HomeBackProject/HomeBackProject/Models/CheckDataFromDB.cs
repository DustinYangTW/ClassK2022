using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeBackProject.Models
{
    public class CheckDataFromDB
    {

        public class CheckAoccount : ValidationAttribute
        {       
            public HomeDataEntities db = new HomeDataEntities();
            public CheckAoccount()
            {
                ErrorMessage = "此帳號(E-mail)有人使用";
            }
            public override bool IsValid(object value)
            {
                //var account = db.AccountData.Where(m => m.EmailAccount == value.ToString()).FirstOrDefault();
                var account = db.AccountData.Find(value.ToString());

                return (account == null) ? true : false;
            }
        }

    }
}