using Microsoft.AspNetCore.Mvc;
using uBlog.Core.Services;
using uBlog.Web.Models;

namespace uBlog.Web.Controllers
{
    public class InstallController : Controller
    {
        private readonly IInstallService installService;

        public InstallController(IInstallService installService)
        {
            this.installService = installService;
        }

        [Route("install")]
        public ActionResult Index()
        {
            if (AppSettings.DbExists())
                return Redirect("/");
            return View();
        }

        [Route("install")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(InstallModel model)
        {
            if (ModelState.IsValid)
            {
                installService.Seed(model.BlogTitle, model.Username, model.Password, model.Email);
                return Redirect("/");
            }
            return View(model);
        }
    }
}