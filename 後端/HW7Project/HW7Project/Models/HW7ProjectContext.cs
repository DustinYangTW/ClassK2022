using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace HW7Project.Models
{
    public class HW7ProjectContext:DbContext
    {
        public HW7ProjectContext():base("name= HW7ProjectConnetion")
        {

        }

        public DbSet<Employees>Employees { get; set; }
        public DbSet<Members>Members { get; set; }
        public DbSet<Orders>Orders { get; set; }
        public DbSet<OrderDetails>OrderDetails { get; set; }
        public DbSet<PayTypes>PayTypes { get; set; }
        public DbSet<Procducts>Procducts { get; set; }
        public DbSet<Shippers>Shippers { get; set; }

       // public System.Data.Entity.DbSet<HW7Project.Models.VMMember> VMMembers { get; set; }
    }
}