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
    
    public partial class Visitas
    {
        public int Visita_Id { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Suscripcion_Id { get; set; }
        public int Trabajador_Id { get; set; }
    
        public virtual Suscripciones Suscripciones { get; set; }
        public virtual Trabajadores Trabajadores { get; set; }
    }
}
