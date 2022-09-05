using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
using static MetaDataHomeBackProject.Models.MetaPeopleData;
using HomeBackProject.library;

namespace HomeBackProject.ViewModel
{
    public class VMForgetPassWord
    {
        [DisplayName("使用者帳號")]
        [Required(ErrorMessage = "必填欄位")]
        [EmailAddress(ErrorMessage = "電子郵件格錯誤")]
        [StringLength(64, ErrorMessage = "最長只能輸入64個字")]
        public string EmailAccount { get; set; }

        [DisplayName("身份證字號")]
        [Required(ErrorMessage = "必填欄位")]
        [MinLength(10, ErrorMessage = "身分字號最少要10碼")]
        [MaxLength(10, ErrorMessage = "身分字號最多10碼")]
        [RegularExpression("[A-Z][1-2][0-9]{8}", ErrorMessage = "**第一碼要大寫or格式錯誤")]
        [ChechIDName(ErrorMessage = "不合法的身分字號")]
        public string IdebtityNumber { get; set; }

        [DisplayName("新密碼")]
        [Required(ErrorMessage = "必填欄位")]
        [RegularExpression("[A-Za-z0-9]{7,20}", ErrorMessage = "密碼格式錯誤，只能輸入英文跟數字")]
        public string PassWord { get; set; }

        [DisplayName("確認密碼")]
        [Required(ErrorMessage = "請再填寫一次密碼")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "密碼最少8碼")]
        [MaxLength(20, ErrorMessage = "密碼最多20碼")]
        [Compare("PassWord", ErrorMessage = "兩次輸入不同")]
        public string ConfirmPassword { get; set; }

    }
}