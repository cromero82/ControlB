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
        public int Estregistro { get; set; }
        public Instituciones()
        {
            Estregistro = 1;
        }
    }
}
