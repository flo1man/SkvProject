namespace SkvProject.Web.ViewModels.Articles
{
    using System;

    using SkvProject.Data.Models.Article;
    using SkvProject.Services.Mapping;

    public class NewsViewModel : IMapFrom<News>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public string OriginalUrl { get; set; }

        public string SourceName { get; set; }

        public string SourceUrl { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
