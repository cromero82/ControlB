using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    /// <summary>
    /// Representa el tipo de discapacidad de personas: 1 Sordera, 9, Sindrome de down, etc.
    /// </summary>
    public class GenEstudianteVM: GenPersonaVM
    {

        public int Id { get; set; }

        [DisplayName("Persona")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int PersonaId { get; set; }
        
        public string Codigo { get; set; }

        [DisplayName("Capacidad excepcional")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int CapacidadExcepcionalId { get; set; }
        [DisplayName("Capacidad excepcional")]
        public string CapacidadExcepcional { get; set; }

        [DisplayName("Discapacidad")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int DiscapacidadId { get; set; }

        [DisplayName("Discapacidad")]
        public string Discapacidad { get; set; }        
    }    
}
