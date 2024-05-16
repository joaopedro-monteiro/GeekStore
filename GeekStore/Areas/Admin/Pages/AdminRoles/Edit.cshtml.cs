using System.Runtime.InteropServices.JavaScript;
using GeekStore.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GeekStore.Areas.Admin.Pages.AdminRoles
{
    [Authorize(Roles = "Admin")]
    public class EditModel(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager) : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager = roleManager;
        private readonly UserManager<IdentityUser> _userManager = userManager;

        public static string? RoleId { get; set; }
        public RoleEdit? RoleEdit { get; set; }
        public RoleModification? RoleModification { get; set; }

        public async Task<IActionResult> OnGet(string id)
        {
            RoleId = id;

            var role = await _roleManager.FindByIdAsync(id);

            var members = new List<IdentityUser>();
            var nonMembers = new List<IdentityUser>();

            foreach (var user in _userManager.Users)
            {
                var isInRole = await _userManager.IsInRoleAsync(user, role!.Name!);
                if (isInRole)
                    members.Add(user);
                else
                    nonMembers.Add(user);
            }

            RoleEdit = new RoleEdit
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            };
            return Page();
        }

        public async Task<IActionResult> OnPost(RoleModification model)
        {
            var role = await _roleManager.FindByIdAsync(RoleId!);

            model.RoleName = role!.Name;
            model.RoleId = RoleId;

            if (!ModelState.IsValid) 
                return RedirectToPage("/AdminRoles/Index");
            foreach (var userId in model.AddIds! ?? new string[] { })
            {
                var user = await _userManager.FindByIdAsync(userId);

                if (user is null) continue;
                var result = await _userManager.AddToRoleAsync(user, model.RoleName!);
                if (!result.Succeeded)
                {
                    Console.WriteLine("Deu erro");
                }
            }

            foreach (var userId in model.DeleteIds! ?? new string[] { })
            {
                var user = await _userManager.FindByIdAsync(userId);

                if (user is null) continue;
                var result = await _userManager.RemoveFromRoleAsync(user, model.RoleName!);
                if (!result.Succeeded)
                {
                    return RedirectToPage("/AdminRoles/Index");
                }

                await _userManager.AddToRoleAsync(user, "User");
            }
            return RedirectToPage("/AdminRoles/Index");
        }
    }
}
