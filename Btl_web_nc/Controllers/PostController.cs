using Btl_web_nc.Models;
using Btl_web_nc.RepositoryInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Btl_web_nc.Controllers
{
    
    [Authorize]
    public class PostController : Controller
    {
        private readonly IPostRepositories postRepositories;
        private readonly ITypeRepositories typeRepositories;
        private readonly IFavouriteRepositories favouriteRepositories;
        private readonly IUserRepositories userRepositories;

        public PostController(IPostRepositories postRepositories, ITypeRepositories typeRepositories, IFavouriteRepositories favouriteRepositories, IUserRepositories userRepositories)
        {
            this.postRepositories = postRepositories;
            this.typeRepositories = typeRepositories;
            this.favouriteRepositories = favouriteRepositories;
            this.userRepositories = userRepositories;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [AdminOrPropertyOwnerFilter]
        public IActionResult PostNew()
        {
            return View();
        }

        [HttpPost]
        [AdminOrPropertyOwnerFilter]
        public IActionResult PostNew(PostViewModel model) {
            if (ModelState.IsValid) {
               int userId = Int32.Parse(User.FindFirst("UserId")?.Value);
                string typeName = model.Type;
                long typeId = typeRepositories.GetTypeByName(typeName);
                Post post = new Post
                {
                    userId = userId,
                    typeId = typeId,
                    title = model.Title,
                    address = model.Address,
                    price = model.Price ??0,
                    status = "Pending",
                    description = model.Description,
                    area = model.Area ??0,
                    createdDate = DateTime.Now,
                    updatedDate = DateTime.Now,
                    imageUrls = model.ImageUrls
                };
                postRepositories.AddNewPost(post);
            }
             return View(model);
        }
        
        [HttpGet]
        public IActionResult PostDetail(long postId)
        {
            Post post = postRepositories.GetPostById(postId);
            int userId = Int32.Parse(User.FindFirst("UserId")?.Value);
            Favourite favourite = favouriteRepositories.GetFavouriteId(postId, userId);
            if (favourite != null)
            {
                ViewBag.isFavourite = true;
            }
            else
            {
                ViewBag.isFavourite = false;
            }
            return View(post);
        }

        [HttpGet]
        public IActionResult ListFavourites()
        {
           int userId = Int32.Parse(User.FindFirst("UserId")?.Value);
            List<Post> favouritePosts = postRepositories.GetFavouritePostsByUserId(userId).Select(p => new Post
            {
                postId = p.postId,
                userId = p.userId,
                typeId = p.typeId,
                title = p.title,
                description = p.description,
                address = p.address,
                price = p.price,
                status = p.status,
                imageUrls = p.imageUrls,
                createdDate = p.createdDate,
                updatedDate = p.updatedDate,
                area = p.area,
                User = userRepositories.GetUserById(p.userId),
                Type = typeRepositories.GetTypeById(p.typeId)
            }).ToList().Where(p => p.status == "Approved").ToList();
            return View("favouritePosts",favouritePosts);
        }
    }
}
