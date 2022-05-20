namespace SkvProject.Web.Controllers
{
    using System.Threading.Tasks;

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
        public async Task<IActionResult> Create(PostInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                inputModel.Categories = this.postsService.GetAllCategoriesNames();
                return this.View(inputModel);
            }

            var userId = this.User.GetId();
            await this.postsService.CreatePostAsync(inputModel, userId);

            return this.RedirectToAction("Index", "Forum");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            await this.postsService.DeletePostAsync(id);
            return this.Redirect("/Forum/Index");
        }
    }
}
