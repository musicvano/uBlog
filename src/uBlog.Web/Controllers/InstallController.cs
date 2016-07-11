using Microsoft.AspNetCore.Mvc;
using uBlog.Core.Services;
using uBlog.Data;

namespace uBlog.Controllers
{
    public class InstallController : Controller
    {
        readonly IInstallService installService;

        public InstallController(IInstallService installService)
        {
            this.installService = installService;
        }

        public IActionResult Index()
        {
            //installService.SeedDb();
            
            return PartialView();
        }
    }
}