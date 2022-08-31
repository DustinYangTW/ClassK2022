using HomeBackProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeBackProject.ViewModel
{
    public class VMIndex
    {
        //土地類型
        public List<HomeData> HomeDatas{ get; set; }
        public List<PeopleData> PeopleDatas{ get; set; }
    }
}