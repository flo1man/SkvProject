namespace SkvProject.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SkvProject.Web.ViewModels.Posts;

    public interface IPostsService
    {
        IEnumerable<CategoryNameViewModel> GetAllCategoriesNames();

        Task CreatePostAsync(PostInputModel inputModel, string userId);

        PostDetailsViewModel GetById(string postId);

        int GetAllPostsCount();

        Task DeletePostAsync(string postId);
    }
}
