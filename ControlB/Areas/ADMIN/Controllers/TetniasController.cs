using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Model.General;
using Services.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlB.Areas.ADMIN.Controllers
{
    public class TetniasController : Controller
    {
        Jresult jresult = new Jresult();
        TetniasBL etniasBL = new TetniasBL();
        JsonResult json;
        // GET: ADMIN/Tetnias
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
        public ActionResult GetList([DataSourceRequest]DataSourceRequest request)
        {
            var result = etniasBL.GetListTetnias(request);            
            json = Json(result);
            json.MaxJsonLength = Int32.MaxValue;
            return json;
        }
    }
}