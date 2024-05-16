using GeekStore.Areas.Admin.Models;
using GeekStore.Areas.Admin.Services.Tables;
using GeekStore.Core.Data.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GeekStore.Areas.Admin.Pages
{
    [Authorize(Roles = "Admin")]
    public class IndexModel(ITableUsersWithRoles tableUser) : PageModel
    {
        private readonly ITableUsersWithRoles _tableUser = tableUser;

        [BindProperty]
        public IQueryable<UserWithRole>? Table { get; set; }
        public void OnGet()
        {
            Table = _tableUser.TableUsersRoles();
        }
    }
}
