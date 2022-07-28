﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace _07ADonet_Send_differentdb.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SchoolEntities : DbContext
    {
        public SchoolEntities()
            : base("name=SchoolEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<主管> 主管 { get; set; }
        public virtual DbSet<客戶> 客戶 { get; set; }
        public virtual DbSet<員工> 員工 { get; set; }
        public virtual DbSet<班級> 班級 { get; set; }
        public virtual DbSet<教授> 教授 { get; set; }
        public virtual DbSet<新客戶> 新客戶 { get; set; }
        public virtual DbSet<課程> 課程 { get; set; }
        public virtual DbSet<學生> 學生 { get; set; }
        public virtual DbSet<客戶業績> 客戶業績 { get; set; }
        public virtual DbSet<課程2> 課程2 { get; set; }
        public virtual DbSet<View_1> View_1 { get; set; }
    
        [DbFunction("SchoolEntities", "fnOffsetFetchNext")]
        public virtual IQueryable<fnOffsetFetchNext_Result> fnOffsetFetchNext(Nullable<int> m, Nullable<int> n)
        {
            var mParameter = m.HasValue ?
                new ObjectParameter("m", m) :
                new ObjectParameter("m", typeof(int));
    
            var nParameter = n.HasValue ?
                new ObjectParameter("n", n) :
                new ObjectParameter("n", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<fnOffsetFetchNext_Result>("[SchoolEntities].[fnOffsetFetchNext](@m, @n)", mParameter, nParameter);
        }
    
        public virtual int deawStar()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("deawStar");
        }
    
        public virtual int deawStar2(Nullable<int> c)
        {
            var cParameter = c.HasValue ?
                new ObjectParameter("c", c) :
                new ObjectParameter("c", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("deawStar2", cParameter);
        }
    
        public virtual ObjectResult<emplyeeDataRow_Result> emplyeeDataRow(Nullable<int> i, Nullable<int> j)
        {
            var iParameter = i.HasValue ?
                new ObjectParameter("i", i) :
                new ObjectParameter("i", typeof(int));
    
            var jParameter = j.HasValue ?
                new ObjectParameter("j", j) :
                new ObjectParameter("j", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<emplyeeDataRow_Result>("emplyeeDataRow", iParameter, jParameter);
        }
    
        public virtual int getCoursePivot()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("getCoursePivot");
        }
    
        public virtual ObjectResult<getOrderDetails_Result> getOrderDetails()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getOrderDetails_Result>("getOrderDetails");
        }
    }
}
