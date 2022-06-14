namespace SkvProject.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SkvProject.Services.Data.Articles;
    using SkvProject.Web.ViewModels.Articles;

    public class NewsController : BaseController
    {
        private const int ArticlesPerPage = 10;

        private readonly INewsService newsService;

        public NewsController(INewsService newsService)
        {
            this.newsService = newsService;
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
    }
}
