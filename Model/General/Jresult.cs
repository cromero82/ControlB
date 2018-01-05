using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.General
{
    public class Jresult
    {
        public dynamic Result { get; set; }
        public bool Success { get; set; }
        public String Message { get; set; }
        public Jresult() { Success = false; Message = "Transacción no pudo ser completada"; }

        /// <summary>
        /// Metodo que ejecuta una rutina para guardar en BD local información de un error
        /// </summary>
        /// <param name="ex"> Excepción controlada que se generó usar la BD del sistema</param>
        /// <param name="model"> Model o dato con el que se intentó usar la BD del sistema</param>
        public void AsignarError(Exception ex, dynamic model)
        {
            //var log = new AppLoggerBL();
            //log.InsLog(ex, model);

            Message = ex.Message;
            Console.WriteLine(ex.Message);
        }

        /// <summary>
        /// Metodo que ejecuta una rutina para guardar en BD local informaciòn de un error
        /// </summary>
        /// <param name="ex"> Excepción controlada que se generó usar la BD del sistema</param>
        public void AsignarError(Exception ex)
        {
            //var log = new AppLoggerBL();
            //log.InsLog(ex, null);            
        }

        public void MensajeError(Exception ex)
        {
            if (ex.Message.Equals("Error al actualizar las entradas. Vea la excepción interna para obtener detalles."))
            {
                Message = ex.InnerException.InnerException.Message;
            }
            else
            {
                Message = ex.Message;
            }
        }
    }
}
