namespace SkvProject.Web.ViewModels.Posts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using SkvProject.Data.Models.Forum;
    using SkvProject.Services.Mapping;
    using SkvProject.Web.ViewModels.Comments;

    public class PostViewModel : IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Url => $"/p/{this.Id}";

        public int VotesCount { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Post, PostViewModel>()
                .ForMember(x => x.Author, y => y.MapFrom(s => s.Author.UserName))
                .ForMember(x => x.VotesCount, y => y.MapFrom(s => s.Votes.Sum(v => (int)v.Type)));
        }
    }
}
