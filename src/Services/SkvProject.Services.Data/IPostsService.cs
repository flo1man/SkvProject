namespace SkvProject.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SkvProject.Web.ViewModels.Posts;

    public interface IPostsService
    {
        IEnumerable<CategoryNameViewModel> GetAllCategoriesNames();

        Task<string> CreatePostAsync(PostInputModel inputModel, string userId);

        PostDetailsViewModel GetById(string postId);

        IEnumerable<PostViewModel> GetLatestPost();

        int GetAllPostsCount();

        Task DeletePostAsync(string postId);

        IEnumerable<PostViewModel> GetPagedPosts(string category, int page, int itemsPerPage = 7);
    }
}
