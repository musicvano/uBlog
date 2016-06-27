using uBlog.Data.Entities;
using uBlog.Data.Repositories;

namespace uBlog.Data
{
    public class SettingRepository : Repository<Settings>, ISettingRepository
    {
        public SettingRepository(BlogContext context) : base(context)
        {
        }
    }
}