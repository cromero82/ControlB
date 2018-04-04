﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.BL.Tipos
{
    /// <summary>
    /// Representa el tipo de discapacidad de personas: 1 Sordera, 9, Sindrome de down, etc.
    /// </summary>
    public class TetniasVM
    {
        
        public int Id { get; set; }
        
       
        public string Nombre { get; set; }

        /// <summary>
        /// Representa el estado del registro
        /// </summary>
      
        public int Estado { get; set; }

        /// <summary>
        /// Representa número oficial 1 (Estrato 1), 2 (Estrato 2)
        /// </summary>
        public string Numero { get; set; }       

        public TetniasVM()
        {
            Estado = 1;
            Numero = "00";
        }
    }
}
