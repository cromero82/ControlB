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
using System.Web;
using System.Web.Mvc;
#endregion

namespace ControlB.Areas.ADMIN.Controllers
{
    public class TetniasController : UtilController
    {
        #region Definiciones generales
        Jresult jresult = new Jresult();
        TetniasBL etniasBL = new TetniasBL();
        JsonResult json;
        // GET: ADMIN/Tetnias
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
            var jresult = etniasBL.GetListTetnias(request);
            return EvaluarResultadoListaGenerico(jresult, request, "Error consultando establecimientos: ");
        }

        /// <summary>
        /// Vista de registro de establecimiento
        /// </summary>
        /// <returns> Vista </returns>
        [Authorize(Roles = "Admin")]
        public ActionResult TetniaView(int? id, string accionCrud)
        {
            // Aqui continuar !!!!!!!!!!!!!!
            ViewBag.Accion = accionCrud;
            return PartialView("TetniaView", new Tetnias());
        }

        /// <summary>
        /// Inserta establecimiento   
        /// </summary>  
        /// <param name="model">Instituciones model</param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult InsTetnia(
           [Bind(Include = "NivelId, Codigo, Nombre, Numero, Estado")]Tetnias model)
        {
            // Inicializaciones
            var jresult = new Jresult();

            // Validaciones
            if (!ModelState.IsValid)
            {
                jresult.Message = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                return Json(jresult);
            }

            // Acceso a la capa de negocio
            var entityBL = new TetniasBL();
            jresult = entityBL.InsTetnia(model);

            // Salida success
            return Json(jresult);
        }
    }
}