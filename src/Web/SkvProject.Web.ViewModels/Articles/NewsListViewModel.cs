namespace SkvProject.Web.ViewModels.Articles
{
    using System.Collections.Generic;

    public class NewsListViewModel : PagingViewModel
    {
        public IEnumerable<NewsViewModel> News { get; set; }
    }
}
