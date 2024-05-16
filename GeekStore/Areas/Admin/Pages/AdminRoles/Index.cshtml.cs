using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GeekStore.Areas.Admin.Pages.AdminRoles
{
    [Authorize(Roles = "Admin")]
    public class IndexModel(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager) : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager = roleManager;
        private readonly UserManager<IdentityUser> _userManager = userManager;

        public IQueryable<IdentityRole>? Roles { get; set; }
        public void OnGet()
        {
            Roles = roleManager.Roles;
        }
    }
}
