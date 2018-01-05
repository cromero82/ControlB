using Model.BL.Tipos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BL
{
    public class GenSedes
    {
        public int Id { get; set; }
        public string CodigoDane { get; set; }

        [Required]
        [Index("UQ_institucion_codigo", IsUnique = true)]
        [MaxLength(150)]
        public string Nombre { get; set; }

        /// <summary>
        /// Definicion FK nombre en el model actual
        /// </summary>
        public int TmunicipioId { get; set; }

        /// <summary>
        /// Definicion FK NivelId foránea al model Tmunicipios
        /// </summary>
        [ForeignKey("InstitucionId")]
        public virtual Instituciones Instituciones { get; set; }

        public string Rector { get; set; }

        //[Required]
        //public string Direccion { get; set; }

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

        public Sedes()
        {
            Estregistro = 1;           
        }
    }
}
