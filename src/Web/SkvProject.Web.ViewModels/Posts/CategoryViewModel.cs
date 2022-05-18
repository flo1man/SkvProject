namespace SkvProject.Web.ViewModels.Posts
{
    using System.Collections.Generic;

    using SkvProject.Data.Models.Forum;
    using SkvProject.Services.Mapping;

    public class CategoryViewModel : IMapFrom<PostCategory>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Url => $"/Forum/ByName/{this.Name.Replace(' ', '-')}";

        public IEnumerable<PostViewModel> Posts { get; set; }
    }
}
