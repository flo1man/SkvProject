namespace SkvProject.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SkvProject.Services.Data;
    using SkvProject.Web.Infrastructure;
    using SkvProject.Web.ViewModels.Comments;

    public class CommentsController : BaseController
    {
        private readonly ICommentsService commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            this.commentsService = commentsService;
        }

        [HttpGet]
        public IActionResult Reply()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Reply(string postId, CommentInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            var userId = this.User.GetId();
            await this.commentsService.CreateCommentAsync(inputModel, userId, postId);

            return this.RedirectToAction("ById", "Posts", new { id = postId });
        }
    }
}
