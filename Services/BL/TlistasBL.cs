using Model.General;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BL
{
    public class TlistasBL
    {
        // Contexto de base de datos (EF)
        private ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// Obtiene lista de tipos de caracteristicas 
        /// </summary>        
        /// <returns> lista de datos</returns>
        public Jresult GetListTcaracteristicas()
        {
            var jresult = new Jresult();
            try
            {
                var listaDatos = db.Tcaracter.Where(x => x.Estado == 1).ToList();
                jresult.Result = listaDatos;
                jresult.Success = true;
            }
            catch (Exception ex)
            {
                jresult.Message = ex.Message;
                Console.WriteLine(ex.Message);
            }
            return jresult;
        }

        /// <summary>
        /// Obtiene lista de tipos de especialidades del nivel academico
        /// </summary>        
        /// <returns> lista de datos</returns>
        public Jresult GetListTespecialidades()
        {
            var jresult = new Jresult();
            try
            {
                var listaDatos = db.Tespecialidades.Where(x => x.Estado == 1).ToList();
                jresult.Result = listaDatos;
                jresult.Success = true;
            }
            catch (Exception ex)
            {
                jresult.Message = ex.Message;
                Console.WriteLine(ex.Message);
            }
            return jresult;
        }
    }
}
