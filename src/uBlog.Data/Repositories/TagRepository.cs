using uBlog.Data.Entities;
using uBlog.Data.Repositories;

namespace uBlog.Data
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(BlogContext context) : base(context)
        {
        }
    }
}