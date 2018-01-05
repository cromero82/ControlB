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
    public class GenNivelesAprobados
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Definicion FK (GenInstituciones) nombre en el model actual
        /// </summary>         
        [Index("Ix_InstitucionId", 1, IsUnique = true)]
        public int InstitucionId { get; set; }

        /// <summary>
        /// Definicion FK InstitucionId foránea al model (GenInstituciones)
        /// </summary>        
        [ForeignKey("InstitucionId")]
        public virtual GenInstituciones GenInstituciones { get; set; }


        /// <summary>
        /// Definicion FK (Tniveles) nombre en el model actual
        /// </summary>        
        [Index("Ix_NivelId", 2, IsUnique = true)]
        public int NivelId { get; set; }

        /// <summary>
        /// Definicion FK InstitucionId foránea al model (Tniveles)
        /// </summary>
        [ForeignKey("NivelId")]
        public virtual Tniveles Niveles { get; set; }

        /// <summary>
        /// Estado del registro
        /// </summary>
        public int Estado { get; set; } = 1;

        /// <summary>
        /// Representa el estado del registro
        /// </summary>
        public int Estregistro { get; set; } = 1;

        public GenNivelesAprobados()
        {
            Estregistro = 1;           
        }
    }
}
