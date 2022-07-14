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

    public class MetaCityTypeData
    {
        [Key]
        [DisplayName("縣市代號")]
        [RegularExpression("[A-Z]{1}", ErrorMessage = "輸入錯誤，請查詢後再輸入")]
        public string CityIDTW { get; set; }
        [DisplayName("縣市名稱")]
        [Required]
        [StringLength(5, ErrorMessage = "最長只能輸入5個字")]
        public string CityTW { get; set; }
    }

    public class MetaFactoryadjacentTypeData
    {
        [Key]
        [DisplayName("工廠鄰近物")]
        public byte FactoryAdjacentStateID { get; set; }
        [DisplayName("鄰近物名稱")]
        [Required]
        [StringLength(30, ErrorMessage = "最長只能輸入30個字")]
        public string FactoryAdjacentName { get; set; }
        [DisplayName("工廠ID")]
        [Required]
        public string FactoryID { get; set; }
    }

    public class MetaHomeadjacentTypeData
    {
        [Key]
        [DisplayName("房屋鄰近物")]
        public byte HomeAdjacentStateID { get; set; }
        [DisplayName("鄰近物名稱")]
        [Required]
        [StringLength(30, ErrorMessage = "最長只能輸入30個字")]
        public string HomeAdjacentName { get; set; }
        [DisplayName("房屋ID")]
        [Required]
        public string HomeID { get; set; }

    }

    public class MetaPeopleRankData
    {
        [Key]
        [DisplayName("會員身分代號")]
        public byte HomeTSaleStateID { get; set; }
        [DisplayName("會員身分")]
        [Required]
        [StringLength(20, ErrorMessage = "最長只能輸入20個字")]
        public string PeopleRank { get; set; }
    }

    public class MetaProgramData
    {
        [Key]
        [DisplayName("會員方案代號")]
        public short ProgramSerialID { get; set; }
        [DisplayName("會員方案名稱")]
        [Required]
        [StringLength(30, ErrorMessage = "最長只能輸入30個字")]
        public string ProgramName { get; set; }
    }
}