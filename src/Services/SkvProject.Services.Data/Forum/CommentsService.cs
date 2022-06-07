namespace SkvProject.Services.Data.Forum
{
    using System.Linq;
    using System.Threading.Tasks;

    using SkvProject.Data.Common.Repositories;
    using SkvProject.Data.Models.Forum;
    using SkvProject.Services.Mapping;
    using SkvProject.Web.ViewModels.Comments;

    public class CommentsService : ICommentsService
    {
        private readonly IDeletableEntityRepository<Comment> commentRepository;

        public CommentsService(IDeletableEntityRepository<Comment> commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        public async Task CreateCommentAsync(CommentInputModel inputModel, string userId)
        {
            var comment = new Comment
            {
                Content = inputModel.CommentContent,
                AuthorId = userId,
                PostId = inputModel.PostId,
            };

            await this.commentRepository.AddAsync(comment);
            await this.commentRepository.SaveChangesAsync();
        }

        public async Task DeleteCommentAsync(string commentId)
        {
            var post = this.commentRepository
                .All()
                .Where(x => x.Id == commentId)
                .FirstOrDefault();

            this.commentRepository.Delete(post);
            await this.commentRepository.SaveChangesAsync();
        }

        public CommentViewModel GetById(string commentId)
        {
            return this.commentRepository
                .All()
                .Where(x => x.Id == commentId)
                .To<CommentViewModel>()
                .FirstOrDefault();
        }
    }
}
