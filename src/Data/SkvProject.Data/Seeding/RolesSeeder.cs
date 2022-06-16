namespace SkvProject.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using SkvProject.Data.Models;

    using static SkvProject.Common.GlobalConstants;

    internal class RolesSeeder : ISeeder
    {
        private const string AdminUsername = "admin";

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            await SeedRoleAsync(roleManager, AdministratorRoleName);

            if (!dbContext.UserRoles.Any())
            {
                var admin = dbContext.Users.FirstOrDefault(x => x.UserName == AdminUsername);

                admin.Roles.Add(new IdentityUserRole<string>()
                {
                    UserId = admin.Id,
                    RoleId = dbContext.Roles
                        .FirstOrDefault(x => x.Name == AdministratorRoleName)?.Id,
                });

                await dbContext.SaveChangesAsync();
            }
        }

        private static async Task SeedRoleAsync(RoleManager<ApplicationRole> roleManager, string roleName)
        {
            var role = await roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                var result = await roleManager.CreateAsync(new ApplicationRole(roleName));
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}
