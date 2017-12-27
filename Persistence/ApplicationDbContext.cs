﻿using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Model;

namespace Persistence
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }

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
