using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace HW7Project.Models
{
    public class Shippers
    {
        [Key]
        [DisplayName("送貨方式編號")]
        public int ShipID { get; set; }
        [DisplayName("送貨方式")]
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(50,ErrorMessage ="最多輸入50個字")]
        public string ShipVia { get; set; }
    }
}