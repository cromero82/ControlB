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

namespace ControlB.Areas.ADMIN.Controllers
{
    public class TjornadasController : Controller
    {
        // GET: ADMIN/Jornadas
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Obtiene una lista de grados para presentarla en un grid
        /// </summary>
        /// <param name="request"> Filtros en cliente </param>
        /// <returns>lista de datos</returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult GetListTjornadas([DataSourceRequest]DataSourceRequest request)
        {
            var institucionesBL = new TjornadasBL();
            var jresult = institucionesBL.GetListTjornadas();
            if (jresult.Success == false)
            {
                ModelState.AddModelError("Error", "Error consultando grados: " + jresult.Message);
                return Json(Enumerable.Empty<object>().ToDataSourceResult(request, ModelState));
            }
            return Json(new DataSourceResult { Data = jresult.Data, Total = jresult.Data.Count });
        }

        /// <summary>
        /// Vista de registro de establecimiento
        /// </summary>
        /// <returns> Vista </returns>
        [Authorize(Roles = "Admin")]
        public ActionResult InsTjornada()
        {
            return PartialView(new Tjornadas());
        }

        /// <summary>
        /// Inserta establecimiento   
        /// </summary>  
        /// <param name="model">Instituciones model</param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult InsTjornada(
           [Bind(Include = "Nombre, Numero")]Tjornadas model)
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
            var entityBL = new TjornadasBL();
            jresult = entityBL.InsTjornada(model);

            // Salida success
            return Json(jresult);
        }

        /// <summary>
        /// Vista para actualizar datos básicos del establecimiento
        /// </summary>
        /// <param name="id"> id del establecimiento</param>
        /// <returns>Vista con datos del establecimiento</returns>
        [Authorize(Roles = "Admin")]
        public ActionResult UpdTjornada(long id)
        {
            // Acceso a la capa de negocio
            var entityBL = new TjornadasBL();
            var jresult = entityBL.GetTjornada(id);

            if (jresult.Success == false)
            {
                ModelState.AddModelError("Error", "Error consultando institución: " + jresult.Message);
                return PartialView(new Tjornadas());
            }

            // Retorna vista parcial con model         
            return PartialView(jresult.Data);
        }

        /// <summary>
        /// Actualiza datos básicos del establecimiento
        /// </summary>
        /// <param name="model"></param>
        /// <returns> Resultado de la transacción </returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        //public ActionResult UpdConductor(Conductores model)
        public ActionResult UpdTjornada(
            [Bind(Include = "Id,  Nombre, Numero")]Tjornadas model)
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

            var entityBL = new TjornadasBL();
            jresult = entityBL.UpdTjornada(model);

            // Salida success
            jresult.Success = true;;
            return Json(jresult);
        }

        /// <summary>
        /// Elimina establecimiento
        /// </summary>
        /// <param name="model"></param>
        /// <returns> Resultado de la transacción </returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DelTjornada(int id)
        {
            // Inicializaciones
            var jresult = new Jresult();

            // Acceso a la capa de negocio            
            var entityBL = new TjornadasBL();
            jresult = entityBL.DelTjornada(id);

            // Salida           
            return Json(jresult);

        }
    }
}