﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PROG5.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DatabaseModelContainer : DbContext
    {
        public DatabaseModelContainer()
            : base("name=DatabaseModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Ninja> NinjaSet { get; set; }
        public virtual DbSet<Equipment> EquipmentSet { get; set; }
        public virtual DbSet<NinjaEquipment> NinjaEquipmentSet { get; set; }
        public virtual DbSet<EquipmentType> EquipmentTypeSet { get; set; }
    }
}