using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Model.General;
using System;
using System.Linq;

namespace Services.BL
{
    public class ClaseBL
    {
        public Jresult ManejadorExcepciones(Exception ex, Jresult jresult, string entidadRelacionada)
        {
            #region Aqui manejo de log - Programacion de contexto (error tecnico + monitoreo de errores)
            //.. Pendiente
            #endregion

            #region Preparando mensaje de error para usuario
            // -------------------------------
            var metodo = ex.TargetSite.Name;

            var accion7 = metodo.Substring(0, 7);
            if (accion7 == "getList")
            {
                jresult.SetError(String.Concat("Se ha presentado un error", " consultando lista de ", entidadRelacionada));
            }
            else
            {
                var accion3 = metodo.Substring(0, 3).ToLower();
                switch (accion3)
                {
                    case "get":
                        accion3 = "consultando ";
                        break;
                    case "ins":
                        accion3 = "insertando ";
                        break;
                    case "upd":
                        accion3 = "actualizando ";
                        break;
                    case "del":
                        accion3 = "eliminando ";
                        break;
                    default:
                        break;
                }
                jresult.SetError(String.Concat("Se ha presentado un error " , accion3, entidadRelacionada));
            }
            #endregion
    
            return jresult;
        }

        /// <summary>
        /// Aplica filtros de kendo grid
        /// </summary>
        /// <param name="jresult"> Informacion de respuesta de transaccion</param>
        /// <param name="filtrosComponenteKendo"> Filtros del componente Kendo</param>
        /// <param name="queryable"> Subconsulta EF</param>
        /// <returns></returns>
        public Jresult AplicadorFiltrosKendo(Jresult jresult, DataSourceRequest filtrosComponenteKendo, IQueryable<Object> queryable)
        {
            // Se aplican filtros de kendo               
            jresult.Data = queryable.ToDataSourceResult(filtrosComponenteKendo);
            jresult.SetOk("Filtro aplicado correctamente");
            return jresult;
        }
    }
}
