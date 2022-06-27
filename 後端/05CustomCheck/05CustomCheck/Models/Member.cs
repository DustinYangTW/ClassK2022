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

        [Required(ErrorMessage = "姓名為必填欄位")]
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
                const string eng = "ABCDEFGHJKLMNPQRSTUVXYZIO";
                string t = id.Substring(0, 1);
                int intEng = eng.IndexOf(t) + 10;
                int n1 = intEng / 10;
                int n2 = intEng % 10;
                int[] a = new int[9];
                for (int i = 0; i < 9; i++)
                {
                    a[i] = Convert.ToInt32(id.Substring(i + 1, 1));
                }
                //int j = 0;
                //for (int i = 0; i < 9; i++)
                //{
                //    if (8 - i <= 0)
                //    {
                //        j = 1;
                //    }
                //    else
                //    {
                //        j = 8 - i;
                //    }
                //    sum += a[i] * (8 - i);
                //}
                for (int i = 0; i < 8; i++)
                {
                    sum += a[i] * (8 - i);
                }
                sum += a[8] + n1 + n2 * 9;
                //sum = n1 + n2 * 9 + a[0] * 8 + a[1] * 7 + a[2] * 6 + a[3] * 5 + a[4] * 4 + a[5] * 3 + a[6] * 2 + a[7] + a[8];
                if (sum % 10 == 0)
                    return true;
                return false;
            }
        }
    }
}