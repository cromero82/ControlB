using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BL
{
    public class Tdepartamentos
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Representa el codigo de departamento (Campo único)
        /// </summary>
        [Index("UQ_dep_cod", IsUnique = true)]
        [MaxLength(5)]
        public string Cod { get; set; }

        /// <summary>
        /// Representa el nombre del departamento: Antioquia, Meta, etc.
        /// </summary>
        [MaxLength(80)]
        [Required]
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

        public Tdepartamentos()
        {
            Estado = 1;           
        }
    }
}
