using Model.Auxiliar;
using Model.BL;
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

        /// <summary>
        /// Inserta lista de departamentos
        /// </summary>
        /// <param name="model"> Modelo de tnivel</param>
        /// <returns> boolean producto transacción</returns>
        public Jresult InsDepartamentos(DatosAbiertosImport model)
        {
            var jresult = new Jresult();
            try
            {                                
                foreach(DatosAbiertosDepartamentos item in model.DepartamentosList)
                {
                    var itemModel = new Tdepartamentos();                    
                    itemModel.Cod = item.iddepto;
                    itemModel.Nombre = item.nomdepto.ToString().TrimStart(' ');
                    itemModel.Latitud = item.deptolatitud;
                    itemModel.Longitud = item.deptolongitud;
                    db.Tdepartamentos.Add(itemModel);
                }
                
                db.SaveChanges();
                jresult.Success = true;
                jresult.Message = "Departamentos registrados satisfactoriamente";

            }
            catch (Exception ex)
            {
                jresult.Message = ex.Message;
                Console.WriteLine(ex.Message);
            }
            return jresult;
        }

        /// <summary>
        /// Obtiene lista de departamentos 
        /// </summary>        
        /// <returns> lista de datos</returns>
        public Jresult GetListDepartamentos()
        {
            var jresult = new Jresult();
            try
            {
                var listaDatos = db.Tdepartamentos.Where(x => x.Estado == 1).ToList();
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
