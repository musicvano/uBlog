using Microsoft.EntityFrameworkCore;
using uBlog.Data.Entities;

namespace uBlog.Data
{
    public interface IBlogContext
    {
        DbSet<Post> Posts { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<PostTag> PostTags { get; set; }
        DbSet<User> Users { get; set; }
    }
}