using GeekStore.Areas.Admin.Models;
using GeekStore.Areas.Admin.Services.Tables;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GeekStore.Areas.Admin.Pages.AdminUsers
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel(UserManager<IdentityUser> userManager) : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager = userManager;
        public UserWithRole? UserDelete { get; set; }

        public async Task<IActionResult> OnGet(string id, string rolename)
        {
            var user = await _userManager.FindByIdAsync(id);

            UserDelete = new UserWithRole()
            {
                UserName = user!.UserName,
                Email = user.Email,
                RoleName = rolename
            };

            return Page();
        }

        public async Task<IActionResult> OnPost(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return NotFound();

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
                return NotFound();

            return RedirectToPage("/AdminUsers/Index");
        }
    }
}
