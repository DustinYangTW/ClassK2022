using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace HW7Project.Models
{
    public class Orders
    {
        [Key]
        [DisplayName("訂單ID")]
        public int OrderID { get; set; }
        [DisplayName("收件名稱")]
        [StringLength(20,ErrorMessage ="最多20個字")]
        public string ShipName { get; set; }
        [DisplayName("出貨時間")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime ShippedDate { get; set; }
        [DisplayName("收件人地址")]
        [StringLength(20,ErrorMessage ="只能輸入20個字")]
        public string ShipAddress { get; set; }

    }
}