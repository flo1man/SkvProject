namespace SkvProject.Web.ViewModels.Posts
{
    using SkvProject.Data.Models.Forum;
    using SkvProject.Services.Mapping;

    public class PostEditInputModel : PostInputModel, IMapFrom<Post>
    {
        public string Id { get; set; }
    }
}
