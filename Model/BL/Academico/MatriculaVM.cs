using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public  class AcaMatriculaVM
    {
        public int Id { get; set; }
        public int GradoId { get; set; }
        public int Grado { get; set; }
        public int EstudianteId { get; set; }
        public string PrimerNombreEstudiante { get; set; }
        public string PrimerApellidoEstudiante { get; set; }
        public string SegundoNombreEstudiante { get; set; }
        public string SegundoApellidoEstudiante { get; set; }
        public int PersonaFamiliarId { get; set; }
        public System.DateTime Fecha { get; set; }
        public int EstadoMatriculaId { get; set; }
        public string Observaciones { get; set; }
        public int Estregistro { get; set; }
        public int ContextoId { get; set; }
    }
}
