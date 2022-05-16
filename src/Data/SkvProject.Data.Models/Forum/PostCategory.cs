namespace SkvProject.Data.Models.Forum
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using SkvProject.Common;
    using SkvProject.Data.Common.Models;

    public class PostCategory : BaseModel<int>
    {
        public PostCategory()
        {
            this.Posts = new HashSet<Post>();
        }

        [Required]
        [MinLength(DataConstants.CategoryNameMinLength)]
        [MaxLength(DataConstants.CategoryNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(DataConstants.CategoryDescriptionMinLength)]
        [MaxLength(DataConstants.CategoryDescriptionMaxLength)]
        public string Description { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}