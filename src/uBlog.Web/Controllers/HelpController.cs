using Microsoft.AspNetCore.Mvc;

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
