using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Model.BL;
using Model.General;
using Services.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlB.Areas.ADMIN.Controllers
{
    public class TgradosController : Controller
    {
        // GET: ADMIN/Tgrados
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
        public ActionResult GetListTgrados([DataSourceRequest]DataSourceRequest request)
        {
            var institucionesBL = new TgradosBL();
            var jresult = institucionesBL.GetListTgrados();
            if (jresult.Success == false)
            {
                ModelState.AddModelError("Error", "Error consultando grados: " + jresult.Message);
                return Json(Enumerable.Empty<object>().ToDataSourceResult(request, ModelState));
            }
            return Json(new DataSourceResult { Data = jresult.Result.Data, Total = jresult.Result.Count });
        }

        /// <summary>
        /// Vista de registro de establecimiento
        /// </summary>
        /// <returns> Vista </returns>
        [Authorize(Roles = "Admin")]
        public ActionResult InsTgrado()
        {
            return PartialView(new Tgrados());
        }

        /// <summary>
        /// Inserta establecimiento   
        /// </summary>  
        /// <param name="model">Instituciones model</param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult InsTgrado(
           [Bind(Include = "NivelId, Codigo, Nombre, Numero, Estado")]Tgrados model)
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
            var entityBL = new TgradosBL();
            jresult = entityBL.InsTgrado(model);

            // Salida success
            return Json(jresult);
        }

        /// <summary>
        /// Vista para actualizar datos básicos del establecimiento
        /// </summary>
        /// <param name="id"> id del establecimiento</param>
        /// <returns>Vista con datos del establecimiento</returns>
        [Authorize(Roles = "Admin")]
        public ActionResult UpdTgrado(long id)
        {
            // Acceso a la capa de negocio
            var entityBL = new TgradosBL();
            var jresult = entityBL.GetTgrado(id);

            if (jresult.Success == false)
            {
                ModelState.AddModelError("Error", "Error consultando institución: " + jresult.Message);
                return PartialView(new Tgrados());
            }

            // Retorna vista parcial con model         
            return PartialView(jresult.Result);
        }

        /// <summary>
        /// Actualiza datos básicos del establecimiento
        /// </summary>
        /// <param name="model"></param>
        /// <returns> Resultado de la transacción </returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        //public ActionResult UpdConductor(Conductores model)
        public ActionResult UpdTgrado(
            [Bind(Include = "Id,  NivelId, Codigo, Nombre, Numero, Estado")]Tgrados model)
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

            var entityBL = new TgradosBL();
            jresult = entityBL.UpdTgrado(model);

            // Salida success
            jresult.Success = true;
            return Json(jresult);
        }

        /// <summary>
        /// Elimina establecimiento
        /// </summary>
        /// <param name="model"></param>
        /// <returns> Resultado de la transacción </returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DelTgrado(int id)
        {
            // Inicializaciones
            var jresult = new Jresult();

            // Acceso a la capa de negocio            
            var entityBL = new TgradosBL();
            jresult = entityBL.DelTgrado(id);

            // Salida           
            return Json(jresult);

        }
    }
}