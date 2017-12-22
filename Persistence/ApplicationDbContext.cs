using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Model;

namespace Persistence
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext()
            : base("BdService")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>();
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
