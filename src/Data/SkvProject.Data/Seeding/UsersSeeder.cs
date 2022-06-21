namespace SkvProject.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using SkvProject.Data.Models;

    public class UsersSeeder : ISeeder
    {
        private const string AdminUsername = "admin";

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var admin = dbContext.Users.FirstOrDefault(x => x.UserName == AdminUsername);

            if (admin == null)
            {
                var newAdmin = new ApplicationUser
                {
                    AccessFailedCount = 0,
                    Email = "admin@admin.com",
                    NormalizedEmail = "ADMIN@ADMIN.COM",
                    TwoFactorEnabled = false,
                    EmailConfirmed = false,
                    IsDeleted = false,
                    CreatedOn = DateTime.UtcNow,
                    LockoutEnabled = false,
                    PhoneNumberConfirmed = true,
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    PasswordHash = "AQAAAAEAACcQAAAAEGQ9IfdyJPYzY9lKPmwWrdN6T3AbPWBjEYxlLW7yfiOGd/4w/wqPv2Q+5O11ncA0gQ==", // Password = 123456
                };

                await dbContext.Users.AddAsync(newAdmin);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
