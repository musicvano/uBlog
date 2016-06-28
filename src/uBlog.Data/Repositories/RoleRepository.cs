using uBlog.Data.Entities;

namespace uBlog.Data.Repositories
{
    public class RoleRepository : EntityBaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(BlogContext context)
            : base(context)
        { }
    }
}