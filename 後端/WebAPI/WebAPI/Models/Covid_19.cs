using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Covid_19
    {
        //"id":"ID","a01":"iso_code","a02":"洲名","a03":"國家","a04":"日期","a05":"總確診數","a06":"新增確診數"

            public string id { get; set; }
            public string a01 { get; set; }
            public string a02 { get; set; }
            public string a03 { get; set; }
            public string a04 { get; set; }
            public string a05 { get; set; }
            public string a06 { get; set; }


    }
}