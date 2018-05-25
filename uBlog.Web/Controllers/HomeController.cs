using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using uBlog.Core.Services;
using uBlog.Web.Models;

namespace uBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfigService configService;
        private readonly IPostService postService;

        public HomeController(IConfigService configService, IPostService postService)
        {
            this.configService = configService;
            this.postService = postService;
        }

        [Route("")]
        [Route("posts")]
        public ActionResult Posts(int page = 1)
        {
            var posts = postService.GetByPage(page, configService.PageSize);
            if (posts.Count == 0)
                return NotFound();
            postService.EncodeContent(posts);
            var model = ModelFactory.Create(posts);
            return View(model);
        }

        [Route("posts/{slug}")]
        public IActionResult Post(string slug)
        {
            var post = postService.GetBySlug(slug);
            if (post == null)
            {
                return NotFound();
            }
            postService.EncodeContent(post);
            var model = ModelFactory.Create(post);
            ViewBag.Title = model.Title;
            return View(model);
        }
    }
}