using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Auth
{
    public class ApplicationRole: IdentityRole
    {
        /// <summary>
        /// Determinara si el rol esta activo o no
        /// </summary>
        public bool Enabled { get; set; }
    }
}
