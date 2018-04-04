﻿using Kendo.Mvc.Extensions;
using Model.BL.Tipos;
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
    public class TetniasBL
    {
        // Contexto de base de datos (EF)
        private ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// Inserta tnivel
        /// </summary>
        /// <param name="model"> Modelo de tnivel</param>
        /// <returns> boolean producto transacción</returns>
        public Jresult InsTnivel(Tetnias model)
        {
            var jresult = new Jresult();
            try
            {
                //var mod = new Tetnias() { Nombre = model.Nombre, CodigoDane = model.CodigoDane, NombreRector = model.NombreRector, NumSedes = model.NumSedes };

                model.Id = db.Tetnias.DefaultIfEmpty().Max(r => r == null ? 0 : r.Id) + 1;
                db.Tetnias.Add(model);
                db.SaveChanges();
                jresult.Success = true;
                jresult.Message = "Nivel académico registrado satisfactoriamente";

            }
            catch (Exception ex)
            {
                jresult.Message = ex.Message;
                Console.WriteLine(ex.Message);
            }
            return jresult;
        }

        public Kendo.Mvc.UI.DataSourceResult GetListTetnias(Kendo.Mvc.UI.DataSourceRequest filtrosComponenteKendo)
        {
            var queryable = db.Tetnias.Where(f=>f.Estado == 1).Select(r => new TetniasVM
            {
                    Id= r.Id,                    
                    Nombre = r.Nombre,                    
                    Numero = r.Numero,
                    Estado = r.Estado
            });            

            // Se aplican filtros de kendo               
            var datos = queryable.ToDataSourceResult(filtrosComponenteKendo);
            return datos;
        }


        /// <summary>
        /// Obtiene lista de tnivels
        /// </summary>        
        /// <returns> lista de datos</returns>
        public Jresult GetListTetnias()
        {
            var jresult = new Jresult();
            try
            {
                var listaDatos = db.Tetnias.Where(x => x.Estado == 1).ToList();
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
        ///// Actualiza datos básicos del tnivel
        ///// </summary>
        ///// <param name="model"> Datos del modelo de tnivel</param>
        ///// <returns> Resultado de la transacción </returns>
        public Jresult UpdTnivel(Tetnias model)
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
                var tnivel = db.Tetnias.Find(id);
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
                var entity = db.Tetnias.SingleOrDefault(b => b.Id == id);
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
