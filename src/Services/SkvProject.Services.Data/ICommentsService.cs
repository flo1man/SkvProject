namespace SkvProject.Services.Data
{
    using System.Threading.Tasks;

    using SkvProject.Web.ViewModels.Comments;

    public interface ICommentsService
    {
        Task CreateCommentAsync(CommentInputModel inputModel, string userId, string postId);

        CommentViewModel GetById(string commentId);
    }
}
