using System.Linq;
using uBlog.Data;
using uBlog.Data.Entities;

namespace uBlog.Core.Services
{
    public class UserService: IUserService
    {
        private readonly IBlogContext context;

        public UserService(IBlogContext context)
        {
            this.context = context;
        }

        public User GetAdmin()
        {
            return context.Users.SingleOrDefault(u => u.Id == 1);
        }
    }
}