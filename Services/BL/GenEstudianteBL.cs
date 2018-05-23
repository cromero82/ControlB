using Kendo.Mvc.Extensions;
using Model;
using Model.General;
using System;
using System.Data.Entity;
using System.Linq;

namespace Services.BL
{
    public class GenEstudianteBL : ClaseBL
    {
        // Contexto de base de datos (EF)
        private ControlcBDEntities db = new ControlcBDEntities();
        Jresult jresult = new Jresult();
        private string entidad = "Estudiante";

        public Jresult GetList(Kendo.Mvc.UI.DataSourceRequest filtrosComponenteKendo)
        {
            try
            {
                var queryable = db.GenEstudiante.Where(f => f.Estregistro == 1).Select(r => new GenEstudianteVM
                {
                    Id = r.Id,
                    Codigo = r.Codigo,
                    CapacidadExcepcional = r.CapacidadExcepcional.Nombre,
                    Discapacidad = r.Discapacidad.Nombre,
                    
                    NumDoc = r.Persona.NumDoc,
                    PrimerNombre = r.Persona.PrimerNombre,
                    SegundoNombre = r.Persona.SegundoNombre,
                    PrimerApellido = r.Persona.PrimerApellido,
                    SegundoApellido = r.Persona.SegundoApellido,
                    FechaNacimiento = r.Persona.FechaNacimiento,
                    
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
        /// Inserta GenEstudiante
        /// </summary>
        /// <param name="model"> Modelo  GenEstudiante</param>
        /// <returns> Resultado de la transacción </returns>
        public Jresult Insert(GenEstudianteVM model)
        {
            try
            {
                GenEstudiante dbItem = GetItemBd(model);
                db.GenEstudiante.Add(dbItem);
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
        /// Actualiza  GenEstudiante
        /// </summary>
        /// <param name="model"> Modelo de tetnia</param>
        /// <returns> Resultado de la transacción </returns>
        public Jresult Update(GenEstudianteVM modelVM)
        {
            try
            {
                var modelBd = GetItemBd(modelVM);
                db.GenEstudiante.Attach(modelBd);
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
                var entity = db.GenEstudiante.Find(id);
                var itemModel = GetItemModel(entity);
                
                // Consulta depto del municipio de la persona
                var listasBl = new TlistasBL();                
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
        /// Elimina GenEstudiante
        /// </summary>
        /// <param name="id">id GenEstudiante</param>
        /// <returns> Resultado de la transacción </returns>
        public Jresult Delete(int id)
        {
            try
            {
                var entity = db.GenEstudiante.SingleOrDefault(b => b.Id == id);
                entity.Estregistro = 0;
                db.GenEstudiante.Attach(entity);
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

        public GenEstudiante GetItemBd(GenEstudianteVM model)
        {
            var itemBD = new GenEstudiante
            {
                Id = model.Id,
                Codigo = model.Codigo,
                CapacidadExcepcionalId = model.CapacidadExcepcionalId,
                DiscapacidadId = model.DiscapacidadId,
                PersonaId = model.PersonaId,
                Estregistro = 1
            };
            if (model.Id > 0)
            {
                itemBD.Id = model.Id;
            }
            return itemBD;
        }

        public GenEstudianteVM GetItemModel(GenEstudiante modelBd)
        {
            return new GenEstudianteVM
            {
                Id = modelBd.Id,
                Codigo = modelBd.Codigo,
                CapacidadExcepcional = modelBd.CapacidadExcepcional.Nombre,
                Discapacidad = modelBd.Discapacidad.Nombre,
                NumDoc = modelBd.Persona.NumDoc,
                PrimerNombre = modelBd.Persona.PrimerNombre,
                SegundoNombre = modelBd.Persona.SegundoNombre,
                PrimerApellido = modelBd.Persona.PrimerApellido,
                SegundoApellido = modelBd.Persona.SegundoApellido,
                FechaNacimiento = modelBd.Persona.FechaNacimiento,
                Estregistro = 1
            };
        }
    }
}
