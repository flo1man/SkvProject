namespace SkvProject.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SkvProject.Common;
    using SkvProject.Services.Data.Articles;

    //[Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class SourceController : BaseController
    {
        private readonly ISourceService sourceService;

        public SourceController(ISourceService sourceService)
        {
            this.sourceService = sourceService;
        }

        public async Task<IActionResult> GatherData()
        {
            await this.sourceService.GetSources();

            return this.RedirectToAction("Index", "Forum");
        }
    }
}
