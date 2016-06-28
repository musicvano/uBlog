using uBlog.Data.Entities;

namespace uBlog.Data.Repositories
{
    public class ErrorRepository : EntityBaseRepository<Error>, IErrorRepository
    {
        public ErrorRepository(BlogContext context)
            : base(context)
        { }

        public override void Commit()
        {
            try
            {
                base.Commit();
            }
            catch { }
        }
    }
}
