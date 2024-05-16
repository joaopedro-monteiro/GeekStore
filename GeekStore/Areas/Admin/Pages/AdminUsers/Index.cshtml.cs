using GeekStore.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GeekStore.Areas.Admin.Services.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace GeekStore.Areas.Admin.Pages.AdminUsers
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
