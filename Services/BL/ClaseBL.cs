using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Model.General;
using System;
using System.Linq;

namespace Services.BL
{
    public class ClaseBL
    {
        public Jresult ManejadorExcepciones(Exception ex, Jresult jresult)
        {
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
            jresult.Result = queryable.ToDataSourceResult(filtrosComponenteKendo);
            jresult.Success = true;
            return jresult;
        }
    }
}
