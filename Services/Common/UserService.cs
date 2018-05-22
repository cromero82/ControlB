using System;
using Model;
using Model.General;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
//using Model.Auth;

namespace Services.Common
{

    public class UserService
    {
        public bool GetRoles(string NombreRol, IPrincipal User)
        {
            var roles = ((ClaimsIdentity)User.Identity).Claims
                .Where(c => c.Type == ClaimTypes.Role                
                )
                ;
            return true;
                //.Select(c => c.Value);

        }
        public IEnumerable<UserGrid> GetAll()
        {
            var result = new List<UserGrid>();

            try
            {
                using (var ctx = new ControlcBDEntities())
                {
                    result = (
                        //from au in ctx.ApplicationUsers
                        from au in ctx.AspNetUsers
                            //from aur in ctx.ApplicationUserRoles.Where(x => x.UserId == au.Id)
                        from aur in ctx.AspNetUserRoles.Where(x => x.UserId == au.Id)
                            //from ar in ctx.ApplicationRoles.Where(x => x.Id == aur.RoleId && x.Enabled)
                            // Pendiente roles activos
                        from ar in ctx.AspNetRoles.Where(x => x.Id == aur.RoleId )
                        select new UserGrid
                        {
                            Id = au.Id,
                            Name = au.Name,
                            LastName = au.LastName,
                            Email = au.Email,
                            Role = ar.Name                            
                        }
                    ).ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //logger.Error(e.Message);
            }

            return result;
        }

        public AspNetUsers Get(string id)
        {
            
            try
            {
               
                using (var ctx = new ControlcBDEntities())
                {
                    var user = ctx.AspNetUsers.Find(id); //ApplicationUsers.Find(id);
                    return user;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }                          
            
            //throw new NotImplementedException();
        }


        public List<GenericEntityList> GetAllUsers()
        {
            var result = new List<GenericEntityList>();

            try
            {
                using (var ctx = new ControlcBDEntities())
                {
                    result = (
                        from au in ctx.AspNetUsers//ApplicationUsers                       
                        select new GenericEntityList
                        {                            
                            Id = au.Id,
                            Nombres = String.Concat(au.Name ," ", au.LastName)
                        }
                    ).ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //logger.Error(e.Message);
            }

            return result;
        }

        public List<GenericEntityList> GetAllRoles()
        {
            var result = new List<GenericEntityList>();

            try
            {
                using (var ctx = new ControlcBDEntities())
                {
                   
                    result = ctx.AspNetRoles.Select( x=>  new GenericEntityList
                        {
                            Id = x.Id,
                            Nombres = x.Name
                        }
                    ).ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //logger.Error(e.Message);
            }

            return result;
        }

        public bool TienePermiso(string filterContext)
        {
            var permiso = new Model.SegPermisos();
            try
            {
                using (var ctx = new ControlcBDEntities())
                {
                    permiso = ctx.SegPermisos.Where(x => x.Sigla == filterContext).FirstOrDefault();
                    if (permiso != null)
                        return true;
                    else
                        return false;
                }

            }
            catch (Exception e)
            {                
                Console.WriteLine(e.Message);
                return false;
            }           
           
        }

        public bool RolTienePermiso(string nombrePermiso, string userId)
        {
            var permiso = new DefaultModel();
            try
            {
                using (var ctx = new ControlcBDEntities())
                {
                    permiso = (

                        //from aur in ctx.ApplicationUserRoles.Where(x => x.UserId == userId)                            
                        from aur in ctx.AspNetUserRoles.Where(x => x.UserId == userId)
                        from srp in ctx.SegRolesPermisos.Where(x => x.RolId == aur.RoleId)
                        from sper in ctx.SegPermisos.Where(x => x.Id == srp.PermisoId && x.Sigla == nombrePermiso)
                        select new DefaultModel
                        {
                            Id = sper.Id
                        }
                    ).FirstOrDefault()
                    ;                   
                    if (permiso != null)
                        return true;
                    else
                        return false;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

        }

        public List<DefaultModel> ListaPermisos( string userId)
        {
            var permiso = new List<DefaultModel>() { };
            try
            {
                using (var ctx = new ControlcBDEntities())
                {
                    permiso = (
                        //from aur in ctx.ApplicationUserRoles.Where(x => x.UserId == userId)
                        from aur in ctx.AspNetUserRoles.Where(x => x.UserId== userId)
                        from srp in ctx.SegRolesPermisos.Where(x => x.RolId == aur.RoleId)
                        from sper in ctx.SegPermisos.Where(x => x.Id == srp.PermisoId)
                        select new DefaultModel
                        {
                            Nombre = sper.Sigla
                        }
                    ).ToList()
                    ;
                    
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);                
            }
            return permiso;
        }

        // Proviene de otro ejemplo proyecto
        //public Boolean isAdminUser()
        //{
        //    if (IUser.Identity.IsAuthenticated)
        //    {
        //        var user = User.Identity;
        //        var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
        //        var s = UserManager.GetRoles(user.GetUserId());
        //        if (s[0].ToString() == "Admin")
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    return false;
        //}

        //public object GetAll()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
