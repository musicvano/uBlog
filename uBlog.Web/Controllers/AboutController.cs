using Microsoft.AspNetCore.Mvc;
using uBlog.Core.Services;
using uBlog.Web.Models;

namespace uBlog.Controllers
{
    public class AboutController : Controller
    {
        IUserService userService;

        public AboutController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Index()
        {
            var user = userService.GetAdmin();
            if (user == null)
            {
                return NotFound();
            }
            var model = ModelFactory.Create(user);
            return View(model);
        }
    }
}