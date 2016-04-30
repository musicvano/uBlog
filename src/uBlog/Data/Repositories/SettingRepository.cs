using uBlog.Data.Entities;

namespace uBlog.Data.Repositories
{
    public class SettingRepository : Repository<Settings>, ISettingRepository
    {
        public SettingRepository(BlogContext context) : base(context)
        {
        }

        public BlogContext BlogContext
        {
            get { return Context as BlogContext; }
        }
    }
}