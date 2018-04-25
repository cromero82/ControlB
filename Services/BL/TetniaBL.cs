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

namespace Services.BL
{
    public class TetniaBL: ClaseBL
    {
        // Contexto de base de datos (EF)
        private ApplicationDbContext db = new ApplicationDbContext();
        Jresult jresult = new Jresult();
        private string entidad = "Etnia";

        /// <summary>
        /// Inserta tetnia
        /// </summary>
        /// <param name="model"> Modelo de tetnia</param>
        /// <returns> Resultado de la transacción </returns>
        public Jresult Insert(TetniaVM model)
        {
           try
            {
                Tetnia dbItem = GetItemBd(model);
                db.Tetnia.Add(dbItem);
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
        /// Actualiza  tetnia
        /// </summary>
        /// <param name="model"> Modelo de tetnia</param>
        /// <returns> Resultado de la transacción </returns>
        public Jresult Update(TetniaVM modelVM)
        {
            try
            {
                var modelBd = GetItemBd(modelVM);
                db.Tetnia.Attach(modelBd);
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

        public Jresult GetList(Kendo.Mvc.UI.DataSourceRequest filtrosComponenteKendo)
        {
            try
            {
                var queryable = db.Tetnia.Where(f => f.Estado == 1).Select(r => new TetniaVM
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
        /// Obtiene un tetnia
        /// </summary>
        /// <param name="id">id del tetnia </param>
        /// <returns> Resultado de la transaccion </returns>
        public Jresult GetTetnia(long id)
        {
            var jresult = new Jresult();
            try
            {
                var tetnia = db.Tetnia.Find(id);
                jresult.Data = GetItemModel(tetnia);
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
        /// Elimina tetnia
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Resultado de la transacción </returns>
        public Jresult Delete(int id)
        {
            var jresult = new Jresult();
            try
            {
                //var entity = db.Tetnia.SingleOrDefault(b => b.Id == id);
                //if (entity != null)
                //{
                //    entity.Estado = 0;
                //    db.SaveChanges();
                //}
                var entity = db.Tetnia.SingleOrDefault(b => b.Id == id);
                entity.Estado = 0;
                //var modelBd = GetItemBd(modelVM);
                db.Tetnia.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
                jresult.SetOk("Modificación de " + entidad + " ha tenido una ejecución satisfactoria");

            }
            catch (Exception ex)
            {
                jresult.Message = "Error eliminando registro: " + ex.Message;
            }
            return jresult;

        }

        public Tetnia GetItemBd(TetniaVM model)
        {
            var itemBD = new Tetnia
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

        public TetniaVM GetItemModel(Tetnia modelBd)
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
