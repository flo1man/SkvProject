namespace SkvProject.Web.ViewModels.FavoritePosts
{
    using System.ComponentModel.DataAnnotations;

    public class FavoritePostsInputModel
    {
        [Required]
        public string PostId { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
