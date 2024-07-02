using GeekStore.Core.Models.Accounts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GeekStore.Pages.Account.Register
{
    public class IndexModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager) : PageModel
    {
        [BindProperty]
        public RegisterViewModel? Model { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostRegister()
        {
            if (!ModelState.IsValid) 
                return Page();
            var user = new IdentityUser
            {
                UserName = Model!.UserName,
                PhoneNumber = Model.PhoneNumber,
                Email = Model.Email
            };

            var result = await userManager.CreateAsync(user, Model.Password!);

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);

                return RedirectToPage("/Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return Page();
        }
    }
}
