﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoFinalDofit.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GimnasiofitEntities : DbContext
    {
        public GimnasiofitEntities()
            : base("name=GimnasiofitEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Articulos> Articulos { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Factura_Productos> Factura_Productos { get; set; }
        public virtual DbSet<Facturas> Facturas { get; set; }
        public virtual DbSet<Plan_Clientes> Plan_Clientes { get; set; }
        public virtual DbSet<Proveedores> Proveedores { get; set; }
        public virtual DbSet<Sexo> Sexo { get; set; }
        public virtual DbSet<Suscripciones> Suscripciones { get; set; }
        public virtual DbSet<Tipo_Movimientos> Tipo_Movimientos { get; set; }
        public virtual DbSet<Trabajadores> Trabajadores { get; set; }
        public virtual DbSet<Turnos> Turnos { get; set; }
        public virtual DbSet<Visitas> Visitas { get; set; }
    }
}
