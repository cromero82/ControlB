﻿using Microsoft.AspNet.Identity.EntityFramework;

namespace Persistence
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
            public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
