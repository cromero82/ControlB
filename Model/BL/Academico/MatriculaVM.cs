using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public  class AcaMatriculaVM
    {
        public int Id { get; set; }

        [DisplayName("Grado")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int GradoId { get; set; }

        [DisplayName("Grado")]        
        public string Grado { get; set; }

        public int EstudianteId { get; set; }

        [DisplayName("Primer nombre")]
        public string PrimerNombreEstudiante { get; set; }

        [DisplayName("Primer apellido")]
        public string PrimerApellidoEstudiante { get; set; }

        [DisplayName("Segundo nombre")]
        public string SegundoNombreEstudiante { get; set; }

        [DisplayName("Segundo apellido")]
        public string SegundoApellidoEstudiante { get; set; }

        [DisplayName("Familiar")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int PersonaFamiliarId { get; set; }

        [DisplayName("Fecha de matricula")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public System.DateTime Fecha { get; set; }

        public int EstadoMatriculaId { get; set; }
        public string Observaciones { get; set; }
        public int Estregistro { get; set; }
        
        public int ContextoId { get; set; }
    }
}
