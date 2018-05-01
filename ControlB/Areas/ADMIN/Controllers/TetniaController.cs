#region include
using ControlB.Utilidades;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Model.BL.Tipos;
using Model.General;
using Services.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
#endregion

namespace ControlB.Areas.ADMIN.Controllers
{
    public class TetniaController : UtilController
    {
                
        TetniaBL entityBL = new TetniaBL();
        String EntityName = "Etnia";
        Object ModelEmpy = new TetniaVM();

        /// <summary>
        /// Obtiene una lista de Tetnia para presentarla en un grid
        /// </summary>
        /// <param name="request"> Filtros kendoGrid en cliente </param>
        /// <returns>lista de datos</returns>
        [HttpPost]
        [Authorize]
        public ActionResult GetList([DataSourceRequest]DataSourceRequest request)
        {           
            var institucionesBL = new TnivelesBL();
            var jresult = entityBL.GetList(request);
            return EvaluarResultadoListaGenerico(jresult, request, "Error consultando establecimientos: ");
        }

        /// <summary>
        /// Vista de edición (Crear y Editar)
        /// </summary>
        /// <param name="id"> id de registro</param>
        /// <param name="accionCrud"> acción que se va a realizar en la vista: Crear o Editar</param>
        /// <returns>Vista</returns>
        [Authorize]
        public ActionResult TetniaView(long? id, string accionCrud)
        {
            ViewBag.Accion = accionCrud;            
            if (accionCrud== "Insertar")
            {
                return PartialView("TetniaView",  ModelEmpy);
            }else
            {
                #region Resolucion vista Editar
                // En caso de accion 'Editar', se accede a la capa de negocio               
                var jresult = entityBL.Get((long)id);

                if (jresult.Success == false)
                {
                    ModelState.AddModelError("Error", "Error consultando: " + EntityName + " " + jresult.Message);
                    return PartialView(ModelEmpy);
                }

                // Retorna vista parcial con model         
                return PartialView(jresult.Data);
                #endregion                
            }                        
        }

        /// <summary>
        /// Inserta Tetnia   
        /// </summary>  
        /// <param name="model">Instituciones model</param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult InsTetnia(TetniaVM model)
        {
            // Validaciones
            if (!ModelState.IsValid)
            {
                ViewBag.Accion = GetMethodCrudName(MethodInfo.GetCurrentMethod().Name);
                return PartialView("TetniaView", model);
            }

            // Acceso a la capa de negocio y result
            return Json(entityBL.Insert(model));
        }

        public ActionResult UpdTetnia(TetniaVM model)
        {
            // Validaciones
            if (!ModelState.IsValid) {
                ViewBag.Accion = GetMethodCrudName(MethodInfo.GetCurrentMethod().Name);
                return PartialView("TetniaView",model);
            }

            // Acceso a la capa de negocio y result
            return Json(entityBL.Update(model));            
        }

        /// <summary>
        /// Elimina Tetnia
        /// </summary>
        /// <param name="model"></param>
        /// <returns> Resultado de la transacción </returns>
        [HttpPost]
        [Authorize]
        public ActionResult DelTetnia(int id)
        {
            // Acceso a la capa de negocio y result
            return Json(entityBL.Delete(id));
        }
    }
}