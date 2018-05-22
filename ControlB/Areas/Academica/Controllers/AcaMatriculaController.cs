using ControlB.Utilidades;
using Kendo.Mvc.UI;
using Model;
using Services.BL;
using System;
using System.Reflection;
using System.Web.Mvc;

namespace ControlB.Areas.Academica.Controllers
{
    public class AcaMatriculaController : UtilController
    {
        AcaMatriculaBL entityBL = new AcaMatriculaBL();
        String EntityName = "Persona";
        Object ModelEmpy = new AcaMatriculaVM();

        /// <summary>
        /// Obtiene una lista de GenMatricula para presentarla en un grid
        /// </summary>
        /// <param name="request"> Filtros kendoGrid en cliente </param>
        /// <returns>lista de datos</returns>
        [HttpPost]
        [Authorize]
        public ActionResult GetList([Kendo.Mvc.UI.DataSourceRequest]DataSourceRequest request)
        {
            var jresult = entityBL.GetList(request);
            return EvaluarResultadoListaGenerico(jresult, request, "Error consultando Personas: ");
        }

        /// <summary>
        /// Vista de edición (Crear y Editar) GenMatricula
        /// </summary>
        /// <param name="id"> id de registro</param>
        /// <param name="accionCrud"> acción que se va a realizar en la vista: Crear o Editar</param>
        /// <returns>Vista para accion crear o editar</returns>
        [Authorize]
        public ActionResult GenMatriculaView(long? id, string accionCrud)
        {
            ViewBag.Accion = accionCrud;
            if (accionCrud == "Insertar")
            {
                return PartialView("GenMatriculaView", ModelEmpy);
            }
            else
            {
                var jresult = entityBL.Get((long)id);
                return ManejadorRetornoVista(jresult, ModelEmpy);
            }
        }

        /// <summary>
        /// Inserta GenMatricula   
        /// </summary>  
        /// <param name="model">Instituciones model</param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult InsGenMatricula(AcaMatriculaVM model)
        {
            // Validaciones
            if (!ModelState.IsValid)
            {
                ViewBag.Accion = GetMethodCrudName(MethodInfo.GetCurrentMethod().Name);
                return PartialView("GenMatriculaView", model);
            }

            // Acceso a la capa de negocio y result
            return Json(entityBL.Insert(model));
        }

        public ActionResult UpdGenMatricula(AcaMatriculaVM model)
        {
            // Validaciones
            if (!ModelState.IsValid)
            {
                ViewBag.Accion = GetMethodCrudName(MethodInfo.GetCurrentMethod().Name);
                return PartialView("GenMatriculaView", model);
            }

            // Acceso a la capa de negocio y result
            return Json(entityBL.Update(model));
        }

        /// <summary>
        /// Elimina GenMatricula
        /// </summary>
        /// <param name="model"></param>
        /// <returns> Resultado de la transacción </returns>
        [HttpPost]
        [Authorize]
        public ActionResult DelGenMatricula(int id)
        {
            // Acceso a la capa de negocio y result
            return Json(entityBL.Delete(id));
        }
    }
}