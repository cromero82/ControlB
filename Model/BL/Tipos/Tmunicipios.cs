using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BL.Tipos
{
    public class Tmunicipios
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Definicion FK nombre en el model actual
        /// </summary>
        public int DepartamentoId { get; set; }

        /// <summary>
        /// Definicion FK NivelId foránea al model Tniveles
        /// </summary>
        [ForeignKey("DepartamentoId")]
        public virtual Tdepartamentos Departamento { get; set; }

        [NotMapped]
        [Display(Name ="Departamento")]
        public string NombreDepartamento { get; set; }

        /// <summary>
        /// Representa el codigo de municipio (Campo único)
        /// </summary>
        [Index("UQ_mun_cod", IsUnique = true)]
        [MaxLength(5)]
        [Display(Name ="Código")]
        public string Cod { get; set; }

        /// <summary>
        /// Representa el nombre del municipio: Antioquia, Meta, etc.
        /// </summary>
        [MaxLength(80)]
        [Required]
        [Display(Name = "Municipio")]
        public string Nombre { get; set; }

        /// <summary>
        /// Representa el estado del registro
        /// </summary>
        [Required]
        public int Estado { get; set; }

        /// <summary>
        /// Posicion geografica latitud 
        /// </summary>        
        public double Latitud { get; set; }

        /// <summary>
        /// Posicion geografica longitud 
        /// </summary>        
        public double Longitud { get; set; }

        public Tmunicipios()
        {
            Estado = 1;
        }
    }
}
