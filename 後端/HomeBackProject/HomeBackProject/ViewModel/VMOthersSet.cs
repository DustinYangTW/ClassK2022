using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace HomeBackProject.ViewModel
{
    public class VMOthersSet
    {
        //土地類型
        [DisplayName("土地類型代號")]
        public byte TerritorySerialID { get; set; }
        [DisplayName("土地類型")]
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(10, ErrorMessage = "最長只能輸入10個字")]
        public string TerritoryTypeSelect { get; set; }


        //銷售代號
        [DisplayName("銷售狀態代號")]
        public byte SaleStateID { get; set; }
        [DisplayName("銷售狀態")]
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(5, ErrorMessage = "最長只能輸入5個字")]
        public string SaleState { get; set; }


        //會員方案
        [DisplayName("會員方案代號")]
        public short ProgramSerialID { get; set; }
        [DisplayName("會員方案名稱")]
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(30, ErrorMessage = "最長只能輸入30個字")]
        public string ProgramName { get; set; }


        //會員身份
        [DisplayName("會員身份代號")]
        public byte HomeTSaleStateID { get; set; }
        [DisplayName("會員身份")]
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(20, ErrorMessage = "最長只能輸入20個字")]
        public string PeopleRank { get; set; }


        //房屋型態
        [DisplayName("房屋類型代碼")]
        public byte HomeTypeID { get; set; }
        [DisplayName("房屋類型")]
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(20, ErrorMessage = "最長只能輸入20個字")]
        public string HomeTypeName { get; set; }

        //縣市代碼
        [DisplayName("縣市代號")]
        [RegularExpression("[A-Z]{1}", ErrorMessage = "輸入錯誤，請查詢後再輸入")]
        public string CityIDTW { get; set; }
        [DisplayName("縣市名稱")]
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(5, ErrorMessage = "最長只能輸入5個字")]
        public string CityTW { get; set; }

        //車位類型
        [DisplayName("車位代號")]
        public byte CarTypeID { get; set; }
        [DisplayName("車位名稱")]
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(20, ErrorMessage = "最長只能輸入20個字")]
        public string CarTypeName { get; set; }

        //廣告類型
        [DisplayName("廣告代號")]
        public short ADID { get; set; }
        [DisplayName("廣告名稱")]
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(30, ErrorMessage = "最長只能輸入30個字")]
        public string ADName { get; set; }
    }
}