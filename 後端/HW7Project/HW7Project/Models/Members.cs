using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace HW7Project.Models
{
    public class Members
    {
        [Key]
        [DisplayName("會員編號")]
        public int MemberID { get; set; }
        [DisplayName("會員帳號")]
        [Required(ErrorMessage = "請填寫帳號")]
        [StringLength(20, ErrorMessage = "不能超過20個字")]
        public string Account { get; set; }
        [Required(ErrorMessage = "必填欄位")]
        [MinLength(8, ErrorMessage = "密碼最少要8碼")]
        [MaxLength(20, ErrorMessage = "密碼最多20碼")]
        [DataType(DataType.Password)]
        [DisplayName("會員密碼")]
        public string PassWord { get; set; }
        [DisplayName("會員名字")]
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(20, ErrorMessage = "最多輸入20個字")]
        public string MemberName { get; set; }
        [DisplayName("會員照片檔案路徑")]
        public string MenberPhotoFile { get; set; }
        [DisplayName("會員生日")]
        [Required(ErrorMessage = "必填欄位")]
        public DateTime MemberBirdthday { get; set; }
        [DisplayName("建立時間")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }


    }
}