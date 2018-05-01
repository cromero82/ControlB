using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
//using Model.Auth;
using Model.BL;
using Model.Auth;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace Persistence
{

    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
           : base("BdService", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        //public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        //public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        //public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }


        //public DbSet<Model.BL.SegPermisos> SegPermisos { get; set; }
        //public DbSet<Model.BL.SegRolesPermisos> SegRolesPermisos { get; set; }

        //public DbSet<GenInstituciones> GenInstituciones { get; set; }
        //public DbSet<Tniveles> Tniveles { get; set; }
        //public DbSet<Tgrados> Tgrados { get; set; }
        //public DbSet<Tjornadas> Tjornadas { get; set; }
        //public DbSet<Tespecialidades> Tespecialidades { get; set; }
        //public DbSet<Tcaracters> Tcaracter { get; set; }
        //public DbSet<Tdepartamentos> Tdepartamentos { get; set; }
        //public DbSet<Tmunicipios> Tmunicipios { get; set; }
        //public DbSet<Tpaises> Tpaises { get; set; }
        //public DbSet<Tmetodologias> Tmetodologias { get; set; }
        //public DbSet<Tdocumentos> Tdocumentos { get; set; }
        //public DbSet<Testratos> Testratos { get; set; }
        //public DbSet<Tsisbens> Tsisben { get; set; }
        //public DbSet<TpVictimaConflictoes> TpVictimaConflicto { get; set; }
        //public DbSet<Tdiscapacidades> Tdiscapacidades { get; set; }
        //public DbSet<TcapExcepcionales> TcapExcepcionales { get; set; }
        //public DbSet<Tetnias> Tetnia { get; set; }
        //public DbSet<GenSedes> GenSedes { get; set; }
        //public DbSet<GenNivelesAprobados> GenNivelesAprobados { get; set; }
        //public DbSet<GenCores> GenCore { get; set; }

        //public ApplicationDbContext()
        //    : base("bdbasicEntities")
        //{
        //}

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<ApplicationUser>();
        //    modelBuilder.Entity<ApplicationRole>();           
        //}

        //public static ApplicationDbContext Create()
        //{
        //    return new ApplicationDbContext();
        //}
    }
}
