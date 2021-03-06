namespace SkvProject.Web.ViewModels.Categories
{
    using System.Collections.Generic;

    using SkvProject.Data.Models.Forum;
    using SkvProject.Services.Mapping;
    using SkvProject.Web.ViewModels.Posts;

    public class CategoryViewModel : PagingViewModel, IMapFrom<PostCategory>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Url => $"/f/{this.Name.Replace(' ', '-')}";

        public IEnumerable<PostViewModel> Posts { get; set; }
    }
}
