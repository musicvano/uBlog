﻿using Microsoft.AspNet.Mvc;

namespace uBlog.Controllers
{
    public class ErrorsController : Controller
    {        
        public IActionResult Details(int code)
        {
            ViewBag.ErrorCode = code;
            return View();
        }
    }
}