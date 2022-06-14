namespace SkvProject.Web.ViewModels.Articles
{
    using System;
    using System.Net;
    using System.Text.RegularExpressions;

    using Ganss.XSS;
    using SkvProject.Common;
    using SkvProject.Data.Models.Article;
    using SkvProject.Services.Mapping;

    public class NewsViewModel : IMapFrom<News>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ShortContent => this.GetShortContent(235);

        public string SanitizedContent =>
            new HtmlSanitizer().Sanitize(this.Content);

        public string ImageUrl { get; set; }

        public string OriginalUrl { get; set; }

        public string SourceName { get; set; }

        public string SourceUrl { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime PostedOn { get; set; }

        public string GetShortContent(int maxLength)
        {
            // TODO: Extract as a service
            var htmlSanitizer = new HtmlSanitizer();
            var html = htmlSanitizer.Sanitize(this.Content);
            var strippedContent = WebUtility.HtmlDecode(html?.StripHtml() ?? string.Empty);
            strippedContent = strippedContent.Replace("\n", " ");
            strippedContent = strippedContent.Replace("\t", " ");
            strippedContent = Regex.Replace(strippedContent, @"\s+", " ").Trim();
            return strippedContent.Length <= maxLength ? strippedContent : strippedContent.Substring(0, maxLength) + "...";
        }
    }
}
