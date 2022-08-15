using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Web.Mvc;

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
        [CheckAoccount]
        public string Account { get; set; }
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

        string password;//定義一個password的field

        //做雜湊
        [Required(ErrorMessage = "必填欄位")]
        [DataType(DataType.Password)]
        [DisplayName("會員密碼")]
        public string PassWord
        {
            get
            {
                return password;
            }
            set
            {
                byte[] hashValue;
                string result = "";

                System.Text.UnicodeEncoding ue = new System.Text.UnicodeEncoding();
                byte[] pwBytes = ue.GetBytes(value);
                SHA256 shHash = SHA256.Create();

                hashValue = shHash.ComputeHash(pwBytes);

                foreach(byte b in hashValue)
                {
                    result += b.ToString();
                }

                password = result;
            }
        }
    }


    //自訂驗證規則寫法
    public class CheckAoccount : ValidationAttribute
    {
        public CheckAoccount()
        {
            ErrorMessage = "此帳號有人使用";
        }
        public override bool IsValid(object value)
        {
            HW7ProjectContext db = new HW7ProjectContext();

            var account = db.Members.Where(m => m.Account == value.ToString()).FirstOrDefault();

            return (account == null)?true:false;
        }
    }
}