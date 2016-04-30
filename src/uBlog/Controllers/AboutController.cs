using Microsoft.AspNet.Mvc;
using uBlog.Services;

namespace uBlog.Controllers
{
    public class AboutController : Controller
    {
        ISettingService settingService;

        public AboutController(ISettingService settingService)
        {
            this.settingService = settingService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}