using Microsoft.AspNet.Mvc;
using uBlog.Services;

namespace uBlog.Controllers
{
    public class PostsController : Controller
    {
        IPostService postService;
        public PostsController(IPostService postService)
        {
            this.postService = postService;
        }

        public IActionResult Index(int page = 1)
        {
            return View(postService.GetByPage(page));
        }

        public IActionResult Details(string slug)
        {
            var post = postService.GetBySlug(slug);
            if (post == null)
            {                                
                return HttpNotFound();
            }            
            return View(post);
        }
    }
}