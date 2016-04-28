using Microsoft.Data.Entity;

namespace uBlog.Entities
{
    public class BlogContext: DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}