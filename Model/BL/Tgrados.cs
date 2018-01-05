using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BL
{
    public class Tgrados
    {
        [Key]
        public int Id { get; set; }
        
        /// <summary>
        /// Definicion FK nombre en el model actual
        /// </summary>
        public int NivelId { get; set; }

        /// <summary>
        /// Definicion FK NivelId foránea al model Tniveles
        /// </summary>
        [ForeignKey("NivelId")]
        public virtual Tniveles TipoNivel { get; set; }

        public string Codigo { get; set; }

        /// <summary>
        /// Representa el nombre del grado: Transición, Primero, etc.
        /// </summary>
        //[Index("GradoNombre",IsUnique = true)]
        public string Nombre { get; set; }

        /// <summary>
        /// Representa el estado del registro
        /// </summary>
        [Required]
        public int Estado { get; set; }

        /// <summary>
        /// Representa número oficial -2 (Prejardin), -1 (Jardín)
        /// </summary>
        public int Numero { get; set; }

        [NotMapped]
        /// <summary>
        /// Representa el nombre del nivel académico
        /// </summary>
        public string NivelAcademico { get; set; }

        public Tgrados()
        {
            Estado = 1;
            Numero = 1;
        }
    }
}
