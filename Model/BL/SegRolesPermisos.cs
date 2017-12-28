using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.BL
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public class SegRolesPermisos
    {
        [Key]
        public int Id { get; set; }        

        
        public int PermisoId { get; set; }

        [ForeignKey("PermisoId")]
        public virtual SegPermisos Permiso { get; set; }


        
        public string RolId { get; set; }

        [ForeignKey("RolId")]
        public virtual ApplicationRole Role { get; set; }

        public int Estregistro { get; set; }

    }
}
