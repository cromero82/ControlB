using ControlB.Utilidades;
using Services.BL;
using System;
using System.Reflection;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Model;

namespace ControlB.Areas.General.Controllers
{
    public class GenEstudianteController   : UtilController
    {
        GenEstudianteBL entityBL = new GenEstudianteBL();
        String EntityName = "Estudiante";
        Object ModelEmpy = new GenEstudianteVM();

        /// <summary>
        /// Obtiene una lista de GenEstudiante para presentarla en un grid
        /// </summary>
        /// <param name="request"> Filtros kendoGrid en cliente </param>
        /// <returns>lista de datos</returns>
        [HttpPost]
        [Authorize]
        public ActionResult GetList([Kendo.Mvc.UI.DataSourceRequest]DataSourceRequest request)
        {
            var jresult = entityBL.GetList(request);
            return EvaluarResultadoListaGenerico(jresult, request, "Error consultando Estudiantes: ");
        }

        /// <summary>
        /// Vista de edición (Crear y Editar) GenEstudiante
        /// </summary>
        /// <param name="id"> id de registro</param>
        /// <param name="accionCrud"> acción que se va a realizar en la vista: Crear o Editar</param>
        /// <returns>Vista para accion crear o editar</returns>
        [Authorize]
        public ActionResult GenEstudianteView(long? id, string accionCrud)
        {
            ViewBag.Accion = accionCrud;
            if (accionCrud == "Insertar")
            {
                return PartialView("GenEstudianteView", ModelEmpy);
            }
            else
            {
                var jresult = entityBL.Get((long)id);
                return ManejadorRetornoVista(jresult, ModelEmpy);
            } 
        }        

        /// <summary>
        /// Inserta GenEstudiante   
        /// </summary>  
        /// <param name="model">Instituciones model</param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult InsGenEstudiante(GenEstudianteVM model)
        {
            // Validaciones
            if (!ModelState.IsValid)
            {
                ViewBag.Accion = GetMethodCrudName(MethodInfo.GetCurrentMethod().Name);
                return PartialView("GenEstudianteView", model);
            }

            // Acceso a la capa de negocio y result
            return Json(entityBL.Insert(model));
        }

        public ActionResult UpdGenEstudiante(GenEstudianteVM model)
        {
            // Validaciones
            if (!ModelState.IsValid)
            {
                ViewBag.Accion = GetMethodCrudName(MethodInfo.GetCurrentMethod().Name);
                return PartialView("GenEstudianteView", model);
            }

            // Acceso a la capa de negocio y result
            return Json(entityBL.Update(model));
        }

        /// <summary>
        /// Elimina GenEstudiante
        /// </summary>
        /// <param name="model"></param>
        /// <returns> Resultado de la transacción </returns>
        [HttpPost]
        [Authorize]
        public ActionResult DelGenEstudiante(int id)
        {
            // Acceso a la capa de negocio y result
            return Json(entityBL.Delete(id));
        }
    }
}