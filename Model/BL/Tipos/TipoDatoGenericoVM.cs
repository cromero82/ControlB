using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BL.Tipos
{
    public class TipoDatoGenericoVM
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public int PadreId { get; set; }
        /// <summary>
        /// Representa número oficial 1 (Estrato 1), 2 (Estrato 2)
        /// </summary>
        public string Numero { get; set; }
    }
}
