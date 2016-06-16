using Microsoft.AspNetCore.Mvc;
using uBlog.Data;

namespace uBlog.Controllers
{
    public class InstallController : Controller
    {
        public IActionResult Index()
        {
            DbSeeder.Seed();
            
            //RedirectToAction("Index", "Posts");
            return Redirect("/");
        }
    }
}