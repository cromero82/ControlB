using Kendo.Mvc.Extensions;
using Model.BL.Tipos;
using Model.General;
using Persistence;
using Services.BL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kendo.Mvc.UI;
using Model.BL;
using Model;

namespace Services.BL
{
    public class TetniaBL: ClaseBL
    {
        // Contexto de base de datos (EF)
        private ControlcBDEntities db = new ControlcBDEntities();
        Jresult jresult = new Jresult();
        private string entidad = "Etnia";

        public Jresult GetList(Kendo.Mvc.UI.DataSourceRequest filtrosComponenteKendo)
        {
            try
            {
                var queryable = db.Tetnias.Where(f => f.Estado == 1).Select(r => new TetniaVM
                {
                    Id = r.Id,
                    Nombre = r.Nombre,
                    Numero = r.Numero,
                    Estado = r.Estado
                });

                #region Aplicacion Filtro kendo
                return AplicadorFiltrosKendo(jresult, filtrosComponenteKendo, queryable);
                #endregion
            }
            #region Manejador Excepcion
            catch (Exception ex) { return ManejadorExcepciones(ex, jresult); }
            #endregion
        }


        /// <summary>
        /// Inserta Tetnia
        /// </summary>
        /// <param name="model"> Modelo  Tetnia</param>
        /// <returns> Resultado de la transacción </returns>
        public Jresult Insert(TetniaVM model)
        {
           try
            {
                Tetnias dbItem = GetItemBd(model);
                db.Tetnias.Add(dbItem);
                db.Entry(dbItem).State = EntityState.Added;
                db.SaveChanges();
                jresult.SetOk("Creación de " + entidad + " ha tenido una ejecución satisfactoria");
            }
            #region Excepcion y salida
            catch (Exception ex)
            {
                jresult.SetError("Modificación de " + entidad + " finalizada con errores ");
            }
            return jresult;
            #endregion
        }

        /// <summary>
        /// Actualiza  Tetnia
        /// </summary>
        /// <param name="model"> Modelo de tetnia</param>
        /// <returns> Resultado de la transacción </returns>
        public Jresult Update(TetniaVM modelVM)
        {
            try
            {
                var modelBd = GetItemBd(modelVM);
                db.Tetnias.Attach(modelBd);
                db.Entry(modelBd).State = EntityState.Modified;
                db.SaveChanges();
                jresult.SetOk("Modificación de " + entidad + " ha tenido una ejecución satisfactoria");
            }
            #region Excepcion y salida
            catch (Exception ex)
            {
                jresult.SetError("Modificación de " + entidad + " finalizada con errores ");
            }
            return jresult;
            #endregion
        }
       
        /// <summary>
        /// Obtiene un tetnia
        /// </summary>
        /// <param name="id">id del tetnia </param>
        /// <returns> Resultado de la transaccion </returns>
        public Jresult Get(long id)
        {
            try
            {
                var entity = db.Tetnias.Find(id);
                jresult.Data = GetItemModel(entity);
                jresult.Success = true;;
            }
            #region Excepcion y salida
            catch (Exception ex)
            {
                jresult.SetError("Error consultando " + entidad);
            }
            return jresult;
            #endregion

        }

        /// <summary>
        /// Elimina Tetnia
        /// </summary>
        /// <param name="id">id Tetnia</param>
        /// <returns> Resultado de la transacción </returns>
        public Jresult Delete(int id)
        {
            try
            {                
                var entity = db.Tetnias.SingleOrDefault(b => b.Id == id);
                entity.Estado = 0;                
                db.Tetnias.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
                jresult.SetOk("Eliminación de " + entidad + " ha tenido una ejecución satisfactoria");

            }
            #region Excepcion y salida
            catch (Exception ex)
            {
                jresult.SetError("Error eliminando " + entidad );
            }
            return jresult;
            #endregion

        }

        public Tetnias GetItemBd(TetniaVM model)
        {
            var itemBD = new Tetnias
            {
                Nombre = model.Nombre,
                Numero = model.Numero,
                Estado =  model.Estado              
            };
            if (model.Id > 0)
            {
                itemBD.Id = model.Id;
            }
            return itemBD;
        }

        public TetniaVM GetItemModel(Tetnias modelBd)
        {
            return new TetniaVM
            {
                Nombre = modelBd.Nombre,
                Numero = modelBd.Numero,
                Estado = modelBd.Estado,
                Id = modelBd.Id
            };
        }
    }
}
