using Microsoft.AspNetCore.Mvc;
using uBlog.Core.Services;

namespace uBlog.Controllers
{
    public class BaseController : Controller
    {
        //private readonly IConfigService configService;

        public BaseController(IConfigService settingService)
        {
            //this.configService = configService;
            //ViewBag.Settings = configService.Configs;
        }
    }
}