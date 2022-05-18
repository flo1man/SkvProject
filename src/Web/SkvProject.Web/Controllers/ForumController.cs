namespace SkvProject.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SkvProject.Services.Data;

    public class ForumController : BaseController
    {
        private readonly IForumService forumService;

        public ForumController(IForumService forumService)
        {
            this.forumService = forumService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = this.forumService.GetCategories();

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult ByName(string category)
        {
            var viewModel = this.forumService.GetCategoryByName(category);

            return this.View(viewModel);
        }
    }
}
