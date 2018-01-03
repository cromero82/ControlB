using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Model.BL;
using Services.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlB.Areas.ADMIN.Controllers
{
    public class TnivelesController : Controller
    {
        // GET: ADMIN/Tniveles
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Obtiene una lista de establecimientos para presentarla en un grid
        /// </summary>
        /// <param name="request"> Filtros en cliente </param>
        /// <returns>lista de datos</returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult GetListTniveles([DataSourceRequest]DataSourceRequest request)
        {
            var institucionesBL = new TnivelesBL();
            var jresult = institucionesBL.GetListTniveles();
            if (jresult.Success == false)
            {
                ModelState.AddModelError("Error", "Error consultando establecimientos: " + jresult.Message);
                return Json(Enumerable.Empty<object>().ToDataSourceResult(request, ModelState));
            }          
            return Json(new DataSourceResult { Data = jresult.Result, Total = jresult.Result.Count });
        }
    }
}