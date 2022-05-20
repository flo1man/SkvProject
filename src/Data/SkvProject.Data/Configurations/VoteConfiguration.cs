namespace SkvProject.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SkvProject.Data.Models.Forum;

    public class VoteConfiguration : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> vote)
        {
            vote.HasOne(x => x.Post)
                .WithMany(x => x.Votes)
                .HasForeignKey(x => x.PostId);

            vote.HasOne(x => x.User)
                .WithMany(x => x.Votes)
                .HasForeignKey(x => x.UserId);
        }
    }
}
