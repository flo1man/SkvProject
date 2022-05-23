namespace SkvProject.Web.ViewModels.Comments
{
    using System;

    using SkvProject.Data.Models.Forum;
    using SkvProject.Services.Mapping;

    public class CommentViewModel : IMapFrom<Comment>
    {
        public string Id { get; set; }

        public string Content { get; set; }

        public string AuthorId { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
