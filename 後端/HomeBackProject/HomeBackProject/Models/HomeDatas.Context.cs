﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HomeDataEntities : DbContext
    {
        public HomeDataEntities()
            : base("name=HomeDataEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AccountData> AccountData { get; set; }
        public virtual DbSet<ADTypeData> ADTypeData { get; set; }
        public virtual DbSet<CarTypeData> CarTypeData { get; set; }
        public virtual DbSet<CityTypeData> CityTypeData { get; set; }
        public virtual DbSet<HomeData> HomeData { get; set; }
        public virtual DbSet<HomeTypeData> HomeTypeData { get; set; }
        public virtual DbSet<PeopleData> PeopleData { get; set; }
        public virtual DbSet<PeopleRankData> PeopleRankData { get; set; }
        public virtual DbSet<ProgramData> ProgramData { get; set; }
        public virtual DbSet<SaleTypeData> SaleTypeData { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
