using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MetaDataHomeBackProject.Models
{
    public class MeataAccountDatas
    {
        [Key]
        [DisplayName("使用者帳號")]
        [Required]
        [EmailAddress(ErrorMessage = "電子郵件格錯誤")]
        [StringLength(64, ErrorMessage = "最長只能輸入64個字")]
        public string EmailAccount { get; set; }
        [DisplayName("使用者帳號")]
        [Required]
        [RegularExpression("[A-Za-z0-9]{7,20}", ErrorMessage = "密碼格是錯誤，只能輸入英文跟數字")]
        public string PassWord { get; set; }
    }

    public class MetaADTypeData
    {
        [Key]
        [DisplayName("廣告代號")]
        public short ADID { get; set; }
        [DisplayName("廣告名稱")]
        [Required]
        [StringLength(30, ErrorMessage = "最長只能輸入30個字")]
        public string ADName { get; set; }
    }

    public class MetaCarTypeData
    {
        [Key]
        [DisplayName("車位代號")]
        public byte CarTypeID { get; set; }
        [DisplayName("車位名稱")]
        [Required]
        [StringLength(20, ErrorMessage = "最長只能輸入20個字")]
        public string CarTypeName { get; set; }
    }
}