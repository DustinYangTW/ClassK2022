using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC0601.Models;

namespace MVC0601.Controllers
{
    public class HomeController : Controller
    {
        public string ShowAryDesc()
        {
            int[] scroce = { 78, 90, 60, 40, 36 };
            string show = "";
            //Linq查詢語法
            //var result = from s in scroce orderby s descending select s;
            var result = scroce.OrderByDescending(s => s);

            //select a from scroce order by a desc

            foreach (var item in result)
            {
                show += item;
            }
            return show;
        }
        public string ShowAryAsc()
        {
            int[] scroce = { 78, 90, 60, 40, 36 };
            string show = "";
            //Linq查詢語法
            //var result = from s in scroce orderby s ascending select s;
            var result = scroce.OrderBy(s => s);

            //select a from scroce order by a desc

            foreach (var item in result)
            {
                show += item;
            }
            return show;
        }


        public string LoginMember(string uid,string pwd)
        {
            Member member = new Member();
            member.Uid = "tom";
            member.Pwd = "123";
            member.Name = "湯姆";

            Member member2 = new Member();
            member2.Uid = "jsper";
            member2.Pwd = "456";
            member2.Name = "賈斯柏";

            Member member3 = new Member();
            member3.Uid = "mary";
            member3.Pwd = "789";
            member3.Name = "馬力";

            Member[] members = new Member[]
            {
                new Member{Uid="tom",Pwd="123",Name="湯姆"},
                new Member { Uid = "jsper", Pwd = "456", Name = "賈斯柏" },
                new Member { Uid = "mary", Pwd = "789", Name = "賈斯柏" }
              };

            //SQL 
            //select * from members where Uid = 'tom' and Pwd = '123'

            //var result = (from m in members
            //             where m.Uid == uid && m.Pwd == pwd
            //             select m).FirstOrDefault();

            //Linq擴充法
            var result = members.Where(m => m.Uid == uid && m.Pwd == pwd).FirstOrDefault();

            string show = "";
            if (result != null)
            {
                show = "歡迎光臨 " + result.Name + " 進入本系統";
            }
            else
                show = "帳戶或密碼錯誤";
            return show;
        }
    }
}