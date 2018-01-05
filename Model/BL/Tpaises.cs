using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BL
{
    public class Tpaises
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Representa el codigo del pais: co (Colombia),  es (España), etc.
        /// </summary>
        [Required]
        [Index("UQ_pais_codigo", IsUnique = true)]
        [MaxLength(4)]
        public string Codigo { get; set; }

        [Required]
        [Display(Name = "Pais")]        
        public string Nombre { get; set; }

        /// <summary>
        /// Representa el estado del registro
        /// </summary>
        [Required]
        public int Estado { get; set; } = 1;

        public Tpaises()
        {
            Estado = 1;
        }
    }
}
