namespace SkvProject.Services.Data.Articles
{
    using System.Collections.Generic;
    using System.Linq;
    using SkvProject.Data.Common.Repositories;
    using SkvProject.Data.Models.Article;
    using SkvProject.Services.Mapping;
    using SkvProject.Web.ViewModels.Articles;

    public class NewsService : INewsService
    {
        private readonly IDeletableEntityRepository<News> newsRepository;

        public NewsService(IDeletableEntityRepository<News> newsRepository)
        {
            this.newsRepository = newsRepository;
        }

        public IEnumerable<NewsViewModel> GetPagedNews(int page, int itemsPerPage = 10)
        {
            var pagedArticles = this.newsRepository.
                All().Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<NewsViewModel>()
                .ToList();

            return pagedArticles;
        }

        public int GetCountOfNews()
        {
            return this.newsRepository.AllAsNoTracking().Count();
        }
    }
}
