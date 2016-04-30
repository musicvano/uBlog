using uBlog.Data.Repositories;

namespace uBlog.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogContext context;

        public UnitOfWork()
        {
            context = new BlogContext();
            Posts = new PostRepository(context);
            Tags = new TagRepository(context);
            Comments = new CommentRepository(context);
            Settings = new SettingRepository(context);
        }

        public IPostRepository Posts { get; private set; }
        public ITagRepository Tags { get; private set; }
        public ICommentRepository Comments { get; private set; }
        public ISettingRepository Settings { get; private set; }

        public int Save()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}