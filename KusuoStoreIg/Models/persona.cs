//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KusuoStoreIg.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class persona
    {
        public string nombrec { get; set; }
        public string apellido { get; set; }
        public string direccion { get; set; }
        public string comuna { get; set; }
        public string region { get; set; }
        public string nrotlf { get; set; }
        public string rut { get; set; }
        public Nullable<int> IDus { get; set; }
    
        public virtual usuario usuario { get; set; }
    }
}
