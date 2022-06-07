namespace SkvProject.Services.Data.Forum
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
        private readonly IForumService forumService;

        public PostsService(
            IRepository<PostCategory> postCategoryRepository,
            IDeletableEntityRepository<Post> postRepository,
            IForumService forumService)
        {
            this.postCategoryRepository = postCategoryRepository;
            this.postRepository = postRepository;
            this.forumService = forumService;
        }

        public IEnumerable<CategoryNameViewModel> GetAllCategoriesNames()
        {
            var viewModel = this.postCategoryRepository
                .AllAsNoTracking()
                .To<CategoryNameViewModel>()
                .ToList();

            return viewModel;
        }

        public async Task<string> CreatePostAsync(PostInputModel inputModel, string userId)
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

            return post.Id;
        }

        public async Task<string> UpdateAsync(PostEditInputModel inputModel)
        {
            var post = this.postRepository.All().FirstOrDefault(x => x.Id == inputModel.Id);

            post.Title = inputModel.Title;
            post.Content = inputModel.Content;
            post.CategoryId = inputModel.CategoryId;

            await this.postRepository.SaveChangesAsync();

            return post.Id;
        }

        public T GetById<T>(string postId)
        {
            return this.postRepository
                .All()
                .Where(x => x.Id == postId)
                .To<T>()
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

        public IEnumerable<PostViewModel> GetPagedPosts(string category, int page, int itemsPerPage = 7)
        {
            var posts = this.forumService.GetCategoryByName(category)?.Posts;

            if (posts == null)
            {
                return null;
            }

            var pagedPosts = posts
                .OrderByDescending(x => x.CreatedOn)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToList();

            return pagedPosts;
        }
    }
}
