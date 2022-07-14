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

    [MetadataType(typeof(MetaPeopleData))]

    public partial class PeopleData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PeopleData()
        {
            this.FactoryData = new HashSet<FactoryData>();
            this.HomeData = new HashSet<HomeData>();
            this.TerritoryData = new HashSet<TerritoryData>();
        }
    
        public string PeopleID { get; set; }
        public string PeopleName { get; set; }
        public string IdebtityNumber { get; set; }
        public System.DateTime Birthday { get; set; }
        public bool Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string EMail { get; set; }
        public string County { get; set; }
        public string Town { get; set; }
        public string RoadAndNumber { get; set; }
        public string CompanyName { get; set; }
        public Nullable<decimal> PeopleAge { get; set; }
        public Nullable<decimal> PeopleCash { get; set; }
        public Nullable<System.DateTime> AuthorizationTime { get; set; }
        public byte SaleStateID { get; set; }
        public Nullable<short> SchemeName { get; set; }
    
        public virtual AccountData AccountData { get; set; }
        public virtual CityTypeData CityTypeData { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FactoryData> FactoryData { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HomeData> HomeData { get; set; }
        public virtual PeopleRankData PeopleRankData { get; set; }
        public virtual ProgramData ProgramData { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TerritoryData> TerritoryData { get; set; }
    }
}
