namespace SkvProject.Services.Data.Articles.Sources
{
    using SkvProject.Data.Common.Repositories;
    using SkvProject.Data.Models.Article;

    public class DotNetSource : SourceService
    {
        public DotNetSource(
            IDeletableEntityRepository<News> newsRepository,
            IDeletableEntityRepository<Source> sourceRepository) 
            : base(newsRepository, sourceRepository)
        {
        }
    }
}
