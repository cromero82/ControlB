using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BL.Tipos
{
    /// <summary>
    /// Representa la metodología de enseñanza del establecimiento: educacion tradicional, escuela nueva, etc.
    /// </summary>
    public class Tdocumentos
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Representa el número que aparece en formato DANE C600
        /// </summary>
        [Required]
        public int Numero { get; set; }

        [Required]
        [Index("UQ_tipodocumento", IsUnique = true)]
        [Display(Name = "Metodología")]
        [MaxLength(80)] 
        public string Nombre { get; set; }

        /// <summary>
        /// Representa el estado del registro
        /// </summary>
        [Required]
        public int Estado { get; set; } = 1;

        public Tdocumentos()
        {
            Estado = 1;
        }
    }
}
