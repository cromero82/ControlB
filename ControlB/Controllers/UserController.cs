using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Logging;
using Model;
using Services;
using Services.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebGrease;

namespace ControlB.Controllers
{
    [Authorize]
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

        //GET: User
        public ActionResult Index()
        {
            return View(
                //_roleManager.Roles.Where(x => x.Enabled).ToList()
                _userService.GetAll()
                );
        }

        public ActionResult Get(string id)
        {
            ViewBag.Roles = _roleManager.Roles.Where(x => x.Enabled).ToList();
            return View(
                _userService.Get(id)
                );
        }

        public async Task<ActionResult> AddRoleToUser(string id, string role)
        {
            var exists = await _userManager.IsInRoleAsync(id, role);
            if (exists)
            {
                throw new Exception("Solo se puede tener un rol por usuario");
            }
            await _userManager.addToRoleAsync(id, role);
            return RedirectToAction("Index");
        }

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
		/// Inserta un nuevo rol
		/// </summary>
		/// <returns>Vista para insertar nuevo rol</returns>
        [Authorize(Roles="Admin")]
		public async Task  InsRol(ApplicationRole rol)
        {
            //if (User.Identity.IsAuthenticated)
            //{


            //    if (!isAdminUser())
            //    {
            //        return RedirectToAction("Index", "Home");
            //    }
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Home");
            //}

            // Si es false, quiere decir que no existe el rol y se debe crear  
                      
            if (!await _roleManager.RoleExistsAsync(rol.Name))
            {                
                await _roleManager.CreateAsync(
                    new ApplicationRole { Name = rol.Name}
                    );
            }
        }

        

    }
}