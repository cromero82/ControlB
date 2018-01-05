using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BL.Tipos
{
    public class Tniveles
    {        
        public int Id { get; set; }

        [Required]
        public string Codigo { get; set; }

        [Required]
        [Display(Name ="Número de orden")]
        public int Numero { get; set; }

        [Required]
        public string Nombre { get; set; }

        /// <summary>
        /// Representa el estado del registro
        /// </summary>
        [Required]
        public int Estado { get; set; } = 1;

        public Tniveles()
        {
            Estado = 1;
        }
    }
}
