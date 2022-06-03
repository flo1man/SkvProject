namespace SkvProject.Services.Data
{
    using System.Threading.Tasks;

    using SkvProject.Data.Common.Repositories;
    using SkvProject.Data.Models.Forum;

    public class FavoriteService : IFavoriteService
    {
        private readonly IDeletableEntityRepository<FavoritePost> favoritePostRepository;

        public FavoriteService(IDeletableEntityRepository<FavoritePost> favoritePostRepository)
        {
            this.favoritePostRepository = favoritePostRepository;
        }

        public async Task AddToFavorite(string postId, string userId)
        {
            var favoritePost = new FavoritePost
            {
                PostId = postId,
                UserId = userId,
            };

            await this.favoritePostRepository.AddAsync(favoritePost);
            await this.favoritePostRepository.SaveChangesAsync();
        }
    }
}
