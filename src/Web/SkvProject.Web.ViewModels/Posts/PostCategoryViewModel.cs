namespace SkvProject.Web.ViewModels.Posts
{
    using System.Collections.Generic;

    using SkvProject.Data.Models.Forum;
    using SkvProject.Services.Mapping;

    public class PostCategoryViewModel : IMapFrom<PostCategory>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<Post> Posts { get; set; }
    }
}
