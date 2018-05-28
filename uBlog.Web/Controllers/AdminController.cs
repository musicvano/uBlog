using Microsoft.AspNetCore.Mvc;

namespace uBlog.Web.Controllers
{
    public class AdminController : Controller
    {        
        public IActionResult Index()
        {
            return PartialView();
        }
    }
}