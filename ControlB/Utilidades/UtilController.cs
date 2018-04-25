#region Include
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Model.General;
using System;
using System.Linq;
using System.Web.Mvc;
#endregion

namespace ControlB.Utilidades
{
    public class UtilController: Controller
    {
        Jresult jresult = new Jresult();
        JsonResult json;

        /// <summary>
        /// Vista index generica
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Nombre de la accion crud
        /// </summary>
        /// <param name="nombreMetodo">Nombre del método post del crud (InsFoo, UpdFoo) </param>
        /// <returns>nombre de la operación</returns>
        public string GetMethodCrudName(string nombreMetodo)
        {
            if (nombreMetodo.ToUpper().Substring(0, 3) == "UPD")
            {
                return "Editar";
            }
            else
            {
                return "Insertar";
            }
        }

        /// <summary>
        /// Define el resultado de salida de aplicar consulta con kendo Grid
        /// </summary>
        /// <param name="jresult"> Contexto de resultado de la transaccion de consulta </param>
        /// <param name="request"> Parametros del kendoGrid </param>
        /// <param name="mensaje"> Mensaje personalizado (si aplica) </param>
        /// <returns>vacio en caso de error, o datos cuando se aplica consulta satisfactoriamente</returns>
        public JsonResult EvaluarResultadoListaGenerico(Jresult jresult, [DataSourceRequest]DataSourceRequest request, string mensaje="Error consultando datos: ")
        {
            if (jresult.Success == false)
            {
                ModelState.AddModelError("Error",mensaje + jresult.Message);
                return Json(Enumerable.Empty<object>().ToDataSourceResult(request, ModelState));
            }
            //return Json(new DataSourceResult { Data = jresult.Result, Total = jresult.Result.Count });
            json = Json(jresult.Data);
            json.MaxJsonLength = Int32.MaxValue;
            return json;
        }        
    }
}