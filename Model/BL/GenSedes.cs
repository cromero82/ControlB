﻿using Model.BL.Tipos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BL
{
    public class GenSedes
    {
        public int Id { get; set; }
        public string CodigoDaneSede { get; set; }

        [Required]
        [Index("UQ_sede", IsUnique = true)]
        [MaxLength(200)]
        public string NombreSede { get; set; }

        /// <summary>
        /// Definicion FK (GenInstituciones) nombre en el model actual
        /// </summary>
        public int InstitucionId { get; set; }

        /// <summary>
        /// Definicion FK InstitucionId foránea al model (GenInstituciones)
        /// </summary>
        [ForeignKey("InstitucionId")]
        public virtual GenInstituciones GenInstituciones { get; set; }

        public string RectorResponsable { get; set; }

        [Required]
        public string Direccion { get; set; }

        [Required]
        public string Correo { get; set; }

        [Required]
        public string Telefono { get; set; }        

        /// <summary>
        /// Estado del registro
        /// </summary>
        public int Estado { get; set; } = 1;

        /// <summary>
        /// Representa el estado del registro
        /// </summary>
        public int Estregistro { get; set; } = 1;

        public GenSedes()
        {
            Estregistro = 1;           
        }
    }
}
