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
    [MetadataType(typeof(MetaTerritoryTypeData))]

    public partial class TerritoryTypeData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TerritoryTypeData()
        {
            this.FactoryData = new HashSet<FactoryData>();
            this.TerritoryData = new HashSet<TerritoryData>();
        }
    
        public int TerritorySerialID { get; set; }
        public string TerritoryTypeSelect { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FactoryData> FactoryData { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TerritoryData> TerritoryData { get; set; }
    }
}
