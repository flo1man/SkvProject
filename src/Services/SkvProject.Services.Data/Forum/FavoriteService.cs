namespace SkvProject.Services.Data.Forum
{
    using System.Linq;
    using System.Threading.Tasks;

    using SkvProject.Data.Common.Repositories;
    using SkvProject.Data.Models.Forum;
    using SkvProject.Web.ViewModels.FavoritePosts;

    public class FavoriteService : IFavoriteService
    {
        private readonly IDeletableEntityRepository<FavoritePost> favoritePostRepository;

        public FavoriteService(IDeletableEntityRepository<FavoritePost> favoritePostRepository)
        {
            this.favoritePostRepository = favoritePostRepository;
        }

        // TODO:
        public async Task AddToFavorite(FavoritePostsInputModel inputModel)
        {
            var isFavoriteExist = this.favoritePostRepository
                .AllAsNoTracking()
                .Any(x => x.UserId == inputModel.UserId && x.PostId == inputModel.PostId);

            if (isFavoriteExist == false)
            {
                var favoritePost = new FavoritePost
                {
                    PostId = inputModel.PostId,
                    UserId = inputModel.UserId,
                };

                await this.favoritePostRepository.AddAsync(favoritePost);
                await this.favoritePostRepository.SaveChangesAsync();
            }
        }
    }
}
