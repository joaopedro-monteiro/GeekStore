using GeekStore.Areas.Admin.Models;
using GeekStore.Core.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GeekStore.Areas.Admin.Services.Tables
{
    public class TableUsersWithRoles(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, GeekStoreDbContext dbContext) : ITableUsersWithRoles
    {
        private readonly RoleManager<IdentityRole> _roleManager = roleManager;
        private readonly UserManager<IdentityUser> _userManager = userManager;
        private readonly GeekStoreDbContext _dbContext = dbContext;

        public IQueryable<UserWithRole> TableUsersRoles()
        {
            var tableUsers = _userManager.Users
                .Join(_dbContext.UserRoles,
                    user => user.Id,
                    userRole => userRole.UserId,
                    (user, userRole) => new
                    {
                        user.Id,
                        user.UserName,
                        user.Email,
                        userRole.RoleId
                    })
                .Join(_roleManager.Roles,
                    user => user.RoleId,
                    role => role.Id,
                    (user, role) => new UserWithRole()
                    {
                        Id = user.Id,
                        UserName = user.UserName,
                        Email = user.Email,
                        RoleName = role.Name,
                        RoleId = user.RoleId
                    });

            return tableUsers;
        }
    }
}
