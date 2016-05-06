using uBlog.Data.Entities;
using uBlog.Data.Repositories;

namespace uBlog.Data
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(BlogContext context) : base(context)
        {
        }
    }
}