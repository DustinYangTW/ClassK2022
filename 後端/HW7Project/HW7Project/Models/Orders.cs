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
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(20,ErrorMessage ="最多20個字")]
        public string ShipName { get; set; }
        [DisplayName("出貨時間")]
        [Required(ErrorMessage = "必填欄位")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime ShippedDate { get; set; }
        [DisplayName("收件人地址")]
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(20,ErrorMessage ="只能輸入20個字")]
        public string ShipAddress { get; set; }
        //Forign Key
        public int ShipID { get; set; }
        public int PayTypeID { get; set; }
        public int EmployeesID { get; set; }
        public int MemberID { get; set; }


        //拉關聯
        public virtual Shippers Shipper { get; set; }
        public virtual PayTypes PayType { get; set; }
        public virtual Employees Employee { get; set; }
        public virtual Members Member { get; set; }

    }
}