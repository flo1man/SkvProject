﻿namespace SkvProject.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SkvProject.Services.Data;
    using SkvProject.Web.Infrastructure;
    using SkvProject.Web.ViewModels.Posts;

    public class PostsController : BaseController
    {
        private readonly IPostsService postsService;

        public PostsController(IPostsService postsService)
        {
            this.postsService = postsService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new PostInputModel
            {
                Categories = this.postsService.GetAllCategoriesNames(),
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(PostInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                inputModel.Categories = this.postsService.GetAllCategoriesNames();
                return this.View(inputModel);
            }

            var userId = this.User.GetId();
            this.postsService.CreatePostAsync(inputModel, userId);

            return this.Redirect("/Forum/Index");
        }
    }
}
