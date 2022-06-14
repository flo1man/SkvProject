namespace SkvProject.Data.Models.Article
{
    using System;

    using SkvProject.Data.Common.Models;

    public class News : BaseDeletableModel<int>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public string OriginalUrl { get; set; }

        public int? SourceId { get; set; }

        public DateTime PostedOn { get; set; }

        public virtual Source Source { get; set; }
    }
}
