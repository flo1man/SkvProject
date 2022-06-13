namespace SkvProject.Web.ViewModels.Posts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using AngleSharp;
    using AngleSharp.Html.Parser;
    using AutoMapper;
    using Ganss.XSS;
    using SkvProject.Data.Models.Forum;
    using SkvProject.Services.Mapping;
    using SkvProject.Web.ViewModels.Comments;

    using static SkvProject.Common.DataConstants;

    public class PostDetailsViewModel : IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string SanitizedContent
        {
            get
            {
                var htmlSanitizer = new HtmlSanitizer();
                var html = htmlSanitizer.Sanitize(this.Content);

                var parser = new HtmlParser();
                var document = parser.ParseDocument(html);

                var images = document.QuerySelectorAll("img");

                foreach (var image in images)
                {
                    image.ClassName = " img img-fluid";
                }

                return document.ToHtml();
            }
        }

        public string CategoryName { get; set; }

        public string AuthorId { get; set; }

        public string AuthorUsername { get; set; }

        public DateTime CreatedOn { get; set; }

        public int VotesCount { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        // Comment content
        [Required(ErrorMessage = "The field is required.")]
        [MinLength(CommentContentMinLength, ErrorMessage = "The content must have at least {1} characters")]
        [MaxLength(CommentContentMaxLength, ErrorMessage = "You can't use more than {1} characters")]
        public string CommentContent { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Post, PostDetailsViewModel>()
                .ForMember(x => x.AuthorUsername, y => y.MapFrom(s => s.Author.UserName))
                .ForMember(x => x.VotesCount, y => y.MapFrom(s => s.Votes.Sum(v => (int)v.Type)));
        }
    }
}
