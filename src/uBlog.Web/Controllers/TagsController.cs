using Microsoft.AspNetCore.Mvc;
using System.Linq;
using uBlog.Core.Services;
using uBlog.Web.Models;

namespace uBlog.Controllers
{
    public class TagsController : Controller
    {
        private readonly ITagService tagService;
        private readonly IPostService postService;
        private readonly IConfigService configService;

        public TagsController(ITagService tagService, IPostService postService, IConfigService configService)
        {
            this.tagService = tagService;
            this.postService = postService;
            this.configService = configService;
        }

        public IActionResult Index()
        {
            var tags = tagService.GetAll();
            var model = ModelFactory.Create(tags);
            return View(model);
        }

        public IActionResult Details(string slug, int page = 1)
        {
            var tag = tagService.GetBySlug(slug);
            if (tag == null)
            {
                return NotFound();
            }
            var posts = postService.GetByTag(tag.Id, page, configService.PageSize);
            postService.EncodeContent(posts);
            var model = ModelFactory.Create(posts);
            ViewBag.Title = "Posts by Tag";
            return View("../Posts/Index", model);
        }
    }
}