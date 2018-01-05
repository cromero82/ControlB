using Kendo.Mvc.UI;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Services.BL;
using Model.General;
using Model.BL;
using ControlB.Areas.ADMIN.Models;

namespace ControlB.Areas.ADMIN.Controllers
{
    public class InstitucionesController : Controller
    {
        // GET: ADMIN/Institucioness
        [Authorize(Roles = "Admin")]
        public ActionResult AdminInstituciones()
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
        public ActionResult GetListInstituciones([DataSourceRequest]DataSourceRequest request)
        {
            var institucionesBL = new InstitucionesBL();
            var jresult = institucionesBL.GetListInstituciones();
            if (jresult.Success == false)
            {
                ModelState.AddModelError("Error", "Error consultando establecimientos: " + jresult.Message);
                return Json(Enumerable.Empty<object>().ToDataSourceResult(request, ModelState));
            }

            //return Json(((IQueryable<InstitucionesGridVM>)jresult.Result).ToDataSourceResult(request));
            //return Json(new DataSourceResult { Data = jresult.Result });            
            return Json(new DataSourceResult { Data = jresult.Result, Total = jresult.Result.Count });
        }

        /// <summary>
        /// Vista de registro de establecimiento
        /// </summary>
        /// <returns> Vista </returns>
        [Authorize(Roles = "Admin")]
        public ActionResult InsInstitucion()
        {
            return PartialView(new GenInstituciones());
        }

        /// <summary>
        /// Inserta establecimiento   
        /// </summary>  
        /// <param name="model">Instituciones model</param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult InsInstitucion(
            [Bind(Include = " Nombre, Direccion, Telefono,Correo, FechaFundacion, Rector, CodigoDane")]GenInstituciones model)
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

            var entityBL = new InstitucionesBL();
            jresult = entityBL.InsInstitucion(model);

            // Salida success
            return Json(jresult);
        }

        /// <summary>
        /// Vista para actualizar datos básicos del establecimiento
        /// </summary>
        /// <param name="id"> id del establecimiento</param>
        /// <returns>Vista con datos del establecimiento</returns>
        [Authorize(Roles = "Admin")]
        public ActionResult UpdInstitucion(long id)
        {
            // Acceso a la capa de negocio
            var entityBL = new InstitucionesBL();
            var jresult = entityBL.GetInstitucion(id);

            if (jresult.Success == false)
            {
                ModelState.AddModelError("Error", "Error consultando institución: " + jresult.Message);
                return PartialView(new GenInstituciones());
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
        public ActionResult UpdInstitucion(
            [Bind(Include = " Id, Nombre, Direccion, Telefono,Correo, FechaFundacion, Rector, CodigoDane")]GenInstituciones model)
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

            var entityBL = new InstitucionesBL();
            jresult = entityBL.UpdInstitucion(model);

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
        public ActionResult DelInstitucion(int id)
        {
            // Inicializaciones
            var jresult = new Jresult();

            // Acceso a la capa de negocio            
            var entityBL = new InstitucionesBL();
            jresult = entityBL.DelInstitucion(id);

            // Salida           
            return Json(jresult);

        }
    }
}