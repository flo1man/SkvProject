namespace SkvProject.Data.Models.Forum
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using SkvProject.Data.Common.Models;

    public class FavoritePost : BaseDeletableModel<string>
    {
        public FavoritePost()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public string PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}
