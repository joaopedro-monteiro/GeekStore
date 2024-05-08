using GeekStore.Core.Models.Accounts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GeekStore.Pages.Account.Login
{
    public class IndexModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager) : PageModel
    {
        [BindProperty]
        public LoginViewModel? Model { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostLogin()
        {
            if (ModelState.IsValid)
            {
                var result =
                    await signInManager.PasswordSignInAsync(Model!.Email!, Model.Password!, Model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToPage("/Index");
                }

                ModelState.AddModelError(string.Empty, "Login Inválido");
            }


            return RedirectToPage("/Account/Login/Index");
        }

        public async Task<IActionResult> OnPostLogoutAsync()
        {
            await signInManager.SignOutAsync();
            return RedirectToPage("../../Index");
        }
    }
}
