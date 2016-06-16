using Microsoft.AspNetCore.Mvc;
using uBlog.Core.Services;
using uBlog.Web.Models;

namespace uBlog.Controllers
{
    public class TagsController : Controller
    {
        private readonly ITagService tagService;

        public TagsController(ITagService tagService)
        {
            this.tagService = tagService;
        }

        public IActionResult Index()
        {
            var tags = tagService.GetAll();
            ///var model = ModelFactory.Create(tags);
            return View(tags);
        }

        public IActionResult Details(string slug)
        {

            return View();
        }
    }
}