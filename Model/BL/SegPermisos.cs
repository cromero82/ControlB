using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.BL
{
    public partial class SegPermisos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SegPermisos() { }

        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; }
        public string Sigla { get; set; }
        public int Estado { get; set; }
        public int Estregistro { get; set; }              
    }
}
