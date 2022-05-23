namespace SkvProject.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using SkvProject.Data.Common.Repositories;
    using SkvProject.Data.Models.Forum;
    using SkvProject.Services.Mapping;
    using SkvProject.Web.ViewModels.Posts;

    public class PostsService : IPostsService
    {
        private readonly IRepository<PostCategory> postCategoryRepository;
        private readonly IDeletableEntityRepository<Post> postRepository;

        public PostsService(
            IRepository<PostCategory> postCategoryRepository,
            IDeletableEntityRepository<Post> postRepository)
        {
            this.postCategoryRepository = postCategoryRepository;
            this.postRepository = postRepository;
        }

        public IEnumerable<CategoryNameViewModel> GetAllCategoriesNames()
        {
            var viewModel = this.postCategoryRepository
                .AllAsNoTracking()
                .To<CategoryNameViewModel>()
                .ToList();

            return viewModel;
        }

        public async Task CreatePostAsync(PostInputModel inputModel, string userId)
        {
            var post = new Post
            {
                Title = inputModel.Title,
                Content = inputModel.Content,
                CategoryId = inputModel.CategoryId,
                AuthorId = userId,
            };

            await this.postRepository.AddAsync(post);
            await this.postRepository.SaveChangesAsync();
        }

        public PostDetailsViewModel GetById(string postId)
        {
            return this.postRepository
                .All()
                .Where(x => x.Id == postId)
                .To<PostDetailsViewModel>()
                .FirstOrDefault();
        }

        public IEnumerable<PostViewModel> GetLatestPost()
        {
            return this.postRepository.All().To<PostViewModel>().OrderByDescending(x => x.CreatedOn).Take(4).ToList();
        }

        public int GetAllPostsCount()
        {
            return this.postRepository.All().Count();
        }

        public async Task DeletePostAsync(string postId)
        {
            var post = this.postRepository
                .All()
                .Where(x => x.Id == postId)
                .FirstOrDefault();

            this.postRepository.Delete(post);
            await this.postRepository.SaveChangesAsync();
        }
    }
}
