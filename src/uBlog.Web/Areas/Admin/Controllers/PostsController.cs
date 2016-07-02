using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using uBlog.Core.Services;

namespace uBlog.Web.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        private readonly IPostService postService;

        public PostsController(IPostService postService)
        {
            this.postService = postService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var posts = postService.GetAll();
            //var p = new List<int>() { 10, 20, 30 };
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var post = postService.Get(id);
            return Ok(post);
        }
    }
}