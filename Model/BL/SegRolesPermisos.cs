using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.BL
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public class SegRolesPermisos
    {
        /// <summary>
        /// identificador
        /// </summary>
        [Key]
        public int Id { get; set; }        

        /// <summary>
        /// Id del permiso
        /// </summary>
        public int PermisoId { get; set; }

        /// <summary>
        /// Definicion llave foránea a la tabla SegPermisos
        /// </summary>
        [ForeignKey("PermisoId")]
        public virtual SegPermisos Permiso { get; set; }


        /// <summary>
        /// Id del Rol
        /// </summary>
        public string RolId { get; set; }

        /// <summary>
        /// Definicion de llave foranea a la tabla AspNetRoles  (ApplicationRole)
        /// </summary>
        [ForeignKey("RolId")]
        public virtual ApplicationRole Role { get; set; }


        /// <summary>
        /// Estado del registro
        /// </summary>
        public int Estregistro { get; set; }

    }
}
