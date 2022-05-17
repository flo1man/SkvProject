namespace SkvProject.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SkvProject.Services.Data;
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
                return this.View();
            }

            // TODO:
            return this.Redirect("/Forum/Index");
        }
    }
}
