using Model.BL.Tipos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.BL
{
    /// <summary>
    /// Similar a JORNADA. Representa el corazon donde estan ubicado las entidades principales: Estudiantes, docentes y registro academico. muy similar a Jornada (agrupa institucion, sede, jornada)
    /// </summary>
    public class GenCore
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Definicion FK sede
        /// </summary>
        public int SedeId { get; set; }


        /// <summary>
        /// Definicion FK jornada
        /// </summary>
        public int JornadaId { get; set; }

        
        /// <summary>
        /// Definicion FK SedeId foránea al model GenSedes
        /// </summary>
        [ForeignKey("SedeId")]
        public virtual GenSedes Sede { get; set; }


        /// <summary>
        /// Definicion FK JornadaId foránea al model Tjornadas
        /// </summary>
        [ForeignKey("JornadaId")]
        public virtual Tjornadas Jornada { get; set; }

        /// <summary>
        /// Estado del registro
        /// </summary>
        public int Estado { get; set; } = 1;

        /// <summary>
        /// Representa el estado del registro
        /// </summary>
        public int Estregistro { get; set; } = 1;

        public GenCore()
        {
            Estregistro = 1;
        }
    }
}
