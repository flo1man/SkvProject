namespace SkvProject.Services.Data.Articles
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AngleSharp;
    using SkvProject.Data.Common.Repositories;
    using SkvProject.Data.Models.Article;
    using SkvProject.Services.Data.Articles.Models;

    public class SourceService : BaseSource, ISourceService
    {
        private const string DefaultArticlePage = "/images/sources/article-dotnet-image.png";

        private readonly IDeletableEntityRepository<News> newsRepository;
        private readonly IDeletableEntityRepository<Source> sourceRepository;

        public SourceService(
            IDeletableEntityRepository<News> newsRepository,
            IDeletableEntityRepository<Source> sourceRepository)
        {
            this.newsRepository = newsRepository;
            this.sourceRepository = sourceRepository;
            this.CurrentPageCount = this.GetCurrentPageCount(this.BaseUrl);
        }

        public override string BaseUrl => "https://devblogs.microsoft.com/dotnet/";

        public virtual async Task GetSources()
        {
            ConcurrentBag<News> listOfArticles = new ConcurrentBag<News>();

            int countOfArticles = 1;
            var sourceId = this.sourceRepository
                .All().FirstOrDefault(x => x.Url == this.BaseUrl).Id;

            Parallel.For(1, this.CurrentPageCount + 1, i =>
            {
                var tempUrl = $"{this.BaseUrl}page/{i}/";

                var document = this.BrowsingContext.OpenAsync(tempUrl).GetAwaiter().GetResult();

                var articles = document.QuerySelectorAll(".entry-title > a");

                var articlesCreation = document.QuerySelectorAll(".entry-post-date-mini");

                List<ArticleInfo> linkes = new();

                for (int j = 0; j < articles.Count(); j++)
                {
                    try
                    {
                        linkes.Add(new ArticleInfo
                        {
                            ArticleUrl = articles[j].Attributes.Where(x => x.Name == "href").FirstOrDefault().TextContent.TrimStart('/'),
                            ImageUrl = DefaultArticlePage,
                            CreatedOn = DateTime.Parse(articlesCreation[j].InnerHtml).ToString("dddd, dd MMMM yyyy"),
                        });
                    }
                    catch (Exception)
                    {
                    }
                }

                foreach (var link in linkes)
                {
                    try
                    {
                        document = this.BrowsingContext.OpenAsync(link.ArticleUrl).GetAwaiter().GetResult();

                        // Remove unnecessary parts
                        document.QuerySelector(".post-detail-avatar").Remove();
                        document.QuerySelector(".post-detail-avatar-section > p").Remove();
                        document.QuerySelector(".entry-meta").Remove();
                        document.QuerySelector(".postdetail-author-info").Remove();

                        var images = document.QuerySelectorAll("img");

                        foreach (var image in images)
                        {
                            image.ClassName = " img img-fluid";
                        }

                        var title = document.QuerySelector(".entry-title").InnerHtml;
                        var content = document.QuerySelector(".entry-content").InnerHtml
                            .Replace("data-srcset=", string.Empty)
                            .Replace("data-src", "src");

                        listOfArticles.Add(new News
                        {
                            Title = title,
                            Content = content,
                            OriginalUrl = link.ArticleUrl,
                            ImageUrl = link.ImageUrl,
                            SourceId = sourceId,
                            PostedOn = DateTime.Parse(link.CreatedOn),
                        });

                        Console.WriteLine($"Article -> {countOfArticles} - {title}");

                        countOfArticles++;
                    }
                    catch (Exception)
                    {
                    }
                }

                linkes.Clear();
            });

            foreach (var article in listOfArticles.OrderByDescending(x => x.PostedOn))
            {
                await this.newsRepository.AddAsync(article);
            }

            await this.newsRepository.SaveChangesAsync();
        }

        private int GetCurrentPageCount(string baseUrl)
        {
            var document = this.BrowsingContext.OpenAsync(baseUrl)
                .GetAwaiter().GetResult();

            var pages = document.QuerySelectorAll(".pagination > li > a");

            return int.Parse(pages[2].TextContent.Replace("Page ", string.Empty));
        }
    }
}
