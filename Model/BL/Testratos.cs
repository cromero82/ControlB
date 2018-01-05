using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BL
{
    /// <summary>
    /// Representa el estrato social: Estrato 1, estrato 2, etc.
    /// </summary>
    public class Testratos
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
        public string Numero { get; set; }       

        public Testratos()
        {
            Estado = 1;
            Numero = "00";
        }
    }
}
