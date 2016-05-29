using Microsoft.AspNet.Mvc;

namespace uBlog.Controllers
{
    public class HelpController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
