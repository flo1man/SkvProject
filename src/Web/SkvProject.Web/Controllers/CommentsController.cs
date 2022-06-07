namespace SkvProject.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SkvProject.Services.Data.Forum;
    using SkvProject.Web.Infrastructure;
    using SkvProject.Web.ViewModels.Comments;

    [Authorize]
    public class CommentsController : Controller
    {
        private readonly ICommentsService commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            this.commentsService = commentsService;
        }

        [HttpPost]
        public async Task<IActionResult> Reply(CommentInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("ById", "Posts", new { id = inputModel.PostId });
            }

            var userId = this.User.GetId();
            await this.commentsService.CreateCommentAsync(inputModel, userId);

            return this.RedirectToAction("ById", "Posts", new { id = inputModel.PostId });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Delete(string id, string postId)
        {
            var comment = this.commentsService.GetById(id);

            if (comment == null)
            {
                return this.Redirect($"/p/{postId}");
            }

            await this.commentsService.DeleteCommentAsync(id);
            return this.Redirect($"/p/{postId}");
        }
    }
}
