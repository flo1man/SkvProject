namespace SkvProject.Web.ViewModels.Posts
{
    using SkvProject.Data.Models.Forum;
    using SkvProject.Services.Mapping;

    public class CategoryNameViewModel : IMapFrom<PostCategory>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
