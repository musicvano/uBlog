using Microsoft.AspNet.Mvc;
using uBlog.Core.Services;

namespace uBlog.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostService postService;

        public PostsController(IPostService postService)
        {
            this.postService = postService;
        }

        public IActionResult Index(int page = 1)
        {
            var p = ViewBag;
            var posts = postService.GetByPage(page);
            if (posts.Count == 0)
            {
                return HttpNotFound();
            }
            return View(posts);
        }

        public IActionResult Details(string slug)
        {
            var post = postService.GetBySlug(slug);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }
    }
}