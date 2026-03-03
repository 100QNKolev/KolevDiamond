using KolevDiamond.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace KolevDiamond.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static async Task CreateAdminRoleAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;

            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

            if (!await roleManager.RoleExistsAsync(AdminUser.AdminRoleName))
            {
                await roleManager.CreateAsync(new IdentityRole(AdminUser.AdminRoleName));
            }

            var adminUser = await userManager.FindByEmailAsync(AdminUser.AdminEmail);
            if (adminUser != null && !await userManager.IsInRoleAsync(adminUser, AdminUser.AdminRoleName))
            {
                await userManager.AddToRoleAsync(adminUser, AdminUser.AdminRoleName);
            }
        }
    }
}
