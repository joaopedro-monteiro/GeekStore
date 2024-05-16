using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GeekStore.Areas.Admin.Pages.AdminRoles
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel(RoleManager<IdentityRole> roleManager) : PageModel
    {
        private RoleManager<IdentityRole> _roleManager { get; set; } = roleManager;

        public IdentityRole? Role { get; set; }

        public async Task<IActionResult> OnGet(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            Role = role;

            return Page();
        }

        public async Task<IActionResult> OnPost(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            if (role is null) 
                return Page();

            await _roleManager.DeleteAsync(role);

            return RedirectToPage("/AdminRoles/Index");
        }
    }
}
