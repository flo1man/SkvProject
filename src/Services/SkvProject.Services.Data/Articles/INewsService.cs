namespace SkvProject.Services.Data.Articles
{
    using System.Collections.Generic;

    using SkvProject.Web.ViewModels.Articles;

    public interface INewsService
    {
        IEnumerable<NewsViewModel> GetPagedNews(int page, int itemsPerPage = 10);

        int GetCountOfNews();
    }
}
