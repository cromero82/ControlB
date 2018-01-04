using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BL
{
    public class Tcaracter
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Representa el nombre del grado: Transición, Primero, etc.
        /// </summary>
        [MaxLength(100)]
        [Required]
        public string Nombre { get; set; }

        /// <summary>
        /// Representa el estado del registro
        /// </summary>
        [Required]
        public int Estado { get; set; }

        /// <summary>
        /// Representa número oficial 1 (Academica), 2 (Tecnica)
        /// </summary>
        [MaxLength(5)]
        public string Numero { get; set; }

        /// <summary>
        /// es una variable auxiliar para guardar el valor del numero de configuracion con la intension de convertirlo a string y asignarlo al campo 'Numero'
        /// </summary>
        [NotMapped]
        [Required]
        public int NumeroAux { get; set; }

        public Tcaracter()
        {
            Estado = 1;
            Numero = "00";
        }
    }
}
