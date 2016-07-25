using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using uBlog.Core.Services;
using uBlog.Data.Entities;

namespace uBlog.Web.Security
{
//    public class AuthMiddleware
//    {
//        private readonly RequestDelegate next;
//        private readonly IMembershipService membershipService;

//        public AuthMiddleware(RequestDelegate next, IMembershipService membershipService)
//        {
//            this.next = next;
//            this.membershipService = membershipService;
//        }

//        public async Task Invoke(HttpContext context)
//        {
//            var request = context.Request;
//            try
//            {
//                if (!context.User.Identities.Any(identity => identity.IsAuthenticated))
//                {
//                    Claim _claim = new Claim(ClaimTypes.Role, "Admin", ClaimValueTypes.String, "ublog");
//                    await context.Authentication.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
//                        new ClaimsPrincipal(new ClaimsIdentity(new[] { _claim }, CookieAuthenticationDefaults.AuthenticationScheme)));
//                }
//            }
//            catch (Exception)
//            {
///*                errorService.Add(new Error() { Message = ex.Message, StackTrace = ex.StackTrace, DateCreated = DateTime.Now });
//                errorService.Save();*/
//            }
//            await next.Invoke(context);
//        }
//    }
}