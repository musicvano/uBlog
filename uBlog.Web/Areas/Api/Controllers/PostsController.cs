using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using uBlog.Core.Services;
using uBlog.Web.Models;

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
        public IEnumerable<PostModel> Get()
        {
            var posts = postService.GetAll();
            var model = ModelFactory.Create(posts);
            return model;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var post = postService.Get(id);
            var model = ModelFactory.Create(post);
            return Ok(model);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PostModel model)
        {
            if (model.Id != id)
            {
                return BadRequest();
            }
            var post = ModelFactory.Create(model);
            postService.Update(post);
            return NoContent();
        }
    }
}