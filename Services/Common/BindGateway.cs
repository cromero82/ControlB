namespace Services.Common
{
    /// <summary>
    /// Clase utilizada en consultas con mas de una tabla que permite almacenar los datos y la cantidad de registros
    /// desde la capa BL a controladores
    /// </summary>
    public class BindGateway
    {
        /// <summary>
        /// Almacena cualquier información (particularmente registros en enumeraciones)
        /// </summary>
        public dynamic Data { get; set; }

        /// <summary>
        /// Almacena la cantidad de registros almacenados en Data
        /// </summary>
        public int Count { get; set; }
    }
}
