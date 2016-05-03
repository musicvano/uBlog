using Microsoft.AspNet.Mvc;

namespace uBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}