using Newtonsoft.Json;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Security.Principal;
using Model.General;

namespace Services.Common
{
    /// <summary>
    /// Model de usuario
    /// </summary>
    public class CurrentUser
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        /// <summary>
        /// Funcion que obtiene información del usuario (campos básicos)
        /// </summary>
        public static CurrentUser Get
        {            
            get
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
                    return  JsonConvert.DeserializeObject<CurrentUser>(jUser);
               
            }
        }
        
    }

    /// <summary>
    /// Clase para obtener información del usuario y sus permisos
    /// </summary>
    public static class UserUtils
    {
        /// <summary>
        /// Funcion que determina si la persona tiene un permiso (Funcion encabezado)
        /// </summary>
        /// <param name="user"> Iprincipal usuario actual</param>
        /// <param name="permissionsString">Codigo del permiso</param>
        /// <returns>valor booleano que determina si el usuario tiene permiso</returns>
        public static bool HasPermission(this IPrincipal user, string permissionsString)
        {
            return HasPermissionBody(permissionsString);
        }

        /// <summary>
        /// Funcion que determina si la persona tiene un permiso (Funcion encabezado)
        /// </summary>
        /// <param name="user"> Iprincipal usuario actual</param>
        /// <param name="permissionsString">Codigo del permiso</param>
        /// <returns>valor booleano que determina si el usuario tiene permiso</returns>
        public static bool HasPermission(string permissionsString)
        {
            return HasPermissionBody(permissionsString);
        }

        /// <summary>
        /// Funcion que determina si el usuario tiene permiso (Funcion cuerpo)
        /// </summary>
        /// <param name="user"></param>
        /// <param name="permissionsString">Codigo del permiso</param>
        /// <returns></returns>
        private static  bool HasPermissionBody( string permissionsString)
        {
            // Obtiene permisos de cache
            var session = HttpContext.Current.Session;

            // si no existe ningún permiso guardado, los consulta por primera vez
            if (session["permisos"] == null)
            {
                UserService _userService = new UserService();
                session["permisos"] = _userService.ListaPermisos(CurrentUser.Get.UserId);
            }

            var permissions = (List<DefaultModel>)session["permisos"];

            // Valida si tiene algun permiso asignado
            if (permissions.Count == 0)
            {
                return false;
            }

            // verifica la lista de permisos con permiso específico a consultar
            foreach (DefaultModel permiso in permissions)
            {
                if (permiso.Nombre == permissionsString)
                {
                    return true;
                }
            }

            return false;
        }


        /// <summary>
        /// Limpia la lista de permisos del usuario
        /// </summary>
        public static void clear()
        {
            var session = HttpContext.Current.Session;
            session["permisos"] = null;
        }
    }
    
}
