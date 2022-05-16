namespace SkvProject.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using SkvProject.Data.Models.Forum;

    public class ForumCategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.PostCategories.Any())
            {
                return;
            }

            await dbContext.PostCategories
                .AddAsync(new PostCategory
                {
                    Name = "General",
                    Description = "This default category is for asking questions, and anything that doesn't seem to fit into the other categories.",
                });

            await dbContext.PostCategories
                .AddAsync(new PostCategory
                {
                    Name = "Backend Development",
                    Description = "Discuss Linux, SQL, .NET, Java / Django, Docker, NGINX and any sort of database.",
                });

            await dbContext.PostCategories
                .AddAsync(new PostCategory
                {
                    Name = "JavaScript",
                    Description = "Ask questions and share tips for JavaScript, jQuery, React, Node, D3.",
                });

            await dbContext.PostCategories
                .AddAsync(new PostCategory
                {
                    Name = "HTML-CSS",
                    Description = "Ask about anything related to HTML and CSS, including web design tools like Sass and Bootstrap.",
                });

            await dbContext.PostCategories
                .AddAsync(new PostCategory
                {
                    Name = "Cyber Security",
                    Description = "Programs, Network, Services, Viruses/Trojan/Spam/Antivirus",
                });

            await dbContext.PostCategories
                .AddAsync(new PostCategory
                {
                    Name = "Career Advice",
                    Description = "Discuss the process of getting a developer job, including preparing, networking, and interviewing.",
                });

            await dbContext.SaveChangesAsync();
        }
    }
}
