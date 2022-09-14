using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
using HomeBackProject.Models;

namespace HomeBackProject.ViewModel
{
    public class VMOthersSet
    {
        //銷售狀態
        public List<SaleTypeData> SaleTypeData { get; set; }
        //會員方案
        public List<ProgramData> ProgramData { get; set; }
        //會員身份
        public List<PeopleRankData> PeopleRankData { get; set; }
        //房屋類型
        public List<HomeTypeData> HomeTypeData { get; set; }
        //縣市代碼
        public List<CityTypeData> CityTypeData { get; set; }
        //車位類型
        public List<CarTypeData> CarTypeData { get; set; }
        //廣告類型
        public List<ADTypeData> ADTypeData { get; set; }
    }
}