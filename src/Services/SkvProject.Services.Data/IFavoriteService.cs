namespace SkvProject.Services.Data
{
    using System.Threading.Tasks;

    using SkvProject.Web.ViewModels.FavoritePosts;

    public interface IFavoriteService
    {
        Task AddToFavorite(FavoritePostsInputModel inputModel);
    }
}
