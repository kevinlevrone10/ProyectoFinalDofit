//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Factura_Productos
    {
        public int Factura_Producto_Id { get; set; }
        public int Cantidad { get; set; }
        public double Costo_Unitario { get; set; }
        public int Factura_Id { get; set; }
        public int Articulo_Id { get; set; }
        public double Costo_Total { get; set; }
    
        public virtual Articulos Articulos { get; set; }
        public virtual Facturas Facturas { get; set; }
    }
}