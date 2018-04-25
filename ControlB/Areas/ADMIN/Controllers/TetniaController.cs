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
        #region Definiciones generales
        Jresult jresult = new Jresult();
        TetniaBL entityBL = new TetniaBL();
        String EntityName = "Etnia";
        JsonResult json;
        // GET: ADMIN/Tetnia
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        /// <summary>
        /// Obtiene una lista de establecimientos para presentarla en un grid
        /// </summary>
        /// <param name="request"> Filtros en cliente </param>
        /// <returns>lista de datos</returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult GetList([DataSourceRequest]DataSourceRequest request)
        {           
            var institucionesBL = new TnivelesBL();
            var jresult = entityBL.GetList(request);
            return EvaluarResultadoListaGenerico(jresult, request, "Error consultando establecimientos: ");
        }

        /// <summary>
        /// Vista de registro de establecimiento
        /// </summary>
        /// <returns> Vista </returns>
        [Authorize(Roles = "Admin")]
        public ActionResult TetniaView(long? id, string accionCrud)
        {
            ViewBag.Accion = accionCrud;            
            if (accionCrud== "Insertar")
            {
                return PartialView("TetniaView", new TetniaVM());
            }else
            {
                // Acceso a la capa de negocio               
                var jresult = entityBL.GetTetnia((long)id);

                if (jresult.Success == false)
                {
                    ModelState.AddModelError("Error", "Error consultando: " + EntityName + " " + jresult.Message);
                    return PartialView(new TetniaVM());
                }

                // Retorna vista parcial con model         
                return PartialView(jresult.Data);
            }
            
            
        }

        /// <summary>
        /// Inserta establecimiento   
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
                jresult.Message = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                return Json(jresult);
            }

            // Acceso a la capa de negocio y result
            jresult = entityBL.Insert( model);

            // Salida success
            return Json(jresult);
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

        public string GetMethodCrudName(string nombreMetodo)
        {
            if (nombreMetodo.ToUpper().Substring(0, 3) == "UPD")
            {
                return "Editar";
            }else
            {
                return "Insertar";
            }
        }

        //public ActionResult DefinitionResult(Jresult jresult, object model)
        //{
        //    if(jresult.Success== true)
        //    {
        //        return Json(jresult);
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("Error",)
        //    }
        //}
    }
}