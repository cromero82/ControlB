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
    
    public partial class AcaGrupo
    {
        public int Id { get; set; }
        public int TgradoId { get; set; }
        public int ContextoId { get; set; }
        public string Nombre { get; set; }
        public int Cupo { get; set; }
        public int Estregistro { get; set; }
    
        public virtual Tgrados Grado { get; set; }
        public virtual GenContexto GenContexto { get; set; }
    }
}