namespace SkvProject.Data.Models.Forum
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using SkvProject.Common;
    using SkvProject.Data.Common.Models;

    public class Post : BaseDeletableModel<string>
    {
        public Post()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Comments = new HashSet<Comment>();
        }

        [Required]
        [MinLength(DataConstants.PostTitleMinLength)]
        [MaxLength(DataConstants.PostTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(DataConstants.PostContentMinLength)]
        [MaxLength(DataConstants.PostContentMaxLength)]
        public string Content { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual ForumCategory Category { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
