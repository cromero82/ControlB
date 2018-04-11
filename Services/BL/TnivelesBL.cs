using Model.BL.Tipos;
using Model.General;
using Persistence;
using System;
using System.Data.Entity;
using System.Linq;

namespace Services.BL
{
    public class TnivelesBL
    {
        // Contexto de base de datos (EF)
        private ApplicationDbContext db = new ApplicationDbContext();
        Jresult jresult = new Jresult();

        //protected override void OnException(ExceptionContext filterContext)
        //{

        //}
        /// <summary>
        /// Inserta tnivel
        /// </summary>
        /// <param name="model"> Modelo de tnivel</param>
        /// <returns> boolean producto transacción</returns>
        public Jresult InsTnivel(Tniveles model)
        {
            model.Id = db.Tniveles.DefaultIfEmpty().Max(r => r == null ? 0 : r.Id) + 1;
            db.Tniveles.Add(model);
            db.SaveChanges();
            jresult.Success = true;
            jresult.Message = "Nivel académico registrado satisfactoriamente";
            return jresult;
        }


        /// <summary>
        /// Obtiene lista de tnivels
        /// </summary>        
        /// <returns> lista de datos</returns>
        public Jresult GetListTniveles()
        {
            var listaDatos = db.Tniveles.Where(x => x.Estado == 1).ToList();
            jresult.Result = listaDatos;
            jresult.Success = true;
            return jresult;
        }

        ///// <summary>
        ///// Actualiza datos básicos del tnivel
        ///// </summary>
        ///// <param name="model"> Datos del modelo de tnivel</param>
        ///// <returns> Resultado de la transacción </returns>
        public Jresult UpdTnivel(Tniveles model)
        {
            var jresult = new Jresult();
            try
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                jresult.Success = true;
                jresult.Message = "Información del nivel académico modificada satisfactoriamente";
            }
            catch (Exception ex)
            {
                jresult.Message = ex.Message;
                Console.WriteLine(ex.Message);
            }
            return jresult;
        }

        /// <summary>
        /// Obtiene un tnivel
        /// </summary>
        /// <param name="id">id del tnivel </param>
        /// <returns> Resultado de la transaccion </returns>
        public Jresult GetTnivel(long id)
        {
            var jresult = new Jresult();
            try
            {
                var tnivel = db.Tniveles.Find(id);
                jresult.Result = tnivel;
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
        /// Elimina tnivel
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Resultado de la transacción </returns>
        public Jresult DelTnivel(int id)
        {
            var jresult = new Jresult();
            try
            {
                var entity = db.Tniveles.SingleOrDefault(b => b.Id == id);
                if (entity != null)
                {
                    entity.Estado = 0;
                    db.SaveChanges();
                }
                db.SaveChanges();

                // Salida success
                jresult.Success = true;
                jresult.Message = "Nivel académico eliminada satisfactoriamente.";
            }
            catch (Exception ex)
            {
                jresult.Message = "Error eliminando registro: " + ex.Message;
            }
            return jresult;

        }
    }
}
