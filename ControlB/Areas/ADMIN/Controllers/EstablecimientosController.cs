using Kendo.Mvc.UI;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Services.BL;

namespace ControlB.Areas.ADMIN.Controllers
{
    public class EstablecimientosController : Controller
    {
        // GET: ADMIN/Establecimientos
        public ActionResult AdminEstablecimientos()
        {
            return View();
        }
       
        /// <summary>
        /// Obtiene una lista de establecimientos para presentarla en un grid
        /// </summary>
        /// <param name="request"> Filtros en cliente </param>
        /// <returns>lista de datos</returns>
        [HttpPost]
        [Authorize]
        public ActionResult GetListEstablecimientos([DataSourceRequest]DataSourceRequest request)
        {
            var institucionesBL = new InstitucionesBL();
            var jresult = institucionesBL.GetListInstituciones();
            if (jresult.Success == false)
            {
                ModelState.AddModelError("Error", "Error consultando establecimientos: " + jresult.Message);
                return Json(Enumerable.Empty<object>().ToDataSourceResult(request, ModelState));
            }
            //return Json(jresult.Result.ToDataSourceResult(request));
            return Json(new DataSourceResult { Data = jresult.Result, Total = jresult.Result.Count });
        }
    }
}