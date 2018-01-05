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
    public class Tmetodologias
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Representa el numero que aparece en anexo c600 del DANE
        /// </summary>
        [Required]                
        public int  Numero { get; set; }
        
        [Required]
        [Index("UQ_nombre", IsUnique = true)]
        [Display(Name = "Metodología")]
        [MaxLength(25)] 
        public string Nombre { get; set; }

        /// <summary>
        /// Representa el estado del registro
        /// </summary>
        [Required]
        public int Estado { get; set; } = 1;

        public Tmetodologias()
        {
            Estado = 1;
        }
    }
}
