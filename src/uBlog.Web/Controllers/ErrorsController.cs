using Microsoft.AspNetCore.Mvc;

namespace uBlog.Controllers
{
    public class ErrorsController : Controller
    {        
        public IActionResult Details(int code)
        {
            ViewBag.ErrorCode = code;
            string message;
            switch (code)
            {
                case 404:
                    message = "Oops! That page couldn't be found :(";
                    break;
                case 500:
                    message = "Oops! Internal server error";
                    break;
                default:
                    message = "Oops! Something wrong";
                    break;
            }
            return View(model: message);
        }
    }
}