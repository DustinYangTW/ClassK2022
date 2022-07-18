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
        [StringLength(20,ErrorMessage ="最多輸入20個字")]
        public string ShipVia { get; set; }
    }
}