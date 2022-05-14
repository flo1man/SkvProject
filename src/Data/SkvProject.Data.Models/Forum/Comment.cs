namespace SkvProject.Data.Models.Forum
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using SkvProject.Common;
    using SkvProject.Data.Common.Models;

    public class Comment : BaseDeletableModel<string>
    {
        public Comment()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MinLength(DataConstants.CommentContentMinLength)]
        [MaxLength(DataConstants.CommentContentMaxLength)]
        public string Content { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        [Required]
        public string PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}
