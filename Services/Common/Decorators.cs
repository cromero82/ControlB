using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Services.Common
{
    
    /// <summary>
    /// Verifica si el rol tiene permiso
    /// </summary>
    public class HassPermission : ActionFilterAttribute
    {
        public string Permiso { get; set; }
        private string UserId { get; set; }
        public readonly UserService _userService = new UserService();

        //public RolesPermisos Permiso { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);   
            if(CurrentUser.Get.UserId == "")
                throw new HttpException(403, "Unauthorized 403");
            if (!UserUtils.HasPermission(Permiso))            
            {
                // aqui codigo de error
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Home",
                    action = "Unauthorized"
                }));                
            }
        }

       
    }
}
