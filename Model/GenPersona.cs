//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class GenPersona
    {
        public int ID { get; set; }
        public int TdocumentoId { get; set; }
        public string NumDoc { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public System.DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int TmunicipioId { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono2 { get; set; }
        public string ModoRegistro { get; set; }
        public int Estregistro { get; set; }
    
        public virtual Tmunicipios Tmunicipios { get; set; }
        public virtual Tdocumentos Tdocumentos { get; set; }
    }
}
