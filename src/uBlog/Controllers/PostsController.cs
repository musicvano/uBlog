using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace uBlog.Controllers
{
    public class PostsController : Controller
    {        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Tags()
        {
            return View();
        }
    }
}
