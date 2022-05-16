namespace SkvProject.Data.Seeding
{
    using SkvProject.Data.Models.Forum;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.PostCategories.Any())
            {
                return;
            }

            //dbContext.PostCategories.AddAsync();
        }
    }
}
