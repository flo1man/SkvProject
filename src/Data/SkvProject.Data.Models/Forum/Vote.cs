namespace SkvProject.Data.Models.Forum
{
    using System.ComponentModel.DataAnnotations;

    using SkvProject.Data.Common.Models;
    using SkvProject.Data.Models.Forum.Enums;

    public class Vote : BaseModel<int>
    {
        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string PostId { get; set; }

        public virtual Post Post { get; set; }

        public VoteType Type { get; set; }
    }
}
