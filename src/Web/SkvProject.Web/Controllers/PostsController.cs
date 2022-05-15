namespace SkvProject.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class PostsController : BaseController
    {
        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(string test)
        {
            return this.View();
        }
    }
}
