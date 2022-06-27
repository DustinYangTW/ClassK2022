using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _05CustomCheck.Models
{
    public class Member
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage ="姓名為必填欄位")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "身份證字號為必填欄位")]
        [RegularExpression("[A-Z[12][0-9]{8}", ErrorMessage = "身份證字號資料錯誤")]
        [ChechIDName]
        public string IDNumber { get; set; }//身份證字號
        public class ChechIDName : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                int sum = 0;
                string id = value.ToString();



                sum = 130;
                if (sum % 10 == 0)
                    return true;

                return false;
            }

        }
    }
}