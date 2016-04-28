using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace uBlog.Controllers
{
    public class BlogController : Controller
    {        
        public IActionResult Posts()
        {
            return View();
        }

        public IActionResult Tags()
        {
            return View();
        }
    }
}
