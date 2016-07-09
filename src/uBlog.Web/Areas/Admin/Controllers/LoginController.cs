using Microsoft.AspNetCore.Mvc;
using uBlog.Web.Models;

namespace uBlog.Web.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        [HttpPost]
        public IActionResult Post([FromBody]LoginModel viewModel)
        {
            if (viewModel.Username == "admin" && viewModel.Password == "admin")
            {
                return Ok(new { success = true });
            }
            return Ok(new { success = false, message = "Username or password is incorrect" });
        }
    }
}