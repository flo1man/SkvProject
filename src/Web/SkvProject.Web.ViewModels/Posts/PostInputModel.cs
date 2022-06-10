namespace SkvProject.Web.ViewModels.Posts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using SkvProject.Web.ViewModels.Categories;

    using static SkvProject.Common.DataConstants;

    public class PostInputModel
    {
        [Required]
        [MinLength(PostTitleMinLength, ErrorMessage = "The title must have at least {1} characters")]
        [MaxLength(PostTitleMaxLength, ErrorMessage = "You can't use more than {1} characters")]
        public string Title { get; set; }

        [Required]
        [MinLength(PostContentMinLength, ErrorMessage = "The content must have at least {1} characters")]
        [MaxLength(PostContentMaxLength, ErrorMessage = "You can't use more than {1} characters")]
        public string Content { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryNameViewModel> Categories { get; set; }
    }
}
