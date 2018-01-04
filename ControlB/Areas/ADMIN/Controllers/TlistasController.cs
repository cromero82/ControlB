using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Services.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlB.Areas.ADMIN.Controllers
{
    public class TlistasController : Controller
    {
        // GET: ADMIN/Tlistas
        //public ActionResult Index()
        //{
        //    return View();
        //}

        /// <summary>
        /// Obtiene una lista de caracteristicas (agrupador de instituciones educativas) para presentarla en un grid
        /// </summary>
        /// <param name="request"> Filtros en cliente </param>
        /// <returns>lista de datos</returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult GetListTcaracteristicas([DataSourceRequest]DataSourceRequest request)
        {
            var listaBl = new TlistasBL();
            var jresult = listaBl.GetListTcaracteristicas();
            if (jresult.Success == false)
            {
                ModelState.AddModelError("Error", "Error consultando datos: " + jresult.Message);
                return Json(Enumerable.Empty<object>().ToDataSourceResult(request, ModelState));
            }
            return Json(new DataSourceResult { Data = jresult.Result, Total = jresult.Result.Count });
        }

        /// <summary>
        /// Obtiene una lista de especialidades (del nivel academico) para presentarla en un grid
        /// </summary>
        /// <param name="request"> Filtros en cliente </param>
        /// <returns>lista de datos</returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult GetListTespecialidades([DataSourceRequest]DataSourceRequest request)
        {
            var listaBl = new TlistasBL();
            var jresult = listaBl.GetListTespecialidades();
            if (jresult.Success == false)
            {
                ModelState.AddModelError("Error", "Error consultando datos: " + jresult.Message);
                return Json(Enumerable.Empty<object>().ToDataSourceResult(request, ModelState));
            }
            return Json(new DataSourceResult { Data = jresult.Result, Total = jresult.Result.Count });
        }
    }
}