using Microsoft.AspNetCore.Mvc;
using System;
using uBlog.Core.Services;
using uBlog.Web.Models;

namespace uBlog.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly IPostService postService;

        public SearchController(IPostService postService)
        {
            this.postService = postService;
        }

        public IActionResult Index(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                return View(null);
            }
            var posts = postService.GetByText(text);
            var model = ModelFactory.Create(posts);
            ViewBag.Text = text;
            return View(model);
        }
    }
}