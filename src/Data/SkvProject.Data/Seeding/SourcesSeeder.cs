namespace SkvProject.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using SkvProject.Data.Models.Article;

    public class SourcesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var sources =
                new
                List<(string Name, string Description, string Url, string DefaultImageUrl)>
                    {
                        (".NET Blog", "Free. Cross-platform. Open source. A developer platform for building all your apps.",
                            "https://devblogs.microsoft.com/dotnet/", "/images/sources/dotnet-blog-image.png"),
                    };

            if (dbContext.Sources.Count() < sources.Count)
            {
                foreach (var source in sources)
                {
                    var dbSource = dbContext.Sources.FirstOrDefault(x => x.Name == source.Name);
                    if (dbSource == null)
                    {
                        dbContext.Sources.Add(
                            new Source
                            {
                                Name = source.Name,
                                Description = source.Description,
                                Url = source.Url,
                                DefaultImageUrl = source.DefaultImageUrl,
                            });
                    }
                    else
                    {
                        dbSource.Name = source.Name;
                        dbSource.Description = source.Description;
                        dbSource.Url = source.Url;
                        dbSource.DefaultImageUrl = source.DefaultImageUrl;
                    }
                }

                await dbContext.SaveChangesAsync();
            }
        }
    }
}
