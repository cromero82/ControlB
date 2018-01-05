
using Model.BL.Tipos;
using Model.General;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BL
{
    public class TjornadasBL
    {
        // Contexto de base de datos (EF)
        private ApplicationDbContext db = new ApplicationDbContext();
        /// <summary>
        /// Inserta tjornada
        /// </summary>
        /// <param name="model"> Modelo de tjornada</param>
        /// <returns> boolean producto transacción</returns>
        public Jresult InsTjornada(Tjornadas model)
        {
            var jresult = new Jresult();
            try
            {
                //var mod = new Tjornadas() { Nombre = model.Nombre, CodigoDane = model.CodigoDane, NombreRector = model.NombreRector, NumSedes = model.NumSedes };

                model.Id = db.Tjornadas.DefaultIfEmpty().Max(r => r == null ? 0 : r.Id) + 1;
                db.Tjornadas.Add(model);
                db.SaveChanges();
                jresult.Success = true;
                jresult.Message = "Jornada académico registrado satisfactoriamente";

            }
            catch (Exception ex)
            {
                jresult.Message = ex.Message;
                Console.WriteLine(ex.Message);
            }
            return jresult;
        }


        /// <summary>
        /// Obtiene lista de tjornadas
        /// </summary>        
        /// <returns> lista de datos</returns>
        public Jresult GetListTjornadas()
        {
            var jresult = new Jresult();
            try
            {
                var listaDatos = db.Tjornadas.Where(x => x.Estado == 1).ToList();
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

        ///// <summary>
        ///// Actualiza datos básicos del tjornada
        ///// </summary>
        ///// <param name="model"> Datos del modelo de tjornada</param>
        ///// <returns> Resultado de la transacción </returns>
        public Jresult UpdTjornada(Tjornadas model)
        {
            var jresult = new Jresult();
            try
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                jresult.Success = true;
                jresult.Message = "Información del jornada académico modificada satisfactoriamente";
            }
            catch (Exception ex)
            {
                jresult.Message = ex.Message;
                Console.WriteLine(ex.Message);
            }
            return jresult;
        }

        /// <summary>
        /// Obtiene un tjornada
        /// </summary>
        /// <param name="id">id del tjornada </param>
        /// <returns> Resultado de la transaccion </returns>
        public Jresult GetTjornada(long id)
        {
            var jresult = new Jresult();
            try
            {
                var tjornada = db.Tjornadas.Find(id);
                jresult.Result = tjornada;
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
        /// Elimina tjornada
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Resultado de la transacción </returns>
        public Jresult DelTjornada(int id)
        {
            var jresult = new Jresult();
            try
            {
                var entity = db.Tjornadas.SingleOrDefault(b => b.Id == id);
                if (entity != null)
                {
                    entity.Estado = 0;
                    db.SaveChanges();
                }
                db.SaveChanges();

                // Salida success
                jresult.Success = true;
                jresult.Message = "Jornada académico eliminada satisfactoriamente.";
            }
            catch (Exception ex)
            {
                jresult.Message = "Error eliminando registro: " + ex.Message;
            }
            return jresult;

        }
    }
}
