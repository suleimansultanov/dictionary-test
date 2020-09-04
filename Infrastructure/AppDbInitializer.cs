using System.Threading.Tasks;
using DAL.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class AppDbInitializer
    {
        public static async Task SeedAsync(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var dbContext = scope.ServiceProvider.GetService<AppDbContext>();

                if (!await roleManager.RoleExistsAsync("Admin"))
                {
                    IdentityRole roleAdmin = new IdentityRole("Admin");
                    await roleManager.CreateAsync(roleAdmin);
                }
                if (!await roleManager.RoleExistsAsync("User"))
                {
                    IdentityRole roleUser = new IdentityRole("User");
                    await roleManager.CreateAsync(roleUser);
                }


                User admin = await userManager.FindByNameAsync("admin@admin.com");
                User user = await userManager.FindByNameAsync("user@user.com");
                if (admin == null)
                {
                    var usr = new User
                    {
                        UserName = "admin@admin.com",
                        Email = "admin@admin.com",
                        PhoneNumber = "1313",
                        PhoneNumberConfirmed = true,
                        EmailConfirmed = true
                    };

                    var result = await userManager.CreateAsync(usr, "admin123");

                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(usr, "Admin");
                    }
                }

                if (user == null)
                {
                    var usr = new User
                    {
                        UserName = "user@user.com",
                        Email = "user@user.com",
                        PhoneNumber = "1313",
                        PhoneNumberConfirmed = true,
                        EmailConfirmed = true
                    };

                    var result = await userManager.CreateAsync(usr, "user123");

                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(usr, "User");
                    }
                }

            }
        }
    }
}
