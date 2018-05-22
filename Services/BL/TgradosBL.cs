using Model;
using Model.General;
using Persistence;
using Services.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BL
{
    public class TgradosBL
    {
        // Contexto de base de datos (EF)
        private ControlcBDEntities db = new ControlcBDEntities();
        /// <summary>
        /// Inserta tgrado
        /// </summary>
        /// <param name="model"> Modelo de tgrado</param>
        /// <returns> boolean producto transacción</returns>
        public Jresult InsTgrado(Tgrados model)
        {
            var jresult = new Jresult();
            try
            {
                //var mod = new Tgrados() { Nombre = model.Nombre, CodigoDane = model.CodigoDane, NombreRector = model.NombreRector, NumSedes = model.NumSedes };

                model.Id = db.Tgrados.DefaultIfEmpty().Max(r => r == null ? 0 : r.Id) + 1;
                db.Tgrados.Add(model);
                db.SaveChanges();
                jresult.Success = true;;
                jresult.Message = "Grado registrado satisfactoriamente";

            }
            catch (Exception ex)
            {
                jresult.Message = ex.Message;
                Console.WriteLine(ex.Message);
            }
            return jresult;
        }


        /// <summary>
        /// Obtiene lista de tgrados
        /// </summary>        
        /// <returns> lista de datos</returns>
        public Jresult GetListTgrados()
        {
            var jresult = new Jresult();
            try
            {                
                BindGateway dataResult = new BindGateway();
                var listaDatos = (
                        from tn in db.Tniveles
                        from tg in db.Tgrados.Where(x => x.NivelId == tn.Id)
                        select new
                        {
                            Id = tg.Id,
                            Nombre = tg.Nombre,
                            Numero = tg.Numero,
                            Codigo = tg.Codigo,
                            NivelAcademico = tn.Nombre
                        }
                    );
                dataResult.Data = listaDatos.ToList();
                dataResult.Count = listaDatos.ToList().Count();
                    //.ToList();
                jresult.Data = dataResult;
                jresult.Success = true;;
            }
            catch (Exception ex)
            {
                jresult.Message = ex.Message;
                Console.WriteLine(ex.Message);
            }
            return jresult;
        }

        ///// <summary>
        ///// Actualiza datos básicos del tgrado
        ///// </summary>
        ///// <param name="model"> Datos del modelo de tgrado</param>
        ///// <returns> Resultado de la transacción </returns>
        public Jresult UpdTgrado(Tgrados model)
        {
            var jresult = new Jresult();
            try
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                jresult.Success = true;;
                jresult.Message = "Información del grado modificada satisfactoriamente";
            }
            catch (Exception ex)
            {
                jresult.Message = ex.Message;
                Console.WriteLine(ex.Message);
            }
            return jresult;
        }

        /// <summary>
        /// Obtiene un tgrado
        /// </summary>
        /// <param name="id">id del tgrado </param>
        /// <returns> Resultado de la transaccion </returns>
        public Jresult GetTgrado(long id)
        {
            var jresult = new Jresult();
            try
            {
                var tgrado = db.Tgrados.Find(id);
                jresult.Data = tgrado;
                jresult.Success = true;;
            }
            catch (Exception ex)
            {
                jresult.Message = ex.Message;
                Console.WriteLine(ex.Message);
            }
            return jresult;

        }

        /// <summary>
        /// Elimina tgrado
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Resultado de la transacción </returns>
        public Jresult DelTgrado(int id)
        {
            var jresult = new Jresult();
            try
            {
                var entity = db.Tgrados.SingleOrDefault(b => b.Id == id);
                if (entity != null)
                {
                    entity.Estado = 0;
                    db.SaveChanges();
                }
                db.SaveChanges();

                // Salida success
                jresult.Success = true;;
                jresult.Message = "Grado eliminada satisfactoriamente.";
            }
            catch (Exception ex)
            {
                jresult.Message = "Error eliminando registro: " + ex.Message;
            }
            return jresult;

        }
    }
}
