namespace SkvProject.Services.Data.Forum
{
    using System.Threading.Tasks;

    using SkvProject.Web.ViewModels.FavoritePosts;

    public interface IFavoriteService
    {
        Task AddToFavorite(FavoritePostsInputModel inputModel);
    }
}
