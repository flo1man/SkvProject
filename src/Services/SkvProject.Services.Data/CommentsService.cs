namespace SkvProject.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using SkvProject.Data.Common.Repositories;
    using SkvProject.Data.Models.Forum;
    using SkvProject.Web.ViewModels.Comments;

    public class CommentsService : ICommentsService
    {
        private readonly IDeletableEntityRepository<Comment> commentRepository;

        public CommentsService(IDeletableEntityRepository<Comment> commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        public async Task CreateCommentAsync(CommentInputModel inputModel, string userId, string postId)
        {
            var comment = new Comment
            {
                Content = inputModel.Content,
                AuthorId = userId,
                PostId = postId,
            };

            await this.commentRepository.AddAsync(comment);
            await this.commentRepository.SaveChangesAsync();
        }
    }
}
