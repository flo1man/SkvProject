namespace SkvProject.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SkvProject.Data;
    using SkvProject.Data.Models.Forum;

    public class ForumController : BaseController
    {
        private readonly ApplicationDbContext dbContext;

        public ForumController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        // only for admins
        public IActionResult CreateCategory()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult CreateCategory(string name, string description)
        {
            var category = new ForumCategory
            {
                Name = name,
                Description = description,
            };

            this.dbContext.ForumCategories.Add(category);
            this.dbContext.SaveChanges();

            return this.Redirect("/");
        }
    }
}
