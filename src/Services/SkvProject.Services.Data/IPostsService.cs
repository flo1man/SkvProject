namespace SkvProject.Services.Data
{
    using System.Collections.Generic;

    using SkvProject.Web.ViewModels.Posts;

    public interface IPostsService
    {
        IEnumerable<CategoryViewModel> GetAllCategoriesNames();
    }
}
