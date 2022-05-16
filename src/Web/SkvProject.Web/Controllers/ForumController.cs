namespace SkvProject.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SkvProject.Data;
    using SkvProject.Data.Models.Forum;
    using SkvProject.Services.Data;
    using System.Collections.Generic;

    public class ForumController : BaseController
    {
        private readonly IPostsService postsService;

        public ForumController(IPostsService postsService)
        {
            this.postsService = postsService;
        }

        public IActionResult Index()
        {
            var viewModel = this.postsService.GetCategories();

            return this.View(viewModel);
        }
    }
}
