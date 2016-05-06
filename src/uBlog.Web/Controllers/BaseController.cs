using Microsoft.AspNet.Mvc;
using uBlog.Core.Services;

namespace uBlog.Controllers
{
    public class BaseController : Controller
    {
        private readonly ISettingService settingService;

        public BaseController(ISettingService settingService)
        {
            this.settingService = settingService;
            ViewBag.Author = settingService.Settings.Author;
        }
    }
}