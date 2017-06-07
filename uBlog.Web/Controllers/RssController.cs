using Microsoft.AspNetCore.Mvc;
using uBlog.Core.Services;
using uBlog.Web.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace uBlog.Web.Controllers
{
    public class RssController : Controller
    {
        private readonly IConfigService configService;
        private readonly IUserService userService;
        private readonly IPostService postService;

        public RssController(IConfigService configService, IUserService userService, IPostService postService)
        {
            this.configService = configService;
            this.userService = userService;
            this.postService = postService;
        }

        /// <summary>
        /// Returns RSS feed
        /// </summary>
        public IActionResult Index()
        {
            var model = new RssModel(configService, userService, postService);
            return new ContentResult
            {
                ContentType = "application/xml",
                Content = model.XmlString(),
                StatusCode = 200                
            };
        }
    }
}