
using Microsoft.AspNetCore.Identity;

namespace GeekStore.Core.Services.Accounts
{
    public class SeedUserRoleInitial(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager) : ISeedUserRoleInitial

    {
        private readonly UserManager<IdentityUser> _userManager = userManager;
        private readonly RoleManager<IdentityRole> _roleManager = roleManager;

        public async Task SeedRolesAsync()
        {
            if (!await _roleManager.RoleExistsAsync("User"))
            {
                var role = new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                };

                var roleResult = await _roleManager.CreateAsync(role);
            }

            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                var role = new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                };

                var roleResult = await _roleManager.CreateAsync(role);
            }

            if (!await _roleManager.RoleExistsAsync("Gerente"))
            {
                var role = new IdentityRole
                {
                    Name = "Gerente",
                    NormalizedName = "GERENTE",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                };

                var roleResult = await _roleManager.CreateAsync(role);
            }
        }

        public async Task SeedUsersAsync()
        {
            if (await _userManager.FindByEmailAsync("usuario@localhost") == null)
            {
                var user = new IdentityUser
                {
                    UserName = "usuario@localhost",
                    Email = "usuario@localhost.com",
                    NormalizedUserName = "USUARIO@LOCALHOST",
                    NormalizedEmail = "USUARIO@LOCALHOST.COM",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                var result = await _userManager.CreateAsync(user, "Numsey#2024");

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                }
            }

            if (await _userManager.FindByEmailAsync("admin@localhost") == null)
            {
                var user = new IdentityUser
                {
                    UserName = "admin@localhost",
                    Email = "admin@localhost.com",
                    NormalizedUserName = "ADMIN@LOCALHOST",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                var result = await _userManager.CreateAsync(user, "Numsey#2024");

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Admin");
                }
            }

            if (await _userManager.FindByEmailAsync("gerente@localhost") == null)
            {
                var user = new IdentityUser
                {
                    UserName = "gerente@localhost",
                    Email = "gerente@localhost.com",
                    NormalizedUserName = "GERENTE@LOCALHOST",
                    NormalizedEmail = "GERENTE@LOCALHOST.COM",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                var result = await _userManager.CreateAsync(user, "Numsey#2024");

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Gerente");
                }
            }
        }
    }
}
