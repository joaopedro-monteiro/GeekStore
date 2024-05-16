using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace GeekStore.Areas.Admin.Pages.AdminRoles
{
    [Authorize(Roles = "Admin")]
    public class CreateModel(RoleManager<IdentityRole> roleManager) : PageModel
    {
        private RoleManager<IdentityRole> RoleManager { get; set; } = roleManager;

        [Required]
        [BindProperty]
        public string? NameNewRole { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost() 
        {
            var name = NameNewRole;            
            
            if(ModelState.IsValid)
            {
                var result = await RoleManager.CreateAsync(new IdentityRole { Name = name, ConcurrencyStamp = Guid.NewGuid().ToString() });
                if (result.Succeeded)
                {
                    return RedirectToPage("Index");
                }               
            }
            return Page();
        }
    }
}
