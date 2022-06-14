namespace SkvProject.Services.Data.Articles
{
    using AngleSharp;

    public abstract class BaseSource
    {
        public IConfiguration Config =>
            Configuration.Default.WithDefaultLoader();

        public IBrowsingContext BrowsingContext =>
            AngleSharp.BrowsingContext.New(this.Config);

        public abstract string BaseUrl { get; }

        public int CurrentPageCount { get; set; }
    }
}
