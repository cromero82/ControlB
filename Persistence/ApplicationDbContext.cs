using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Model;
using Model.Auth;
using Model.BL;

namespace Persistence
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }
        
    
        public DbSet<SegPermisos> SegPermisos { get; set; }
        public DbSet<SegRolesPermisos> SegRolesPermisos { get; set; }

        public DbSet<Instituciones> Instituciones { get; set; }
        public DbSet<Tniveles> Tniveles { get; set; }
        public DbSet<Tgrados> Tgrados { get; set; }
        public DbSet<Tjornadas> Tjornadas { get; set; }
        public DbSet<Tespecialidades> Tespecialidades { get; set; }
        public DbSet<Tcaracter> Tcaracter { get; set; }
        public DbSet<Tdepartamentos> Tdepartamentos { get; set; }
        public DbSet<Tmunicipios> Tmunicipios { get; set; }
        public DbSet<Tpaises> Tpaises { get; set; }
        public DbSet<Tmetodologias> Tmetodologias { get; set; }
        public DbSet<Tdocumentos> Tdocumentos { get; set; }
        public DbSet<Testratos> Testratos { get; set; }
        public DbSet<Tsisben> Tsisben { get; set; }
        public DbSet<TpVictimaConflicto> TpVictimaConflicto { get; set; }
        public DbSet<Tdiscapacidades> Tdiscapacidades { get; set; }
        public DbSet<TcapExcepcionales> TcapExcepcionales { get; set; }

        public ApplicationDbContext()
            : base("BdService")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>();
            modelBuilder.Entity<ApplicationRole>();           
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
