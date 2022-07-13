using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MetaDataHomeBackProject.Models
{
    public class MeataAccountData
    {
        [Key]
        [DisplayName("使用者帳號")]
        [Required]
        [EmailAddress(ErrorMessage = "電子郵件格錯誤")]
        [StringLength(64)]
        public string EmailAccount { get; set; }
        [DisplayName("使用者帳號")]
        [Required]
        [RegularExpression("[A-Za-z0-9]{7,20}", ErrorMessage = "密碼格是錯誤，只能輸入英文跟數字")]
        public string PassWord { get; set; }
    }
}