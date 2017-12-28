using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BL
{
    public class SegUsuariosRoles
    {
        // FK
        public int UserId { get; set; }
        public int RolId { get; set; }
        public int Estregistro { get; set; }
    }
}
