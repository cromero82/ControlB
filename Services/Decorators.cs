using Common;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Services
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
            if (!_userService.RolTienePermiso(Permiso, CurrentUser.Get.UserId))
            {
                //filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                //{
                //    controller = "Home",
                //    action = "Index"
                //}));
                throw new HttpException(403, "Unauthorized 403");
            }
        }
    }
}
