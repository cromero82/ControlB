using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BL
{
    public class Instituciones
    {
        public int Id { get; set; }
        public string CodigoDane { get; set; }

        [Required]
        public string Nombre { get; set; }
        public string Rector { get; set; }

        [Required]
        public string Direccion { get; set; }

        [Required]
        public string Correo { get; set; }

        [Required]
        public string Telefono { get; set; }

        public DateTime FechaFundacion { get; set; } 

        /// <summary>
        /// Estado del registro
        /// </summary>
        public int Estado { get; set; } = 1;

        /// <summary>
        /// Representa el estado del registro
        /// </summary>
        public int Estregistro { get; set; } = 1;

        public Instituciones()
        {
            Estregistro = 1;
        }
    }
}
