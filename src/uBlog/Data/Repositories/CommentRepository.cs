using uBlog.Data.Entities;

namespace uBlog.Data.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(BlogContext context) : base(context)
        {
        }

        public BlogContext BlogContext
        {
            get { return Context as BlogContext; }
        }
    }
}