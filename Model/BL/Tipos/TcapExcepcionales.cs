using System.ComponentModel.DataAnnotations;
namespace Model.BL.Tipos
{
    /// <summary>
    /// Representa el tipo de discapacidad de personas: 1 Sordera, 9, Sindrome de down, etc.
    /// </summary>
    public class TcapExcepcionales
    {
        [Key]
        public int Id { get; set; }
        
        [MaxLength(50)]
        [Required]
        public string Nombre { get; set; }

        /// <summary>
        /// Representa el estado del registro
        /// </summary>
        [Required]
        public int Estado { get; set; }

        /// <summary>
        /// Representa número oficial 1 (Estrato 1), 2 (Estrato 2)
        /// </summary>
        [MaxLength(5)]
        public string Numero { get; set; }       

        public TcapExcepcionales()
        {
            Estado = 1;
            Numero = "00";
        }
    }
}
