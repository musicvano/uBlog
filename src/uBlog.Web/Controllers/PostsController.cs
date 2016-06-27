using Microsoft.AspNetCore.Mvc;
using uBlog.Core.Services;
using uBlog.Web.Models;

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
            var posts = postService.GetByPage(page, true);
            if (posts.Count == 0)
            {
                return NotFound();
            }
            var model = ModelFactory.Create(posts);
            return View(model);
        }

        public IActionResult Details(string slug)
        {
            var post = postService.GetBySlug(slug, true);
            if (post == null)
            {
                return NotFound();
            }
            var model = ModelFactory.Create(post);
            ViewBag.Title = model.Title;
            return View(model);
        }
    }
}