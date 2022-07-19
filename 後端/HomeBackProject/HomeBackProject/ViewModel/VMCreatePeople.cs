using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MetaDataHomeBackProject.Models;

namespace HomeBackProject.ViewModel
{
    public class VMCreatePeople
    {
        [DisplayName("使用者帳號")]
        [Required(ErrorMessage = "必填欄位")]
        [EmailAddress(ErrorMessage = "電子郵件格錯誤")]
        [StringLength(64, ErrorMessage = "最長只能輸入64個字")]
        public string EmailAccount { get; set; }
        [DisplayName("使用者密碼")]
        [Required(ErrorMessage = "必填欄位")]
        [RegularExpression("[A-Za-z0-9]{7,20}", ErrorMessage = "密碼格式錯誤，只能輸入英文跟數字")]
        public string PassWord { get; set; }

        [DisplayName("姓名")]
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(55, ErrorMessage = "最長只能輸入55個字")]
        public string PeopleName { get; set; }

        [Required(ErrorMessage = "必填欄位")]
        [RegularExpression("[A-Z][1-2][0-9]{8}", ErrorMessage = "身份證字號資料錯誤")]
        [MetaPeopleData.ChechIDName(ErrorMessage = "不合法的身分字號")]
        public string IdebtityNumber { get; set; }
        [DisplayName("生日")]
        [Required(ErrorMessage = "必填欄位")]
        public System.DateTime Birthday { get; set; }
        [DisplayName("性別")]
        [Required(ErrorMessage = "必填欄位")]
        public bool Gender { get; set; }
        [DisplayName("手機號碼")]
        [Required(ErrorMessage = "必填欄位")]
        [RegularExpression("[0][9][0-9]{8}", ErrorMessage = "電話號碼輸入錯誤")]
        public string PhoneNumber { get; set; }
        [DisplayName("E-mail")]
        [Required(ErrorMessage = "必填欄位")]
        [EmailAddress(ErrorMessage = "電子郵件格式錯誤")]
        [StringLength(64, ErrorMessage = "最長只能輸入64個字")]
        public string EMail { get; set; }
        [DisplayName("縣市")]
        [Required(ErrorMessage = "必填欄位")]
        public string County { get; set; }
        [DisplayName("鄉鎮")]
        [Required(ErrorMessage = "必填欄位")]
        public string Town { get; set; }
        [DisplayName("道路與號碼")]
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(20, ErrorMessage = "最長只能輸入20個字")]
        public string RoadAndNumber { get; set; }
        [DisplayName("公司名稱")]
        [StringLength(20, ErrorMessage = "最長只能輸入20個字")]
        public string CompanyName { get; set; }

        [DisplayName("會員身分")]
        [Required(ErrorMessage = "必填欄位")]
        public byte SaleStateID { get; set; }
    }
}