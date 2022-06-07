namespace SkvProject.Services.Data.Forum
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SkvProject.Web.ViewModels.Posts;

    public interface IPostsService
    {
        IEnumerable<CategoryNameViewModel> GetAllCategoriesNames();

        Task<string> CreatePostAsync(PostInputModel inputModel, string userId);

        Task<string> UpdateAsync(PostEditInputModel inputModel);

        T GetById<T>(string postId);

        IEnumerable<PostViewModel> GetLatestPost();

        int GetAllPostsCount();

        Task DeletePostAsync(string postId);

        IEnumerable<PostViewModel> GetPagedPosts(string category, int page, int itemsPerPage = 7);
    }
}
