namespace SkvProject.Services
{
    using System;

    using SkvProject.Services.Data;
    using SkvProject.Web.ViewModels.Posts;

    public class DateService : IDateService
    {
        private const int SECOND = 1;
        private const int MINUTE = 60 * SECOND;
        private const int HOUR = 60 * MINUTE;
        private const int DAY = 24 * HOUR;
        private const int MONTH = 30 * DAY;

        private readonly IPostsService postsService;
        private readonly ICommentsService commentsService;

        public DateService(IPostsService postsService, ICommentsService commentsService)
        {
            this.postsService = postsService;
            this.commentsService = commentsService;
        }

        public string GetCreationFromNow<T>(string id, T model)
        {
            bool isModelComment = false;

            if (typeof(T).Name.Contains("Comment") || typeof(T).Name.Contains("comment"))
            {
                isModelComment = true;
            }

            var postCreated = isModelComment ?
                this.commentsService.GetById(id).CreatedOn :
                this.postsService.GetById<PostViewModel>(id).CreatedOn;

            var ts = new TimeSpan(DateTime.UtcNow.Ticks - postCreated.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 1 * MINUTE)
            {
                return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";
            }

            if (delta < 2 * MINUTE)
            {
                return "a minute ago";
            }

            if (delta < 45 * MINUTE)
            {
                return ts.Minutes + " minutes ago";
            }

            if (delta < 90 * MINUTE)
            {
                return "an hour ago";
            }

            if (delta < 24 * HOUR)
            {
                return ts.Hours + " hours ago";
            }

            if (delta < 48 * HOUR)
            {
                return "yesterday";
            }

            if (delta < 30 * DAY)
            {
                return ts.Days + " days ago";
            }

            if (delta < 12 * MONTH)
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "one month ago" : months + " months ago";
            }
            else
            {
                int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                return years <= 1 ? "one year ago" : years + " years ago";
            }
        }
    }
}
