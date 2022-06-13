using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Northwind.Models
{
    public class MetaCategories
    {
        [DisplayName("種類ID")]
        public int CategoryID { get; set; }
        [DisplayName("類別名稱")]
        [Required(ErrorMessage = "類別名稱為必填欄位")]
        [StringLength(15, ErrorMessage = "格式錯誤，最多15個字")]
        public string CategoryName { get; set; }
        [DisplayName("類別說明")]
        public string Description { get; set; }
        [DisplayName("產品圖片")]
        public byte[] Picture { get; set; }
    }  
    public class MetaProducts
    {
        [DisplayName("產品ID")]
        public int ProductID { get; set; }

        [DisplayName("名稱ID")]
        [Required(ErrorMessage = "名稱ID為必填欄位")]
        [StringLength(40, ErrorMessage = "格式錯誤，最多40個字")]
        public string ProductName { get; set; }

        [DisplayName("供應商ID")]
        public Nullable<int> SupplierID { get; set; }

        [DisplayName("種類ID")]
        public Nullable<int> CategoryID { get; set; }

        [DisplayName("每個/單位")]
        [StringLength(20, ErrorMessage = "格式錯誤，最多20個字")]
        public string QuantityPerUnit { get; set; }

        [DisplayName("商品單價")]
        [Range(double.Epsilon,double.MaxValue, ErrorMessage = "必須要正小數")]
        public Nullable<decimal> UnitPrice { get; set; }

        [DisplayName("商品庫存量")]
        [Range(0, ushort.MaxValue, ErrorMessage = "必須要大於等於0")]
        public Nullable<short> UnitsInStock { get; set; }

        [DisplayName("商品訂購量")]
        [Range(0, ushort.MaxValue, ErrorMessage = "必須要大於等於0")]
        public Nullable<short> UnitsOnOrder { get; set; }

        [DisplayName("商品安全庫存量")]
        [Range(0, ushort.MaxValue, ErrorMessage = "必須要大於等於0")]
        public Nullable<short> ReorderLevel { get; set; }

        [DisplayName("是否下架")]
        [DefaultValue(false)]
        public bool Discontinued { get; set; }
    }
}