using Model.BL.Tipos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BL
{
    public class GenPersona
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "el campo {0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "la longitud permitida es máxima de {0} carácteres")]
        [DisplayName("Primer nombre")]
        public string PrimerNombre { get; set; }

        [MaxLength(50, ErrorMessage = "la longitud permitida es máxima de {0} carácteres")]
        [DisplayName("Segundo nombre")]
        public string SegundoNombre { get; set; }

        [Required(ErrorMessage = "el campo {0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "la longitud permitida es máxima de {0} carácteres")]
        [DisplayName("Primer apellido")]
        public string PrimerApellido { get; set; }

        [MaxLength(50, ErrorMessage = "la longitud permitida es máxima de {0} carácteres")]
        [DisplayName("Segundo apellido")]
        public string SegundoApellido { get; set; }

        [Index("UQ_persona_numdocumento", IsUnique = true)]
        [Required(ErrorMessage = "el campo {0} es obligatorio")]
        [MaxLength(30, ErrorMessage = "la longitud permitida es máxima de {0} carácteres")]
        public string NumeroDocumento { get; set; }

        //[Range(minimum:1,maximum:10)]
        [Required(ErrorMessage = "el campo {0} es obligatorio")]
        public int Tdocumento { get; set; }

        /// <summary>
        /// Definicion FK NivelId foránea al model Tdocumentos
        /// </summary>
        [ForeignKey("Tdocumento")]
        [Required(ErrorMessage = "el campo {0} es obligatorio")]
        public virtual Tdocumentos FkTdocmentos { get; set; }

        /// <summary>
        /// Definicion FK nombre en el model actual
        /// </summary>
        public int TmunicipioId { get; set; }


        /// <summary>
        /// Representa departamento, se utiliza como dato dependiente de municipio (ciudad) por ese motivo no se mapea en BD
        /// </summary>
        [NotMapped]
        public int TdepartamentoId { get; set; }

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
    }
}
