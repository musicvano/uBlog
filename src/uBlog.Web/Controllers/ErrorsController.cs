using Microsoft.AspNetCore.Mvc;

namespace uBlog.Controllers
{
    public class ErrorsController : Controller
    {        
        public IActionResult Index(int code)
        {
            ViewBag.ErrorCode = code;
            switch (code)
            {
                case 404:
                    ViewBag.Message = "Oops! That page couldn't be found :(";
                    break;
                case 500:
                    ViewBag.Message = "Oops! Internal server error";
                    break;
                default:
                    ViewBag.Message = "Oops! Something wrong";
                    break;
            }
            return PartialView();
        }
    }
}