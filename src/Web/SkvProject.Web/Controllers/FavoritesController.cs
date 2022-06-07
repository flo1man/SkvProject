namespace SkvProject.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SkvProject.Services.Data.Forum;
    using SkvProject.Web.ViewModels.FavoritePosts;

    [ApiController]
    [Route("api/[controller]")]
    public class FavoritesController : ControllerBase
    {
        private readonly IFavoriteService favoriteService;

        public FavoritesController(IFavoriteService favoriteService)
        {
            this.favoriteService = favoriteService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddToFavorite(FavoritePostsInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect($"/p/{inputModel.PostId}");
            }

            await this.favoriteService.AddToFavorite(inputModel);

            return this.Redirect($"/p/{inputModel.PostId}");
        }
    }
}
