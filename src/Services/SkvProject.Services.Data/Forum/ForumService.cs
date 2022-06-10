namespace SkvProject.Services.Data.Forum
{
    using System.Collections.Generic;
    using System.Linq;

    using SkvProject.Data.Common.Repositories;
    using SkvProject.Data.Models.Forum;
    using SkvProject.Services.Mapping;
    using SkvProject.Web.ViewModels.Categories;

    public class ForumService : IForumService
    {
        private readonly IRepository<PostCategory> postCategoryRepository;

        public ForumService(IRepository<PostCategory> postCategoryRepository)
        {
            this.postCategoryRepository = postCategoryRepository;
        }

        public IEnumerable<CategoryViewModel> GetCategories()
        {
            var viewModel = this.postCategoryRepository
                .AllAsNoTracking()
                .To<CategoryViewModel>()
                .ToList();

            return viewModel;
        }

        public int GetCategoriesCount()
        {
            return this.postCategoryRepository.All().Count();
        }

        public CategoryViewModel GetCategoryByName(string category)
        {
            var viewModel = this.postCategoryRepository
                .All()
                .Where(x => x.Name.Replace(" ", "-") == category.Replace(" ", "-"))
                .To<CategoryViewModel>()
                .FirstOrDefault();

            return viewModel;
        }
    }
}
