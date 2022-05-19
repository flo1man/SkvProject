﻿namespace SkvProject.Web.ViewModels.Posts
{
    using System;
    using System.Collections.Generic;

    using SkvProject.Data.Models.Forum;
    using SkvProject.Services.Mapping;

    public class PostViewModel : IMapFrom<Post>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string AuthorId { get; set; }

        public DateTime CreatedOn { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}