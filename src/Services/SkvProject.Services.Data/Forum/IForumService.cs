namespace SkvProject.Services.Data.Forum
{
    using System.Collections.Generic;

    using SkvProject.Web.ViewModels.Forum;

    public interface IForumService
    {
        IEnumerable<CategoryViewModel> GetCategories();

        CategoryViewModel GetCategoryByName(string category);

        int GetCategoriesCount();
    }
}
