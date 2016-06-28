using uBlog.Data;
using uBlog.Data.Entities;
using uBlog.Data.Repositories;

namespace uBlog.Data.Repositories
{
    public class UserRoleRepository : EntityBaseRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(BlogContext context)
            : base(context)
        { }
    }
}
