using Kendo.Mvc.Extensions;
using Model;
using Model.General;
using System;
using System.Data.Entity;
using System.Linq;

namespace Services.BL
{
    public class AcaMatriculaBL : ClaseBL
    {
        // Contexto de base de datos (EF)
        private ControlcBDEntities db = new ControlcBDEntities();
        Jresult jresult = new Jresult();
        private string entidad = "Persona";

        public Jresult GetList(Kendo.Mvc.UI.DataSourceRequest filtrosComponenteKendo)
        {
            try
            {
                var queryable = db.AcaMatricula.Where(f => f.Estregistro == 1).Select(r => new AcaMatriculaVM
                {
                    Id = r.Id,
                    Grado = r.Grado.Nombre,
                    PrimerNombreEstudiante = r.Estudiante.Persona.PrimerNombre,
                    SegundoNombreEstudiante = r.Estudiante.Persona.SegundoNombre,
                    PrimerApellidoEstudiante = r.Estudiante.Persona.PrimerApellido,
                    SegundoApellidoEstudiante = r.Estudiante.Persona.SegundoApellido,
                    Fecha = r.Fecha,
                    Observaciones = r.Observaciones                    
                });

                #region Aplicacion Filtro kendo
                return AplicadorFiltrosKendo(jresult, filtrosComponenteKendo, queryable);
                #endregion
            }
            #region Manejador Excepcion
            catch (Exception ex) { return ManejadorExcepciones(ex, jresult, entidad); }
            #endregion
        }


        /// <summary>
        /// Inserta AcaMatricula
        /// </summary>
        /// <param name="model"> Modelo  AcaMatricula</param>
        /// <returns> Resultado de la transacción </returns>
        public Jresult Insert(AcaMatriculaVM model)
        {
            try
            {
                AcaMatricula dbItem = GetItemBd(model);
                db.AcaMatricula.Add(dbItem);
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
        /// Actualiza  AcaMatricula
        /// </summary>
        /// <param name="model"> Modelo de tetnia</param>
        /// <returns> Resultado de la transacción </returns>
        public Jresult Update(AcaMatriculaVM modelVM)
        {
            try
            {
                var modelBd = GetItemBd(modelVM);
                db.AcaMatricula.Attach(modelBd);
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
                // Consulta persona
                var entity = db.AcaMatricula.Find(id);
                var itemModel = GetItemModel(entity);
                
                // Consulta depto del municipio de la persona
                var listasBl = new TlistasBL();
                //var resultGetDepartamentoByMunicipio = listasBl.GetDepartamentoByMunicipio(entity.);
                //if (resultGetDepartamentoByMunicipio.Success)
                //{
                //    itemModel.TdepartamentoId = resultGetDepartamentoByMunicipio.Data;
                //    jresult.Data = itemModel;
                //    jresult.SetOk("");
                //    return jresult;
                //}
                return jresult;
            }
            #region Excepcion y salida
            catch (Exception ex)
            {
                return ManejadorExcepciones(ex, jresult, entidad);                
            }            
            #endregion

        }

        /// <summary>
        /// Elimina AcaMatricula
        /// </summary>
        /// <param name="id">id AcaMatricula</param>
        /// <returns> Resultado de la transacción </returns>
        public Jresult Delete(int id)
        {
            try
            {
                var entity = db.AcaMatricula.SingleOrDefault(b => b.Id == id);
                entity.Estregistro = 0;
                db.AcaMatricula.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
                jresult.SetOk("Eliminación de " + entidad + " ha tenido una ejecución satisfactoria");
                return jresult;
            }
            #region Excepcion y salida
            catch (Exception ex)
            {
                return ManejadorExcepciones(ex, jresult, entidad);
            }
            #endregion

        }

        public AcaMatricula GetItemBd(AcaMatriculaVM model)
        {
            var itemBD = new AcaMatricula
            {
                Id = model.Id,
                ContextoId = model.ContextoId,
                EstadoMatriculaId = model.EstadoMatriculaId,
                EstudianteId = model.EstudianteId,
                Fecha = model.Fecha,
                GradoId = model.GradoId,
                Observaciones = model.Observaciones,
                PersonaFamiliarId = model.PersonaFamiliarId,
                Estregistro = 1
            };
            if (model.Id > 0)
            {
                itemBD.Id = model.Id;
            }
            return itemBD;
        }

        public AcaMatriculaVM GetItemModel(AcaMatricula modelBd)
        {
            return new AcaMatriculaVM
            {
                Id = modelBd.Id,
                ContextoId = modelBd.ContextoId,
                EstadoMatriculaId = modelBd.EstadoMatriculaId,
                EstudianteId = modelBd.EstudianteId,
                Fecha = modelBd.Fecha,
                GradoId = modelBd.GradoId,
                Observaciones = modelBd.Observaciones,
                PersonaFamiliarId = modelBd.PersonaFamiliarId,
                Estregistro = 1
            };
        }
    }
}
