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
    
    public partial class GenContexto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GenContexto()
        {
            this.AcaGrupo = new HashSet<AcaGrupo>();
            this.AcaMatricula = new HashSet<AcaMatricula>();
        }
    
        public int Id { get; set; }
        public int UnidadOrganizacionalId { get; set; }
        public int CalendarioId { get; set; }
        public int Estregistro { get; set; }
    
        public virtual AcaCalendario Calendario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AcaGrupo> AcaGrupo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AcaMatricula> AcaMatricula { get; set; }
    }
}
