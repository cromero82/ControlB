using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.BL
{
    public class Tjornadas
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Representa el nombre del grado: Transición, Primero, etc.
        /// </summary>
        [MaxLength(50)]
        public string Nombre { get; set; }

        /// <summary>
        /// Representa el estado del registro
        /// </summary>
        [Required]
        public int Estado { get; set; }

        /// <summary>
        /// Representa número oficial 1 (Completa), 2 (Mañana)
        /// </summary>
        public int Numero { get; set; }       

        public Tjornadas()
        {
            Estado = 1;
            Numero = 0;
        }
    }
}
