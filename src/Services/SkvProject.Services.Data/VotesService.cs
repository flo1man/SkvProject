namespace SkvProject.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using SkvProject.Data.Common.Repositories;
    using SkvProject.Data.Models.Forum;
    using SkvProject.Data.Models.Forum.Enums;

    public class VotesService : IVotesService
    {
        private readonly IRepository<Vote> voteRepository;

        public VotesService(IRepository<Vote> voteRepository)
        {
            this.voteRepository = voteRepository;
        }

        public int GetVotesCount(string postId)
        {
            return this.voteRepository.All()
                .Where(x => x.PostId == postId).Sum(x => (int)x.Type);
        }

        public async Task VoteAsync(string postId, string userId, bool isUpVote)
        {
            var vote = this.voteRepository.All()
                .FirstOrDefault(x => x.PostId == postId && x.UserId == userId);

            if (vote != null)
            {
                vote.Type = isUpVote ? VoteType.UpVote : VoteType.DownVote;
            }
            else
            {
                vote = new Vote
                {
                    PostId = postId,
                    UserId = userId,
                    Type = isUpVote ? VoteType.UpVote : VoteType.DownVote,
                };

                await this.voteRepository.AddAsync(vote);
            }

            await this.voteRepository.SaveChangesAsync();
        }
    }
}
