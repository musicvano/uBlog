using uBlog.Data.Entities;
using uBlog.Data.Repositories;

namespace uBlog.Data
{
    public class ConfigRepository : Repository<Config>, IConfigRepository
    {
        public ConfigRepository(BlogContext context) : base(context)
        {
        }
    }
}