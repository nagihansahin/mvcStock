﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mvcStock.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MvcDbStockEntities : DbContext
    {
        public MvcDbStockEntities()
            : base("name=MvcDbStockEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<KategoriTbl> KategoriTbl { get; set; }
        public virtual DbSet<MusteriTbl> MusteriTbl { get; set; }
        public virtual DbSet<SatisTbl> SatisTbl { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TblUrunler> TblUrunler { get; set; }
    }
}