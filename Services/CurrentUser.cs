using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Security.Principal;
using Services;
using Persistence;
using Model.BL;

namespace Services
{
    public class CurrentUser
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public static CurrentUser Get
        {
            get
            {
                // Si nunca se ha guardado la información del usuario, se solicita por primera vez
                if(UserUtils.currentUser == null || UserUtils.currentUser.UserId == null)
                {
                    var user = HttpContext.Current.User;
                    if (user == null)
                    {
                        return null;
                    }
                    else if (string.IsNullOrEmpty(user.Identity.GetUserId()))
                    {
                        return null;
                    }
                    var jUser = ((ClaimsIdentity)user.Identity).FindFirst(ClaimTypes.UserData).Value;
                    session["permisos"] = JsonConvert.DeserializeObject<CurrentUser>(jUser);
                }                
                return UserUtils.currentUser;
            }
        }
        
    }
    public static class UserUtils
    {
        //public static CurrentUser currentUser { get; set; }
        //public static List<DefaultModel> permisos { get; set; }
        public static bool HasPermission(this IPrincipal user, string permissionsString)
        {
            // Obtiene permisos de cache
            var session = HttpContext.Current.Session;
            var permissions = session["permisos"] as IDictionary<string, DefaultModel>;

            // Valida la existencia del objeto
            if (permissions == null)
            {
                UserService _userService = new UserService();
                session["permisos"] = _userService.ListaPermisos( currentUser.UserId);
            }

            // Valida si tiene algun permiso asignado
            if (permissions.Count == 0)
            {
                return false;
            }

            // Covierte permisos en lista
            string[] permissionsList = permissionsString.Split(Convert.ToChar(","));

            // Valida si tiene alguno de los permisos especificados
            string permission;
            for (int i = 0; i < permissionsList.Length; i++)
            {
                permission = permissionsList[i];
                if (permissions.ContainsKey(permission))
                {
                    return true;
                }
            }

            return false;


            //// Si lista de permisos esta vacia, consulta la lista de permisos
            //if (permisos == null || permisos.Count ==0)
            //{
            //    UserService _userService = new UserService();
            //    permisos = _userService.ListaPermisos( currentUser.UserId);
            //}

            //// Busca si el permiso esta en la lista
            //foreach(DefaultModel permiso in permisos)
            //{
            //    if(permiso.Nombre == permissionsString)
            //    {
            //        return true;
            //    }
            //}
            
            //return false;
        }

        public static void clear()
        {
            UserUtils.currentUser = new CurrentUser();
            if(permisos != null)
            {
                permisos.Clear();
            }
        }
    }
    
}
