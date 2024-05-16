using GeekStore.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GeekStore.Areas.Admin.Pages.AdminUsers
{
    [Authorize(Roles = "Admin")]
    public class UpdateModel(UserManager<IdentityUser> userManager) : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager = userManager;

        [BindProperty]
        public IdentityUser? UserEdit { get; set; }

        public async Task<IActionResult> OnGet(string id)
        {
            UserEdit = await _userManager.FindByIdAsync(id);
            
            return Page();
        }

        public async Task<IActionResult> OnPost(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null) 
                return NotFound();

            user.UserName = UserEdit!.UserName;
            user.Email = UserEdit.Email;
            user.PhoneNumber = UserEdit.PhoneNumber;

            if (!ModelState.IsValid)
                return RedirectToPage("/AdminUsers/Index");

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded) 
                return NotFound();

            return RedirectToPage("/AdminUsers/Index");

        }
    }
}