namespace SkvProject.Services.Data
{
    using System.Threading.Tasks;

    public interface IFavoriteService
    {
        Task AddToFavorite(string postId, string userId);
    }
}
