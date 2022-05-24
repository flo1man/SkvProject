namespace SkvProject.Web.ViewModels.Comments
{
    using System;

    using AutoMapper;
    using SkvProject.Data.Models.Forum;
    using SkvProject.Services.Mapping;

    public class CommentViewModel : IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                .ForMember(x => x.Author, y => y.MapFrom(s => s.Author.UserName));
        }
    }
}
