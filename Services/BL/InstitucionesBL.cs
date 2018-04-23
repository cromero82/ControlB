using Model.BL;
using Model.General;
using Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BL
{
    public class InstitucionesBL
    {
        // Contexto de base de datos (EF)
        private ApplicationDbContext db = new ApplicationDbContext();
        /// <summary>
        /// Inserta establecimiento
        /// </summary>
        /// <param name="model"> Modelo de establecimiento</param>
        /// <returns> boolean producto transacción</returns>
        public Jresult InsInstitucion(GenInstituciones model)
        {
            var jresult = new Jresult();
            try
            {
                //var mod = new GenInstituciones() { Nombre = model.Nombre, CodigoDane = model.CodigoDane, NombreRector = model.NombreRector, NumSedes = model.NumSedes };

                model.Id = db.GenInstituciones.DefaultIfEmpty().Max(r => r == null ? 0 : r.Id) + 1;
                db.GenInstituciones.Add(model);
                db.SaveChanges();
                jresult.Success = true;;
                jresult.Message = "Institucion registrado satisfactoriamente";

            }
            catch (Exception ex)
            {
                jresult.Message = ex.Message;
                Console.WriteLine(ex.Message);
            }
            return jresult;
        }


        /// <summary>
        /// Obtiene lista de establecimientos
        /// </summary>        
        /// <returns> lista de datos</returns>
        public Jresult GetListInstituciones()
        {
            var jresult = new Jresult();
            try
            {
                var listaDatos = db.GenInstituciones.Where(x => x.Estado == 1).ToList();                
                jresult.Data = listaDatos;
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
        ///// Actualiza datos básicos del establecimiento
        ///// </summary>
        ///// <param name="model"> Datos del modelo de establecimiento</param>
        ///// <returns> Resultado de la transacción </returns>
        public Jresult UpdInstitucion(GenInstituciones model)
        {
            var jresult = new Jresult();
            try
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                jresult.Success = true;;
                jresult.Message = "Información del establecimiento modificada satisfactoriamente";
            }
            catch (Exception ex)
            {
                jresult.Message = ex.Message;
                Console.WriteLine(ex.Message);
            }
            return jresult;
        }

        /// <summary>
        /// Obtiene un establecimiento
        /// </summary>
        /// <param name="id">id del establecimiento </param>
        /// <returns> Resultado de la transaccion </returns>
        public Jresult GetInstitucion(long id)
        {
            var jresult = new Jresult();
            try
            {
                var establecimiento = db.GenInstituciones.Find(id);
                jresult.Data = establecimiento;
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
        /// Elimina establecimiento
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Resultado de la transacción </returns>
        public Jresult DelInstitucion(int id)
        {
            var jresult = new Jresult();
            try
            {
                var entity = db.GenInstituciones.SingleOrDefault(b => b.Id == id);
                if (entity != null)
                {
                    entity.Estado = 0;
                    db.SaveChanges();
                }                                                
                db.SaveChanges();

                // Salida success
                jresult.Success = true;;
                jresult.Message = "Institucion eliminada satisfactoriamente.";
            }
            catch (Exception ex)
            {
                jresult.Message = "Error eliminando registro: " + ex.Message;
            }
            return jresult;

        }
    }
}
