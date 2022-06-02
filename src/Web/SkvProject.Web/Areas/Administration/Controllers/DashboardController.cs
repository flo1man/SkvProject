namespace SkvProject.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SkvProject.Common;
    using SkvProject.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class DashboardController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
