using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HW7Project.Models
{
    public class Employees
    {
        [Key]
        [DisplayName("員工編號")]
        public int EmployeesID { get; set; }
        [Required(ErrorMessage ="請填寫員工姓名")]
        [StringLength(100,ErrorMessage ="員工名稱不超過100字")]
        [DisplayName("員工姓名")]
        public string EmployeeName { get; set; }
        [DisplayName("建立時間")]
        public DateTime CreateDate { get; set; }
        [Required(ErrorMessage = "請填寫帳號")]
        [StringLength(20, ErrorMessage = "不能超過20個字")]
        [DisplayName("員工帳號")]
        public string Account { get; set; }
        [Required(ErrorMessage = "請填寫密碼")]
        [StringLength(20, ErrorMessage = "不能超過20個字")]
        [DisplayName("員工密碼")]
        public string Password { get; set; }

    }
}