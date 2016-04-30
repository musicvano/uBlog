using uBlog.Data.Entities;

namespace uBlog.Data.Repositories
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(BlogContext context) : base(context)
        {
        }

        public BlogContext BlogContext
        {
            get { return Context as BlogContext; }
        }
    }
}