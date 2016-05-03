using Microsoft.AspNet.Mvc;

namespace uBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TagsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}