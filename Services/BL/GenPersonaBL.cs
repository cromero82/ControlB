using Kendo.Mvc.Extensions;
using Model;
using Model.BL;
using Model.General;
using Services.BL;
using System;
using System.Data.Entity;
using System.Linq;

namespace Services.BL
{
    public class GenPersonaBL: ClaseBL
    {
        // Contexto de base de datos (EF)
        private ControlcBDEntities db = new ControlcBDEntities();
        Jresult jresult = new Jresult();
        private string entidad = "Persona";

        public Jresult GetList(Kendo.Mvc.UI.DataSourceRequest filtrosComponenteKendo)
        {
            try
            {
                var queryable = db.GenPersona.Where(f => f.Estregistro == 1).Select(r => new GenPersonaVM
                {
                    Id = r.Id,
                    TdocumentoId = r.TdocumentoId,
                    Tdocumento = r.Tdocumentos.Nombre,
                    NumDoc = r.NumDoc,
                    PrimerNombre = r.PrimerNombre,
                    SegundoNombre = r.SegundoNombre,
                    PrimerApellido = r.PrimerApellido,
                    SegundoApellido = r.SegundoApellido,
                    FechaNacimiento = r.FechaNacimiento,
                    Direccion = r.Direccion,
                    Telefono = r.Telefono,
                    TmunicipioId = r.TmunicipioId,
                    Tmunicipio = r.Tmunicipios.Nombre,
                    Tdepartamento = r.Tmunicipios.Tdepartamentos.Nombre,
                    CorreoElectronico = r.CorreoElectronico,
                    Telefono2 = r.Telefono2,
                    ModoRegistro = r.ModoRegistro
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
        /// Inserta GenPersona
        /// </summary>
        /// <param name="model"> Modelo  GenPersona</param>
        /// <returns> Resultado de la transacción </returns>
        public Jresult Insert(GenPersonaVM model)
        {
           try
            {
                GenPersona dbItem = GetItemBd(model);
                db.GenPersona.Add(dbItem);
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
        /// Actualiza  GenPersona
        /// </summary>
        /// <param name="model"> Modelo de tetnia</param>
        /// <returns> Resultado de la transacción </returns>
        public Jresult Update(GenPersonaVM modelVM)
        {
            try
            {
                var modelBd = GetItemBd(modelVM);
                db.GenPersona.Attach(modelBd);
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
                var entity = db.GenPersona.Find(id);
                jresult.Data = GetItemModel(entity);

                // Consulta depto del municipio de la persona
                if (jresult.Success)
                {                    
                    var listasBl = new TlistasBL();
                    var resultConsultaDept = listasBl.GetDepartamentoByMunicipio(entity.TmunicipioId);
                    jresult.Success = resultConsultaDept.Success;
                }               
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
        /// Elimina GenPersona
        /// </summary>
        /// <param name="id">id GenPersona</param>
        /// <returns> Resultado de la transacción </returns>
        public Jresult Delete(int id)
        {
            try
            {                
                var entity = db.GenPersona.SingleOrDefault(b => b.Id == id);
                entity.Estregistro = 0;                
                db.GenPersona.Attach(entity);
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

        public GenPersona GetItemBd(GenPersonaVM model)
        {
            var itemBD = new GenPersona
            {
                TdocumentoId = model.TdocumentoId,
                NumDoc = model.NumDoc,
                PrimerNombre =  model.PrimerNombre,
                SegundoNombre = model.SegundoNombre,
                PrimerApellido = model.PrimerApellido,
                SegundoApellido = model.SegundoApellido,
                FechaNacimiento = model.FechaNacimiento,
                Direccion = model.Direccion,
                Telefono = model.Telefono,
                TmunicipioId = model.TmunicipioId,
                CorreoElectronico = model.CorreoElectronico,
                Telefono2 = model.Telefono2,
                ModoRegistro = model.ModoRegistro,
                Estregistro = 1
            };
            if (model.Id > 0)
            {
                itemBD.Id = model.Id;
            }
            return itemBD;
        }

        public GenPersonaVM GetItemModel(GenPersona modelBd)
        {
            return new GenPersonaVM
            {
                TdocumentoId = modelBd.TdocumentoId,
                NumDoc = modelBd.NumDoc,
                PrimerNombre = modelBd.PrimerNombre,
                SegundoNombre = modelBd.SegundoNombre,
                PrimerApellido = modelBd.PrimerApellido,
                SegundoApellido = modelBd.SegundoApellido,
                FechaNacimiento = modelBd.FechaNacimiento,
                Direccion = modelBd.Direccion,
                Telefono = modelBd.Telefono,
                TmunicipioId = modelBd.TmunicipioId,
                CorreoElectronico = modelBd.CorreoElectronico,
                Telefono2 = modelBd.Telefono2,
                ModoRegistro = modelBd.ModoRegistro
            };
        }
    }
}
