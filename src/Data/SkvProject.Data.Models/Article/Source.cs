namespace SkvProject.Data.Models.Article
{
    using System.Collections.Generic;

    using SkvProject.Data.Common.Models;

    public class Source : BaseDeletableModel<int>
    {
        public Source()
        {
            this.News = new HashSet<News>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public string DefaultImageUrl { get; set; }

        public virtual ICollection<News> News { get; set; }
    }
}
