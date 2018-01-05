using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Auxiliar
{

    /// <summary>
    /// Clase utilizada para importar datos externos: www.datos.gov.co
    /// </summary>
    public class DatosAbiertosImport
    {
        /// <summary>
        /// Cadena de caracteres que representa el json
        /// </summary>
        public string DatosStringJson { get; set; }
        public IEnumerable<DatosAbiertosDepartamentos> DepartamentosList { get; set; }
        public IEnumerable<DatosAbiertosMunicipios> MunicipiosList { get; set; }
    }

    public class DatosAbiertosDepartamentos
    {
        public string iddepto { get; set; }
        public string nomdepto { get; set; }
        public double deptolatitud { get; set; }
        public double deptolongitud { get; set; }
    }

    public class DatosAbiertosMunicipios
    {
        public string cod_depto { get; set; }
        public string cod_mpio { get; set; }
        public string nom_mpio { get; set; }        
    }
}