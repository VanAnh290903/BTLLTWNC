using Btl_web_nc.Models;
using Btl_web_nc.RepositoryInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Btl_web_nc.Controllers
{
    [MyAuthenFilter]
    public class FavouriteController : Controller
    {
        private readonly IFavouriteRepositories _favouriteRepository;
        public FavouriteController(IFavouriteRepositories favouriteRepository)
        {
            _favouriteRepository = favouriteRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddToFavourite(long postId)
        {
            int userId = Int32.Parse(User.FindFirst("UserId")?.Value);
            _favouriteRepository.AddToFavourite(postId, userId);
            return Json(new { success = true });
        }
        [HttpDelete]
        public IActionResult RemovePostInFavourite(long postId)
        {
            int userId = Int32.Parse(User.FindFirst("UserId")?.Value);
            Favourite favourite = _favouriteRepository.GetFavouriteId(postId, userId);
            _favouriteRepository.RemoveFromFavourite(favourite.favouriteId);
            return Json(new { success = true });
        }
    }
}
