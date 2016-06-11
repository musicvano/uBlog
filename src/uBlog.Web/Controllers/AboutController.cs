using Microsoft.AspNet.Mvc;
using uBlog.Core.Services;

namespace uBlog.Controllers
{
    public class AboutController : Controller
    {
        IConfigService configService;

        public AboutController(IConfigService configService)
        {
            this.configService = configService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}