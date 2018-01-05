using ControlB.Areas.ADMIN.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Model.Auxiliar;
using Model.General;
using Newtonsoft.Json;
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
        //GET: ADMIN/Tlistas
        public ActionResult Index()
        {
            return View();
        }

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
        [Authorize]
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

        /// <summary>
        /// Obtiene una lista de caracteristicas (agrupador de instituciones educativas) para presentarla en un grid
        /// </summary>
        /// <param name="request"> Filtros en cliente </param>
        /// <returns>lista de datos</returns>
        [HttpPost]
        [Authorize]
        public ActionResult GetListTdepartamentos([DataSourceRequest]DataSourceRequest request)
        {
            var listaBl = new TlistasBL();
            var jresult = listaBl.GetListDepartamentos();
            if (jresult.Success == false)
            {
                ModelState.AddModelError("Error", "Error consultando datos: " + jresult.Message);
                return Json(Enumerable.Empty<object>().ToDataSourceResult(request, ModelState));
            }
            return Json(new DataSourceResult { Data = jresult.Result, Total = jresult.Result.Count });
        }

        /// <summary>
        /// Inserta departamentos al sistema
        /// </summary>  
        /// <param name="model">Lista de departamentos en formato Json (los cuales provienen seguramente del sitio www.datos.gov.co</param>
        /// <returns>Resultado de la operacion</returns>
        //[ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult InsDepartamentos( DatosAbiertosImport model)
        {
            // Inicializaciones
            var jresult = new Jresult();

            // Des-serializo el json de departamentos
            model.DepartamentosList = JsonConvert.DeserializeObject<List<DatosAbiertosDepartamentos>>(model.DatosStringJson);
                       

            // Validaciones
            if (!ModelState.IsValid)
            {
                jresult.Message = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                return Json(jresult);
            }

            // Acceso a la capa de negocio

            var entityBL = new TlistasBL();
            jresult = entityBL.InsDepartamentos(model);

            // Salida success
            return Json(jresult);
        }

        /// <summary>
        /// Inserta departamentos al sistema
        /// </summary>  
        /// <param name="model">Lista de departamentos en formato Json (los cuales provienen seguramente del sitio www.datos.gov.co</param>
        /// <returns>Resultado de la operacion</returns>
        //[ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult InsListaMunicipios(DatosAbiertosImport model)
        {
            // Inicializaciones
            var jresult = new Jresult();

            // Des-serializo el json de departamentos
            model.MunicipiosList = JsonConvert.DeserializeObject<List<DatosAbiertosMunicipios>>(model.DatosStringJson);


            // Validaciones
            if (!ModelState.IsValid)
            {
                jresult.Message = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                return Json(jresult);
            }

            // Acceso a la capa de negocio

            var entityBL = new TlistasBL();
            jresult = entityBL.InsListaMunicipios(model);

            // Salida success
            return Json(jresult);
        }

        /// <summary>
        /// Obtiene una lista de caracteristicas (agrupador de instituciones educativas) para presentarla en un grid
        /// </summary>
        /// <param name="request"> Filtros en cliente </param>
        /// <returns>lista de datos</returns>
        [HttpPost]
        [Authorize]
        public ActionResult GetListTmunicipios([DataSourceRequest]DataSourceRequest request)
        {
            var listaBl = new TlistasBL();
            var jresult = listaBl.GetListMunicipios();
            if (jresult.Success == false)
            {
                ModelState.AddModelError("Error", "Error consultando datos: " + jresult.Message);
                return Json(Enumerable.Empty<object>().ToDataSourceResult(request, ModelState));
            }
            return Json(new DataSourceResult { Data = jresult.Result.Data, Total = jresult.Result.Count });
        }

        /// <summary>
        /// Obtiene una lista de paises  para presentarla en un grid
        /// </summary>
        /// <param name="request"> Filtros en cliente </param>
        /// <returns>lista de datos</returns>
        [HttpPost]
        [Authorize]
        public ActionResult GetListTpaises([DataSourceRequest]DataSourceRequest request)
        {
            var listaBl = new TlistasBL();
            var jresult = listaBl.GetListPaises();
            if (jresult.Success == false)
            {
                ModelState.AddModelError("Error", "Error consultando datos: " + jresult.Message);
                return Json(Enumerable.Empty<object>().ToDataSourceResult(request, ModelState));
            }
            return Json(new DataSourceResult { Data = jresult.Result, Total = jresult.Result.Count });
        }

        /// <summary>
        /// Obtiene una lista de metodologías para presentarlas en un grid
        /// </summary>
        /// <param name="request"> Filtros en cliente </param>
        /// <returns>lista de datos</returns>
        [HttpPost]
        [Authorize]
        public ActionResult GetListTmetodologias([DataSourceRequest]DataSourceRequest request)
        {
            var listaBl = new TlistasBL();
            var jresult = listaBl.GetListMetodologias();
            if (jresult.Success == false)
            {
                ModelState.AddModelError("Error", "Error consultando datos: " + jresult.Message);
                return Json(Enumerable.Empty<object>().ToDataSourceResult(request, ModelState));
            }
            return Json(new DataSourceResult { Data = jresult.Result, Total = jresult.Result.Count });
        }

        /// <summary>
        /// Obtiene una lista de tipos de documentos para presentarlas en un grid
        /// </summary>
        /// <param name="request"> Filtros en cliente </param>
        /// <returns>lista de datos</returns>
        [HttpPost]
        [Authorize]
        public ActionResult GetListTdocumentos([DataSourceRequest]DataSourceRequest request)
        {
            var listaBl = new TlistasBL();
            var jresult = listaBl.GetListTiposDocumentos();
            if (jresult.Success == false)
            {
                ModelState.AddModelError("Error", "Error consultando datos: " + jresult.Message);
                return Json(Enumerable.Empty<object>().ToDataSourceResult(request, ModelState));
            }
            return Json(new DataSourceResult { Data = jresult.Result, Total = jresult.Result.Count });
        }

        /// <summary>
        /// Obtiene una lista de estratos sociales para presentarlas en un grid
        /// </summary>
        /// <param name="request"> Filtros en cliente </param>
        /// <returns>lista de datos</returns>
        [HttpPost]
        [Authorize]
        public ActionResult GetListTestratos([DataSourceRequest]DataSourceRequest request)
        {
            var listaBl = new TlistasBL();
            var jresult = listaBl.GetListEstratosSociales();
            if (jresult.Success == false)
            {
                ModelState.AddModelError("Error", "Error consultando datos: " + jresult.Message);
                return Json(Enumerable.Empty<object>().ToDataSourceResult(request, ModelState));
            }
            return Json(new DataSourceResult { Data = jresult.Result, Total = jresult.Result.Count });
        }

        /// <summary>
        /// Obtiene una lista de clasificacion del SISBEN presentarlas en un grid
        /// </summary>
        /// <param name="request"> Filtros en cliente </param>
        /// <returns>lista de datos</returns>
        [HttpPost]
        [Authorize]
        public ActionResult GetListTsisben([DataSourceRequest]DataSourceRequest request)
        {
            var listaBl = new TlistasBL();
            var jresult = listaBl.GetListEstratosSociales();
            if (jresult.Success == false)
            {
                ModelState.AddModelError("Error", "Error consultando datos: " + jresult.Message);
                return Json(Enumerable.Empty<object>().ToDataSourceResult(request, ModelState));
            }
            return Json(new DataSourceResult { Data = jresult.Result, Total = jresult.Result.Count });
        }

    }
}