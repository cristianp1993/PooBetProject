//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BetProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class empleado
    {
        public int emp_codigo { get; set; }
        public string emp_documento { get; set; }
        public string emp_perfil { get; set; }
        public Nullable<decimal> emp_salario { get; set; }
    
        public virtual persona persona { get; set; }
    }
}
