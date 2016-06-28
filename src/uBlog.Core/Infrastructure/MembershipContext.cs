using System.Security.Principal;
using uBlog.Data.Entities;

namespace uBlog.Core.Infrastructure
{
    public class MembershipContext
    {
        public IPrincipal Principal { get; set; }
        public User User { get; set; }
        public bool IsValid()
        {
            return Principal != null;
        }
    }
}