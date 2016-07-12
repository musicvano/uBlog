using Microsoft.AspNetCore.Mvc;
using System;
using uBlog.Core.Services;
using uBlog.Web;

namespace uBlog.Controllers
{
    public class InstallController : Controller
    {
        private readonly IInstallService installService;

        public InstallController(IInstallService installService)
        {
            this.installService = installService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (AppSettings.IsInstalled())
            {
                return NotFound();
            }
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(object model)
        {
            if (AppSettings.IsInstalled())
            {
                return NotFound();
            }
            try
            {
                installService.RecreateDatabase();
                installService.SeedDatabase();
                return Redirect("/");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return PartialView();
        }
    }
}