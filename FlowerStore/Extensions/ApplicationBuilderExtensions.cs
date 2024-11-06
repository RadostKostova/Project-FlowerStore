using FlowerStore.Infrastructure.Data.Models.Roles;
using Microsoft.AspNetCore.Identity;
using static FlowerStore.Core.Constants.AdminConstants;

namespace FlowerStore.Extensions
{
    /// <summary>
    /// Extensions for Application Builder. Configuring the pipeline to create admin when building the app.
    /// </summary>

    public static class ApplicationBuilderExtensions
    {
        public static async Task CreateAdminRoleAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleExist = await roleManager.RoleExistsAsync(AdminRole);

            if (userManager != null && roleManager != null && roleExist == false)
            {
                var role = new IdentityRole(AdminRole);
                await roleManager.CreateAsync(role);

                var admin = await userManager.FindByEmailAsync(AdminEmail);

                if (admin != null)
                {
                    await userManager.AddToRoleAsync(admin, role.Name);
                }
            }
        }
    }
}
