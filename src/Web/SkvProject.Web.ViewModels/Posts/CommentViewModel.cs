namespace SkvProject.Web.ViewModels.Forum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using SkvProject.Data.Models.Forum;
    using SkvProject.Services.Mapping;

    public class CommentViewModel : IMapFrom<Comment>
    {
        public string Content { get; set; }

        public string AuthorId { get; set; }

    }
}
