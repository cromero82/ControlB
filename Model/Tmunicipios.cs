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
    
    public partial class Tmunicipios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tmunicipios()
        {
            this.GenInstituciones = new HashSet<GenInstituciones>();
            this.GenPersona = new HashSet<GenPersona>();
        }
    
        public int Id { get; set; }
        public int DepartamentoId { get; set; }
        public string Cod { get; set; }
        public string Nombre { get; set; }
        public int Estado { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GenInstituciones> GenInstituciones { get; set; }
        public virtual Tdepartamentos Tdepartamentos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GenPersona> GenPersona { get; set; }
    }
}
