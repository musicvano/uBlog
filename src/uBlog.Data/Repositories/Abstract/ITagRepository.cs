using uBlog.Data.Entities;

namespace uBlog.Data.Repositories
{
    public interface ITagRepository : IRepository<Tag>
    {
        Tag GetBySlug(string slug);
    }
}