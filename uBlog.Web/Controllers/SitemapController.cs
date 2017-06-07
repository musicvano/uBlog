using Microsoft.AspNetCore.Mvc;
using uBlog.Core.Services;
using uBlog.Web.Models;

namespace uBlog.Controllers
{
    public class SitemapController : Controller
    {
        private readonly IConfigService configService;
        private readonly IPostService postService;
        private readonly ITagService tagService;

        public SitemapController(IConfigService configService, IPostService postService, ITagService tagService)
        {
            this.configService = configService;
            this.postService = postService;
            this.tagService = tagService;
        }

        /// <summary>
        /// Returns sitemap file for search engines
        /// </summary>
        public IActionResult Index()
        {
            var model = new SitemapModel(configService, postService, tagService);
            return new ContentResult
            {
                ContentType = "application/xml",
                Content = model.XmlString(),
                StatusCode = 200
            };
        }
    }
}