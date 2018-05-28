using Microsoft.AspNetCore.Mvc;
using uBlog.Core.Services;
using uBlog.Web.Models;

namespace uBlog.Web.Controllers
{
    public class PostsController : Controller
    {
        private readonly IConfigService configService;
        private readonly IPostService postService;

        public PostsController(IConfigService configService, IPostService postService)
        {
            this.configService = configService;
            this.postService = postService;
        }

        public ActionResult Index(int page = 1)
        {
            var posts = postService.GetByPage(page, configService.PageSize);
            if (posts.Count == 0)
                return NotFound();
            postService.EncodeContent(posts);
            var model = ModelFactory.Create(posts);
            return View(model);
        }

        public IActionResult Details(string slug)
        {
            var post = postService.GetBySlug(slug);
            if (post == null)
                return NotFound();
            postService.EncodeContent(post);
            var model = ModelFactory.Create(post);
            ViewBag.Title = model.Title;
            return View(model);
        }
    }
}