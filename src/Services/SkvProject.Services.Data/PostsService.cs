namespace SkvProject.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using SkvProject.Data.Common.Repositories;
    using SkvProject.Data.Models.Forum;
    using SkvProject.Services.Mapping;
    using SkvProject.Web.ViewModels.Posts;

    public class PostsService : IPostsService
    {
        private readonly IRepository<PostCategory> postCategoryRepository;

        public PostsService(IRepository<PostCategory> postCategoryRepository)
        {
            this.postCategoryRepository = postCategoryRepository;
        }

        public IEnumerable<PostCategoryViewModel> GetCategories()
        {
            var viewModel = this.postCategoryRepository
                .AllAsNoTracking()
                .To<PostCategoryViewModel>()
                .ToList();

            return viewModel;
        }

        public IEnumerable<CategoryViewModel> GetAllCategoriesNames()
        {
            var viewModel = this.postCategoryRepository
                .AllAsNoTracking()
                .To<CategoryViewModel>()
                .ToList();

            return viewModel;
        }
    }
}
