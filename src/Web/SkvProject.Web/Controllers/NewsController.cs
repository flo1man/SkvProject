namespace SkvProject.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SkvProject.Data.Common.Repositories;
    using SkvProject.Data.Models.Article;
    using SkvProject.Services.Data.Articles;
    using SkvProject.Services.Mapping;
    using SkvProject.Web.ViewModels.Articles;
    using System.Linq;

    public class NewsController : BaseController
    {
        private const int ArticlesPerPage = 10;

        private readonly INewsService newsService;
        private readonly IDeletableEntityRepository<News> newsRepository;

        public NewsController(
            INewsService newsService,
            IDeletableEntityRepository<News> newsRepository)
        {
            this.newsService = newsService;
            this.newsRepository = newsRepository;
        }

        [HttpGet]
        public IActionResult List(int page = 1)
        {
            var countOfNews = this.newsService.GetCountOfNews();
            var models = this.newsService.GetPagedNews(page);

            var viewModel = new NewsListViewModel
            {
                News = models,
                ItemsCount = countOfNews,
                PageNumber = page,
                ItemsPerPage = ArticlesPerPage,
            };

            return this.View(viewModel);
        }

        public IActionResult ById(int id, string slug)
        {
            var news = this.newsRepository.All()
                .Where(x => x.Id == id)
                .To<NewsViewModel>().FirstOrDefault();
            if (news == null)
            {
                return this.NotFound();
            }

            return this.View(news);
        }
    }
}
