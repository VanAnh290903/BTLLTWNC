using Btl_web_nc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Btl_web_nc.RepositoryInterfaces;


namespace Btl_web_nc.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostRepositories postRepositories;
        private readonly IUserRepositories userRepositories;
        private readonly ITypeRepositories typeRepositories;

        public HomeController(ILogger<HomeController> logger, IPostRepositories postRepositories, IUserRepositories userRepositories , ITypeRepositories typeRepositories)
        {
            _logger = logger;
            this.postRepositories = postRepositories;
            this.userRepositories = userRepositories;
            this.typeRepositories = typeRepositories;
        }
        [HttpGet]
        public IActionResult Index(string typeName="All", string title="")
        {
            List<Post> posts = postRepositories.GetAllPosts().Select(p => new Post
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
            if(typeName != "All")
            {
                posts = posts.Where(p => p.Type.typeName == typeName).ToList();
            }
            if(title != "")
            {
                posts = posts.Where(p => p.title.Contains(title)).ToList();
            }
            return View("index", posts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [AdminAuthorFilter]
        public IActionResult TestRole()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
