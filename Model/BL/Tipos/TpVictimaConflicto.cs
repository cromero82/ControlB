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
    /// Representa los tipos de poblacion victimas de conflicto: 1 (En situación de desplazamiento)
    /// </summary>
    public class TpVictimaConflicto
    {
        [Key]
        public int Id { get; set; }
        
        [MaxLength(50)]
        [Required]
        public string Nombre { get; set; }

        /// <summary>
        /// Representa el estado del registro
        /// </summary>
        [Required]
        public int Estado { get; set; }

        /// <summary>
        /// Representa número oficial 1 (Estrato 1), 2 (Estrato 2)
        /// </summary>
        [MaxLength(5)]
        [Index("UQ_victimaconfl_num", IsUnique = true)]
        public string Numero { get; set; }       

        public TpVictimaConflicto()
        {
            Estado = 1;
            Numero = "00";
        }
    }
}
