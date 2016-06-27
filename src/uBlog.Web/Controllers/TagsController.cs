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

        public TagsController(ITagService tagService, IPostService postService)
        {
            this.tagService = tagService;
            this.postService = postService;
        }

        public IActionResult Index()
        {
            var tags = tagService.GetAll();
            var model = ModelFactory.Create(tags);
            return View(model);
        }

        public IActionResult Details(string slug, int page = 1)
        {
            var posts = postService.GetByTagSlug(slug, page);
            var model = ModelFactory.Create(posts);
            ViewBag.Title = "Posts by Tag";
            return View("../Posts/Index", model);
        }
    }
}