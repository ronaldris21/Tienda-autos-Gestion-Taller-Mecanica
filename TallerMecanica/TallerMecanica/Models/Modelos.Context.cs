﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TallerMecanica.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TallerMecanicoEntities1 : DbContext
    {
        public TallerMecanicoEntities1()
            : base("name=TallerMecanicoEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<MateriaPrima> MateriaPrima { get; set; }
        public virtual DbSet<MateriaPrima_ProductoComprado> MateriaPrima_ProductoComprado { get; set; }
        public virtual DbSet<MateriaPrima_ProductoPreEnsamblado> MateriaPrima_ProductoPreEnsamblado { get; set; }
        public virtual DbSet<ProductoComprado> ProductoComprado { get; set; }
        public virtual DbSet<ProductoPreEnsamblado> ProductoPreEnsamblado { get; set; }
    }
}