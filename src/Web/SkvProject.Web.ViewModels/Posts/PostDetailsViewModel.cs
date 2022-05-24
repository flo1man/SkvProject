namespace SkvProject.Web.ViewModels.Posts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using SkvProject.Data.Models.Forum;
    using SkvProject.Services.Mapping;
    using SkvProject.Web.ViewModels.Comments;

    using static SkvProject.Common.DataConstants;

    public class PostDetailsViewModel : IMapFrom<Post>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string AuthorId { get; set; }

        public DateTime CreatedOn { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }

        // Comment content
        [Required]
        [MinLength(CommentContentMinLength, ErrorMessage = "The content must have at least {1} characters")]
        [MaxLength(CommentContentMaxLength, ErrorMessage = "You can't use more than {1} characters")]
        public string CommentContent { get; set; }
    }
}
