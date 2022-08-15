using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HW7Project.Models
{
    public class PayTypes
    {
        [Key]
        [DisplayName("付款ID")]
        public int PayTypeID { get; set; }
        [DisplayName("付款名稱")]
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(20,ErrorMessage ="只能輸入20個數字")]
        public string PayTypeName { get; set; }
    }
}