namespace SkvProject.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new PostInputModel
            {
                Categories = this.postsService.GetAllCategoriesNames(),
            };

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(PostInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                inputModel.Categories = this.postsService.GetAllCategoriesNames();
                return this.View(inputModel);
            }

            var userId = this.User.GetId();
            var postId = await this.postsService.CreatePostAsync(inputModel, userId);

            return this.Redirect($"/p/{postId}");
        }

        [HttpGet]
        public IActionResult ById(string id)
        {
            var viewModel = this.postsService.GetById(id);

            if (viewModel == null)
            {
                // TODO:
                return this.RedirectToAction("Index", "Forum");
            }

            return this.View(viewModel);
        }

        [Authorize]
        public async Task<IActionResult> Delete(string id, string categoryName)
        {
            var post = this.postsService.GetById(id);
            var sanitizeCategory = categoryName.Replace(' ', '-');
            if (post == null)
            {
                return this.Redirect($"/f/{sanitizeCategory}");
            }

            await this.postsService.DeletePostAsync(id);
            return this.Redirect($"/f/{sanitizeCategory}");
        }
    }
}
