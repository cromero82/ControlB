using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Model.BL
{
    /// <summary>
    /// Representa el tipo de discapacidad de personas: 1 Sordera, 9, Sindrome de down, etc.
    /// </summary>
    public class GenPersonaVM
    {

        public int Id { get; set; }
        public int TdocumentoId { get; set; }

        [DisplayName("Tipo de documento")]        
        public string Tdocumento { get; set; }

        [DisplayName("Número de documento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string NumDoc { get; set; }

        [DisplayName("Primer nombre")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string PrimerNombre { get; set; }

        [DisplayName("Segundo nombre")]
        public string SegundoNombre { get; set; }

        [DisplayName("Primer apellido")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string PrimerApellido { get; set; }

        [DisplayName("Segundo apellido")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string SegundoApellido { get; set; }

        [DisplayName("Fecha de nacimiento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public System.DateTime FechaNacimiento { get; set; }

        [DisplayName("Dirección")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Direccion { get; set; }

        [DisplayName("Teléfono")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Telefono { get; set; }

        [DisplayName("Ciudad (Municipio)")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int TmunicipioId { get; set; }

        [DisplayName("Ciudad (Documento)")]
        public string Tmunicipio { get; set; }

        [DisplayName("Departamento (Documento)")]
        public string Tdepartamento { get; set; }

        [DisplayName("Correo electrónico")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string CorreoElectronico { get; set; }

        [DisplayName("Teléfono adicional")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Telefono2 { get; set; }

        public string ModoRegistro { get; set; }
        public int Estregistro { get; set; }
    }    
}
