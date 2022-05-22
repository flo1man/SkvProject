namespace SkvProject.Web.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;

    using static SkvProject.Common.DataConstants;

    public class CommentInputModel
    {
        [Required]
        [MinLength(CommentContentMinLength, ErrorMessage = "The title must have at least {1} characters")]
        [MaxLength(CommentContentMaxLength, ErrorMessage = "You can't use more than {1} characters")]
        public string Content { get; set; }

        [Required]
        public string PostId { get; set; }

        public string AuthorId { get; set; }
    }
}
