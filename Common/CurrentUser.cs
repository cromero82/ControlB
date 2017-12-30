using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Security.Principal;
using Services;

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
                if(User.currentUser == null)
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
                    User.currentUser = JsonConvert.DeserializeObject<CurrentUser>(jUser);
                }                
                return User.currentUser;
            }
        }
        
    }
    public static class User
    {
        public static CurrentUser currentUser { get; set; }
        public static List<String> permisos { get; set; }
        public static bool HasPermission(this IPrincipal user, string permissionsString)
        {
            // Si lista de permisos esta vacia, consulta la lista de permisos
            if(permisos.Count == 0)
            {
                UserService _userService = new UserService();
            }
            
            return true;
        }
    }
    
}
