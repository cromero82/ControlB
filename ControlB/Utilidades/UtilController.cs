using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Model.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlB.Utilidades
{
    public class UtilController: Controller
    {
        JsonResult json;
        public JsonResult EvaluarResultadoListaGenerico(Jresult jresult, [DataSourceRequest]DataSourceRequest request, string mensaje="Error consultando datos: ")
        {
            if (jresult.Success == false)
            {
                ModelState.AddModelError("Error",mensaje + jresult.Message);
                return Json(Enumerable.Empty<object>().ToDataSourceResult(request, ModelState));
            }
            //return Json(new DataSourceResult { Data = jresult.Result, Total = jresult.Result.Count });
            json = Json(jresult.Result);
            json.MaxJsonLength = Int32.MaxValue;
            return json;
        }        
    }
}