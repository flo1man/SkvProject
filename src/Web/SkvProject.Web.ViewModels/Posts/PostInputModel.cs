namespace SkvProject.Web.ViewModels.Posts
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using SkvProject.Data.Models.Forum;
    using SkvProject.Services.Mapping;

    using static SkvProject.Common.DataConstants;

    public class PostInputModel : IMapTo<Post>
    {
        [Required]
        [MinLength(PostTitleMinLength, ErrorMessage = "The title must have at least {1} characters")]
        [MaxLength(PostTitleMaxLength, ErrorMessage = "You can't use more than {1} characters")]
        public string Title { get; set; }

        [Required]
        [MinLength(PostContentMinLength, ErrorMessage = "The content must have at least {1} characters")]
        [MaxLength(PostContentMaxLength, ErrorMessage = "You can't use more than {1} characters")]
        public string Content { get; set; }

        [Range(1, int.MaxValue)]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
    }
}
