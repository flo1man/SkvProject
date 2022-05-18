namespace SkvProject.Web.ViewModels.Posts
{
    using System.Collections.Generic;

    using SkvProject.Data.Models.Forum;
    using SkvProject.Services.Mapping;

    public class PostViewModel : IMapFrom<Post>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string AuthorId { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
