//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace HomeBackProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using MetaDataHomeBackProject.Models;

    [MetadataType(typeof(MetaFactoryData))]

    public partial class FactoryData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FactoryData()
        {
            this.FactoryadjacentTypeData = new HashSet<FactoryadjacentTypeData>();
        }
    
        public string FactoryID { get; set; }
        public string FactoryName { get; set; }
        public decimal FactoryMoney { get; set; }
        public decimal FactorySquareMeters { get; set; }
        public Nullable<decimal> FactoryMetersMoney { get; set; }
        public string FactoryCity { get; set; }
        public string FactoryTown { get; set; }
        public string FactoryStreet { get; set; }
        public Nullable<byte> FactoryFloor { get; set; }
        public Nullable<byte> FactoryHighFloor { get; set; }
        public byte FactoryAges { get; set; }
        public bool FactorySaleAndLease { get; set; }
        public string FactoryFeatures { get; set; }
        public byte FactorySaleType { get; set; }
        public string FactoryTerritory { get; set; }
        public string FactoryPeopleID { get; set; }
        public Nullable<short> FactoryADLevel { get; set; }
    
        public virtual ADTypeData ADTypeData { get; set; }
        public virtual CityTypeData CityTypeData { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FactoryadjacentTypeData> FactoryadjacentTypeData { get; set; }
        public virtual PeopleData PeopleData { get; set; }
        public virtual SaleTypeData SaleTypeData { get; set; }
    }
}
