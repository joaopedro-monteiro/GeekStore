using GeekStore.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;

namespace GeekStore.Areas.Admin.Services.Tables
{
    public interface ITableUsersWithRoles
    {
        IQueryable<UserWithRole> TableUsersRoles();
    }
}
