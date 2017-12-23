﻿using Persistence.DbContextScope;
using Persistence.Interfaces;
using System;
using Model;
using Model.BL;
using System.Collections.Generic;
using Persistence.Extensiones;
using System.Linq;

namespace Services
{

    public class UserService
    {
        //private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<ApplicationUser> _applicationUserRepo;

        public UserService(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<ApplicationUser> applicationUserRepo
        )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _applicationUserRepo = applicationUserRepo;
        }

        public UserService()
        {
        }

        public IEnumerable<UserForGridView> GetAll()
        {
            var result = new List<UserForGridView>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    var abc = _applicationUserRepo.GetAll().ToList();

                    var users = ctx.GetEntity<ApplicationUser>();
                    var roles = ctx.GetEntity<ApplicationRole>();
                    var usersPerRoles = ctx.GetEntity<ApplicationUserRole>();

                    var queryUsersPerRoles = (
                        from upr in usersPerRoles
                        from r in roles.Where(x => x.Id == upr.RoleId)
                        select new
                        {
                            upr.UserId,
                            r.Name
                        }
                    ).AsQueryable();

                    result = (
                        from u in users
                        select new UserForGridView
                        {
                            Id = u.Id,
                            Email = u.Email,
                            Roles = queryUsersPerRoles.Where(x =>
                                x.UserId == u.Id
                            ).Select(x => x.Name).ToList()
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

        public object Get(string id)
        {
            throw new NotImplementedException();
        }

        //public object GetAll()
        //{
        //    throw new NotImplementedException();
        //}
    }
}