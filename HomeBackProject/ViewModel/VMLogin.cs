using HomeBackProject.library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeBackProject.ViewModel
{
    public class VMLogin
    {
        [DisplayName("帳號(Email)")]
        [Required(ErrorMessage = "必填欄位")]
        [EmailAddress(ErrorMessage = "電子郵件格錯誤")]
        [StringLength(64, ErrorMessage = "最長只能輸入64個字")]
        public string EmailAccount { get; set; }
        [DisplayName("密碼")]
        [Required(ErrorMessage = "必填欄位")]
        [RegularExpression("[A-Za-z0-9]{7,20}", ErrorMessage = "密碼格式錯誤，只能輸入英文跟數字")]
        [MinLength(8, ErrorMessage = "密碼最少要8碼")]
        [MaxLength(20, ErrorMessage = "密碼最多20碼")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
    }
}