namespace SkvProject.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SkvProject.Data;
    using SkvProject.Data.Models.Forum;

    public class ForumController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
