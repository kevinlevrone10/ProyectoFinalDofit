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
    
    public partial class Articulos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Articulos()
        {
            this.Factura_Productos = new HashSet<Factura_Productos>();
        }
    
        public int Articulo_Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public double Costo_Unitario { get; set; }
        public int Cantidad { get; set; }
        public double Precio_Venta { get; set; }
        public double Total_Costo { get; set; }
        public string Categoria { get; set; }
        public string Linea { get; set; }
        public bool Activo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Factura_Productos> Factura_Productos { get; set; }
    }
}
