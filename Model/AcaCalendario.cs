//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class AcaCalendario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AcaCalendario()
        {
            this.GenContexto = new HashSet<GenContexto>();
        }
    
        public int Id { get; set; }
        public System.DateTime FechaInicial { get; set; }
        public string FechaFinal { get; set; }
        public int AnioInicial { get; set; }
        public string Nombre { get; set; }
        public int EstadoVigencia { get; set; }
        public int EstRegistro { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GenContexto> GenContexto { get; set; }
    }
}
