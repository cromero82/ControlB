using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Logging;
using Model;
using Model.General;
using Model.Auth;
using Services;
using Services.Auth;
using Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebGrease;

namespace ControlB.Controllers
{    
    public class UserController : Controller
    {
        public readonly UserService _userService = new UserService();
    

        private ApplicationRoleManager _roleManager
        {
            get
            {
                return HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
        }

        private ApplicationUserManager _userManager
        {
            get
            {
                return HttpContext.GetOwinContext().Get<ApplicationUserManager>();
            }
        }

        [Authorize]
        public ActionResult Index()
        {
            return View(
                //_roleManager.Roles.Where(x => x.Enabled).ToList()
                _userService.GetAll()
                );
        }

        public ActionResult Get(string id)
        {
            ViewBag.Roles = _roleManager.Roles.ToList();
            return View(
                _userService.Get(id)
                );
        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> AddRoleToUser(string id, string role)
        {
            //var exists = await _userManager.IsInRoleAsync(id, role);
            //if (exists)
            //{
            //    throw new Exception("Solo se puede tener un rol por usuario");
            //}
            await _userManager.addToRoleAsync(id, role);
            return RedirectToAction("Index");
        }

        //[Authorize(Roles = "Admin")]
        public async Task CreateRoles()
        {
            // Listado de roles genéricos
            var roles = new List<ApplicationRole>
            {
                new ApplicationRole {Name = "Admin" },
                new ApplicationRole {Name = "Moderator" },
                new ApplicationRole {Name = "User" }
            };
            foreach (var r in roles)
            { 
                // Si es false, quiere decir que no existe el rol y se debe crear              
                if(!await _roleManager.RoleExistsAsync(r.Name))
                {
                    await _roleManager.CreateAsync(r);
                }               
            }
        }

        /// <summary>
		/// Vista para inserta un nuevo rol
		/// </summary>
		/// <returns>Vista para insertar nuevo rol</returns>
        [Authorize(Roles = "Admin")]
        public ActionResult InsRol()
        {
            return View();
        }

        /// <summary>
		/// Inserta un nuevo rol
		/// </summary>
		/// <returns>Vista para insertar nuevo rol</returns>
        [Authorize(Roles="Admin")]
		public async Task  InsRol(ApplicationRole rol)
        {            
            // Si es false, quiere decir que no existe el rol y se debe crear  
                      
            if (!await _roleManager.RoleExistsAsync(rol.Name))
            {                
                await _roleManager.CreateAsync(
                    new ApplicationRole { Name = rol.Name}
                    );
            }
        }

        /// <summary>
		/// Inserta un nuevo rol
		/// </summary>
		/// <returns>Vista para insertar un rol a un usuario</returns>
        //[Authorize(Roles = "Admin")]          
        [HassPermission(Permiso = "Per1")]
        public ActionResult InsRolUsuario(string userId)
        {
            var user = new ApplicationUser();
            //var x = User.Identity.GetUserId();
            user = _userService.Get(userId);
            var model = new AsignacionRolGridVM
            {
                UserId = userId,
                NombreUsuario = user.Name,
                Roles = _userService.GetAllRoles()
            };
            return View(model);
        }

        /// <summary>
		/// Inserta un nuevo rol
		/// </summary>
		/// <returns>Vista para insertar un rol a un usuario</returns>
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> InsRolUsuario(AsignacionRolGridVM model)
        {
            await _userManager.addToRoleAsync(model.UserId, model.RolId);
            return RedirectToAction("Index");
        }
    }

    public class PermisoAttribute : ActionFilterAttribute
    {
        
        public string Permiso { get; set; }
        public string UserId
        {
            //get
            //{
            //    return User.Identity.GetUserId();
            //}
            get; set;
        }
        public readonly UserService _userService = new UserService();       

        //public RolesPermisos Permiso { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (!_userService.TienePermiso(Permiso))
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Home",
                    action = "Index"
                }));
            }
        }
    }


    
}