namespace SkvProject.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using SkvProject.Data.Common.Repositories;
    using SkvProject.Data.Models.Forum;
    using SkvProject.Services.Mapping;
    using SkvProject.Web.ViewModels.Posts;

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
