using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Model.BL.Tipos;
using Model.General;
using Services.BL;
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
            return Json(new DataSourceResult { Data = jresult.Data, Total = jresult.Data.Count });
        }

        /// <summary>
        /// Vista de registro de establecimiento
        /// </summary>
        /// <returns> Vista </returns>
        [Authorize(Roles = "Admin")]
        public ActionResult InsTnivel()
        {
            return PartialView(new Tniveles());
        }

        /// <summary>
        /// Inserta establecimiento   
        /// </summary>  
        /// <param name="model">Instituciones model</param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult InsTnivel(
           [Bind(Include = " Nombre, Codigo, Numero, Estado")]Tniveles model)
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
            var entityBL = new TnivelesBL();
            jresult = entityBL.InsTnivel(model);

            // Salida success
            return Json(jresult);
        }

        /// <summary>
        /// Vista para actualizar datos básicos del establecimiento
        /// </summary>
        /// <param name="id"> id del establecimiento</param>
        /// <returns>Vista con datos del establecimiento</returns>
        [Authorize(Roles = "Admin")]
        public ActionResult UpdTnivel(long id)
        {
            // Acceso a la capa de negocio
            var entityBL = new TnivelesBL();
            var jresult = entityBL.GetTnivel(id);

            if (jresult.Success == false)
            {
                ModelState.AddModelError("Error", "Error consultando institución: " + jresult.Message);
                return PartialView(new Tniveles());
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
        public ActionResult UpdTnivel(
            [Bind(Include = "Id,  Nombre, Codigo, Numero, Estado")]Tniveles model)
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

            var entityBL = new TnivelesBL();
            jresult = entityBL.UpdTnivel(model);

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
        public ActionResult DelTnivel(int id)
        {
            // Inicializaciones
            var jresult = new Jresult();

            // Acceso a la capa de negocio            
            var entityBL = new TnivelesBL();
            jresult = entityBL.DelTnivel(id);

            // Salida           
            return Json(jresult);

        }
    }
}