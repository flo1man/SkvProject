namespace SkvProject.Services.Data
{
    using System.Threading.Tasks;

    public interface IVotesService
    {
        Task VoteAsync(string postId, string userId, bool isUpVote);

        int GetVotesCount(string postId);
    }
}
