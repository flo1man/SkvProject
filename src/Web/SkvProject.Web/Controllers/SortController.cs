namespace SkvProject.Web.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using SkvProject.Services.Data.Forum;

    [ApiController]
    [Route("api/[controller]")]
    public class SortController : ControllerBase
    {
        private readonly IForumService forumService;

        public SortController(IForumService forumService)
        {
            this.forumService = forumService;
        }

        [HttpGet]
        public IActionResult ByVotes(string categoryName)
        {
            var inputModel = this.forumService.GetCategoryByName(categoryName);
            inputModel.Posts = inputModel.Posts.Take(2);
            return new RedirectToActionResult("ByName", "Forum", inputModel);
        }
    }
}
