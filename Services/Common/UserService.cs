using Persistence.DbContextScope;
using Persistence.Interfaces;
using System;
using Model;
using Model.General;
using System.Collections.Generic;
using Persistence.Extensiones;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Persistence;
using Model.Auth;

namespace Services.Common
{

    public class UserService
    {
        public IEnumerable<UserGrid> GetAll()
        {
            var result = new List<UserGrid>();

            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    result = (
                        from au in ctx.ApplicationUsers
                        from aur in ctx.ApplicationUserRoles.Where(x => x.UserId == au.Id)
                        from ar in ctx.ApplicationRoles.Where(x => x.Id == aur.RoleId && x.Enabled)
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

        public ApplicationUser Get(string id)
        {
            var user = new ApplicationUser();
            try
            {               
                using (var ctx = new ApplicationDbContext())
                {
                    user = ctx.ApplicationUsers.Find(id);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }                          
            return user;
            //throw new NotImplementedException();
        }


        public List<GenericEntityList> GetAllUsers()
        {
            var result = new List<GenericEntityList>();

            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    result = (
                        from au in ctx.ApplicationUsers                       
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
                using (var ctx = new ApplicationDbContext())
                {
                    result = (
                        from au in ctx.ApplicationRoles.Where(x => x.Enabled)
                        select new GenericEntityList
                        {
                            Id = au.Id,
                            Nombres = au.Name
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
            var permiso = new SegPermisos();
            try
            {
                using (var ctx = new ApplicationDbContext())
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
                using (var ctx = new ApplicationDbContext())
                {
                    permiso = (

                        from aur in ctx.ApplicationUserRoles.Where(x => x.UserId == userId)                            
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
                using (var ctx = new ApplicationDbContext())
                {
                    permiso = (
                        from aur in ctx.ApplicationUserRoles.Where(x => x.UserId == userId)
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
