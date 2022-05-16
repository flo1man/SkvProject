﻿namespace SkvProject.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

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
