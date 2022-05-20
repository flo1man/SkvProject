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
            this.FavoritePosts = new HashSet<FavoritePost>();
            this.Votes = new HashSet<Vote>();
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

        public virtual PostCategory Category { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<FavoritePost> FavoritePosts { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
