namespace SkvProject.Web.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using SkvProject.Services.Data.Forum;
    using SkvProject.Web.ViewModels.Categories;

    public class ForumController : BaseController
    {
        private const int PostsPerPage = 7;

        private readonly IForumService forumService;
        private readonly IPostsService postsService;

        public ForumController(
            IForumService forumService,
            IPostsService postsService)
        {
            this.forumService = forumService;
            this.postsService = postsService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = this.forumService.GetCategories();

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult ByName(string category, int pageNumber = 1)
        {
            var inputModel = this.forumService.GetCategoryByName(category);
            var posts = this.postsService.GetPagedPosts(category, pageNumber);

            var viewModel = new CategoryViewModel
            {
                Description = inputModel.Description,
                Name = inputModel.Name,
                Posts = posts,
                ItemsCount = inputModel.Posts.Count(),
                PageNumber = pageNumber,
                ItemsPerPage = PostsPerPage,
            };

            return this.View(viewModel);
        }
    }
}
