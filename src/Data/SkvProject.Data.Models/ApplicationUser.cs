// ReSharper disable VirtualMemberCallInConstructor
namespace SkvProject.Data.Models
{
    using System;
    using System.Collections.Generic;

    using SkvProject.Data.Common.Models;

    using Microsoft.AspNetCore.Identity;
    using SkvProject.Data.Models.Forum;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.Posts = new HashSet<Post>();
            this.Comments = new HashSet<Comment>();
            this.FavoritePosts = new HashSet<FavoritePost>();
        }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<FavoritePost> FavoritePosts { get; set; }
    }
}
